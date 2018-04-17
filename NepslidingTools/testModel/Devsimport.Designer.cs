namespace NepslidingTools.testModel
{
    partial class Devsimport
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
            DevExpress.XtraEditors.Controls.RadioGroupItem radioGroupItem1 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            DevExpress.XtraEditors.Controls.RadioGroupItem radioGroupItem2 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            DevExpress.XtraEditors.Controls.RadioGroupItem radioGroupItem3 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.importdev_st = new DevExpress.XtraWizard.WizardControl();
            this.selectdev_wiz = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importdev_st)).BeginInit();
            this.importdev_st.SuspendLayout();
            this.selectdev_wiz.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.completionWizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "iMaginary";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.importdev_st);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 396);
            this.panel1.TabIndex = 0;
            // 
            // importdev_st
            // 
            this.importdev_st.Controls.Add(this.selectdev_wiz);
            this.importdev_st.Controls.Add(this.wizardPage1);
            this.importdev_st.Controls.Add(this.completionWizardPage1);
            this.importdev_st.Controls.Add(this.wizardPage2);
            this.importdev_st.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importdev_st.Location = new System.Drawing.Point(0, 0);
            this.importdev_st.LookAndFeel.UseDefaultLookAndFeel = false;
            this.importdev_st.Name = "importdev_st";
            this.importdev_st.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.selectdev_wiz,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.importdev_st.Size = new System.Drawing.Size(625, 396);
            this.importdev_st.Text = "导入硬件到系统";
            this.importdev_st.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.importdev_st.FinishClick += new System.ComponentModel.CancelEventHandler(this.importdev_st_FinishClick);
            this.importdev_st.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.importdev_st_NextClick);
            // 
            // selectdev_wiz
            // 
            this.selectdev_wiz.Controls.Add(this.groupBox2);
            this.selectdev_wiz.Enabled = true;
            this.selectdev_wiz.Name = "selectdev_wiz";
            this.selectdev_wiz.Size = new System.Drawing.Size(565, 228);
            this.selectdev_wiz.Text = "选择硬件类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioGroup1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 228);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择类型";
            this.groupBox2.CursorChanged += new System.EventHandler(this.groupBox2_CursorChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(3, 18);
            this.radioGroup1.Name = "radioGroup1";
            // 
            // 
            // 
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioGroup1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Appearance.Options.UseForeColor = true;
            radioGroupItem1.Description = "扫描枪";
            radioGroupItem1.Value = null;
            radioGroupItem2.Description = "热敏打印机";
            radioGroupItem2.Value = null;
            radioGroupItem3.Description = "卡尺";
            radioGroupItem3.Value = null;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            radioGroupItem1,
            radioGroupItem2,
            radioGroupItem3});
            this.radioGroup1.Size = new System.Drawing.Size(559, 207);
            this.radioGroup1.TabIndex = 0;
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.groupBox1);
            this.wizardPage1.Enabled = true;
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(565, 228);
            this.wizardPage1.Text = "请选择设备";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "硬件列表";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "com1",
            "com2",
            "com4",
            "com5",
            "com6",
            "com7",
            "com8",
            "com9",
            "com10",
            "com11",
            "com12",
            "com13",
            "com14",
            "com15",
            "com16",
            "com17",
            "com18"});
            this.listBox1.Location = new System.Drawing.Point(3, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(559, 207);
            this.listBox1.TabIndex = 0;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.textBoxX2);
            this.completionWizardPage1.Enabled = true;
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(565, 228);
            this.completionWizardPage1.Text = "测试成功了！为工具命名昵称";
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(13, 81);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(253, 22);
            this.textBoxX2.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.textBoxX1);
            this.wizardPage2.Enabled = true;
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(565, 228);
            this.wizardPage2.Text = "等待com的测试数据";
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(3, 62);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(308, 22);
            this.textBoxX1.TabIndex = 0;
            this.textBoxX1.Text = "00000011";
            // 
            // Devsimport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 396);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Devsimport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            this.Load += new System.EventHandler(this.Devsimport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.importdev_st)).EndInit();
            this.importdev_st.ResumeLayout(false);
            this.selectdev_wiz.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.completionWizardPage1.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraWizard.WizardControl importdev_st;
        private DevExpress.XtraWizard.WelcomeWizardPage selectdev_wiz;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
    }
}