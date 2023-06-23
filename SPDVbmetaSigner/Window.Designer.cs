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
            this.TextLogBox = new System.Windows.Forms.TextBox();
            this.PartsI = new System.Windows.Forms.DataGridView();
            this.Sign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PartNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizelen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClrBTN = new System.Windows.Forms.Button();
            this.SignNowBtn = new System.Windows.Forms.Button();
            this.GPboxOPT = new System.Windows.Forms.GroupBox();
            this.RSALEN = new System.Windows.Forms.ComboBox();
            this.AndrverBOX = new System.Windows.Forms.ComboBox();
            this.nProgressBar1 = new HuaweiUnlocker.UI.NProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PartsI)).BeginInit();
            this.GPboxOPT.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextLogBox
            // 
            this.TextLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(67)))), ((int)(((byte)(90)))));
            this.TextLogBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TextLogBox.Location = new System.Drawing.Point(12, 52);
            this.TextLogBox.Multiline = true;
            this.TextLogBox.Name = "TextLogBox";
            this.TextLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextLogBox.Size = new System.Drawing.Size(324, 353);
            this.TextLogBox.TabIndex = 0;
            // 
            // PartsI
            // 
            this.PartsI.AllowUserToAddRows = false;
            this.PartsI.AllowUserToOrderColumns = true;
            this.PartsI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartsI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.PartsI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PartsI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartsI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sign,
            this.PartNam,
            this.sizelen});
            this.PartsI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.PartsI.Location = new System.Drawing.Point(342, 12);
            this.PartsI.MultiSelect = false;
            this.PartsI.Name = "PartsI";
            this.PartsI.RowHeadersVisible = false;
            this.PartsI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PartsI.Size = new System.Drawing.Size(442, 367);
            this.PartsI.TabIndex = 35;
            // 
            // Sign
            // 
            this.Sign.HeaderText = "Custom";
            this.Sign.Name = "Sign";
            // 
            // PartNam
            // 
            this.PartNam.HeaderText = "Partition";
            this.PartNam.Name = "PartNam";
            this.PartNam.ReadOnly = true;
            // 
            // sizelen
            // 
            this.sizelen.HeaderText = "Length";
            this.sizelen.Name = "sizelen";
            // 
            // ClrBTN
            // 
            this.ClrBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.ClrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClrBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClrBTN.ForeColor = System.Drawing.Color.Crimson;
            this.ClrBTN.Location = new System.Drawing.Point(559, 412);
            this.ClrBTN.Margin = new System.Windows.Forms.Padding(2);
            this.ClrBTN.Name = "ClrBTN";
            this.ClrBTN.Size = new System.Drawing.Size(225, 28);
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
            this.SignNowBtn.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.SignNowBtn.Location = new System.Drawing.Point(12, 412);
            this.SignNowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SignNowBtn.Name = "SignNowBtn";
            this.SignNowBtn.Size = new System.Drawing.Size(543, 28);
            this.SignNowBtn.TabIndex = 38;
            this.SignNowBtn.Text = "Extract Headers";
            this.SignNowBtn.UseVisualStyleBackColor = false;
            this.SignNowBtn.Click += new System.EventHandler(this.SignNowBtn_Click);
            // 
            // GPboxOPT
            // 
            this.GPboxOPT.Controls.Add(this.RSALEN);
            this.GPboxOPT.Controls.Add(this.AndrverBOX);
            this.GPboxOPT.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.GPboxOPT.Location = new System.Drawing.Point(12, 3);
            this.GPboxOPT.Name = "GPboxOPT";
            this.GPboxOPT.Size = new System.Drawing.Size(324, 43);
            this.GPboxOPT.TabIndex = 39;
            this.GPboxOPT.TabStop = false;
            this.GPboxOPT.Text = "Options";
            // 
            // RSALEN
            // 
            this.RSALEN.FormattingEnabled = true;
            this.RSALEN.Location = new System.Drawing.Point(178, 16);
            this.RSALEN.Name = "RSALEN";
            this.RSALEN.Size = new System.Drawing.Size(140, 21);
            this.RSALEN.TabIndex = 1;
            this.RSALEN.Text = "RSA_4096";
            // 
            // AndrverBOX
            // 
            this.AndrverBOX.FormattingEnabled = true;
            this.AndrverBOX.Location = new System.Drawing.Point(6, 16);
            this.AndrverBOX.Name = "AndrverBOX";
            this.AndrverBOX.Size = new System.Drawing.Size(166, 21);
            this.AndrverBOX.TabIndex = 0;
            this.AndrverBOX.Text = "Android_8";
            // 
            // nProgressBar1
            // 
            this.nProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.nProgressBar1.BackColorProgressLeft = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.nProgressBar1.BackColorProgressRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.nProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.nProgressBar1.Location = new System.Drawing.Point(342, 385);
            this.nProgressBar1.Name = "nProgressBar1";
            this.nProgressBar1.Size = new System.Drawing.Size(441, 20);
            this.nProgressBar1.Step = 10;
            this.nProgressBar1.TabIndex = 36;
            this.nProgressBar1.Text = "nProgressBar1";
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
            this.ClientSize = new System.Drawing.Size(791, 451);
            this.Controls.Add(this.GPboxOPT);
            this.Controls.Add(this.SignNowBtn);
            this.Controls.Add(this.ClrBTN);
            this.Controls.Add(this.nProgressBar1);
            this.Controls.Add(this.PartsI);
            this.Controls.Add(this.TextLogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.Text = "SPD Sign TOOL";
            ((System.ComponentModel.ISupportInitialize)(this.PartsI)).EndInit();
            this.GPboxOPT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizelen;
    }
}

