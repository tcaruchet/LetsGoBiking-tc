namespace LetsGoBiking_tc.WF
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
            this.DtgStations = new System.Windows.Forms.DataGridView();
            this.BtnGetStations = new System.Windows.Forms.Button();
            this.BtnOrderByContract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgStations
            // 
            this.DtgStations.AllowUserToAddRows = false;
            this.DtgStations.AllowUserToDeleteRows = false;
            this.DtgStations.AllowUserToOrderColumns = true;
            this.DtgStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgStations.Location = new System.Drawing.Point(12, 38);
            this.DtgStations.Name = "DtgStations";
            this.DtgStations.ReadOnly = true;
            this.DtgStations.RowHeadersWidth = 51;
            this.DtgStations.RowTemplate.Height = 24;
            this.DtgStations.Size = new System.Drawing.Size(541, 525);
            this.DtgStations.TabIndex = 0;
            // 
            // BtnGetStations
            // 
            this.BtnGetStations.Location = new System.Drawing.Point(12, 9);
            this.BtnGetStations.Name = "BtnGetStations";
            this.BtnGetStations.Size = new System.Drawing.Size(140, 23);
            this.BtnGetStations.TabIndex = 1;
            this.BtnGetStations.Text = "GetAllStations";
            this.BtnGetStations.UseVisualStyleBackColor = true;
            this.BtnGetStations.Click += new System.EventHandler(this.BtnGetStations_Click);
            // 
            // BtnOrderByContract
            // 
            this.BtnOrderByContract.Location = new System.Drawing.Point(413, 9);
            this.BtnOrderByContract.Name = "BtnOrderByContract";
            this.BtnOrderByContract.Size = new System.Drawing.Size(140, 23);
            this.BtnOrderByContract.TabIndex = 2;
            this.BtnOrderByContract.Text = "Filtrer par Ville";
            this.BtnOrderByContract.UseVisualStyleBackColor = true;
            this.BtnOrderByContract.Click += new System.EventHandler(this.BtnOrderByContract_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 575);
            this.Controls.Add(this.BtnOrderByContract);
            this.Controls.Add(this.BtnGetStations);
            this.Controls.Add(this.DtgStations);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "LetsGoBiking_tc - Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgStations;
        private System.Windows.Forms.Button BtnGetStations;
        private System.Windows.Forms.Button BtnOrderByContract;
    }
}

