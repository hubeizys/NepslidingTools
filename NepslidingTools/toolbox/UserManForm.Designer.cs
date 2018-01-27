namespace NepslidingTools.toolbox
{
    partial class UserManForm
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
            this.main_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.search_gb = new System.Windows.Forms.GroupBox();
            this.head_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.query_bt = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.time_dtp = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.username_tb = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.caozuo_gb = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.add_bt = new DevComponents.DotNetBar.ButtonX();
            this.del_bt = new DevComponents.DotNetBar.ButtonX();
            this.edit_bt = new DevComponents.DotNetBar.ButtonX();
            this.info_bt = new DevComponents.DotNetBar.ButtonX();
            this.users_gc = new DevExpress.XtraGrid.GridControl();
            this.manuser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Manager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.power = new DevExpress.XtraGrid.Columns.GridColumn();
            this.main_tlp.SuspendLayout();
            this.search_gb.SuspendLayout();
            this.head_tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_dtp)).BeginInit();
            this.caozuo_gb.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users_gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manuser)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tlp
            // 
            this.main_tlp.BackColor = System.Drawing.Color.Transparent;
            this.main_tlp.ColumnCount = 1;
            this.main_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tlp.Controls.Add(this.search_gb, 0, 0);
            this.main_tlp.Controls.Add(this.caozuo_gb, 0, 1);
            this.main_tlp.Controls.Add(this.users_gc, 0, 2);
            this.main_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tlp.ForeColor = System.Drawing.Color.Black;
            this.main_tlp.Location = new System.Drawing.Point(0, 0);
            this.main_tlp.Name = "main_tlp";
            this.main_tlp.RowCount = 3;
            this.main_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.main_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.main_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.main_tlp.Size = new System.Drawing.Size(665, 652);
            this.main_tlp.TabIndex = 0;
            // 
            // search_gb
            // 
            this.search_gb.BackColor = System.Drawing.Color.Transparent;
            this.search_gb.Controls.Add(this.head_tlp);
            this.search_gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search_gb.ForeColor = System.Drawing.Color.Black;
            this.search_gb.Location = new System.Drawing.Point(3, 3);
            this.search_gb.Name = "search_gb";
            this.search_gb.Size = new System.Drawing.Size(659, 114);
            this.search_gb.TabIndex = 0;
            this.search_gb.TabStop = false;
            this.search_gb.Text = "查询选项";
            // 
            // head_tlp
            // 
            this.head_tlp.ColumnCount = 4;
            this.head_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.head_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.head_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.head_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.head_tlp.Controls.Add(this.query_bt, 3, 1);
            this.head_tlp.Controls.Add(this.labelX1, 0, 0);
            this.head_tlp.Controls.Add(this.labelX2, 2, 0);
            this.head_tlp.Controls.Add(this.time_dtp, 3, 0);
            this.head_tlp.Controls.Add(this.username_tb, 1, 0);
            this.head_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.head_tlp.ForeColor = System.Drawing.Color.Black;
            this.head_tlp.Location = new System.Drawing.Point(3, 18);
            this.head_tlp.Name = "head_tlp";
            this.head_tlp.RowCount = 3;
            this.head_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.head_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.head_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.head_tlp.Size = new System.Drawing.Size(653, 93);
            this.head_tlp.TabIndex = 0;
            // 
            // query_bt
            // 
            this.query_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.query_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.query_bt.Dock = System.Windows.Forms.DockStyle.Left;
            this.query_bt.Location = new System.Drawing.Point(363, 43);
            this.query_bt.Name = "query_bt";
            this.query_bt.Size = new System.Drawing.Size(200, 34);
            this.query_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.query_bt.TabIndex = 0;
            this.query_bt.Text = "查询";
            this.query_bt.Click += new System.EventHandler(this.query_bt_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(42, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 34);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "用户名";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(282, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 34);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "添加时间";
            // 
            // time_dtp
            // 
            // 
            // 
            // 
            this.time_dtp.BackgroundStyle.Class = "DateTimeInputBackground";
            this.time_dtp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.time_dtp.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.time_dtp.ButtonDropDown.Visible = true;
            this.time_dtp.Dock = System.Windows.Forms.DockStyle.Left;
            this.time_dtp.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.time_dtp.ForeColor = System.Drawing.Color.Black;
            this.time_dtp.IsPopupCalendarOpen = false;
            this.time_dtp.Location = new System.Drawing.Point(363, 6);
            this.time_dtp.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            // 
            // 
            // 
            // 
            // 
            // 
            this.time_dtp.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.time_dtp.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.time_dtp.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.time_dtp.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.time_dtp.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.time_dtp.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.time_dtp.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.time_dtp.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.time_dtp.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.time_dtp.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.time_dtp.MonthCalendar.TodayButtonVisible = true;
            this.time_dtp.Name = "time_dtp";
            this.time_dtp.Size = new System.Drawing.Size(200, 26);
            this.time_dtp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.time_dtp.TabIndex = 3;
            // 
            // username_tb
            // 
            this.username_tb.AutoCompleteCustomSource.AddRange(new string[] {
            "11111111",
            "33333333",
            "1111233131",
            "12213123",
            "12311111",
            "111111123"});
            this.username_tb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.username_tb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.username_tb.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.username_tb.Border.Class = "TextBoxBorder";
            this.username_tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.username_tb.DisabledBackColor = System.Drawing.Color.White;
            this.username_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.username_tb.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.username_tb.ForeColor = System.Drawing.Color.Black;
            this.username_tb.Location = new System.Drawing.Point(123, 6);
            this.username_tb.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.username_tb.Name = "username_tb";
            this.username_tb.PreventEnterBeep = true;
            this.username_tb.Size = new System.Drawing.Size(114, 26);
            this.username_tb.TabIndex = 4;
            // 
            // caozuo_gb
            // 
            this.caozuo_gb.Controls.Add(this.flowLayoutPanel1);
            this.caozuo_gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caozuo_gb.ForeColor = System.Drawing.Color.Black;
            this.caozuo_gb.Location = new System.Drawing.Point(3, 123);
            this.caozuo_gb.Name = "caozuo_gb";
            this.caozuo_gb.Size = new System.Drawing.Size(659, 54);
            this.caozuo_gb.TabIndex = 1;
            this.caozuo_gb.TabStop = false;
            this.caozuo_gb.Text = " 操作";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.add_bt);
            this.flowLayoutPanel1.Controls.Add(this.del_bt);
            this.flowLayoutPanel1.Controls.Add(this.edit_bt);
            this.flowLayoutPanel1.Controls.Add(this.info_bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(653, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // add_bt
            // 
            this.add_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.add_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.add_bt.Location = new System.Drawing.Point(15, 3);
            this.add_bt.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.add_bt.Name = "add_bt";
            this.add_bt.Size = new System.Drawing.Size(75, 23);
            this.add_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.add_bt.TabIndex = 0;
            this.add_bt.Text = "添加";
            // 
            // del_bt
            // 
            this.del_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.del_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.del_bt.Location = new System.Drawing.Point(120, 3);
            this.del_bt.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.del_bt.Name = "del_bt";
            this.del_bt.Size = new System.Drawing.Size(75, 23);
            this.del_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.del_bt.TabIndex = 1;
            this.del_bt.Text = "删除";
            // 
            // edit_bt
            // 
            this.edit_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.edit_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.edit_bt.Location = new System.Drawing.Point(225, 3);
            this.edit_bt.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.edit_bt.Name = "edit_bt";
            this.edit_bt.Size = new System.Drawing.Size(75, 23);
            this.edit_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.edit_bt.TabIndex = 2;
            this.edit_bt.Text = "编辑";
            // 
            // info_bt
            // 
            this.info_bt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.info_bt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.info_bt.Location = new System.Drawing.Point(330, 3);
            this.info_bt.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.info_bt.Name = "info_bt";
            this.info_bt.Size = new System.Drawing.Size(75, 23);
            this.info_bt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.info_bt.TabIndex = 3;
            this.info_bt.Text = "查看详情";
            // 
            // users_gc
            // 
            this.users_gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_gc.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.users_gc.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black;
            this.users_gc.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.users_gc.EmbeddedNavigator.Appearance.Options.UseForeColor = true;
            this.users_gc.Location = new System.Drawing.Point(3, 183);
            this.users_gc.MainView = this.manuser;
            this.users_gc.Name = "users_gc";
            this.users_gc.Size = new System.Drawing.Size(659, 466);
            this.users_gc.TabIndex = 2;
            this.users_gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.manuser});
            // 
            // manuser
            // 
            this.manuser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.username,
            this.Manager,
            this.addTime,
            this.power});
            this.manuser.GridControl = this.users_gc;
            this.manuser.Name = "manuser";
            // 
            // username
            // 
            this.username.Caption = "用户名";
            this.username.FieldName = "username";
            this.username.Name = "username";
            this.username.OptionsColumn.AllowEdit = false;
            this.username.Visible = true;
            this.username.VisibleIndex = 0;
            // 
            // Manager
            // 
            this.Manager.Caption = "管理者";
            this.Manager.FieldName = "Manager";
            this.Manager.Name = "Manager";
            this.Manager.OptionsColumn.AllowEdit = false;
            this.Manager.Visible = true;
            this.Manager.VisibleIndex = 1;
            // 
            // addTime
            // 
            this.addTime.Caption = "添加时间";
            this.addTime.FieldName = "addTime";
            this.addTime.Name = "addTime";
            this.addTime.OptionsColumn.AllowEdit = false;
            this.addTime.Visible = true;
            this.addTime.VisibleIndex = 2;
            // 
            // power
            // 
            this.power.Caption = "权利";
            this.power.FieldName = "power";
            this.power.Name = "power";
            this.power.OptionsColumn.AllowEdit = false;
            this.power.Visible = true;
            this.power.VisibleIndex = 3;
            // 
            // UserManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 652);
            this.Controls.Add(this.main_tlp);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserManForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManForm_Load);
            this.main_tlp.ResumeLayout(false);
            this.search_gb.ResumeLayout(false);
            this.head_tlp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.time_dtp)).EndInit();
            this.caozuo_gb.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.users_gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manuser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tlp;
        private System.Windows.Forms.GroupBox search_gb;
        private System.Windows.Forms.TableLayoutPanel head_tlp;
        private DevComponents.DotNetBar.ButtonX query_bt;
        private System.Windows.Forms.GroupBox caozuo_gb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX add_bt;
        private DevComponents.DotNetBar.ButtonX del_bt;
        private DevComponents.DotNetBar.ButtonX edit_bt;
        private DevExpress.XtraGrid.GridControl users_gc;
        private DevExpress.XtraGrid.Views.Grid.GridView manuser;
        private DevExpress.XtraGrid.Columns.GridColumn username;
        private DevExpress.XtraGrid.Columns.GridColumn Manager;
        private DevExpress.XtraGrid.Columns.GridColumn addTime;
        private DevExpress.XtraGrid.Columns.GridColumn power;
        private DevComponents.DotNetBar.ButtonX info_bt;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput time_dtp;
        private DevComponents.DotNetBar.Controls.TextBoxX username_tb;
    }
}