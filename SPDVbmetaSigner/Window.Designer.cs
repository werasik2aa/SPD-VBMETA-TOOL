namespace SPDVbmetaSigner
{
    partial class Window
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TextLogBox = new System.Windows.Forms.TextBox();
            this.PartsI = new System.Windows.Forms.DataGridView();
            this.Sign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PartNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizelen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClrBTN = new System.Windows.Forms.Button();
            this.SignNowBtn = new System.Windows.Forms.Button();
            this.GPboxOPT = new System.Windows.Forms.GroupBox();
            this.DBG = new System.Windows.Forms.CheckBox();
            this.RSALEN = new System.Windows.Forms.ComboBox();
            this.AndrverBOX = new System.Windows.Forms.ComboBox();
            this.SNboxTXT = new System.Windows.Forms.TextBox();
            this.GpBox = new System.Windows.Forms.GroupBox();
            this.UlB = new System.Windows.Forms.GroupBox();
            this.UlockDevBTN = new System.Windows.Forms.Button();
            this.GenULSignBTN = new System.Windows.Forms.Button();
            this.LockDevBTN = new System.Windows.Forms.Button();
            this.nProgressBar1 = new HuaweiUnlocker.UI.NProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PartsI)).BeginInit();
            this.GPboxOPT.SuspendLayout();
            this.GpBox.SuspendLayout();
            this.UlB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextLogBox
            // 
            this.TextLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(90)))));
            this.TextLogBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TextLogBox.Location = new System.Drawing.Point(6, 19);
            this.TextLogBox.Multiline = true;
            this.TextLogBox.Name = "TextLogBox";
            this.TextLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextLogBox.Size = new System.Drawing.Size(335, 353);
            this.TextLogBox.TabIndex = 0;
            // 
            // PartsI
            // 
            this.PartsI.AllowUserToAddRows = false;
            this.PartsI.AllowUserToOrderColumns = true;
            this.PartsI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartsI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.PartsI.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(90)))));
            this.PartsI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PartsI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartsI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sign,
            this.PartNam,
            this.sizelen});
            this.PartsI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.PartsI.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(90)))));
            this.PartsI.Location = new System.Drawing.Point(347, 19);
            this.PartsI.MultiSelect = false;
            this.PartsI.Name = "PartsI";
            this.PartsI.RowHeadersVisible = false;
            this.PartsI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PartsI.Size = new System.Drawing.Size(426, 353);
            this.PartsI.TabIndex = 35;
            // 
            // Sign
            // 
            this.Sign.HeaderText = "Custom";
            this.Sign.Name = "Sign";
            // 
            // PartNam
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.PartNam.DefaultCellStyle = dataGridViewCellStyle3;
            this.PartNam.HeaderText = "Partition";
            this.PartNam.Name = "PartNam";
            this.PartNam.ReadOnly = true;
            // 
            // sizelen
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.sizelen.DefaultCellStyle = dataGridViewCellStyle4;
            this.sizelen.HeaderText = "Length";
            this.sizelen.Name = "sizelen";
            // 
            // ClrBTN
            // 
            this.ClrBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.ClrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClrBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClrBTN.ForeColor = System.Drawing.Color.Crimson;
            this.ClrBTN.Location = new System.Drawing.Point(568, 462);
            this.ClrBTN.Margin = new System.Windows.Forms.Padding(2);
            this.ClrBTN.Name = "ClrBTN";
            this.ClrBTN.Size = new System.Drawing.Size(216, 28);
            this.ClrBTN.TabIndex = 37;
            this.ClrBTN.Text = "Clear";
            this.ClrBTN.UseVisualStyleBackColor = false;
            this.ClrBTN.Click += new System.EventHandler(this.ClrBTN_Click);
            // 
            // SignNowBtn
            // 
            this.SignNowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.SignNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignNowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignNowBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SignNowBtn.Location = new System.Drawing.Point(351, 462);
            this.SignNowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SignNowBtn.Name = "SignNowBtn";
            this.SignNowBtn.Size = new System.Drawing.Size(213, 28);
            this.SignNowBtn.TabIndex = 38;
            this.SignNowBtn.Text = "Extract VBMETA";
            this.SignNowBtn.UseVisualStyleBackColor = false;
            this.SignNowBtn.Click += new System.EventHandler(this.SignNowBtn_Click);
            // 
            // GPboxOPT
            // 
            this.GPboxOPT.Controls.Add(this.DBG);
            this.GPboxOPT.Controls.Add(this.RSALEN);
            this.GPboxOPT.Controls.Add(this.AndrverBOX);
            this.GPboxOPT.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.GPboxOPT.Location = new System.Drawing.Point(5, 3);
            this.GPboxOPT.Name = "GPboxOPT";
            this.GPboxOPT.Size = new System.Drawing.Size(779, 43);
            this.GPboxOPT.TabIndex = 39;
            this.GPboxOPT.TabStop = false;
            this.GPboxOPT.Text = "Options";
            // 
            // DBG
            // 
            this.DBG.AutoSize = true;
            this.DBG.Location = new System.Drawing.Point(324, 18);
            this.DBG.Name = "DBG";
            this.DBG.Size = new System.Drawing.Size(58, 17);
            this.DBG.TabIndex = 2;
            this.DBG.Text = "Debug";
            this.DBG.UseVisualStyleBackColor = true;
            this.DBG.CheckedChanged += new System.EventHandler(this.DBG_CheckedChanged);
            // 
            // RSALEN
            // 
            this.RSALEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RSALEN.FormattingEnabled = true;
            this.RSALEN.Location = new System.Drawing.Point(178, 16);
            this.RSALEN.Name = "RSALEN";
            this.RSALEN.Size = new System.Drawing.Size(140, 21);
            this.RSALEN.TabIndex = 1;
            // 
            // AndrverBOX
            // 
            this.AndrverBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AndrverBOX.FormattingEnabled = true;
            this.AndrverBOX.Location = new System.Drawing.Point(6, 16);
            this.AndrverBOX.Name = "AndrverBOX";
            this.AndrverBOX.Size = new System.Drawing.Size(166, 21);
            this.AndrverBOX.TabIndex = 0;
            // 
            // SNboxTXT
            // 
            this.SNboxTXT.Location = new System.Drawing.Point(6, 19);
            this.SNboxTXT.Name = "SNboxTXT";
            this.SNboxTXT.Size = new System.Drawing.Size(324, 20);
            this.SNboxTXT.TabIndex = 41;
            this.SNboxTXT.Text = "YOUR_SN_HERE";
            this.SNboxTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GpBox
            // 
            this.GpBox.Controls.Add(this.TextLogBox);
            this.GpBox.Controls.Add(this.PartsI);
            this.GpBox.ForeColor = System.Drawing.SystemColors.Window;
            this.GpBox.Location = new System.Drawing.Point(5, 52);
            this.GpBox.Name = "GpBox";
            this.GpBox.Size = new System.Drawing.Size(779, 380);
            this.GpBox.TabIndex = 42;
            this.GpBox.TabStop = false;
            this.GpBox.Text = "VBMETA";
            // 
            // UlB
            // 
            this.UlB.Controls.Add(this.SNboxTXT);
            this.UlB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.UlB.Location = new System.Drawing.Point(5, 438);
            this.UlB.Name = "UlB";
            this.UlB.Size = new System.Drawing.Size(341, 52);
            this.UlB.TabIndex = 43;
            this.UlB.TabStop = false;
            this.UlB.Text = "UnlockCodeGen";
            // 
            // UlockDevBTN
            // 
            this.UlockDevBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.UlockDevBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UlockDevBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UlockDevBTN.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.UlockDevBTN.Location = new System.Drawing.Point(351, 496);
            this.UlockDevBTN.Margin = new System.Windows.Forms.Padding(2);
            this.UlockDevBTN.Name = "UlockDevBTN";
            this.UlockDevBTN.Size = new System.Drawing.Size(213, 28);
            this.UlockDevBTN.TabIndex = 41;
            this.UlockDevBTN.Text = "Unlock Device [FASTBOOT]";
            this.UlockDevBTN.UseVisualStyleBackColor = false;
            this.UlockDevBTN.Click += new System.EventHandler(this.UlockDevBTN_Click);
            // 
            // GenULSignBTN
            // 
            this.GenULSignBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.GenULSignBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenULSignBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenULSignBTN.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.GenULSignBTN.Location = new System.Drawing.Point(5, 495);
            this.GenULSignBTN.Margin = new System.Windows.Forms.Padding(2);
            this.GenULSignBTN.Name = "GenULSignBTN";
            this.GenULSignBTN.Size = new System.Drawing.Size(341, 28);
            this.GenULSignBTN.TabIndex = 44;
            this.GenULSignBTN.Text = "Generate Signature.bin for Unlock";
            this.GenULSignBTN.UseVisualStyleBackColor = false;
            this.GenULSignBTN.Click += new System.EventHandler(this.GenULSignBTN_Click);
            // 
            // LockDevBTN
            // 
            this.LockDevBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.LockDevBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LockDevBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LockDevBTN.ForeColor = System.Drawing.Color.Crimson;
            this.LockDevBTN.Location = new System.Drawing.Point(568, 496);
            this.LockDevBTN.Margin = new System.Windows.Forms.Padding(2);
            this.LockDevBTN.Name = "LockDevBTN";
            this.LockDevBTN.Size = new System.Drawing.Size(216, 28);
            this.LockDevBTN.TabIndex = 45;
            this.LockDevBTN.Text = "Lock Device [FASTBOOT]";
            this.LockDevBTN.UseVisualStyleBackColor = false;
            this.LockDevBTN.Click += new System.EventHandler(this.LockDevBTN_Click);
            // 
            // nProgressBar1
            // 
            this.nProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.nProgressBar1.BackColorProgressLeft = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.nProgressBar1.BackColorProgressRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.nProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.nProgressBar1.Location = new System.Drawing.Point(351, 438);
            this.nProgressBar1.Name = "nProgressBar1";
            this.nProgressBar1.Size = new System.Drawing.Size(433, 20);
            this.nProgressBar1.Step = 10;
            this.nProgressBar1.TabIndex = 36;
            this.nProgressBar1.Text = "Text";
            this.nProgressBar1.Value = 0;
            this.nProgressBar1.ValueMaximum = 100;
            this.nProgressBar1.ValueMinimum = 0;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(788, 528);
            this.Controls.Add(this.LockDevBTN);
            this.Controls.Add(this.GenULSignBTN);
            this.Controls.Add(this.nProgressBar1);
            this.Controls.Add(this.UlockDevBTN);
            this.Controls.Add(this.GpBox);
            this.Controls.Add(this.ClrBTN);
            this.Controls.Add(this.UlB);
            this.Controls.Add(this.SignNowBtn);
            this.Controls.Add(this.GPboxOPT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.Text = "SPD Sign TOOL";
            ((System.ComponentModel.ISupportInitialize)(this.PartsI)).EndInit();
            this.GPboxOPT.ResumeLayout(false);
            this.GPboxOPT.PerformLayout();
            this.GpBox.ResumeLayout(false);
            this.GpBox.PerformLayout();
            this.UlB.ResumeLayout(false);
            this.UlB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextLogBox;
        private HuaweiUnlocker.UI.NProgressBar nProgressBar1;
        private System.Windows.Forms.Button ClrBTN;
        private System.Windows.Forms.Button SignNowBtn;
        private System.Windows.Forms.DataGridView PartsI;
        private System.Windows.Forms.GroupBox GPboxOPT;
        private System.Windows.Forms.ComboBox RSALEN;
        private System.Windows.Forms.ComboBox AndrverBOX;
        private System.Windows.Forms.TextBox SNboxTXT;
        private System.Windows.Forms.GroupBox GpBox;
        private System.Windows.Forms.GroupBox UlB;
        private System.Windows.Forms.Button UlockDevBTN;
        private System.Windows.Forms.Button GenULSignBTN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizelen;
        private System.Windows.Forms.Button LockDevBTN;
        private System.Windows.Forms.CheckBox DBG;
    }
}

