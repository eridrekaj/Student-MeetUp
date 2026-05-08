using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using BCrypt.Net;

namespace Student_MeetUp
{
    public partial class Form : System.Windows.Forms.Form
    {

        // krijojme dy lista; studentet dhe departamentet

        List<Student> listaStudenteve = new List<Student>();
        List<Department> listaDepartamenteve = new List<Department>();

        Student? perdoruesiAktual = null;

        string pathStudents = "students_db.json";
        string pathDepartments = "departments_db.json";

        public Form()
        {

            InitializeComponent();
            LexoNgaDatabase();

            // fshehim faqet e brendshme ne fillim

            tabMain.TabPages.Remove(tabExplore);
            tabMain.TabPages.Remove(tabProfiliIm);

            // mbushim combot per fakultete, qe i kemi ne liste

            MbushListat();

        }

        // funksioni qe lexon nga skedari dhe i deserializon ne liste
        private void LexoNgaDatabase()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // lexo perdoruesit

            if (File.Exists(pathStudents))
            {
                string json = File.ReadAllText(pathStudents);
                if (!string.IsNullOrWhiteSpace(json))
                    listaStudenteve = JsonSerializer.Deserialize<List<Student>>(json, options) ?? new List<Student>();
            }

            // lexo departamentet

            if (File.Exists(pathDepartments))
            {
                string jsonUni = File.ReadAllText(pathDepartments);
                if (!string.IsNullOrWhiteSpace(jsonUni))
                    listaDepartamenteve = JsonSerializer.Deserialize<List<Department>>(jsonUni, options) ?? new List<Department>();
            }
        }

        // funksioni qe mbushim listat dinamike
        private void MbushListat()
        {

            // mbushim departamentet - kemi nga 2 vlera, per frontend dhe per backend

            cmbDepartamentiIm.DataSource = listaDepartamenteve.ToList();
            cmbDepartamentiIm.DisplayMember = "Emri";
            cmbDepartamentiIm.ValueMember = "Id";
            cmbDepartamentiIm.SelectedIndex = -1;

            cmbDepartamentiKerkoj.DataSource = listaDepartamenteve.ToList();
            cmbDepartamentiKerkoj.DisplayMember = "Emri";
            cmbDepartamentiKerkoj.ValueMember = "Id";
            cmbDepartamentiKerkoj.SelectedIndex = -1;

            cmbDepartamentiIm2.DataSource = listaDepartamenteve.ToList();
            cmbDepartamentiIm2.DisplayMember = "Emri";
            cmbDepartamentiIm2.ValueMember = "Id";
            cmbDepartamentiIm2.SelectedIndex = -1;

            cmbDepartamentiKerkoj2.DataSource = listaDepartamenteve.ToList();
            cmbDepartamentiKerkoj2.DisplayMember = "Emri";
            cmbDepartamentiKerkoj2.ValueMember = "Id";
            cmbDepartamentiKerkoj2.SelectedIndex = -1;

            // mbushim gjinite

            if (cmbSeksiIm.Items.Count == 0)
            {
                string[] sekset = { "Mashkull", "Femer" };
                cmbSeksiIm.Items.AddRange(sekset);
                cmbSeksiKerkoj.Items.AddRange(sekset);
                cmbSeksiIm2.Items.AddRange(sekset);
                cmbSeksiKerkoj2.Items.AddRange(sekset);
            }
        }

        // kur klikojme butonin register

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // username tashme ne liste

            if (listaStudenteve.Any(u => u.Username.ToLower() == txtRegUser.Text.ToLower()) || txtRegUser.Text == null)
            {
                MessageBox.Show("Emri i perdoruesit bosh, ose i zene.");
                return;
            }

            // kontrollojme nese eshte selektuar gjinia dhe nje fakultetet nga lista (SelectedValue nuk duhet te jete null)

            if (cmbDepartamentiIm.SelectedValue == null ||
                cmbDepartamentiKerkoj.SelectedValue == null ||
                string.IsNullOrEmpty(cmbSeksiIm.Text) ||
                string.IsNullOrEmpty(cmbSeksiKerkoj.Text))
            {
                MessageBox.Show("Fushat e Departmanteve dhe Seksi jane te detyruara!");
                return;
            }

            Student iRi = new Student
            {
                Username = txtRegUser.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(txtRegPass.Text),
                Emri = txtRegEmri.Text,
                Info = txtRegAbout.Text,
                Kontakti = txtRegKontakt.Text,
                SeksiIm = cmbSeksiIm.Text,
                SeksiKerkoj = cmbSeksiKerkoj.Text,
                DepartamentiIm = (int)cmbDepartamentiIm.SelectedValue,
                DepartamentiKerkoj = (int)cmbDepartamentiKerkoj.SelectedValue,
                Datelindja = dtpBirth.Value.ToShortDateString()
            };

            listaStudenteve.Add(iRi);
            RuajNeDatabase();
            PastroFushat();

            MessageBox.Show("Llogaria u krijua me sukses! Tani mund te identifikoheni.");
            tabMain.SelectedTab = tabLogin;
        
        }

        // kur klikojme login

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var une = listaStudenteve.FirstOrDefault(u => u.Username.Equals(txtLoginUser.Text, StringComparison.OrdinalIgnoreCase));

            if (une != null && BCrypt.Net.BCrypt.Verify(txtLoginPass.Text, une.Password))
            {

                perdoruesiAktual = une;

                // shfaqim tabelat e dashboardit

                if (!tabMain.TabPages.Contains(tabExplore)) tabMain.TabPages.Add(tabExplore);
                if (!tabMain.TabPages.Contains(tabProfiliIm)) tabMain.TabPages.Add(tabProfiliIm);

                // heqim tabelat e frontendit

                tabMain.TabPages.Remove(tabLogin);
                tabMain.TabPages.Remove(tabRegister);
                tabMain.TabPages.Remove(tabInfo);

                // plotesojme fushat e tekstit

                txtEditAbout.Text = une.Info;
                txtEditKontakt.Text = une.Kontakti;
                cmbSeksiIm2.Text = une.SeksiIm;
                cmbSeksiKerkoj2.Text = une.SeksiKerkoj;

                // plotesojme listen e departamenteve dhe caktojme departamentin e selektuar me pare nga user

                cmbDepartamentiIm2.BindingContext = new BindingContext();
                cmbDepartamentiKerkoj2.BindingContext = new BindingContext();

                if (une.DepartamentiIm > 0)
                {
                    var lista = (List<Department>)cmbDepartamentiIm2.DataSource;
                    int index = lista.FindIndex(f => f.Id == une.DepartamentiIm);

                    // kontrollojme qe index-i eshte i vlefshem dhe brenda numrit te elementeve aktuale

                    if (index != -1 && index < cmbDepartamentiIm2.Items.Count)
                    {
                        cmbDepartamentiIm2.SelectedIndex = index;
                    }
                }

                if (une.DepartamentiKerkoj > 0)
                {
                    var listaMatch = (List<Department>)cmbDepartamentiKerkoj2.DataSource;
                    int indexMatch = listaMatch.FindIndex(f => f.Id == une.DepartamentiKerkoj);

                    if (indexMatch != -1 && indexMatch < cmbDepartamentiKerkoj2.Items.Count)
                    {
                        cmbDepartamentiKerkoj2.SelectedIndex = indexMatch;
                    }
                }

                // vendosim datelindjen

                if (DateTime.TryParse(une.Datelindja, out DateTime dt)) dtpBirth2.Value = dt;

                // rifreskojme matches per te dhenat e reja

                RifreskoMatches();
                tabMain.SelectedTab = tabExplore;
                MessageBox.Show($"Miresevjen, {une.Emri}!");
            }
            else
            {
                MessageBox.Show("Username ose Password i gabuar!");
            }
        }

        // funksion qe rifreskon matches
        private void RifreskoMatches()
        {
            lstMatches.Items.Clear();

            // krahasimi behet me ID (int) qe eshte me e shpejte dhe me e sigurte

            var matchet = listaStudenteve.Where(tjetri =>
                tjetri.Username != perdoruesiAktual.Username && // perjashto mua
                tjetri.DepartamentiIm == perdoruesiAktual.DepartamentiKerkoj && // departamenti i tjetrit eshte ai qe kerkoj une
                perdoruesiAktual.DepartamentiIm == tjetri.DepartamentiKerkoj && // departamenti im eshte ai qe kerkon tjetri
                perdoruesiAktual.SeksiIm == tjetri.SeksiKerkoj && // seksi im eshte seksi qe tjetri kerkon
                tjetri.SeksiIm == perdoruesiAktual.SeksiKerkoj // seksi qe une kerkoj eshte seksi i tjetrit
            ).ToList();

            foreach (var m in matchet)
            {
                lstMatches.Items.Add(m);
            }

            if (matchet.Count == 0) lstMatches.Items.Add("Nuk u gjet asnje student match nga ky fakultet.");
        }

        // kur klikon per te ruajte ndryshimet

        private void btnRuajNdryshimet_Click_1(object sender, EventArgs e)
        {
            if (perdoruesiAktual != null)
            {
                perdoruesiAktual.Info = txtEditAbout.Text;
                perdoruesiAktual.Kontakti = txtEditKontakt.Text;
                perdoruesiAktual.SeksiIm = cmbSeksiIm2.Text;
                perdoruesiAktual.SeksiKerkoj = cmbSeksiKerkoj2.Text;
                perdoruesiAktual.Datelindja = dtpBirth2.Value.ToShortDateString();

                // marrim id-te e departamenteve nga selektimi
                if (cmbDepartamentiIm2.SelectedValue != null)
                    perdoruesiAktual.DepartamentiIm = (int)cmbDepartamentiIm2.SelectedValue;

                if (cmbDepartamentiKerkoj2.SelectedValue != null)
                    perdoruesiAktual.DepartamentiKerkoj = (int)cmbDepartamentiKerkoj2.SelectedValue;

                RuajNeDatabase();
                RifreskoMatches();
                PastroProfilinMatch();

                MessageBox.Show("Ndryshimet ne profilin tend u ruajten!");
            }
        }

        // kur klikon Logout

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            perdoruesiAktual = null; // zeron perdoruesin aktual

            // shfaq tab te frontendit

            tabMain.TabPages.Add(tabLogin);
            tabMain.TabPages.Add(tabRegister);
            tabMain.TabPages.Add(tabInfo);

            // fsheh tab te backendit

            tabMain.TabPages.Remove(tabExplore);
            tabMain.TabPages.Remove(tabProfiliIm);

            // pastrojme fushat e Login dhe shfaqim login serish

            txtLoginUser.Clear();
            txtLoginPass.Clear();
            tabMain.SelectedTab = tabLogin;

        }

        // funksion ndihmes per te ruajte ne skedar

        private void RuajNeDatabase()
        {
            string json = JsonSerializer.Serialize(listaStudenteve, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(pathStudents, json);
        }

        // funksion ndihmes per te pastruar fushat

        private void PastroFushat()
        {
            txtRegUser.Clear(); txtRegPass.Clear(); txtRegEmri.Clear(); txtRegAbout.Clear();
            cmbSeksiIm.SelectedIndex = -1; cmbDepartamentiIm.SelectedIndex = -1;
        }

        // funksion ndihmes per te mbush me te dhena studentin qe klikon

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMatches.SelectedItem is Student personi)
            {

                lblMatchAbout.Text = "Bio: " + personi.Info;
                lblMatchContact.Text = "Kontakt: " + personi.Kontakti;

                // per te shfaqur emrin e departmanteve ne label, gjejme objektin ne baze te ID-se

                var fak = listaDepartamenteve.FirstOrDefault(f => f.Id == personi.DepartamentiIm);
                lblMatchBirthday.Text = "Departamenti: " + (fak != null ? fak.Emri : "I panjohur");

            }
        }

        // funksion ndihmes per te pastruar detajet e matches kur ndryshojme selektimin
        private void PastroProfilinMatch()
        {
            
            lblMatchAbout.Text = "Bio: ";
            lblMatchContact.Text = "Kontakt: ";
            lblMatchBirthday.Text = "Departamenti: ";
            lstMatches.SelectedIndex = -1; // hiq selektimin nga lista
        
        }

        // eventet boshe te ruajtura sipas kerkeses

        private void dtpBirth_ValueChanged(object sender, EventArgs e) { }
        private void cmbDepartamentiIm_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbDepartamentiIm2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label12_Click_1(object sender, EventArgs e) { }
        private void cmbSeksiIm2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void txtRegKontakt_TextChanged(object sender, EventArgs e) { }
        private void cmbDepartamentiKerkoj2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cmbSeksiIm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}