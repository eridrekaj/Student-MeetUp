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
            public string Username { get; set; }
            public string Password { get; set; }
            public string Emri { get; set; }
            public string AboutMe { get; set; }
            public string Kontakti { get; set; }
            public string SeksiIm { get; set; }
            public string SeksiKerkoj { get; set; }
            public string QytetiIm { get; set; }
            public string QytetiKerkoj { get; set; }

            public override string ToString() => $"{Emri}, {SeksiIm}";
        }

        List<User> database = new List<User>();
        User perdoruesiAktual = null;
        string path = "users_db.json";

        TabPage faqjaDashboard;

        public Form1()
        {
            InitializeComponent();
            LexoNgaDatabase();

            // Ruajmë referencën e Dashboard dhe e fshehim në fillim
            faqjaDashboard = tabDashboard;
            tabMain.TabPages.Remove(faqjaDashboard);
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
                QytetiKerkoj = cmbQytetiKerkoj.Text
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

                // --- NDRYSHIMI I TAB-EVE ---
                tabMain.TabPages.Add(faqjaDashboard);    // Shtojmë Dashboard
                tabMain.TabPages.Remove(tabLogin);       // Heqim Login
                tabMain.TabPages.Remove(tabRegister);    // Heqim Register

                // Mbushim fushat e editimit
                txtEditAbout.Text = une.AboutMe;
                txtEditKontakt.Text = une.Kontakti;

                RifreskoMatches();

                tabMain.SelectedTab = faqjaDashboard;    // Fokusojmë Dashboard-in
                MessageBox.Show($"Mirësevjen {une.Emri}!");
            }
            else
            {
                MessageBox.Show("Username ose Password i gabuar!");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. Pastrojmë përdoruesin aktual
            perdoruesiAktual = null;

            // 2. Shtojmë faqet e login/register përsëri
            tabMain.TabPages.Add(tabLogin);
            tabMain.TabPages.Add(tabRegister);

            // 3. Heqim Dashboard-in
            tabMain.TabPages.Remove(faqjaDashboard);

            // 4. Pastrojmë kutitë e login-it që mos mbetet password-i aty
            txtLoginUser.Clear();
            txtLoginPass.Clear();

            // 5. Na dërgon te faqja e parë
            tabMain.SelectedTab = tabLogin;

            MessageBox.Show("Dole me sukses!");
        }

        private void btnRuajNdryshimet_Click(object sender, EventArgs e)
        {
            if (perdoruesiAktual != null)
            {
                perdoruesiAktual.AboutMe = txtEditAbout.Text;
                perdoruesiAktual.Kontakti = txtEditKontakt.Text;
                RuajNeDatabase();
                MessageBox.Show("Profili u përditësua!");
                RifreskoMatches();
            }
        }

        private void RifreskoMatches()
        {
            lstMatches.Items.Clear();
            var matchet = database.Where(tjetri =>
                tjetri.Username != perdoruesiAktual.Username &&
                tjetri.QytetiIm == perdoruesiAktual.QytetiKerkoj &&
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
                database = JsonSerializer.Deserialize<List<User>>(json);
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
                }
            }
        }


        // Eventet e panevojshme që mund të lihen bosh ose të fshihen nëse nuk përdoren

        /*
        private void btnRegister_Click_1(object sender, EventArgs e) => btnRegister_Click(sender, e);
        private void btnLogin_Click_1(object sender, EventArgs e) => btnLogin_Click(sender, e);
        private void txtRegKontakt_TextChanged(object sender, EventArgs e) { }
        private void dtpBirth_ValueChanged(object sender, EventArgs e) { }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }

        */

    }
}