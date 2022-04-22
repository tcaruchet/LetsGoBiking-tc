namespace LetsGoBiking_tc.WF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnGetAllStations = new System.Windows.Forms.Button();
            this.DtgStations = new System.Windows.Forms.DataGridView();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.TxtContractName = new System.Windows.Forms.TextBox();
            this.BtnFindStationsByCityAndContractName = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblUrl = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetAllStations
            // 
            this.BtnGetAllStations.Location = new System.Drawing.Point(12, 12);
            this.BtnGetAllStations.Name = "BtnGetAllStations";
            this.BtnGetAllStations.Size = new System.Drawing.Size(119, 29);
            this.BtnGetAllStations.TabIndex = 0;
            this.BtnGetAllStations.Text = "GetAllStations";
            this.BtnGetAllStations.UseVisualStyleBackColor = true;
            this.BtnGetAllStations.Click += new System.EventHandler(this.BtnGetAllStations_Click);
            // 
            // DtgStations
            // 
            this.DtgStations.AllowUserToAddRows = false;
            this.DtgStations.AllowUserToDeleteRows = false;
            this.DtgStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgStations.Location = new System.Drawing.Point(12, 47);
            this.DtgStations.Name = "DtgStations";
            this.DtgStations.ReadOnly = true;
            this.DtgStations.RowHeadersWidth = 51;
            this.DtgStations.RowTemplate.Height = 29;
            this.DtgStations.Size = new System.Drawing.Size(1177, 391);
            this.DtgStations.TabIndex = 1;
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(864, 12);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.PlaceholderText = "Ville";
            this.TxtCity.Size = new System.Drawing.Size(125, 27);
            this.TxtCity.TabIndex = 2;
            // 
            // TxtContractName
            // 
            this.TxtContractName.Location = new System.Drawing.Point(995, 12);
            this.TxtContractName.Name = "TxtContractName";
            this.TxtContractName.PlaceholderText = "Contract Name";
            this.TxtContractName.Size = new System.Drawing.Size(125, 27);
            this.TxtContractName.TabIndex = 3;
            // 
            // BtnFindStationsByCityAndContractName
            // 
            this.BtnFindStationsByCityAndContractName.Location = new System.Drawing.Point(1126, 12);
            this.BtnFindStationsByCityAndContractName.Name = "BtnFindStationsByCityAndContractName";
            this.BtnFindStationsByCityAndContractName.Size = new System.Drawing.Size(63, 29);
            this.BtnFindStationsByCityAndContractName.TabIndex = 4;
            this.BtnFindStationsByCityAndContractName.Text = "Filtrer";
            this.BtnFindStationsByCityAndContractName.UseVisualStyleBackColor = true;
            this.BtnFindStationsByCityAndContractName.Click += new System.EventHandler(this.BtnFindStationsByCityAndContractName_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LblSize);
            this.groupBox1.Controls.Add(this.LblTime);
            this.groupBox1.Controls.Add(this.LblUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1177, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistiques";
            // 
            // LblUrl
            // 
            this.LblUrl.AutoSize = true;
            this.LblUrl.Location = new System.Drawing.Point(14, 33);
            this.LblUrl.Name = "LblUrl";
            this.LblUrl.Size = new System.Drawing.Size(42, 20);
            this.LblUrl.TabIndex = 0;
            this.LblUrl.Text = "URL :";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Location = new System.Drawing.Point(14, 62);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(90, 20);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "Temps mis : ";
            // 
            // LblSize
            // 
            this.LblSize.AutoSize = true;
            this.LblSize.Location = new System.Drawing.Point(14, 91);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(54, 20);
            this.LblSize.TabIndex = 2;
            this.LblSize.Text = "Taille : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnFindStationsByCityAndContractName);
            this.Controls.Add(this.TxtContractName);
            this.Controls.Add(this.TxtCity);
            this.Controls.Add(this.DtgStations);
            this.Controls.Add(this.BtnGetAllStations);
            this.Name = "Form1";
            this.Text = "Mon Super Programme";
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnGetAllStations;
        private DataGridView DtgStations;
        private TextBox TxtCity;
        private TextBox TxtContractName;
        private Button BtnFindStationsByCityAndContractName;
        private GroupBox groupBox1;
        private Label LblSize;
        private Label LblTime;
        private Label LblUrl;
    }
}