namespace DatingApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabLogin = new TabPage();
            lgnForm = new GroupBox();
            txtLoginUser = new TextBox();
            txtLoginPass = new TextBox();
            btnLogin = new Button();
            tabRegister = new TabPage();
            label10 = new Label();
            label9 = new Label();
            label6 = new Label();
            txtRegKontakt = new TextBox();
            label3 = new Label();
            btnRegister = new Button();
            dtpBirth = new DateTimePicker();
            cmbQytetiKerkoj = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            cmbQytetiIm = new ComboBox();
            cmbSeksiKerkoj = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cmbSeksiIm = new ComboBox();
            txtRegAbout = new TextBox();
            txtRegEmri = new TextBox();
            txtRegPass = new TextBox();
            txtRegUser = new TextBox();
            tabDashboard = new TabPage();
            btnLogout = new Button();
            lstMatches = new ListBox();
            grpProfili = new GroupBox();
            btnRuajNdryshimet = new Button();
            label8 = new Label();
            label7 = new Label();
            txtEditKontakt = new TextBox();
            txtEditAbout = new TextBox();
            tabMain.SuspendLayout();
            tabLogin.SuspendLayout();
            lgnForm.SuspendLayout();
            tabRegister.SuspendLayout();
            tabDashboard.SuspendLayout();
            grpProfili.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabLogin);
            tabMain.Controls.Add(tabRegister);
            tabMain.Controls.Add(tabDashboard);
            tabMain.Location = new Point(12, 12);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(697, 475);
            tabMain.TabIndex = 0;
            // 
            // tabLogin
            // 
            tabLogin.Controls.Add(lgnForm);
            tabLogin.Location = new Point(4, 29);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(3);
            tabLogin.Size = new Size(689, 442);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "Identifikimi";
            tabLogin.UseVisualStyleBackColor = true;
            // 
            // lgnForm
            // 
            lgnForm.Controls.Add(txtLoginUser);
            lgnForm.Controls.Add(txtLoginPass);
            lgnForm.Controls.Add(btnLogin);
            lgnForm.Location = new Point(39, 34);
            lgnForm.Name = "lgnForm";
            lgnForm.Size = new Size(250, 201);
            lgnForm.TabIndex = 5;
            lgnForm.TabStop = false;
            // 
            // txtLoginUser
            // 
            txtLoginUser.Location = new Point(6, 48);
            txtLoginUser.Name = "txtLoginUser";
            txtLoginUser.PlaceholderText = "Emri i Perdoruesit";
            txtLoginUser.Size = new Size(238, 27);
            txtLoginUser.TabIndex = 0;
            // 
            // txtLoginPass
            // 
            txtLoginPass.Location = new Point(6, 81);
            txtLoginPass.Name = "txtLoginPass";
            txtLoginPass.PasswordChar = '*';
            txtLoginPass.PlaceholderText = "Fjalekalimi";
            txtLoginPass.Size = new Size(234, 27);
            txtLoginPass.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(61, 146);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(122, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Identifikohu";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tabRegister
            // 
            tabRegister.Controls.Add(label10);
            tabRegister.Controls.Add(label9);
            tabRegister.Controls.Add(label6);
            tabRegister.Controls.Add(txtRegKontakt);
            tabRegister.Controls.Add(label3);
            tabRegister.Controls.Add(btnRegister);
            tabRegister.Controls.Add(dtpBirth);
            tabRegister.Controls.Add(cmbQytetiKerkoj);
            tabRegister.Controls.Add(label5);
            tabRegister.Controls.Add(label4);
            tabRegister.Controls.Add(cmbQytetiIm);
            tabRegister.Controls.Add(cmbSeksiKerkoj);
            tabRegister.Controls.Add(label2);
            tabRegister.Controls.Add(label1);
            tabRegister.Controls.Add(cmbSeksiIm);
            tabRegister.Controls.Add(txtRegAbout);
            tabRegister.Controls.Add(txtRegEmri);
            tabRegister.Controls.Add(txtRegPass);
            tabRegister.Controls.Add(txtRegUser);
            tabRegister.Location = new Point(4, 29);
            tabRegister.Name = "tabRegister";
            tabRegister.Padding = new Padding(3);
            tabRegister.Size = new Size(689, 442);
            tabRegister.TabIndex = 1;
            tabRegister.Text = "Regjistrimi";
            tabRegister.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(366, 141);
            label10.Name = "label10";
            label10.Size = new Size(132, 20);
            label10.TabIndex = 18;
            label10.Text = "Detajet e Partnerit:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(364, 21);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 17;
            label9.Text = "Detajet e Mia:";
            label9.Click += label9_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(366, 274);
            label6.Name = "label6";
            label6.Size = new Size(134, 20);
            label6.TabIndex = 16;
            label6.Text = "Menyra e Kontaktit";
            // 
            // txtRegKontakt
            // 
            txtRegKontakt.Location = new Point(362, 298);
            txtRegKontakt.Name = "txtRegKontakt";
            txtRegKontakt.PlaceholderText = "Telefon, Instagram, etj";
            txtRegKontakt.Size = new Size(249, 27);
            txtRegKontakt.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 263);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 14;
            label3.Text = "Datelindja";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(239, 373);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(186, 29);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Krijo Llogarinë";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(107, 263);
            dtpBirth.MaxDate = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            dtpBirth.MinDate = new DateTime(1950, 1, 1, 0, 0, 0, 0);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(174, 27);
            dtpBirth.TabIndex = 12;
            dtpBirth.Value = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            // 
            // cmbQytetiKerkoj
            // 
            cmbQytetiKerkoj.FormattingEnabled = true;
            cmbQytetiKerkoj.Items.AddRange(new object[] { "Berati", "Durrësi", "Elbasani", "Fieri", "Gjirokastra", "Korça", "Kukësi", "Lezha", "Lushnja", "Saranda", "Shkodra", "Tirana", "Vlora" });
            cmbQytetiKerkoj.Location = new Point(486, 178);
            cmbQytetiKerkoj.Name = "cmbQytetiKerkoj";
            cmbQytetiKerkoj.Size = new Size(151, 28);
            cmbQytetiKerkoj.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 181);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 10;
            label5.Text = "Qyteti *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 99);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 9;
            label4.Text = "Qyteti *";
            // 
            // cmbQytetiIm
            // 
            cmbQytetiIm.FormattingEnabled = true;
            cmbQytetiIm.Items.AddRange(new object[] { "Berati", "Durrësi", "Elbasani", "Fieri", "Gjirokastra", "Korça", "Kukësi", "Lezha", "Lushnja", "Saranda", "Shkodra", "Tirana", "Vlora" });
            cmbQytetiIm.Location = new Point(439, 91);
            cmbQytetiIm.Name = "cmbQytetiIm";
            cmbQytetiIm.Size = new Size(151, 28);
            cmbQytetiIm.TabIndex = 8;
            // 
            // cmbSeksiKerkoj
            // 
            cmbSeksiKerkoj.FormattingEnabled = true;
            cmbSeksiKerkoj.Items.AddRange(new object[] { "Femer", "Mashkull" });
            cmbSeksiKerkoj.Location = new Point(486, 204);
            cmbSeksiKerkoj.Name = "cmbSeksiKerkoj";
            cmbSeksiKerkoj.Size = new Size(151, 28);
            cmbSeksiKerkoj.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 207);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 6;
            label2.Text = "Seksi *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 65);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 5;
            label1.Text = "Seksi *";
            // 
            // cmbSeksiIm
            // 
            cmbSeksiIm.FormattingEnabled = true;
            cmbSeksiIm.Items.AddRange(new object[] { "Femer", "Mashkull" });
            cmbSeksiIm.Location = new Point(439, 57);
            cmbSeksiIm.Name = "cmbSeksiIm";
            cmbSeksiIm.Size = new Size(151, 28);
            cmbSeksiIm.TabIndex = 4;
            // 
            // txtRegAbout
            // 
            txtRegAbout.Location = new Point(23, 209);
            txtRegAbout.Multiline = true;
            txtRegAbout.Name = "txtRegAbout";
            txtRegAbout.PlaceholderText = "Rreth Meje";
            txtRegAbout.Size = new Size(258, 48);
            txtRegAbout.TabIndex = 3;
            // 
            // txtRegEmri
            // 
            txtRegEmri.Location = new Point(23, 155);
            txtRegEmri.Name = "txtRegEmri";
            txtRegEmri.PlaceholderText = "Emri qe Shfaqet";
            txtRegEmri.Size = new Size(258, 27);
            txtRegEmri.TabIndex = 2;
            // 
            // txtRegPass
            // 
            txtRegPass.Location = new Point(23, 99);
            txtRegPass.Name = "txtRegPass";
            txtRegPass.PasswordChar = '*';
            txtRegPass.PlaceholderText = "Fjalekalimi *";
            txtRegPass.Size = new Size(258, 27);
            txtRegPass.TabIndex = 1;
            // 
            // txtRegUser
            // 
            txtRegUser.Location = new Point(23, 55);
            txtRegUser.Name = "txtRegUser";
            txtRegUser.PlaceholderText = "Emri i Perdoruesit *";
            txtRegUser.Size = new Size(258, 27);
            txtRegUser.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(btnLogout);
            tabDashboard.Controls.Add(lstMatches);
            tabDashboard.Controls.Add(grpProfili);
            tabDashboard.Location = new Point(4, 29);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Size = new Size(689, 442);
            tabDashboard.TabIndex = 2;
            tabDashboard.Text = "Dashboard";
            tabDashboard.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(58, 337);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(165, 29);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Dil ( Logout )";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lstMatches
            // 
            lstMatches.FormattingEnabled = true;
            lstMatches.Location = new Point(340, 30);
            lstMatches.Name = "lstMatches";
            lstMatches.Size = new Size(330, 384);
            lstMatches.TabIndex = 6;
            // 
            // grpProfili
            // 
            grpProfili.Controls.Add(btnRuajNdryshimet);
            grpProfili.Controls.Add(label8);
            grpProfili.Controls.Add(label7);
            grpProfili.Controls.Add(txtEditKontakt);
            grpProfili.Controls.Add(txtEditAbout);
            grpProfili.Location = new Point(15, 21);
            grpProfili.Name = "grpProfili";
            grpProfili.Size = new Size(306, 277);
            grpProfili.TabIndex = 5;
            grpProfili.TabStop = false;
            grpProfili.Text = "Profili Im";
            // 
            // btnRuajNdryshimet
            // 
            btnRuajNdryshimet.Location = new Point(53, 219);
            btnRuajNdryshimet.Name = "btnRuajNdryshimet";
            btnRuajNdryshimet.Size = new Size(182, 29);
            btnRuajNdryshimet.TabIndex = 4;
            btnRuajNdryshimet.Text = "Ruaj Ndryshimet";
            btnRuajNdryshimet.UseVisualStyleBackColor = true;
            btnRuajNdryshimet.Click += btnRuajNdryshimet_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 26);
            label8.Name = "label8";
            label8.Size = new Size(81, 20);
            label8.TabIndex = 3;
            label8.Text = "Rreth Meje";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 133);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 2;
            label7.Text = "Menyra e Kontaktit";
            // 
            // txtEditKontakt
            // 
            txtEditKontakt.Location = new Point(17, 156);
            txtEditKontakt.Name = "txtEditKontakt";
            txtEditKontakt.Size = new Size(258, 27);
            txtEditKontakt.TabIndex = 1;
            // 
            // txtEditAbout
            // 
            txtEditAbout.Location = new Point(17, 49);
            txtEditAbout.Multiline = true;
            txtEditAbout.Name = "txtEditAbout";
            txtEditAbout.Size = new Size(258, 71);
            txtEditAbout.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 499);
            Controls.Add(tabMain);
            Name = "Form1";
            Text = "Dating App";
            tabMain.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            lgnForm.ResumeLayout(false);
            lgnForm.PerformLayout();
            tabRegister.ResumeLayout(false);
            tabRegister.PerformLayout();
            tabDashboard.ResumeLayout(false);
            grpProfili.ResumeLayout(false);
            grpProfili.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabLogin;
        private TabPage tabRegister;
        private TabPage tabDashboard;
        private TextBox txtLoginUser;
        private TextBox txtLoginPass;
        private Button btnLogin;
        private GroupBox lgnForm;
        private ComboBox cmbSeksiIm;
        private TextBox txtRegAbout;
        private TextBox txtRegEmri;
        private TextBox txtRegPass;
        private TextBox txtRegUser;
        private Label label1;
        private ComboBox cmbSeksiKerkoj;
        private Label label2;
        private ComboBox cmbQytetiKerkoj;
        private Label label5;
        private Label label4;
        private ComboBox cmbQytetiIm;
        private Button btnRegister;
        private DateTimePicker dtpBirth;
        private Label label3;
        private TextBox txtRegKontakt;
        private Label label6;
        private ListBox lstMatches;
        private GroupBox grpProfili;
        private Button btnRuajNdryshimet;
        private Label label8;
        private Label label7;
        private TextBox txtEditKontakt;
        private TextBox txtEditAbout;
        private Button btnLogout;
        private Label label9;
        private Label label10;
    }
}