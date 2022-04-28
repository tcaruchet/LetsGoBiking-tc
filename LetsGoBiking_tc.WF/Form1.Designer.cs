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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblSizeRequest = new System.Windows.Forms.Label();
            this.LblUrlRequest = new System.Windows.Forms.Label();
            this.LblTimeLastRequest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSearchRoute = new System.Windows.Forms.Button();
            this.TxtEndGeo = new System.Windows.Forms.TextBox();
            this.TxtEndAddress = new System.Windows.Forms.TextBox();
            this.TxtStartGeo = new System.Windows.Forms.TextBox();
            this.DtgRoute = new System.Windows.Forms.DataGridView();
            this.TxtStartAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnTestCache = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRoute)).BeginInit();
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
            this.BtnOrderByContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOrderByContract.Location = new System.Drawing.Point(413, 9);
            this.BtnOrderByContract.Name = "BtnOrderByContract";
            this.BtnOrderByContract.Size = new System.Drawing.Size(140, 23);
            this.BtnOrderByContract.TabIndex = 2;
            this.BtnOrderByContract.Text = "Filtrer par Ville";
            this.BtnOrderByContract.UseVisualStyleBackColor = true;
            this.BtnOrderByContract.Click += new System.EventHandler(this.BtnOrderByContract_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LblSizeRequest);
            this.groupBox1.Controls.Add(this.LblUrlRequest);
            this.groupBox1.Controls.Add(this.BtnTestCache);
            this.groupBox1.Controls.Add(this.LblTimeLastRequest);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(573, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistiques";
            // 
            // LblSizeRequest
            // 
            this.LblSizeRequest.AutoSize = true;
            this.LblSizeRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSizeRequest.Location = new System.Drawing.Point(135, 79);
            this.LblSizeRequest.Name = "LblSizeRequest";
            this.LblSizeRequest.Size = new System.Drawing.Size(113, 16);
            this.LblSizeRequest.TabIndex = 0;
            this.LblSizeRequest.Text = "Pas de requête";
            // 
            // LblUrlRequest
            // 
            this.LblUrlRequest.AutoSize = true;
            this.LblUrlRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUrlRequest.Location = new System.Drawing.Point(55, 26);
            this.LblUrlRequest.Name = "LblUrlRequest";
            this.LblUrlRequest.Size = new System.Drawing.Size(113, 16);
            this.LblUrlRequest.TabIndex = 0;
            this.LblUrlRequest.Text = "Pas de requête";
            // 
            // LblTimeLastRequest
            // 
            this.LblTimeLastRequest.AutoSize = true;
            this.LblTimeLastRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimeLastRequest.Location = new System.Drawing.Point(233, 51);
            this.LblTimeLastRequest.Name = "LblTimeLastRequest";
            this.LblTimeLastRequest.Size = new System.Drawing.Size(113, 16);
            this.LblTimeLastRequest.TabIndex = 0;
            this.LblTimeLastRequest.Text = "Pas de requête";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Taille de la requête";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Route";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temps pris pour la dernière requête";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BtnSearchRoute);
            this.groupBox2.Controls.Add(this.TxtEndGeo);
            this.groupBox2.Controls.Add(this.TxtEndAddress);
            this.groupBox2.Controls.Add(this.TxtStartGeo);
            this.groupBox2.Controls.Add(this.DtgRoute);
            this.groupBox2.Controls.Add(this.TxtStartAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(573, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 409);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calcul d\'itinéraire";
            // 
            // BtnSearchRoute
            // 
            this.BtnSearchRoute.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnSearchRoute.Location = new System.Drawing.Point(578, 24);
            this.BtnSearchRoute.Name = "BtnSearchRoute";
            this.BtnSearchRoute.Size = new System.Drawing.Size(75, 52);
            this.BtnSearchRoute.TabIndex = 1;
            this.BtnSearchRoute.Text = "Je pars !";
            this.BtnSearchRoute.UseVisualStyleBackColor = false;
            this.BtnSearchRoute.Click += new System.EventHandler(this.BtnSearchRoute_ClickAsync);
            // 
            // TxtEndGeo
            // 
            this.TxtEndGeo.Enabled = false;
            this.TxtEndGeo.Location = new System.Drawing.Point(435, 54);
            this.TxtEndGeo.Name = "TxtEndGeo";
            this.TxtEndGeo.Size = new System.Drawing.Size(133, 22);
            this.TxtEndGeo.TabIndex = 0;
            // 
            // TxtEndAddress
            // 
            this.TxtEndAddress.Location = new System.Drawing.Point(155, 54);
            this.TxtEndAddress.Name = "TxtEndAddress";
            this.TxtEndAddress.Size = new System.Drawing.Size(218, 22);
            this.TxtEndAddress.TabIndex = 0;
            // 
            // TxtStartGeo
            // 
            this.TxtStartGeo.Enabled = false;
            this.TxtStartGeo.Location = new System.Drawing.Point(435, 24);
            this.TxtStartGeo.Name = "TxtStartGeo";
            this.TxtStartGeo.Size = new System.Drawing.Size(133, 22);
            this.TxtStartGeo.TabIndex = 0;
            // 
            // DtgRoute
            // 
            this.DtgRoute.AllowUserToAddRows = false;
            this.DtgRoute.AllowUserToDeleteRows = false;
            this.DtgRoute.AllowUserToOrderColumns = true;
            this.DtgRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRoute.Location = new System.Drawing.Point(9, 82);
            this.DtgRoute.Name = "DtgRoute";
            this.DtgRoute.ReadOnly = true;
            this.DtgRoute.RowHeadersWidth = 51;
            this.DtgRoute.RowTemplate.Height = 24;
            this.DtgRoute.Size = new System.Drawing.Size(644, 321);
            this.DtgRoute.TabIndex = 0;
            // 
            // TxtStartAddress
            // 
            this.TxtStartAddress.Location = new System.Drawing.Point(155, 24);
            this.TxtStartAddress.Name = "TxtStartAddress";
            this.TxtStartAddress.Size = new System.Drawing.Size(218, 22);
            this.TxtStartAddress.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Adresse de Destination";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "(lat,lng)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(379, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "(lat,lng)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Adresse de Départ";
            // 
            // BtnTestCache
            // 
            this.BtnTestCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTestCache.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnTestCache.Location = new System.Drawing.Point(517, 76);
            this.BtnTestCache.Name = "BtnTestCache";
            this.BtnTestCache.Size = new System.Drawing.Size(136, 23);
            this.BtnTestCache.TabIndex = 2;
            this.BtnTestCache.Text = "Tester le Cache";
            this.BtnTestCache.UseVisualStyleBackColor = false;
            this.BtnTestCache.Click += new System.EventHandler(this.BtnTestCache_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 575);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnOrderByContract);
            this.Controls.Add(this.BtnGetStations);
            this.Controls.Add(this.DtgStations);
            this.MaximumSize = new System.Drawing.Size(1262, 622);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "LetsGoBiking_tc - Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRoute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgStations;
        private System.Windows.Forms.Button BtnGetStations;
        private System.Windows.Forms.Button BtnOrderByContract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTimeLastRequest;
        private System.Windows.Forms.Label LblSizeRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblUrlRequest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSearchRoute;
        private System.Windows.Forms.TextBox TxtEndGeo;
        private System.Windows.Forms.TextBox TxtEndAddress;
        private System.Windows.Forms.TextBox TxtStartGeo;
        private System.Windows.Forms.TextBox TxtStartAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DtgRoute;
        private System.Windows.Forms.Button BtnTestCache;
    }
}

