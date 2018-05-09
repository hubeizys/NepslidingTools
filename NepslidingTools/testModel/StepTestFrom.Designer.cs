using DevExpress.XtraCharts;

namespace NepslidingTools.testModel
{
    partial class StepTestFrom
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            Series series1 = new DevExpress.XtraCharts.Series();
            LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.lj_lab = new DevComponents.DotNetBar.LabelX();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3d = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtkw = new System.Windows.Forms.TextBox();
            this.textcl = new System.Windows.Forms.TextBox();
            this.combjg = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.nearNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LJH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xuhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OkOrNg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toptime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_st = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_canselect = new System.Windows.Forms.Label();
            this.cbb_canselect = new System.Windows.Forms.ComboBox();
            this.lab_defportname = new System.Windows.Forms.Label();
            this.lab_defport = new System.Windows.Forms.Label();
            this.lble = new System.Windows.Forms.Label();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbox_gcxia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgc = new System.Windows.Forms.TextBox();
            this.txtll = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_portst = new System.Windows.Forms.Timer(this.components);
            this.timer_tostep = new System.Windows.Forms.Timer(this.components);
            this.timer_shine = new System.Windows.Forms.Timer(this.components);
            this.timer_ref = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lj_lab
            // 
            this.lj_lab.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lj_lab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lj_lab.ForeColor = System.Drawing.Color.Black;
            this.lj_lab.Location = new System.Drawing.Point(28, 86);
            this.lj_lab.Name = "lj_lab";
            this.lj_lab.Size = new System.Drawing.Size(37, 23);
            this.lj_lab.TabIndex = 0;
            this.lj_lab.Text = "零件:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(28, 115);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3d
            // 
            this.panel3d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3d.ForeColor = System.Drawing.Color.Black;
            this.panel3d.Location = new System.Drawing.Point(340, 3);
            this.panel3d.Name = "panel3d";
            this.panel3d.Size = new System.Drawing.Size(339, 239);
            this.panel3d.TabIndex = 2;
            this.panel3d.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3d_Paint);
            this.panel3d.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3d_MouseDown);
            this.panel3d.MouseEnter += new System.EventHandler(this.panel3d_MouseEnter);
            this.panel3d.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3d_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.txtkw);
            this.panel2.Controls.Add(this.textcl);
            this.panel2.Controls.Add(this.combjg);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.labelX4);
            this.panel2.Controls.Add(this.labelX3);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(685, 3);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(438, 279);
            this.panel2.TabIndex = 3;
            // 
            // txtkw
            // 
            this.txtkw.BackColor = System.Drawing.Color.White;
            this.txtkw.ForeColor = System.Drawing.Color.Black;
            this.txtkw.Location = new System.Drawing.Point(66, 236);
            this.txtkw.Name = "txtkw";
            this.txtkw.Size = new System.Drawing.Size(163, 22);
            this.txtkw.TabIndex = 8;
            // 
            // textcl
            // 
            this.textcl.BackColor = System.Drawing.Color.White;
            this.textcl.ForeColor = System.Drawing.Color.Black;
            this.textcl.Location = new System.Drawing.Point(302, 238);
            this.textcl.Name = "textcl";
            this.textcl.Size = new System.Drawing.Size(100, 22);
            this.textcl.TabIndex = 7;
            this.textcl.TextChanged += new System.EventHandler(this.textcl_TextChanged);
            // 
            // combjg
            // 
            this.combjg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.combjg.ForeColor = System.Drawing.Color.Black;
            this.combjg.FormattingEnabled = true;
            this.combjg.Location = new System.Drawing.Point(168, 198);
            this.combjg.Name = "combjg";
            this.combjg.Size = new System.Drawing.Size(121, 21);
            this.combjg.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(327, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(103, 200);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(70, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "结果：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(11, 200);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(103, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "工具: 卡尺";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(237, 236);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(70, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "测量值为： ";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(10, 236);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "所在工位: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::NepslidingTools.Properties.Resources._4318727ea8c1806a17c555929d2dea8e;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nearNo,
            this.LJH,
            this.xuhao,
            this.TestTime,
            this.step1,
            this.step2,
            this.step3,
            this.step4,
            this.step5,
            this.OkOrNg});
            this.tableLayoutPanel1.SetColumnSpan(this.dgv1, 3);
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 448);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1120, 291);
            this.dgv1.TabIndex = 4;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            // 
            // nearNo
            // 
            this.nearNo.DataPropertyName = "measureb";
            this.nearNo.HeaderText = "测量编号";
            this.nearNo.Name = "nearNo";
            this.nearNo.ReadOnly = true;
            this.nearNo.Visible = false;
            // 
            // LJH
            // 
            this.LJH.DataPropertyName = "PN";
            this.LJH.HeaderText = "零件号";
            this.LJH.Name = "LJH";
            this.LJH.ReadOnly = true;
            this.LJH.Visible = false;
            // 
            // xuhao
            // 
            this.xuhao.DataPropertyName = "id";
            this.xuhao.HeaderText = "序号";
            this.xuhao.Name = "xuhao";
            this.xuhao.ReadOnly = true;
            this.xuhao.Visible = false;
            // 
            // TestTime
            // 
            this.TestTime.DataPropertyName = "time";
            this.TestTime.HeaderText = "测试时间";
            this.TestTime.Name = "TestTime";
            this.TestTime.ReadOnly = true;
            this.TestTime.Visible = false;
            // 
            // step1
            // 
            this.step1.DataPropertyName = "step1";
            this.step1.HeaderText = "步骤1";
            this.step1.Name = "step1";
            this.step1.ReadOnly = true;
            this.step1.Visible = false;
            // 
            // step2
            // 
            this.step2.DataPropertyName = "step2";
            this.step2.HeaderText = "步骤2";
            this.step2.Name = "step2";
            this.step2.ReadOnly = true;
            this.step2.Visible = false;
            // 
            // step3
            // 
            this.step3.DataPropertyName = "step3";
            this.step3.HeaderText = "步骤3";
            this.step3.Name = "step3";
            this.step3.ReadOnly = true;
            this.step3.Visible = false;
            // 
            // step4
            // 
            this.step4.DataPropertyName = "step4";
            this.step4.HeaderText = "步骤4";
            this.step4.Name = "step4";
            this.step4.ReadOnly = true;
            this.step4.Visible = false;
            // 
            // step5
            // 
            this.step5.DataPropertyName = "step5";
            this.step5.HeaderText = "步骤5";
            this.step5.Name = "step5";
            this.step5.ReadOnly = true;
            this.step5.Visible = false;
            // 
            // OkOrNg
            // 
            this.OkOrNg.DataPropertyName = "OKorNG";
            this.OkOrNg.HeaderText = "OkOrNg";
            this.OkOrNg.Name = "OkOrNg";
            this.OkOrNg.ReadOnly = true;
            this.OkOrNg.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.buttonX4);
            this.groupBox1.Controls.Add(this.buttonX3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(28, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(102, 70);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(102, 33);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "完成";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(10, 68);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 3;
            this.buttonX4.Text = "重测";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(10, 33);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 2;
            this.buttonX3.Text = "跳过";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toptime
            // 
            this.toptime.Tick += new System.EventHandler(this.toptime_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.72824F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.34281F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3d, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.97011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.91105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.18329F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1126, 742);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.tableLayoutPanel1_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lab_st);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lab_canselect);
            this.panel1.Controls.Add(this.cbb_canselect);
            this.panel1.Controls.Add(this.lab_defportname);
            this.panel1.Controls.Add(this.lab_defport);
            this.panel1.Controls.Add(this.lble);
            this.panel1.Controls.Add(this.lj_lab);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(331, 279);
            this.panel1.TabIndex = 7;
            // 
            // lab_st
            // 
            this.lab_st.AutoSize = true;
            this.lab_st.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lab_st.ForeColor = System.Drawing.Color.OrangeRed;
            this.lab_st.Location = new System.Drawing.Point(122, 34);
            this.lab_st.Name = "lab_st";
            this.lab_st.Size = new System.Drawing.Size(43, 13);
            this.lab_st.TabIndex = 12;
            this.lab_st.Text = "未连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "工具状态";
            // 
            // lab_canselect
            // 
            this.lab_canselect.AutoSize = true;
            this.lab_canselect.ForeColor = System.Drawing.Color.ForestGreen;
            this.lab_canselect.Location = new System.Drawing.Point(27, 56);
            this.lab_canselect.Name = "lab_canselect";
            this.lab_canselect.Size = new System.Drawing.Size(55, 13);
            this.lab_canselect.TabIndex = 10;
            this.lab_canselect.Text = "可选工具";
            // 
            // cbb_canselect
            // 
            this.cbb_canselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_canselect.FormattingEnabled = true;
            this.cbb_canselect.Location = new System.Drawing.Point(120, 53);
            this.cbb_canselect.Name = "cbb_canselect";
            this.cbb_canselect.Size = new System.Drawing.Size(121, 21);
            this.cbb_canselect.TabIndex = 9;
            this.cbb_canselect.SelectedIndexChanged += new System.EventHandler(this.cbb_canselect_SelectedIndexChanged);
            // 
            // lab_defportname
            // 
            this.lab_defportname.AutoSize = true;
            this.lab_defportname.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lab_defportname.ForeColor = System.Drawing.Color.OrangeRed;
            this.lab_defportname.Location = new System.Drawing.Point(122, 13);
            this.lab_defportname.Name = "lab_defportname";
            this.lab_defportname.Size = new System.Drawing.Size(57, 13);
            this.lab_defportname.TabIndex = 8;
            this.lab_defportname.Text = "portname";
            // 
            // lab_defport
            // 
            this.lab_defport.AutoSize = true;
            this.lab_defport.ForeColor = System.Drawing.Color.ForestGreen;
            this.lab_defport.Location = new System.Drawing.Point(27, 13);
            this.lab_defport.Name = "lab_defport";
            this.lab_defport.Size = new System.Drawing.Size(79, 13);
            this.lab_defport.TabIndex = 7;
            this.lab_defport.Text = "默认使用工具";
            // 
            // lble
            // 
            this.lble.AutoSize = true;
            this.lble.Location = new System.Drawing.Point(65, 91);
            this.lble.Name = "lble";
            this.lble.Size = new System.Drawing.Size(0, 13);
            this.lble.TabIndex = 6;
            // 
            // chartControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chartControl1, 3);
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(3, 288);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "测量结果波动";
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1120, 154);
            this.chartControl1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtbox_gcxia);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtgc);
            this.panel3.Controls.Add(this.txtll);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(340, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 34);
            this.panel3.TabIndex = 9;
            // 
            // txtbox_gcxia
            // 
            this.txtbox_gcxia.BackColor = System.Drawing.Color.White;
            this.txtbox_gcxia.ForeColor = System.Drawing.Color.Black;
            this.txtbox_gcxia.Location = new System.Drawing.Point(263, 6);
            this.txtbox_gcxia.Name = "txtbox_gcxia";
            this.txtbox_gcxia.Size = new System.Drawing.Size(45, 22);
            this.txtbox_gcxia.TabIndex = 12;
            this.txtbox_gcxia.Text = "0.15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(208, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "下公差： ";
            // 
            // txtgc
            // 
            this.txtgc.BackColor = System.Drawing.Color.White;
            this.txtgc.ForeColor = System.Drawing.Color.Black;
            this.txtgc.Location = new System.Drawing.Point(157, 6);
            this.txtgc.Name = "txtgc";
            this.txtgc.Size = new System.Drawing.Size(45, 22);
            this.txtgc.TabIndex = 10;
            this.txtgc.Text = "0.15";
            // 
            // txtll
            // 
            this.txtll.BackColor = System.Drawing.Color.White;
            this.txtll.ForeColor = System.Drawing.Color.Black;
            this.txtll.Location = new System.Drawing.Point(57, 7);
            this.txtll.Name = "txtll";
            this.txtll.Size = new System.Drawing.Size(39, 22);
            this.txtll.TabIndex = 9;
            this.txtll.Text = "13.15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(102, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "上公差： ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "理论值： ";
            // 
            // timer_portst
            // 
            this.timer_portst.Enabled = true;
            this.timer_portst.Interval = 3000;
            this.timer_portst.Tick += new System.EventHandler(this.timer_portst_Tick);
            // 
            // timer_tostep
            // 
            this.timer_tostep.Interval = 1000;
            this.timer_tostep.Tick += new System.EventHandler(this.timer_tostep_Tick);
            // 
            // timer_shine
            // 
            this.timer_shine.Tick += new System.EventHandler(this.timer_shine_Tick);
            // 
            // timer_ref
            // 
            this.timer_ref.Tick += new System.EventHandler(this.timer_ref_Tick);
            // 
            // StepTestFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StepTestFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试界面";
            this.Deactivate += new System.EventHandler(this.StepTestFrom_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StepTestFrom_FormClosed);
            this.Load += new System.EventHandler(this.StepTestFrom_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.StepTestFrom_Scroll);
            this.MouseEnter += new System.EventHandler(this.StepTestFrom_MouseEnter);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lj_lab;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel3d;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Timer toptime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtkw;
        private System.Windows.Forms.TextBox textcl;
        private System.Windows.Forms.ComboBox combjg;
        private System.Windows.Forms.TextBox txtgc;
        private System.Windows.Forms.TextBox txtll;
        private System.Windows.Forms.Label lble;
        private System.Windows.Forms.DataGridViewTextBoxColumn nearNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LJH;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn step1;
        private System.Windows.Forms.DataGridViewTextBoxColumn step2;
        private System.Windows.Forms.DataGridViewTextBoxColumn step3;
        private System.Windows.Forms.DataGridViewTextBoxColumn step4;
        private System.Windows.Forms.DataGridViewTextBoxColumn step5;
        private System.Windows.Forms.DataGridViewTextBoxColumn OkOrNg;
        private System.Windows.Forms.Label lab_defport;
        private System.Windows.Forms.Label lab_defportname;
        private System.Windows.Forms.ComboBox cbb_canselect;
        private System.Windows.Forms.Label lab_canselect;
        private System.Windows.Forms.Label lab_st;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_portst;
        private System.Windows.Forms.TextBox txtbox_gcxia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer_tostep;
        private System.Windows.Forms.Timer timer_shine;
        private System.Windows.Forms.Timer timer_ref;
    }
}