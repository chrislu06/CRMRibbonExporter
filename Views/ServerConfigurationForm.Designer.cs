namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    partial class ServerConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_configurations = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxServerAddr = new System.Windows.Forms.TextBox();
            this.lblServerAddr = new System.Windows.Forms.Label();
            this.lblDomainAndUsername = new System.Windows.Forms.Label();
            this.tbxDomainUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.MaskedTextBox();
            this.gbxServerConfig = new System.Windows.Forms.GroupBox();
            this.cbxOffice365 = new System.Windows.Forms.CheckBox();
            this.cbxHttps = new System.Windows.Forms.CheckBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.gbxOrgs = new System.Windows.Forms.GroupBox();
            this.btnSelectOrg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOrganizations = new System.Windows.Forms.ListBox();
            this.gbxServerConfig.SuspendLayout();
            this.gbxOrgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Server Configurations:";
            // 
            // cmb_configurations
            // 
            this.cmb_configurations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_configurations.FormattingEnabled = true;
            this.cmb_configurations.Location = new System.Drawing.Point(17, 40);
            this.cmb_configurations.Name = "cmb_configurations";
            this.cmb_configurations.Size = new System.Drawing.Size(473, 24);
            this.cmb_configurations.TabIndex = 1;
            this.cmb_configurations.SelectedIndexChanged += new System.EventHandler(this.cmb_configurations_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(496, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxServerAddr
            // 
            this.tbxServerAddr.Location = new System.Drawing.Point(164, 37);
            this.tbxServerAddr.Name = "tbxServerAddr";
            this.tbxServerAddr.Size = new System.Drawing.Size(414, 22);
            this.tbxServerAddr.TabIndex = 4;
            // 
            // lblServerAddr
            // 
            this.lblServerAddr.AutoSize = true;
            this.lblServerAddr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerAddr.Location = new System.Drawing.Point(13, 37);
            this.lblServerAddr.Name = "lblServerAddr";
            this.lblServerAddr.Size = new System.Drawing.Size(110, 20);
            this.lblServerAddr.TabIndex = 5;
            this.lblServerAddr.Text = "Server Address:";
            // 
            // lblDomainAndUsername
            // 
            this.lblDomainAndUsername.AutoSize = true;
            this.lblDomainAndUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainAndUsername.Location = new System.Drawing.Point(13, 65);
            this.lblDomainAndUsername.Name = "lblDomainAndUsername";
            this.lblDomainAndUsername.Size = new System.Drawing.Size(137, 20);
            this.lblDomainAndUsername.TabIndex = 7;
            this.lblDomainAndUsername.Text = "Domain\\Username:";
            // 
            // tbxDomainUsername
            // 
            this.tbxDomainUsername.Location = new System.Drawing.Point(164, 63);
            this.tbxDomainUsername.Name = "tbxDomainUsername";
            this.tbxDomainUsername.Size = new System.Drawing.Size(414, 22);
            this.tbxDomainUsername.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(13, 93);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 20);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(164, 91);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(414, 22);
            this.tbxPassword.TabIndex = 10;
            // 
            // gbxServerConfig
            // 
            this.gbxServerConfig.Controls.Add(this.cbxOffice365);
            this.gbxServerConfig.Controls.Add(this.cbxHttps);
            this.gbxServerConfig.Controls.Add(this.btnClearForm);
            this.gbxServerConfig.Controls.Add(this.btnSaveConfig);
            this.gbxServerConfig.Controls.Add(this.tbxPassword);
            this.gbxServerConfig.Controls.Add(this.tbxServerAddr);
            this.gbxServerConfig.Controls.Add(this.lblPassword);
            this.gbxServerConfig.Controls.Add(this.lblServerAddr);
            this.gbxServerConfig.Controls.Add(this.lblDomainAndUsername);
            this.gbxServerConfig.Controls.Add(this.tbxDomainUsername);
            this.gbxServerConfig.Location = new System.Drawing.Point(17, 73);
            this.gbxServerConfig.Name = "gbxServerConfig";
            this.gbxServerConfig.Size = new System.Drawing.Size(584, 234);
            this.gbxServerConfig.TabIndex = 11;
            this.gbxServerConfig.TabStop = false;
            this.gbxServerConfig.Text = "Create New Server Configuration";
            this.gbxServerConfig.Visible = false;
            // 
            // cbxOffice365
            // 
            this.cbxOffice365.AutoSize = true;
            this.cbxOffice365.Location = new System.Drawing.Point(17, 160);
            this.cbxOffice365.Name = "cbxOffice365";
            this.cbxOffice365.Size = new System.Drawing.Size(323, 21);
            this.cbxOffice365.TabIndex = 14;
            this.cbxOffice365.Text = "Is this organization provisioned for Office 365?";
            this.cbxOffice365.UseVisualStyleBackColor = true;
            // 
            // cbxHttps
            // 
            this.cbxHttps.AutoSize = true;
            this.cbxHttps.Location = new System.Drawing.Point(17, 132);
            this.cbxHttps.Name = "cbxHttps";
            this.cbxHttps.Size = new System.Drawing.Size(207, 21);
            this.cbxHttps.TabIndex = 13;
            this.cbxHttps.Text = "Secure Socket Layer (https)";
            this.cbxHttps.UseVisualStyleBackColor = true;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(466, 187);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(112, 34);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(348, 187);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(112, 34);
            this.btnSaveConfig.TabIndex = 11;
            this.btnSaveConfig.Text = "Connect";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // gbxOrgs
            // 
            this.gbxOrgs.Controls.Add(this.btnSelectOrg);
            this.gbxOrgs.Controls.Add(this.label2);
            this.gbxOrgs.Controls.Add(this.lbOrganizations);
            this.gbxOrgs.Location = new System.Drawing.Point(17, 313);
            this.gbxOrgs.Name = "gbxOrgs";
            this.gbxOrgs.Size = new System.Drawing.Size(584, 138);
            this.gbxOrgs.TabIndex = 12;
            this.gbxOrgs.TabStop = false;
            this.gbxOrgs.Text = "Organizations";
            this.gbxOrgs.Visible = false;
            // 
            // btnSelectOrg
            // 
            this.btnSelectOrg.Location = new System.Drawing.Point(233, 50);
            this.btnSelectOrg.Name = "btnSelectOrg";
            this.btnSelectOrg.Size = new System.Drawing.Size(148, 38);
            this.btnSelectOrg.TabIndex = 2;
            this.btnSelectOrg.Text = "Save";
            this.btnSelectOrg.UseVisualStyleBackColor = true;
            this.btnSelectOrg.Click += new System.EventHandler(this.btnSelectOrg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select an Organization";
            // 
            // lbOrganizations
            // 
            this.lbOrganizations.FormattingEnabled = true;
            this.lbOrganizations.ItemHeight = 16;
            this.lbOrganizations.Location = new System.Drawing.Point(17, 21);
            this.lbOrganizations.Name = "lbOrganizations";
            this.lbOrganizations.Size = new System.Drawing.Size(207, 100);
            this.lbOrganizations.TabIndex = 0;
            // 
            // ServerConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 463);
            this.Controls.Add(this.gbxOrgs);
            this.Controls.Add(this.gbxServerConfig);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_configurations);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ServerConfigurationForm";
            this.Text = "ServerConfiguration";
            this.Load += new System.EventHandler(this.ServerConfiguration_Load);
            this.gbxServerConfig.ResumeLayout(false);
            this.gbxServerConfig.PerformLayout();
            this.gbxOrgs.ResumeLayout(false);
            this.gbxOrgs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_configurations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxServerAddr;
        private System.Windows.Forms.Label lblServerAddr;
        private System.Windows.Forms.Label lblDomainAndUsername;
        private System.Windows.Forms.TextBox tbxDomainUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.MaskedTextBox tbxPassword;
        private System.Windows.Forms.GroupBox gbxServerConfig;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.CheckBox cbxOffice365;
        private System.Windows.Forms.CheckBox cbxHttps;
        private System.Windows.Forms.GroupBox gbxOrgs;
        private System.Windows.Forms.Button btnSelectOrg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbOrganizations;
    }
}