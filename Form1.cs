using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace DatingApp
{
    public partial class Form1 : Form
    {
        // 1. Modeli i Përdoruesit
        public class User
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Emri { get; set; } = string.Empty;
            public string AboutMe { get; set; } = string.Empty;
            public string Kontakti { get; set; } = string.Empty;
            public string Datelindja { get; set; } = string.Empty;
            public string SeksiIm { get; set; } = string.Empty;
            public string SeksiKerkoj { get; set; } = string.Empty;
            public string QytetiIm { get; set; } = string.Empty;
            public string QytetiKerkoj { get; set; } = string.Empty;
            public string QytetiIm2 { get; set; }
            public string SeksiIm2 { get; set; }
            public string QytetiKerkoj2 { get; set; }
            public string SeksiKerkoj2 { get; set; }
            public string FotoPath { get; set; } = string.Empty; // Ruajmë emrin e skedarit, p.sh. "ervis_482.jpg"

            public override string ToString() => $"{Emri}, {SeksiIm}";
        }

        List<User> database = new List<User>();
        User? perdoruesiAktual = null;
        string path = "users_db.json";

        TabPage? faqjaExplore;
        TabPage? faqjaProfiliIm;

        public Form1()
        {
            InitializeComponent();
            LexoNgaDatabase();

            // Ruajmë referencat dhe i heqim nga ekrani në fillim
            faqjaExplore = tabExplore;
            faqjaProfiliIm = tabProfiliIm;

            tabMain.TabPages.Remove(faqjaExplore);
            tabMain.TabPages.Remove(faqjaProfiliIm);

            MbushListat();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Kontrolli nëse username ekziston
            if (database.Any(u => u.Username.ToLower() == txtRegUser.Text.ToLower()))
            {
                MessageBox.Show("Ky username është i zënë!");
                return;
            }

            // Kontrolli i fushave bosh
            if (string.IsNullOrWhiteSpace(txtRegUser.Text) || string.IsNullOrWhiteSpace(txtRegPass.Text) || string.IsNullOrWhiteSpace(cmbSeksiIm.Text) || string.IsNullOrWhiteSpace(cmbQytetiIm.Text) || string.IsNullOrWhiteSpace(cmbQytetiKerkoj.Text))
            {
                MessageBox.Show("Fushat me * jane te detyruara");
                return;
            }

            User iRi = new User
            {
                Username = txtRegUser.Text,
                Password = txtRegPass.Text,
                Emri = txtRegEmri.Text,
                AboutMe = txtRegAbout.Text,
                Kontakti = txtRegKontakt.Text,
                SeksiIm = cmbSeksiIm.Text,
                SeksiKerkoj = cmbSeksiKerkoj.Text,
                QytetiIm = cmbQytetiIm.Text,
                QytetiKerkoj = cmbQytetiKerkoj.Text,
                Datelindja = dtpBirth.Value.ToShortDateString()
            };

            database.Add(iRi);
            RuajNeDatabase();
            PastroFushat();
            MessageBox.Show("Llogaria u krijua me sukses!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLoginUser.Text) || string.IsNullOrWhiteSpace(txtLoginPass.Text))
            {
                MessageBox.Show("Ju lutem plotësoni Username dhe Password për t'u identifikuar!");
                return; // Ndalon këtu dhe nuk vazhdon me pjesën tjetër të kodit
            }

            var une = database.FirstOrDefault(u => u.Username == txtLoginUser.Text && u.Password == txtLoginPass.Text);

            if (une != null)
            {

                perdoruesiAktual = une;

                MbushListat();

                // 1. Shtojmë faqet e Dashboard-it
                tabMain.TabPages.Add(faqjaExplore!);
                tabMain.TabPages.Add(faqjaProfiliIm!);

                // 2. Heqim faqet e hyrjes
                tabMain.TabPages.Remove(tabLogin);
                tabMain.TabPages.Remove(tabRegister);

                // 3. Mbushim të dhënat te faqja "Profili Im"
                txtEditAbout.Text = une.AboutMe;
                txtEditKontakt.Text = une.Kontakti;

                cmbSeksiIm2.Text = une.SeksiIm;
                cmbQytetiIm2.Text = une.QytetiIm;
                cmbSeksiKerkoj2.Text = une.SeksiKerkoj;
                cmbQytetiKerkoj2.Text = une.QytetiKerkoj;

                // Konvertimi i string-ut në datë që ta kuptojë DateTimePicker
                if (DateTime.TryParse(une.Datelindja, out DateTime dt))
                {
                    dtpBirth2.Value = dt;
                }

                ShfaqFotonTime(); // Funksioni që shkruam më parë

                // 4. Rifreskojmë listën te "Profile të Tjera"
                RifreskoMatches();

                // Na dërgon automatikisht te faqja Explore (Profile të Tjera)
                tabMain.SelectedTab = faqjaExplore;

                MessageBox.Show($"Mirësevjen {une.Emri}!");
            }
            else
            {
                MessageBox.Show("Gabim në hyrje!");
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void RifreskoMatches()
        {
            lstMatches.Items.Clear();
            /*
            var matchet = database.Where(tjetri =>
                tjetri.Username != perdoruesiAktual.Username &&
                tjetri.QytetiIm == perdoruesiAktual.QytetiKerkoj &&
                (perdoruesiAktual.SeksiKerkoj == "Both" || tjetri.SeksiIm == perdoruesiAktual.SeksiKerkoj)
            ).ToList();
            */
            var matchet = database.Where(tjetri =>
                tjetri.Username != perdoruesiAktual.Username &&
                tjetri.QytetiIm == perdoruesiAktual.QytetiKerkoj &&
                perdoruesiAktual.QytetiIm == tjetri.QytetiKerkoj && // Match i dyanshëm qyteti
                (perdoruesiAktual.SeksiKerkoj == "Both" || tjetri.SeksiIm == perdoruesiAktual.SeksiKerkoj)
            ).ToList();

            foreach (var m in matchet)
            {
                lstMatches.Items.Add(m);
            }

            if (matchet.Count == 0) lstMatches.Items.Add("Nuk u gjet asnjë match.");
        }

        private void RuajNeDatabase()
        {
            string json = JsonSerializer.Serialize(database);
            File.WriteAllText(path, json);
        }

        private void LexoNgaDatabase()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    database = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                }
            }
        }

        private void PastroFushat()
        {
            txtRegUser.Clear(); txtRegPass.Clear(); txtRegEmri.Clear(); txtRegAbout.Clear();
            cmbSeksiIm.SelectedIndex = -1; cmbSeksiKerkoj.SelectedIndex = -1;
        }

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Kontrollojmë nëse përdoruesi ka përzgjedhur vërtet diçka
            if (lstMatches.SelectedItem != null)
            {
                // 2. Marrim objektin e përdoruesit që klikuam
                // (ListBox e mban objektin e plotë User, jo vetëm tekstin)
                if (lstMatches.SelectedItem is User personiKlikuar)
                {
                    // 3. Shfaqim të dhënat e tij te Label-et që krijuam
                    lblMatchAbout.Text = "Rreth meje: " + personiKlikuar.AboutMe;
                    lblMatchContact.Text = "Kontakti: " + personiKlikuar.Kontakti;

                    // Opsionale: I bëjmë Label-et me ngjyrë tjetër që të bien në sy
                    lblMatchContact.ForeColor = Color.Blue;

                    // Shfaq foton
                    string rrugaFoto = Path.Combine(Application.StartupPath, "uploads", personiKlikuar.FotoPath ?? "");

                    if (!string.IsNullOrEmpty(personiKlikuar.FotoPath) && File.Exists(rrugaFoto))
                    {
                        // Përdorim MemoryStream që skedari të mos mbetet i "bllokuar" nga Windows
                        using (var ms = new MemoryStream(File.ReadAllBytes(rrugaFoto)))
                        {
                            picProfiliIm.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picProfiliIm.Image = null; // Ose një foto default
                    }

                }
            }
        }

        private void btnNdryshoFoton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imazhe|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // 1. Krijo dosjen uploads nëse nuk ekziston
                string folderi = Path.Combine(Application.StartupPath, "uploads");
                if (!Directory.Exists(folderi)) Directory.CreateDirectory(folderi);

                // 2. Fshi foton e vjetër nëse ekziston
                if (!string.IsNullOrEmpty(perdoruesiAktual.FotoPath))
                {
                    string rrugaVjeter = Path.Combine(folderi, perdoruesiAktual.FotoPath);
                    if (File.Exists(rrugaVjeter))
                    {
                        // Duhet të lirojmë PictureBox-in para se ta fshijmë
                        picProfiliIm.Image?.Dispose();
                        picProfiliIm.Image = null;
                        File.Delete(rrugaVjeter);
                    }
                }

                // 3. Gjenero emër të ri: username_random.jpg
                string prapashtesa = Path.GetExtension(ofd.FileName);
                string emriRi = $"{perdoruesiAktual.Username}_{Guid.NewGuid().ToString().Substring(0, 5)}{prapashtesa}";
                string rrugaRe = Path.Combine(folderi, emriRi);

                // 4. Kopjo foton në direktori dhe përditëso User-in
                File.Copy(ofd.FileName, rrugaRe);
                perdoruesiAktual.FotoPath = emriRi;
                RuajNeDatabase();

                MessageBox.Show("Fotoja u ruajt!");
            }
        }

        private void ShfaqFotonTime()
        {
            // Kontrollojmë nëse përdoruesi aktual ka një foto të regjistruar
            if (perdoruesiAktual != null && !string.IsNullOrEmpty(perdoruesiAktual.FotoPath))
            {
                string folderi = Path.Combine(Application.StartupPath, "uploads");
                string rrugaPlote = Path.Combine(folderi, perdoruesiAktual.FotoPath);

                if (File.Exists(rrugaPlote))
                {
                    try
                    {
                        // Përdorim MemoryStream që të mos e bllokojmë skedarin në Windows
                        byte[] bytes = File.ReadAllBytes(rrugaPlote);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            // Supozojmë se PictureBox-i te faqja "Profili Im" quhet picProfiliIm
                            picProfiliIm.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gabim gjatë ngarkimit të fotos suaj: " + ex.Message);
                    }
                }
                else
                {
                    picProfiliIm.Image = null; // Ose vendos një foto default "no-image.png"
                }
            }
            else
            {
                picProfiliIm.Image = null;
            }
        }

        private void btnRuajNdryshimet_Click_1(object sender, EventArgs e)
        {

            if (perdoruesiAktual != null)
            {
                // 1. Marrim vlerat e reja nga TextBox-et e faqes "Profili Im"
                // Sigurohu që emrat txtEditAbout dhe txtEditKontakt janë saktë në Designer
                perdoruesiAktual.AboutMe = txtEditAbout.Text;
                perdoruesiAktual.Kontakti = txtEditKontakt.Text;

                perdoruesiAktual.QytetiIm = cmbQytetiIm2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.SeksiIm = cmbSeksiIm2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.QytetiKerkoj = cmbQytetiKerkoj2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.SeksiKerkoj = cmbSeksiKerkoj2.SelectedItem?.ToString() ?? "";

                perdoruesiAktual.Datelindja = dtpBirth2.Value.ToShortDateString();

                // 2. Gjejmë këtë përdorues në listën kryesore dhe e përditësojmë atë
                int index = database.FindIndex(u => u.Username == perdoruesiAktual.Username);
                if (index != -1)
                {
                    database[index] = perdoruesiAktual;
                }

                // 3. Shkruajmë gjithë listën e re në skedarin JSON
                RuajNeDatabase();

                // 4. Rifreskojmë matchet që të tjerët të shohin ndryshimet tona
                RifreskoMatches();

                MessageBox.Show("Të dhënat u ruajtën me sukses në databazë!");
            }
            else
            {
                MessageBox.Show("Gabim: Nuk u gjet asnjë sesion aktiv!");
            }

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

            perdoruesiAktual = null;

            // Kthejmë faqet fillestare
            tabMain.TabPages.Add(tabLogin);
            tabMain.TabPages.Add(tabRegister);

            // Heqim faqet e përdoruesit
            tabMain.TabPages.Remove(faqjaExplore!);
            tabMain.TabPages.Remove(faqjaProfiliIm!);

            tabMain.SelectedTab = tabLogin;

            MessageBox.Show("Dole nga Platforma");

        }

        private void MbushListat()
        {

            string[] qytetet = { "Berati", "Durresi", "Elbasani", "Fieri", "Gjirokastra", "Korca", "Kukesi", "Lezha", "Lushnja", "Saranda", "Shkoder", "Tirana", "Vlora" };

            // Vetëm nëse nuk janë mbushur më parë ( ne regjistrim )
            if (cmbSeksiIm.Items.Count == 0)
            {

                cmbQytetiIm.Items.AddRange(qytetet);
                cmbQytetiKerkoj.Items.AddRange(qytetet);

                cmbSeksiIm.Items.AddRange(new string[] { "Mashkull", "Femer" });
                cmbSeksiKerkoj.Items.AddRange(new string[] { "Mashkull", "Femer", "Te dyja" });

            }

            // Vetëm nëse nuk janë mbushur më parë ( ne profil )
            if (cmbSeksiIm2.Items.Count == 0)
            {

                cmbQytetiIm2.Items.AddRange(qytetet);
                cmbQytetiKerkoj2.Items.AddRange(qytetet);

                cmbSeksiIm2.Items.AddRange(new string[] { "Mashkull", "Femer" });
                cmbSeksiKerkoj2.Items.AddRange(new string[] { "Mashkull", "Femer", "Te dyja" });

            }

        }

        private void cmbQytetiIm2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbQytetiIm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {

        }
        private void cmbSeksiIm2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRuajNdryshimet_Click(object sender, EventArgs e)
        {

        }

    }
}