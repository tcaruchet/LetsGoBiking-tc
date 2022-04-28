namespace LetsGoBiking_tc.Host
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStartRouting = new System.Windows.Forms.Button();
            this.LblStatusRouting = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStartWeb = new System.Windows.Forms.Button();
            this.BtnStartWF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStartRouting
            // 
            this.BtnStartRouting.Location = new System.Drawing.Point(12, 41);
            this.BtnStartRouting.Name = "BtnStartRouting";
            this.BtnStartRouting.Size = new System.Drawing.Size(264, 67);
            this.BtnStartRouting.TabIndex = 0;
            this.BtnStartRouting.Text = "Démarrer Routing";
            this.BtnStartRouting.UseVisualStyleBackColor = true;
            this.BtnStartRouting.Click += new System.EventHandler(this.BtnStartRouting_Click);
            // 
            // LblStatusRouting
            // 
            this.LblStatusRouting.AutoSize = true;
            this.LblStatusRouting.Location = new System.Drawing.Point(155, 9);
            this.LblStatusRouting.Name = "LblStatusRouting";
            this.LblStatusRouting.Size = new System.Drawing.Size(87, 16);
            this.LblStatusRouting.TabIndex = 1;
            this.LblStatusRouting.Text = "Non-démarré";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status WCF Services:";
            // 
            // BtnStartWeb
            // 
            this.BtnStartWeb.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnStartWeb.Location = new System.Drawing.Point(12, 114);
            this.BtnStartWeb.Name = "BtnStartWeb";
            this.BtnStartWeb.Size = new System.Drawing.Size(129, 48);
            this.BtnStartWeb.TabIndex = 3;
            this.BtnStartWeb.Text = "Démarrer \r\nSite Web";
            this.BtnStartWeb.UseVisualStyleBackColor = false;
            this.BtnStartWeb.Click += new System.EventHandler(this.BtnStartWeb_Click);
            // 
            // BtnStartWF
            // 
            this.BtnStartWF.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnStartWF.Location = new System.Drawing.Point(147, 114);
            this.BtnStartWF.Name = "BtnStartWF";
            this.BtnStartWF.Size = new System.Drawing.Size(129, 48);
            this.BtnStartWF.TabIndex = 3;
            this.BtnStartWF.Text = "Démarrer \r\nClient Lourd";
            this.BtnStartWF.UseVisualStyleBackColor = false;
            this.BtnStartWF.Click += new System.EventHandler(this.BtnStartWF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 174);
            this.Controls.Add(this.BtnStartWF);
            this.Controls.Add(this.BtnStartWeb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblStatusRouting);
            this.Controls.Add(this.BtnStartRouting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "StartRouting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartRouting;
        private System.Windows.Forms.Label LblStatusRouting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStartWeb;
        private System.Windows.Forms.Button BtnStartWF;
    }
}

