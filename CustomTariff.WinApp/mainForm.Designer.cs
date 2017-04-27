namespace CustomTariff.WinApp
{
    partial class mainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTariffCode = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCommandText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.cboTariffStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.txtDivisionCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoadCustomsTariff = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNewTariffCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCompanyCode = new System.Windows.Forms.Label();
            this.lblDivisionCode = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTariffCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFullPartName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStatCode = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTariffUnit = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNewStatCode = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNewTariffUnit = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDutyRate = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtNewDutyRate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDescriptionAddon = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 136);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(960, 216);
            this.dataGridView1.TabIndex = 15;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearch.Location = new System.Drawing.Point(780, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTariffCode
            // 
            this.txtTariffCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTariffCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTariffCode.Location = new System.Drawing.Point(125, 93);
            this.txtTariffCode.MaxLength = 35;
            this.txtTariffCode.Name = "txtTariffCode";
            this.txtTariffCode.Size = new System.Drawing.Size(177, 22);
            this.txtTariffCode.TabIndex = 2;
            this.txtTariffCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConditionFilter_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripProgressBar1,
            this.lblCommandText,
            this.toolStripStatusLabel3,
            this.lblTotalRecords});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(984, 25);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 20);
            this.lblStatus.Text = "Status";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblCommandText
            // 
            this.lblCommandText.Font = new System.Drawing.Font("Tahoma", 7.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCommandText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCommandText.Name = "lblCommandText";
            this.lblCommandText.Size = new System.Drawing.Size(695, 20);
            this.lblCommandText.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(38, 20);
            this.toolStripStatusLabel3.Text = "Total ";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = false;
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(90, 20);
            this.lblTotalRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTariffStatus
            // 
            this.cboTariffStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTariffStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTariffStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboTariffStatus.FormattingEnabled = true;
            this.cboTariffStatus.Items.AddRange(new object[] {
            "ALL",
            "ADD",
            "CHANGE",
            "NOT FOUND",
            "NOT CHANGE"});
            this.cboTariffStatus.Location = new System.Drawing.Point(125, 63);
            this.cboTariffStatus.Name = "cboTariffStatus";
            this.cboTariffStatus.Size = new System.Drawing.Size(177, 24);
            this.cboTariffStatus.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Status :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(321, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Company Code :";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCompanyCode.Location = new System.Drawing.Point(432, 64);
            this.txtCompanyCode.MaxLength = 2;
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(100, 22);
            this.txtCompanyCode.TabIndex = 0;
            this.txtCompanyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConditionFilter_KeyDown);
            // 
            // txtDivisionCode
            // 
            this.txtDivisionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDivisionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDivisionCode.Location = new System.Drawing.Point(674, 64);
            this.txtDivisionCode.MaxLength = 2;
            this.txtDivisionCode.Name = "txtDivisionCode";
            this.txtDivisionCode.Size = new System.Drawing.Size(100, 22);
            this.txtDivisionCode.TabIndex = 1;
            this.txtDivisionCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConditionFilter_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(563, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Division Code :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tariff Code :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(321, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescription.Location = new System.Drawing.Point(432, 93);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(342, 22);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConditionFilter_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(16, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(958, 2);
            this.label6.TabIndex = 16;
            // 
            // btnLoadCustomsTariff
            // 
            this.btnLoadCustomsTariff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnLoadCustomsTariff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadCustomsTariff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnLoadCustomsTariff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLoadCustomsTariff.Location = new System.Drawing.Point(16, 12);
            this.btnLoadCustomsTariff.Name = "btnLoadCustomsTariff";
            this.btnLoadCustomsTariff.Size = new System.Drawing.Size(285, 28);
            this.btnLoadCustomsTariff.TabIndex = 12;
            this.btnLoadCustomsTariff.Text = "Load Customs Tariff ...";
            this.btnLoadCustomsTariff.UseVisualStyleBackColor = false;
            this.btnLoadCustomsTariff.Click += new System.EventHandler(this.btnLoadCustomsTariff_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(17, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(958, 2);
            this.label7.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(825, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Export V.2 (XLSX)";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(669, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 28);
            this.button2.TabIndex = 13;
            this.button2.Text = "Export V.1 (XLSX)";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.txtDescriptionAddon);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.txtNewDutyRate);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.lblDutyRate);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtNewTariffUnit);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtNewStatCode);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.lblTariffUnit);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.lblStatCode);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblFullPartName);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblTariffCode);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblDivisionCode);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblCompanyCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtNewTariffCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 175);
            this.panel1.TabIndex = 18;
            // 
            // txtNewTariffCode
            // 
            this.txtNewTariffCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewTariffCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNewTariffCode.Location = new System.Drawing.Point(137, 81);
            this.txtNewTariffCode.MaxLength = 35;
            this.txtNewTariffCode.Name = "txtNewTariffCode";
            this.txtNewTariffCode.Size = new System.Drawing.Size(150, 22);
            this.txtNewTariffCode.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(23, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "NEW : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(23, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Company Code :";
            // 
            // lblCompanyCode
            // 
            this.lblCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCompanyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompanyCode.Location = new System.Drawing.Point(137, 6);
            this.lblCompanyCode.Name = "lblCompanyCode";
            this.lblCompanyCode.Size = new System.Drawing.Size(125, 24);
            this.lblCompanyCode.TabIndex = 10;
            this.lblCompanyCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDivisionCode
            // 
            this.lblDivisionCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivisionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDivisionCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDivisionCode.Location = new System.Drawing.Point(372, 6);
            this.lblDivisionCode.Name = "lblDivisionCode";
            this.lblDivisionCode.Size = new System.Drawing.Size(100, 24);
            this.lblDivisionCode.TabIndex = 12;
            this.lblDivisionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(268, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Division Code :";
            // 
            // lblTariffCode
            // 
            this.lblTariffCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTariffCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTariffCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTariffCode.Location = new System.Drawing.Point(137, 38);
            this.lblTariffCode.Name = "lblTariffCode";
            this.lblTariffCode.Size = new System.Drawing.Size(150, 24);
            this.lblTariffCode.TabIndex = 14;
            this.lblTariffCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(51, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Tariff Code :";
            // 
            // lblFullPartName
            // 
            this.lblFullPartName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullPartName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFullPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFullPartName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFullPartName.Location = new System.Drawing.Point(601, 6);
            this.lblFullPartName.Name = "lblFullPartName";
            this.lblFullPartName.Size = new System.Drawing.Size(340, 24);
            this.lblFullPartName.TabIndex = 16;
            this.lblFullPartName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(493, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "Full PartName : ";
            // 
            // lblStatCode
            // 
            this.lblStatCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStatCode.Location = new System.Drawing.Point(372, 38);
            this.lblStatCode.Name = "lblStatCode";
            this.lblStatCode.Size = new System.Drawing.Size(100, 24);
            this.lblStatCode.TabIndex = 18;
            this.lblStatCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(296, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "StatCode :";
            // 
            // lblTariffUnit
            // 
            this.lblTariffUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTariffUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTariffUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTariffUnit.Location = new System.Drawing.Point(601, 38);
            this.lblTariffUnit.Name = "lblTariffUnit";
            this.lblTariffUnit.Size = new System.Drawing.Size(100, 24);
            this.lblTariffUnit.TabIndex = 20;
            this.lblTariffUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(528, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 16);
            this.label20.TabIndex = 19;
            this.label20.Text = "TariffUnit :";
            // 
            // txtNewStatCode
            // 
            this.txtNewStatCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewStatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNewStatCode.Location = new System.Drawing.Point(372, 81);
            this.txtNewStatCode.MaxLength = 15;
            this.txtNewStatCode.Name = "txtNewStatCode";
            this.txtNewStatCode.Size = new System.Drawing.Size(100, 22);
            this.txtNewStatCode.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(296, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 16);
            this.label21.TabIndex = 22;
            this.label21.Text = "StatCode :";
            // 
            // txtNewTariffUnit
            // 
            this.txtNewTariffUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewTariffUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNewTariffUnit.Location = new System.Drawing.Point(601, 81);
            this.txtNewTariffUnit.MaxLength = 6;
            this.txtNewTariffUnit.Name = "txtNewTariffUnit";
            this.txtNewTariffUnit.Size = new System.Drawing.Size(100, 22);
            this.txtNewTariffUnit.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(528, 84);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 24;
            this.label22.Text = "TariffUnit :";
            // 
            // lblDutyRate
            // 
            this.lblDutyRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDutyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDutyRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDutyRate.Location = new System.Drawing.Point(841, 38);
            this.lblDutyRate.Name = "lblDutyRate";
            this.lblDutyRate.Size = new System.Drawing.Size(100, 24);
            this.lblDutyRate.TabIndex = 26;
            this.lblDutyRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label24.Location = new System.Drawing.Point(765, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 16);
            this.label24.TabIndex = 25;
            this.label24.Text = "DutyRate :";
            // 
            // txtNewDutyRate
            // 
            this.txtNewDutyRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewDutyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNewDutyRate.Location = new System.Drawing.Point(841, 81);
            this.txtNewDutyRate.MaxLength = 10;
            this.txtNewDutyRate.Name = "txtNewDutyRate";
            this.txtNewDutyRate.Size = new System.Drawing.Size(100, 22);
            this.txtNewDutyRate.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label25.Location = new System.Drawing.Point(763, 84);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 16);
            this.label25.TabIndex = 28;
            this.label25.Text = "DutyRate :";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label26.Location = new System.Drawing.Point(69, 72);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(872, 2);
            this.label26.TabIndex = 29;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label27.Location = new System.Drawing.Point(51, 84);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 16);
            this.label27.TabIndex = 30;
            this.label27.Text = "Tariff Code :";
            // 
            // txtDescriptionAddon
            // 
            this.txtDescriptionAddon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescriptionAddon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescriptionAddon.Location = new System.Drawing.Point(137, 109);
            this.txtDescriptionAddon.MaxLength = 512;
            this.txtDescriptionAddon.Name = "txtDescriptionAddon";
            this.txtDescriptionAddon.Size = new System.Drawing.Size(335, 22);
            this.txtDescriptionAddon.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label28.Location = new System.Drawing.Point(49, 112);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(82, 16);
            this.label28.TabIndex = 32;
            this.label28.Text = "Description :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnUpdate.Location = new System.Drawing.Point(137, 137);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(601, 109);
            this.txtRemark.MaxLength = 512;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(340, 22);
            this.txtRemark.TabIndex = 33;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label29.Location = new System.Drawing.Point(528, 112);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 16);
            this.label29.TabIndex = 34;
            this.label29.Text = "Remark :";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLoadCustomsTariff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDivisionCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTariffStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtTariffCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customs Tariff 2017";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTariffCode;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ComboBox cboTariffStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.TextBox txtDivisionCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel lblCommandText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalRecords;
        private System.Windows.Forms.Button btnLoadCustomsTariff;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNewDutyRate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblDutyRate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtNewTariffUnit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtNewStatCode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTariffUnit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblStatCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblFullPartName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTariffCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDivisionCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCompanyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNewTariffCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDescriptionAddon;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtRemark;
    }
}

