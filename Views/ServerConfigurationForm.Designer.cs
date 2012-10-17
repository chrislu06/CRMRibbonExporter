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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDomainUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.cbxHttps = new System.Windows.Forms.CheckBox();
            this.cbxOffice365 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
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
            this.tbxServerAddr.Location = new System.Drawing.Point(152, 37);
            this.tbxServerAddr.Name = "tbxServerAddr";
            this.tbxServerAddr.Size = new System.Drawing.Size(426, 22);
            this.tbxServerAddr.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "domain\\username:";
            // 
            // tbxDomainUsername
            // 
            this.tbxDomainUsername.Location = new System.Drawing.Point(152, 63);
            this.tbxDomainUsername.Name = "tbxDomainUsername";
            this.tbxDomainUsername.Size = new System.Drawing.Size(426, 22);
            this.tbxDomainUsername.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(152, 91);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(426, 22);
            this.tbxPassword.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxOffice365);
            this.groupBox1.Controls.Add(this.cbxHttps);
            this.groupBox1.Controls.Add(this.btnClearForm);
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.tbxPassword);
            this.groupBox1.Controls.Add(this.tbxServerAddr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxDomainUsername);
            this.groupBox1.Location = new System.Drawing.Point(17, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 234);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create New Server Configuration";
            this.groupBox1.Visible = false;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(348, 189);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(112, 34);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(466, 189);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(112, 34);
            this.btnSaveConfig.TabIndex = 11;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
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
            // ServerConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_configurations);
            this.Controls.Add(this.label1);
            this.Name = "ServerConfigurationForm";
            this.Text = "ServerConfiguration";
            this.Load += new System.EventHandler(this.ServerConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_configurations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxServerAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDomainUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbxPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.CheckBox cbxOffice365;
        private System.Windows.Forms.CheckBox cbxHttps;
    }
}