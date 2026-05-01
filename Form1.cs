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

        List<User> database = new List<User>();
        User? perdoruesiAktual = null;
        string path = "users_db.json"; // path i plote ne "bin/Debug/net10.0" ku do krijohet skedari JSON

        public Form1()
        {
            InitializeComponent();
            LexoNgaDatabase();

            tabMain.TabPages.Remove(tabExplore);
            tabMain.TabPages.Remove(tabProfiliIm);

            MbushListat(); // funksion ndihmes per te populuar listat e qyteteve dhe gjinive

        }

        // eventi i klikimit te butonit "Regjistrohu"

        private void btnRegister_Click(object sender, EventArgs e)
        {

            // kontrolli nese username egziston

            if (database.Any(u => u.Username.ToLower() == txtRegUser.Text.ToLower()))
            {
                MessageBox.Show("Ky username eshte i zene!");
                return;
            }

            // kontrolli per disa fusha bosh

            if (string.IsNullOrWhiteSpace(txtRegUser.Text) || string.IsNullOrWhiteSpace(txtRegPass.Text) || string.IsNullOrWhiteSpace(cmbSeksiIm.Text) || string.IsNullOrWhiteSpace(cmbQytetiIm.Text) || string.IsNullOrWhiteSpace(cmbQytetiKerkoj.Text))
            {
                MessageBox.Show("Fushat me * jane te detyruara");
                return;
            }

            // objekti i ri per perdoruesin qe do regjistrohet

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

        // eventi i klikimit te butonit "Login"
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLoginUser.Text) || string.IsNullOrWhiteSpace(txtLoginPass.Text))
            {
                MessageBox.Show("Ju lutem plotesoni Username dhe Password per tu identifikuar!");
                return; // ndalon ketu dhe nuk vazhdon me pjesen tjeter te kodit
            }

            var une = database.FirstOrDefault(u => u.Username == txtLoginUser.Text && u.Password == txtLoginPass.Text);

            if (une != null)
            {

                perdoruesiAktual = une;

                MbushListat();

                // vendosim faqet e dashboard-it te perdoruesit

                tabMain.TabPages.Add(tabExplore!);
                tabMain.TabPages.Add(tabProfiliIm!);

                // heqim faqet e regjistrimit dhe login nga tabControl-i kryesor

                tabMain.TabPages.Remove(tabLogin);
                tabMain.TabPages.Remove(tabRegister);
                tabMain.TabPages.Remove(tabInfo);

                // mbushim te dhenat e perdoruesit te faqja "Profili Im"

                txtEditAbout.Text = une.AboutMe;
                txtEditKontakt.Text = une.Kontakti;

                cmbSeksiIm2.Text = une.SeksiIm;
                cmbQytetiIm2.Text = une.QytetiIm;
                cmbSeksiKerkoj2.Text = une.SeksiKerkoj;
                cmbQytetiKerkoj2.Text = une.QytetiKerkoj;

                // pergatisim datelindjen ne DateTimePicker - pasi ne User e kemi ruajtur si string
                if (DateTime.TryParse(une.Datelindja, out DateTime dt))
                {
                    dtpBirth2.Value = dt;
                }

                // ShfaqFotonTime(); // funksioni per foto, per tu punuar

                // rifreskojme listen e matches ne faqen Explore, qe te shfaqen vetem personat qe i perputhen kerkesave te perdoruesit
                RifreskoMatches();

                // shkojme direkt ne faqen Explore pasi te lidhemi
                tabMain.SelectedTab = tabExplore;

                MessageBox.Show($"Miresevjen {une.Emri}!");
            }
            else
            {
                MessageBox.Show("Gabim ne hyrje!");
            }

        }

        // funksion ndihmes per te rifreskuar listen e matches ne faqen kryesore, bazuar ne kerkesat e perdoruesit aktual
        private void RifreskoMatches()
        {

            lstMatches.Items.Clear();

            var matchet = database.Where(tjetri =>
                tjetri.Username != perdoruesiAktual.Username && // perjashto veten
                tjetri.QytetiIm == perdoruesiAktual.QytetiKerkoj && // tjetri kerkon qytetin ku jetoj une
                perdoruesiAktual.QytetiIm == tjetri.QytetiKerkoj && // match i dyanshem qyteti
                (perdoruesiAktual.SeksiKerkoj == "Both" || tjetri.SeksiIm == perdoruesiAktual.SeksiKerkoj)
            ).ToList();

            foreach (var m in matchet)
            {
                lstMatches.Items.Add(m);
            }

            if (matchet.Count == 0) lstMatches.Items.Add("Nuk u gjet asnje match.");

        }

        // funksion ndihmes per te ruajtur listen e perdoruesve ne skedarin JSON

        private void RuajNeDatabase()
        {
            string json = JsonSerializer.Serialize(database);
            File.WriteAllText(path, json);
        }

        // funksion ndihmes per te lexuar listen e perdoruesve nga skedari JSON, ne fillim te programit
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

        // funksion ndihmes per te pastruar fushat e regjistrimit pasi krijohet nje llogari e re
        private void PastroFushat()
        {

            txtRegUser.Clear();
            txtRegPass.Clear();
            txtRegEmri.Clear();
            txtRegAbout.Clear();

            cmbSeksiIm.SelectedIndex = -1; cmbSeksiKerkoj.SelectedIndex = -1;

        }

        // funksion i cili ekzekutohet kur perdoruesi klikon nje nga matches ne listen e matches, per te shfaqur me shume detaje rreth tij

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {

            // kontrollojme nese perdoruesi ka perzgjedhur vertet diçka

            if (lstMatches.SelectedItem != null)
            {

                // marrim objektin e perdoruesit qe klikuam (ListBox e mban objektin e plote User, jo vetem tekstin)

                if (lstMatches.SelectedItem is User personiKlikuar)
                {

                    // shfaqim te dhenat e tij te label perkates

                    lblMatchAbout.Text = "Rreth meje: " + personiKlikuar.AboutMe;
                    lblMatchContact.Text = "Kontakti: " + personiKlikuar.Kontakti;

                    lblMatchBirthday.Text = "Datelindja: " + personiKlikuar.Datelindja;

                    // i bejme label-et me ngjyre tjeter qe te bien ne sy

                    lblMatchAbout.ForeColor = Color.Blue;
                    lblMatchContact.ForeColor = Color.Green;
                    lblMatchBirthday.ForeColor = Color.Red;

                    // shfaq foton ( per tu punuar )

                    /*
                    
					string rrugaFoto = Path.Combine(Application.StartupPath, "uploads", personiKlikuar.FotoPath ?? "");

                    if (!string.IsNullOrEmpty(personiKlikuar.FotoPath) && File.Exists(rrugaFoto))
                    {
                        // perdorim MemoryStream qe skedari te mos mbetet i bllokuar nga Windows
                        using (var ms = new MemoryStream(File.ReadAllBytes(rrugaFoto)))
                        {
                            picProfiliIm.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picProfiliIm.Image = null; // Ose nje foto default
                    }
					
					*/

                }

            }

        }

        /*

        private void btnNdryshoFoton_Click(object sender, EventArgs e)
        {
            
			OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imazhe|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
				// krijo folder uploads nese nuk ekziston
                
				string folderi = Path.Combine(Application.StartupPath, "uploads");
                if (!Directory.Exists(folderi)) Directory.CreateDirectory(folderi);

                // fshi foton e vjeter nese ekziston
                
				if (!string.IsNullOrEmpty(perdoruesiAktual.FotoPath))
                {
                    
					string rrugaVjeter = Path.Combine(folderi, perdoruesiAktual.FotoPath);
                    if (File.Exists(rrugaVjeter))
                    {
                        // duhet te lirojme PictureBox para se ta fshijme
                        
						picProfiliIm.Image?.Dispose();
                        picProfiliIm.Image = null;
                        File.Delete(rrugaVjeter);
                    
					}
                
				}

                // gjenero emer te ri: username_random.jpg
                
				string prapashtesa = Path.GetExtension(ofd.FileName);
                string emriRi = $"{perdoruesiAktual.Username}_{Guid.NewGuid().ToString().Substring(0, 5)}{prapashtesa}";
                string folderIRi = Path.Combine(folderi, emriRi);

                // kopjo foton ne direktori dhe perditeso User-in
				
                File.Copy(ofd.FileName, folderIRi);
                perdoruesiAktual.FotoPath = emriRi;
                RuajNeDatabase();

                MessageBox.Show("Fotoja u ruajt!");
            
			}
        
		}

        private void ShfaqFotonTime()
        {
            
			// kontrollojme nese perdoruesi aktual ka nje foto te regjistruar
            
			if (perdoruesiAktual != null && !string.IsNullOrEmpty(perdoruesiAktual.FotoPath))
            {
                
				string folderi = Path.Combine(Application.StartupPath, "uploads");
                string pathPlote = Path.Combine(folderi, perdoruesiAktual.FotoPath);

                if (File.Exists(pathPlote))
                {
                    try
                    {
                        
						// perdorim MemoryStream qe te mos e bllokojme skedarin ne Windows
                        byte[] bytes = File.ReadAllBytes(pathPlote);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            // supozojme se PictureBox-i te faqja "Profili Im" quhet picProfiliIm
                            picProfiliIm.Image = Image.FromStream(ms);
                        }
                    
					}
                    
					catch (Exception ex)
                    {
                        MessageBox.Show("Gabim gjate ngarkimit te fotos: " + ex.Message);
                    }
                
				}
                else
                {
                    picProfiliIm.Image = null; // ose vendos nje foto default "no-image.png"
                }
            }
            else
            {
                picProfiliIm.Image = null;
            }
        }
		
		*/

        // funksion qe egzekutohet kur ruan ndryshimet
        private void btnRuajNdryshimet_Click_1(object sender, EventArgs e)
        {

            if (perdoruesiAktual != null)
            {

                // marrim vlerat e reja nga TextBox-et e faqes "Profili Im"

                perdoruesiAktual.AboutMe = txtEditAbout.Text;
                perdoruesiAktual.Kontakti = txtEditKontakt.Text;

                perdoruesiAktual.QytetiIm = cmbQytetiIm2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.SeksiIm = cmbSeksiIm2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.QytetiKerkoj = cmbQytetiKerkoj2.SelectedItem?.ToString() ?? "";
                perdoruesiAktual.SeksiKerkoj = cmbSeksiKerkoj2.SelectedItem?.ToString() ?? "";

                perdoruesiAktual.Datelindja = dtpBirth2.Value.ToShortDateString();

                // gejme kete perdorues ne listen kryesore dhe e perditesojme ate

                int index = database.FindIndex(u => u.Username == perdoruesiAktual.Username);
                if (index != -1)
                {
                    database[index] = perdoruesiAktual;
                }

                // shkruajme gjithe listen e re ne skedarin JSON

                RuajNeDatabase();

                // rifreskojme matchet qe te tjeret te shohin ndryshimet tona

                RifreskoMatches();

                MessageBox.Show("Te dhenat u ruajten me sukses!");

            }

            else
            {
                MessageBox.Show("Gabim: Nuk u gjet asnje sesion aktiv!");
            }

        }

        // funksion logout

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

            perdoruesiAktual = null;

            // pastrojme fushat per identifikim

            txtLoginUser.Clear();
            txtLoginPass.Clear();

            // kthejme faqet fillestare

            tabMain.TabPages.Add(tabLogin);
            tabMain.TabPages.Add(tabRegister);
            tabMain.TabPages.Add(tabInfo);

            // heqim faqet e perdoruesit

            tabMain.TabPages.Remove(tabExplore!);
            tabMain.TabPages.Remove(tabProfiliIm!);

            tabMain.SelectedTab = tabLogin;

            MessageBox.Show("Dole nga Platforma");

        }

        // funksion ndihmes qe populon listat

        private void MbushListat()
        {

            string[] qytetet = { "Berati", "Durresi", "Elbasani", "Fieri", "Gjirokastra", "Korca", "Kukesi", "Lezha", "Lushnja", "Saranda", "Shkoder", "Tirana", "Vlora" };

            // vetem nese nuk jane mbushur me pare ( ne regjistrim )

            if (cmbSeksiIm.Items.Count == 0)
            {

                cmbQytetiIm.Items.AddRange(qytetet);
                cmbQytetiKerkoj.Items.AddRange(qytetet);

                cmbSeksiIm.Items.AddRange(new string[] { "Mashkull", "Femer" });
                cmbSeksiKerkoj.Items.AddRange(new string[] { "Mashkull", "Femer", "Te dyja" });

            }

            // vetem nese nuk jane mbushur me pare ( ne profil )

            if (cmbSeksiIm2.Items.Count == 0)
            {

                cmbQytetiIm2.Items.AddRange(qytetet);
                cmbQytetiKerkoj2.Items.AddRange(qytetet);

                cmbSeksiIm2.Items.AddRange(new string[] { "Mashkull", "Femer" });
                cmbSeksiKerkoj2.Items.AddRange(new string[] { "Mashkull", "Femer", "Te dyja" });

            }

        }

        // funksione ndihmes qe mund te fshihen

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }

}