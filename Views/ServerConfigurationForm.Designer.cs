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
            this.btnConnect = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Server Configurations:";
            // 
            // cmb_configurations
            // 
            this.cmb_configurations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_configurations.FormattingEnabled = true;
            this.cmb_configurations.Location = new System.Drawing.Point(13, 32);
            this.cmb_configurations.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_configurations.Name = "cmb_configurations";
            this.cmb_configurations.Size = new System.Drawing.Size(335, 21);
            this.cmb_configurations.TabIndex = 1;
            this.cmb_configurations.SelectedIndexChanged += new System.EventHandler(this.cmb_configurations_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(352, 27);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbxServerAddr
            // 
            this.tbxServerAddr.Location = new System.Drawing.Point(123, 30);
            this.tbxServerAddr.Margin = new System.Windows.Forms.Padding(2);
            this.tbxServerAddr.Name = "tbxServerAddr";
            this.tbxServerAddr.Size = new System.Drawing.Size(312, 20);
            this.tbxServerAddr.TabIndex = 1;
            // 
            // lblServerAddr
            // 
            this.lblServerAddr.AutoSize = true;
            this.lblServerAddr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerAddr.Location = new System.Drawing.Point(10, 30);
            this.lblServerAddr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerAddr.Name = "lblServerAddr";
            this.lblServerAddr.Size = new System.Drawing.Size(87, 15);
            this.lblServerAddr.TabIndex = 5;
            this.lblServerAddr.Text = "Server Address:";
            // 
            // lblDomainAndUsername
            // 
            this.lblDomainAndUsername.AutoSize = true;
            this.lblDomainAndUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainAndUsername.Location = new System.Drawing.Point(10, 53);
            this.lblDomainAndUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDomainAndUsername.Name = "lblDomainAndUsername";
            this.lblDomainAndUsername.Size = new System.Drawing.Size(110, 15);
            this.lblDomainAndUsername.TabIndex = 7;
            this.lblDomainAndUsername.Text = "Domain\\Username:";
            // 
            // tbxDomainUsername
            // 
            this.tbxDomainUsername.Location = new System.Drawing.Point(123, 51);
            this.tbxDomainUsername.Margin = new System.Windows.Forms.Padding(2);
            this.tbxDomainUsername.Name = "tbxDomainUsername";
            this.tbxDomainUsername.Size = new System.Drawing.Size(312, 20);
            this.tbxDomainUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(10, 76);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(123, 74);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(312, 20);
            this.tbxPassword.TabIndex = 3;
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
            this.gbxServerConfig.Location = new System.Drawing.Point(13, 59);
            this.gbxServerConfig.Margin = new System.Windows.Forms.Padding(2);
            this.gbxServerConfig.Name = "gbxServerConfig";
            this.gbxServerConfig.Padding = new System.Windows.Forms.Padding(2);
            this.gbxServerConfig.Size = new System.Drawing.Size(438, 190);
            this.gbxServerConfig.TabIndex = 11;
            this.gbxServerConfig.TabStop = false;
            this.gbxServerConfig.Text = "Create New Server Configuration";
            this.gbxServerConfig.Visible = false;
            // 
            // cbxOffice365
            // 
            this.cbxOffice365.AutoSize = true;
            this.cbxOffice365.Location = new System.Drawing.Point(13, 130);
            this.cbxOffice365.Margin = new System.Windows.Forms.Padding(2);
            this.cbxOffice365.Name = "cbxOffice365";
            this.cbxOffice365.Size = new System.Drawing.Size(243, 17);
            this.cbxOffice365.TabIndex = 5;
            this.cbxOffice365.Text = "Is this organization provisioned for Office 365?";
            this.cbxOffice365.UseVisualStyleBackColor = true;
            // 
            // cbxHttps
            // 
            this.cbxHttps.AutoSize = true;
            this.cbxHttps.Location = new System.Drawing.Point(13, 107);
            this.cbxHttps.Margin = new System.Windows.Forms.Padding(2);
            this.cbxHttps.Name = "cbxHttps";
            this.cbxHttps.Size = new System.Drawing.Size(158, 17);
            this.cbxHttps.TabIndex = 4;
            this.cbxHttps.Text = "Secure Socket Layer (https)";
            this.cbxHttps.UseVisualStyleBackColor = true;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(339, 151);
            this.btnClearForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(84, 28);
            this.btnClearForm.TabIndex = 7;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(251, 151);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(84, 28);
            this.btnSaveConfig.TabIndex = 6;
            this.btnSaveConfig.Text = "Connect";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // gbxOrgs
            // 
            this.gbxOrgs.Controls.Add(this.btnSelectOrg);
            this.gbxOrgs.Controls.Add(this.label2);
            this.gbxOrgs.Controls.Add(this.lbOrganizations);
            this.gbxOrgs.Location = new System.Drawing.Point(13, 254);
            this.gbxOrgs.Margin = new System.Windows.Forms.Padding(2);
            this.gbxOrgs.Name = "gbxOrgs";
            this.gbxOrgs.Padding = new System.Windows.Forms.Padding(2);
            this.gbxOrgs.Size = new System.Drawing.Size(438, 112);
            this.gbxOrgs.TabIndex = 12;
            this.gbxOrgs.TabStop = false;
            this.gbxOrgs.Text = "Organizations";
            this.gbxOrgs.Visible = false;
            // 
            // btnSelectOrg
            // 
            this.btnSelectOrg.Location = new System.Drawing.Point(175, 41);
            this.btnSelectOrg.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectOrg.Name = "btnSelectOrg";
            this.btnSelectOrg.Size = new System.Drawing.Size(111, 31);
            this.btnSelectOrg.TabIndex = 2;
            this.btnSelectOrg.Text = "Save";
            this.btnSelectOrg.UseVisualStyleBackColor = true;
            this.btnSelectOrg.Click += new System.EventHandler(this.btnSelectOrg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select an Organization";
            // 
            // lbOrganizations
            // 
            this.lbOrganizations.FormattingEnabled = true;
            this.lbOrganizations.Location = new System.Drawing.Point(13, 17);
            this.lbOrganizations.Margin = new System.Windows.Forms.Padding(2);
            this.lbOrganizations.Name = "lbOrganizations";
            this.lbOrganizations.Size = new System.Drawing.Size(156, 82);
            this.lbOrganizations.TabIndex = 0;
            // 
            // ServerConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 376);
            this.Controls.Add(this.gbxOrgs);
            this.Controls.Add(this.gbxServerConfig);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmb_configurations);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnConnect;
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