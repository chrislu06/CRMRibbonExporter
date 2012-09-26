namespace Microsoft.Crm.Sdk.Samples
{
    partial class InitialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_allRibbons = new System.Windows.Forms.Button();
            this.btn_specificRibbons = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(102, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(372, 94);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_allRibbons
            // 
            this.btn_allRibbons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_allRibbons.Location = new System.Drawing.Point(12, 158);
            this.btn_allRibbons.Name = "btn_allRibbons";
            this.btn_allRibbons.Size = new System.Drawing.Size(161, 83);
            this.btn_allRibbons.TabIndex = 1;
            this.btn_allRibbons.Text = "Get all Organization Ribbons";
            this.btn_allRibbons.UseVisualStyleBackColor = true;
            // 
            // btn_specificRibbons
            // 
            this.btn_specificRibbons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_specificRibbons.Location = new System.Drawing.Point(405, 158);
            this.btn_specificRibbons.Name = "btn_specificRibbons";
            this.btn_specificRibbons.Size = new System.Drawing.Size(161, 83);
            this.btn_specificRibbons.TabIndex = 2;
            this.btn_specificRibbons.Text = "Get Specific Organization Ribbons";
            this.btn_specificRibbons.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Organization: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_specificRibbons);
            this.Controls.Add(this.btn_allRibbons);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InitialForm";
            this.Text = "Fancy CRM Ribbon Exporter";
            this.Load += new System.EventHandler(this.InitialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_allRibbons;
        private System.Windows.Forms.Button btn_specificRibbons;
        private System.Windows.Forms.Label label1;
    }
}