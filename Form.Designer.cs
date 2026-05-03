namespace Student_MeetUp
{
    partial class Form : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            tabMain = new TabControl();
            tabLogin = new TabPage();
            lgnForm = new GroupBox();
            txtLoginUser = new TextBox();
            txtLoginPass = new TextBox();
            btnLogin = new Button();
            tabRegister = new TabPage();
            label10 = new Label();
            label9 = new Label();
            txtRegKontakt = new TextBox();
            label3 = new Label();
            btnRegister = new Button();
            dtpBirth = new DateTimePicker();
            cmbDepartamentiKerkoj = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            cmbDepartamentiIm = new ComboBox();
            cmbSeksiKerkoj = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cmbSeksiIm = new ComboBox();
            txtRegAbout = new TextBox();
            txtRegEmri = new TextBox();
            txtRegPass = new TextBox();
            txtRegUser = new TextBox();
            tabInfo = new TabPage();
            label12 = new Label();
            tabExplore = new TabPage();
            groupBox1 = new GroupBox();
            lblMatchBirthday = new Label();
            lblMatchContact = new Label();
            lblMatchAbout = new Label();
            lstMatches = new ListBox();
            tabProfiliIm = new TabPage();
            btnRuajNdryshimet = new Button();
            groupBox2 = new GroupBox();
            cmbDepartamentiKerkoj2 = new ComboBox();
            label13 = new Label();
            label14 = new Label();
            cmbDepartamentiIm2 = new ComboBox();
            cmbSeksiKerkoj2 = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            cmbSeksiIm2 = new ComboBox();
            btnNdryshoFoton = new Button();
            picProfiliIm = new PictureBox();
            btnLogout = new Button();
            grpProfili = new GroupBox();
            label11 = new Label();
            dtpBirth2 = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            txtEditKontakt = new TextBox();
            txtEditAbout = new TextBox();
            tabMain.SuspendLayout();
            tabLogin.SuspendLayout();
            lgnForm.SuspendLayout();
            tabRegister.SuspendLayout();
            tabInfo.SuspendLayout();
            tabExplore.SuspendLayout();
            groupBox1.SuspendLayout();
            tabProfiliIm.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProfiliIm).BeginInit();
            grpProfili.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabLogin);
            tabMain.Controls.Add(tabRegister);
            tabMain.Controls.Add(tabInfo);
            tabMain.Controls.Add(tabExplore);
            tabMain.Controls.Add(tabProfiliIm);
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
            lgnForm.Location = new Point(214, 88);
            lgnForm.Name = "lgnForm";
            lgnForm.Size = new Size(250, 201);
            lgnForm.TabIndex = 5;
            lgnForm.TabStop = false;
            // 
            // txtLoginUser
            // 
            txtLoginUser.Location = new Point(6, 48);
            txtLoginUser.Name = "txtLoginUser";
            txtLoginUser.PlaceholderText = "Emri i perdoruesit";
            txtLoginUser.Size = new Size(238, 27);
            txtLoginUser.TabIndex = 0;
            txtLoginUser.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLoginPass
            // 
            txtLoginPass.Location = new Point(6, 81);
            txtLoginPass.Name = "txtLoginPass";
            txtLoginPass.PasswordChar = '*';
            txtLoginPass.PlaceholderText = "Fjalekalimi";
            txtLoginPass.Size = new Size(234, 27);
            txtLoginPass.TabIndex = 1;
            txtLoginPass.TextAlign = HorizontalAlignment.Center;
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
            tabRegister.Controls.Add(txtRegKontakt);
            tabRegister.Controls.Add(label3);
            tabRegister.Controls.Add(btnRegister);
            tabRegister.Controls.Add(dtpBirth);
            tabRegister.Controls.Add(cmbDepartamentiKerkoj);
            tabRegister.Controls.Add(label5);
            tabRegister.Controls.Add(label4);
            tabRegister.Controls.Add(cmbDepartamentiIm);
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
            label10.Location = new Point(362, 182);
            label10.Name = "label10";
            label10.Size = new Size(134, 20);
            label10.TabIndex = 18;
            label10.Text = "Detajet e partnerit:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(362, 25);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 17;
            label9.Text = "Detajet e mia:";
            // 
            // txtRegKontakt
            // 
            txtRegKontakt.Location = new Point(23, 301);
            txtRegKontakt.Name = "txtRegKontakt";
            txtRegKontakt.PlaceholderText = "Menyra kontaktit; tel, email, etj";
            txtRegKontakt.Size = new Size(258, 27);
            txtRegKontakt.TabIndex = 15;
            txtRegKontakt.TextChanged += txtRegKontakt_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 344);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 14;
            label3.Text = "Datelindja";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(247, 394);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(186, 29);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Krijo Llogarinë";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(107, 341);
            dtpBirth.MaxDate = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            dtpBirth.MinDate = new DateTime(1950, 1, 1, 0, 0, 0, 0);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(174, 27);
            dtpBirth.TabIndex = 12;
            dtpBirth.Value = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            dtpBirth.ValueChanged += dtpBirth_ValueChanged;
            // 
            // cmbDepartamentiKerkoj
            // 
            cmbDepartamentiKerkoj.FormattingEnabled = true;
            cmbDepartamentiKerkoj.Location = new Point(362, 282);
            cmbDepartamentiKerkoj.Name = "cmbDepartamentiKerkoj";
            cmbDepartamentiKerkoj.Size = new Size(249, 28);
            cmbDepartamentiKerkoj.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 251);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 10;
            label5.Text = "Departamenti *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 96);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 9;
            label4.Text = "Departamenti *";
            label4.Click += label4_Click;
            // 
            // cmbDepartamentiIm
            // 
            cmbDepartamentiIm.FormattingEnabled = true;
            cmbDepartamentiIm.Location = new Point(362, 128);
            cmbDepartamentiIm.Name = "cmbDepartamentiIm";
            cmbDepartamentiIm.Size = new Size(249, 28);
            cmbDepartamentiIm.TabIndex = 8;
            cmbDepartamentiIm.SelectedIndexChanged += cmbDepartamentiIm_SelectedIndexChanged;
            // 
            // cmbSeksiKerkoj
            // 
            cmbSeksiKerkoj.FormattingEnabled = true;
            cmbSeksiKerkoj.Location = new Point(460, 213);
            cmbSeksiKerkoj.Name = "cmbSeksiKerkoj";
            cmbSeksiKerkoj.Size = new Size(151, 28);
            cmbSeksiKerkoj.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 218);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 6;
            label2.Text = "Seksi *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 62);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 5;
            label1.Text = "Seksi *";
            // 
            // cmbSeksiIm
            // 
            cmbSeksiIm.FormattingEnabled = true;
            cmbSeksiIm.Location = new Point(460, 57);
            cmbSeksiIm.Name = "cmbSeksiIm";
            cmbSeksiIm.Size = new Size(151, 28);
            cmbSeksiIm.TabIndex = 4;
            cmbSeksiIm.SelectedIndexChanged += cmbSeksiIm_SelectedIndexChanged;
            // 
            // txtRegAbout
            // 
            txtRegAbout.Location = new Point(23, 195);
            txtRegAbout.Multiline = true;
            txtRegAbout.Name = "txtRegAbout";
            txtRegAbout.PlaceholderText = "Rreth Meje";
            txtRegAbout.Size = new Size(258, 92);
            txtRegAbout.TabIndex = 3;
            // 
            // txtRegEmri
            // 
            txtRegEmri.Location = new Point(23, 148);
            txtRegEmri.Name = "txtRegEmri";
            txtRegEmri.PlaceholderText = "Emri qe shfaqet";
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
            txtRegUser.PlaceholderText = "Emri i perdoruesit *";
            txtRegUser.Size = new Size(258, 27);
            txtRegUser.TabIndex = 0;
            // 
            // tabInfo
            // 
            tabInfo.Controls.Add(label12);
            tabInfo.Location = new Point(4, 29);
            tabInfo.Name = "tabInfo";
            tabInfo.Size = new Size(689, 442);
            tabInfo.TabIndex = 4;
            tabInfo.Text = "Info";
            tabInfo.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 21);
            label12.Name = "label12";
            label12.Size = new Size(502, 280);
            label12.TabIndex = 0;
            label12.Text = resources.GetString("label12.Text");
            label12.Click += label12_Click;
            // 
            // tabExplore
            // 
            tabExplore.Controls.Add(groupBox1);
            tabExplore.Controls.Add(lstMatches);
            tabExplore.Location = new Point(4, 29);
            tabExplore.Name = "tabExplore";
            tabExplore.Size = new Size(689, 442);
            tabExplore.TabIndex = 2;
            tabExplore.Text = "Eksploro";
            tabExplore.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMatchBirthday);
            groupBox1.Controls.Add(lblMatchContact);
            groupBox1.Controls.Add(lblMatchAbout);
            groupBox1.Location = new Point(353, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 404);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detajet e personit";
            // 
            // lblMatchBirthday
            // 
            lblMatchBirthday.AutoSize = true;
            lblMatchBirthday.Location = new Point(18, 31);
            lblMatchBirthday.Name = "lblMatchBirthday";
            lblMatchBirthday.Size = new Size(15, 20);
            lblMatchBirthday.TabIndex = 3;
            lblMatchBirthday.Text = "-";
            // 
            // lblMatchContact
            // 
            lblMatchContact.AutoSize = true;
            lblMatchContact.Location = new Point(18, 61);
            lblMatchContact.Name = "lblMatchContact";
            lblMatchContact.Size = new Size(15, 20);
            lblMatchContact.TabIndex = 2;
            lblMatchContact.Text = "-";
            // 
            // lblMatchAbout
            // 
            lblMatchAbout.AutoSize = true;
            lblMatchAbout.Location = new Point(18, 90);
            lblMatchAbout.Name = "lblMatchAbout";
            lblMatchAbout.Size = new Size(15, 20);
            lblMatchAbout.TabIndex = 1;
            lblMatchAbout.Text = "-";
            // 
            // lstMatches
            // 
            lstMatches.FormattingEnabled = true;
            lstMatches.Location = new Point(17, 18);
            lstMatches.Name = "lstMatches";
            lstMatches.Size = new Size(330, 404);
            lstMatches.TabIndex = 6;
            lstMatches.SelectedIndexChanged += lstMatches_SelectedIndexChanged;
            // 
            // tabProfiliIm
            // 
            tabProfiliIm.Controls.Add(btnRuajNdryshimet);
            tabProfiliIm.Controls.Add(groupBox2);
            tabProfiliIm.Controls.Add(btnNdryshoFoton);
            tabProfiliIm.Controls.Add(picProfiliIm);
            tabProfiliIm.Controls.Add(btnLogout);
            tabProfiliIm.Controls.Add(grpProfili);
            tabProfiliIm.Location = new Point(4, 29);
            tabProfiliIm.Name = "tabProfiliIm";
            tabProfiliIm.Size = new Size(689, 442);
            tabProfiliIm.TabIndex = 3;
            tabProfiliIm.Text = "Profili Im";
            tabProfiliIm.UseVisualStyleBackColor = true;
            // 
            // btnRuajNdryshimet
            // 
            btnRuajNdryshimet.Location = new Point(278, 347);
            btnRuajNdryshimet.Name = "btnRuajNdryshimet";
            btnRuajNdryshimet.Size = new Size(94, 29);
            btnRuajNdryshimet.TabIndex = 4;
            btnRuajNdryshimet.Text = "Ruaj Ndryshimet";
            btnRuajNdryshimet.UseVisualStyleBackColor = true;
            btnRuajNdryshimet.Click += btnRuajNdryshimet_Click_1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbDepartamentiKerkoj2);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(cmbDepartamentiIm2);
            groupBox2.Controls.Add(cmbSeksiKerkoj2);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(cmbSeksiIm2);
            groupBox2.Location = new Point(341, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(306, 279);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detajet e perputhjes";
            // 
            // cmbDepartamentiKerkoj2
            // 
            cmbDepartamentiKerkoj2.FormattingEnabled = true;
            cmbDepartamentiKerkoj2.Location = new Point(10, 240);
            cmbDepartamentiKerkoj2.Name = "cmbDepartamentiKerkoj2";
            cmbDepartamentiKerkoj2.Size = new Size(288, 28);
            cmbDepartamentiKerkoj2.TabIndex = 26;
            cmbDepartamentiKerkoj2.SelectedIndexChanged += cmbDepartamentiKerkoj2_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 210);
            label13.Name = "label13";
            label13.Size = new Size(172, 20);
            label13.TabIndex = 25;
            label13.Text = "Departamenti partnerit *";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 143);
            label14.Name = "label14";
            label14.Size = new Size(132, 20);
            label14.TabIndex = 24;
            label14.Text = "Departamenti im *";
            label14.Click += label14_Click;
            // 
            // cmbDepartamentiIm2
            // 
            cmbDepartamentiIm2.FormattingEnabled = true;
            cmbDepartamentiIm2.Location = new Point(9, 173);
            cmbDepartamentiIm2.Name = "cmbDepartamentiIm2";
            cmbDepartamentiIm2.Size = new Size(288, 28);
            cmbDepartamentiIm2.TabIndex = 23;
            cmbDepartamentiIm2.SelectedIndexChanged += cmbDepartamentiIm2_SelectedIndexChanged;
            // 
            // cmbSeksiKerkoj2
            // 
            cmbSeksiKerkoj2.FormattingEnabled = true;
            cmbSeksiKerkoj2.Location = new Point(145, 91);
            cmbSeksiKerkoj2.Name = "cmbSeksiKerkoj2";
            cmbSeksiKerkoj2.Size = new Size(151, 28);
            cmbSeksiKerkoj2.TabIndex = 22;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 96);
            label15.Name = "label15";
            label15.Size = new Size(113, 20);
            label15.TabIndex = 21;
            label15.Text = "Seksi partnerit *";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 57);
            label16.Name = "label16";
            label16.Size = new Size(73, 20);
            label16.TabIndex = 20;
            label16.Text = "Seksi im *";
            // 
            // cmbSeksiIm2
            // 
            cmbSeksiIm2.FormattingEnabled = true;
            cmbSeksiIm2.Location = new Point(145, 52);
            cmbSeksiIm2.Name = "cmbSeksiIm2";
            cmbSeksiIm2.Size = new Size(151, 28);
            cmbSeksiIm2.TabIndex = 19;
            cmbSeksiIm2.SelectedIndexChanged += cmbSeksiIm2_SelectedIndexChanged;
            // 
            // btnNdryshoFoton
            // 
            btnNdryshoFoton.Location = new Point(583, 329);
            btnNdryshoFoton.Name = "btnNdryshoFoton";
            btnNdryshoFoton.Size = new Size(94, 29);
            btnNdryshoFoton.TabIndex = 13;
            btnNdryshoFoton.Text = "Ruaj Foton";
            btnNdryshoFoton.UseVisualStyleBackColor = true;
            btnNdryshoFoton.Visible = false;
            // 
            // picProfiliIm
            // 
            picProfiliIm.Location = new Point(552, 364);
            picProfiliIm.Name = "picProfiliIm";
            picProfiliIm.Size = new Size(125, 62);
            picProfiliIm.SizeMode = PictureBoxSizeMode.Zoom;
            picProfiliIm.TabIndex = 12;
            picProfiliIm.TabStop = false;
            picProfiliIm.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(244, 382);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(165, 29);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Dil ( Logout )";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // grpProfili
            // 
            grpProfili.Controls.Add(label11);
            grpProfili.Controls.Add(dtpBirth2);
            grpProfili.Controls.Add(label8);
            grpProfili.Controls.Add(label7);
            grpProfili.Controls.Add(txtEditKontakt);
            grpProfili.Controls.Add(txtEditAbout);
            grpProfili.Location = new Point(16, 27);
            grpProfili.Name = "grpProfili";
            grpProfili.Size = new Size(306, 279);
            grpProfili.TabIndex = 6;
            grpProfili.TabStop = false;
            grpProfili.Text = "Profili im";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 211);
            label11.Name = "label11";
            label11.Size = new Size(78, 20);
            label11.TabIndex = 16;
            label11.Text = "Datelindja";
            // 
            // dtpBirth2
            // 
            dtpBirth2.Location = new Point(101, 208);
            dtpBirth2.MaxDate = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            dtpBirth2.MinDate = new DateTime(1950, 1, 1, 0, 0, 0, 0);
            dtpBirth2.Name = "dtpBirth2";
            dtpBirth2.Size = new Size(174, 27);
            dtpBirth2.TabIndex = 15;
            dtpBirth2.Value = new DateTime(2010, 12, 31, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 26);
            label8.Name = "label8";
            label8.Size = new Size(81, 20);
            label8.TabIndex = 3;
            label8.Text = "Rreth meje";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 133);
            label7.Name = "label7";
            label7.Size = new Size(132, 20);
            label7.TabIndex = 2;
            label7.Text = "Menyra e kontaktit";
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
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 499);
            Controls.Add(tabMain);
            Name = "Form";
            Text = "Student MeetUp";
            tabMain.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            lgnForm.ResumeLayout(false);
            lgnForm.PerformLayout();
            tabRegister.ResumeLayout(false);
            tabRegister.PerformLayout();
            tabInfo.ResumeLayout(false);
            tabInfo.PerformLayout();
            tabExplore.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabProfiliIm.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProfiliIm).EndInit();
            grpProfili.ResumeLayout(false);
            grpProfili.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabLogin;
        private TabPage tabRegister;
        private TabPage tabExplore;
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
        private ComboBox cmbDepartamentiKerkoj;
        private Label label5;
        private Label label4;
        private ComboBox cmbDepartamentiIm;
        private Button btnRegister;
        private DateTimePicker dtpBirth;
        private Label label3;
        private TextBox txtRegKontakt;
        private ListBox lstMatches;
        private Label label9;
        private Label label10;
        private GroupBox groupBox1;
        private Label lblMatchContact;
        private Label lblMatchAbout;
        private TabPage tabProfiliIm;
        private GroupBox grpProfili;
        private Button btnRuajNdryshimet;
        private Label label8;
        private Label label7;
        private TextBox txtEditKontakt;
        private TextBox txtEditAbout;
        private Button btnNdryshoFoton;
        private PictureBox picProfiliIm;
        private Button btnLogout;
        private GroupBox groupBox2;
        private ComboBox cmbDepartamentiKerkoj2;
        private Label label13;
        private Label label14;
        private ComboBox cmbDepartamentiIm2;
        private ComboBox cmbSeksiKerkoj2;
        private Label label15;
        private Label label16;
        private ComboBox cmbSeksiIm2;
        private Label label11;
        private DateTimePicker dtpBirth2;
        private Label lblMatchBirthday;
        private TabPage tabInfo;
        private Label label12;
    }
}