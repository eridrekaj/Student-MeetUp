using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Student_MeetUp
{
    public partial class Form : System.Windows.Forms.Form
    {
		
		// krijojme dy lista; studentet dhe fakultetet
		
        List<Student> listaStudenteve = new List<Student>();
        List<Faculty> listaFakulteteve = new List<Faculty>();

        Student? perdoruesiAktual = null;

        string pathStudents = "students_db.json";
        string pathFaculties = "faculties_db.json";

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

            // lexo fakultetet
            
			if (File.Exists(pathFaculties))
            {
                string jsonUni = File.ReadAllText(pathFaculties);
                if (!string.IsNullOrWhiteSpace(jsonUni))
                    listaFakulteteve = JsonSerializer.Deserialize<List<Faculty>>(jsonUni, options) ?? new List<Faculty>();
            }
        }
		
		// funksioni qe mbushim listat dinamike

        private void MbushListat()
        {
			
			// mbushim fakultetet - kemi nga 2 vlera, per frontend dhe per backend

            cmbFakultetiIm.DataSource = listaFakulteteve.ToList();
            cmbFakultetiIm.DisplayMember = "Emri";
            cmbFakultetiIm.ValueMember = "Id";
            cmbFakultetiIm.SelectedIndex = -1;

            cmbFakultetiKerkoj.DataSource = listaFakulteteve.ToList();
            cmbFakultetiKerkoj.DisplayMember = "Emri";
            cmbFakultetiKerkoj.ValueMember = "Id";
            cmbFakultetiKerkoj.SelectedIndex = -1;

            cmbFakultetiIm2.DataSource = listaFakulteteve.ToList();
            cmbFakultetiIm2.DisplayMember = "Emri";
            cmbFakultetiIm2.ValueMember = "Id";
            cmbFakultetiIm2.SelectedIndex = -1;

            cmbFakultetiKerkoj2.DataSource = listaFakulteteve.ToList();
            cmbFakultetiKerkoj2.DisplayMember = "Emri";
            cmbFakultetiKerkoj2.ValueMember = "Id";
            cmbFakultetiKerkoj2.SelectedIndex = -1;

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
            
			if (listaStudenteve.Any(u => u.Username.ToLower() == txtRegUser.Text.ToLower()) || txtRegUser.Text == null )
            {
                MessageBox.Show("Emri i perdoruesit bosh, ose i zene.");
                return;
            }

            // kontrollojme nese eshte selektuar gjinia dhe nje fakultet nga lista (SelectedValue nuk duhet te jete null)
            
			if (cmbFakultetiIm.SelectedValue == null || cmbSeksiIm.SelectedValue == null || cmbFakultetiKerkoj.SelectedValue == null || cmbSeksiKerkoj.SelectedValue == null)
            {
                MessageBox.Show("Fushat e Fakultetit dhe Username jane te detyruara!");
                return;
            }

            Student iRi = new Student
            {
                Username = txtRegUser.Text,
                Password = txtRegPass.Text,
                Emri = txtRegEmri.Text,
                Info = txtRegAbout.Text,
                Kontakti = txtRegKontakt.Text,
                SeksiIm = cmbSeksiIm.Text,
                SeksiKerkoj = cmbSeksiKerkoj.Text,
                FakultetiIm = (int)cmbFakultetiIm.SelectedValue,
                FakultetiKerkoj = (int)cmbFakultetiKerkoj.SelectedValue,
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
            var une = listaStudenteve.FirstOrDefault(u => u.Username == txtLoginUser.Text && u.Password == txtLoginPass.Text);

            if (une != null)
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

                // plotesojme listen e fakulteteve dhe caktojme fakultetin e selektuar me pare nga user

                cmbFakultetiIm2.BindingContext = new BindingContext();
                cmbFakultetiKerkoj2.BindingContext = new BindingContext();

                if (une.FakultetiIm > 0)
                {
                    var lista = (List<Faculty>)cmbFakultetiIm2.DataSource;
                    int index = lista.FindIndex(f => f.Id == une.FakultetiIm);

                    // kontrollojme qe index-i eshte i vlefshem dhe brenda numrit te elementeve aktuale
                    
					if (index != -1 && index < cmbFakultetiIm2.Items.Count)
                    {
                        cmbFakultetiIm2.SelectedIndex = index;
                    }
                }

                if (une.FakultetiKerkoj > 0)
                {
                    var listaMatch = (List<Faculty>)cmbFakultetiKerkoj2.DataSource;
                    int indexMatch = listaMatch.FindIndex(f => f.Id == une.FakultetiKerkoj);

                    if (indexMatch != -1 && indexMatch < cmbFakultetiKerkoj2.Items.Count)
                    {
                        cmbFakultetiKerkoj2.SelectedIndex = indexMatch;
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
                tjetri.FakultetiIm == perdoruesiAktual.FakultetiKerkoj && // fakulteti i tjetrit eshte ai qe kerkoj une
                perdoruesiAktual.FakultetiIm == tjetri.FakultetiKerkoj && // fakulteti im eshte ai qe kerkon tjetri
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

                // marrim id-te e fakulteteve nga selektimi
                if (cmbFakultetiIm2.SelectedValue != null)
                    perdoruesiAktual.FakultetiIm = (int)cmbFakultetiIm2.SelectedValue;

                if (cmbFakultetiKerkoj2.SelectedValue != null)
                    perdoruesiAktual.FakultetiKerkoj = (int)cmbFakultetiKerkoj2.SelectedValue;

                RuajNeDatabase();
                RifreskoMatches();
                MessageBox.Show("Ndryshimet ne profilin tuaj u ruajten!");
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
            cmbSeksiIm.SelectedIndex = -1; cmbFakultetiIm.SelectedIndex = -1;
        }
		
		// funksion ndihmes per te mbush me te dhena studentin qe klikon

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (lstMatches.SelectedItem is Student personi)
            {
                
				lblMatchAbout.Text = "Bio: " + personi.Info;
                lblMatchContact.Text = "Kontakt: " + personi.Kontakti;

                // per te shfaqur emrin e fakultetit ne label, gjejme objektin ne baze te ID-se
                
				var fak = listaFakulteteve.FirstOrDefault(f => f.Id == personi.FakultetiIm);
                lblMatchBirthday.Text = "Fakulteti: " + (fak != null ? fak.Emri : "I panjohur");
            
			}
		}

        // eventet boshe te ruajtura sipas kerkeses
        
		private void dtpBirth_ValueChanged(object sender, EventArgs e) { }
        private void cmbFakultetiIm_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbFakultetiIm2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label12_Click_1(object sender, EventArgs e) { }
        private void cmbSeksiIm2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void txtRegKontakt_TextChanged(object sender, EventArgs e) { }
        private void cmbFakultetiKerkoj2_SelectedIndexChanged(object sender, EventArgs e) { }

    }

}