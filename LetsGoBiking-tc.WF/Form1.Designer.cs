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
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).BeginInit();
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
            this.DtgStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgStations.Location = new System.Drawing.Point(12, 47);
            this.DtgStations.Name = "DtgStations";
            this.DtgStations.ReadOnly = true;
            this.DtgStations.RowHeadersWidth = 51;
            this.DtgStations.RowTemplate.Height = 29;
            this.DtgStations.Size = new System.Drawing.Size(776, 391);
            this.DtgStations.TabIndex = 1;
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(463, 12);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.PlaceholderText = "Ville";
            this.TxtCity.Size = new System.Drawing.Size(125, 27);
            this.TxtCity.TabIndex = 2;
            // 
            // TxtContractName
            // 
            this.TxtContractName.Location = new System.Drawing.Point(594, 12);
            this.TxtContractName.Name = "TxtContractName";
            this.TxtContractName.PlaceholderText = "Contract Name";
            this.TxtContractName.Size = new System.Drawing.Size(125, 27);
            this.TxtContractName.TabIndex = 3;
            // 
            // BtnFindStationsByCityAndContractName
            // 
            this.BtnFindStationsByCityAndContractName.Location = new System.Drawing.Point(725, 12);
            this.BtnFindStationsByCityAndContractName.Name = "BtnFindStationsByCityAndContractName";
            this.BtnFindStationsByCityAndContractName.Size = new System.Drawing.Size(63, 29);
            this.BtnFindStationsByCityAndContractName.TabIndex = 4;
            this.BtnFindStationsByCityAndContractName.Text = "Filtrer";
            this.BtnFindStationsByCityAndContractName.UseVisualStyleBackColor = true;
            this.BtnFindStationsByCityAndContractName.Click += new System.EventHandler(this.BtnFindStationsByCityAndContractName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnFindStationsByCityAndContractName);
            this.Controls.Add(this.TxtContractName);
            this.Controls.Add(this.TxtCity);
            this.Controls.Add(this.DtgStations);
            this.Controls.Add(this.BtnGetAllStations);
            this.Name = "Form1";
            this.Text = "Mon Super Programme";
            ((System.ComponentModel.ISupportInitialize)(this.DtgStations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BtnGetAllStations;
        private DataGridView DtgStations;
        private TextBox TxtCity;
        private TextBox TxtContractName;
        private Button BtnFindStationsByCityAndContractName;
    }
}