﻿namespace NepslidingTools.toolbox
{
    partial class BomFrom2
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
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_lj = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_configmain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_lj = new System.Windows.Forms.Label();
            this.textBox_query = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_tot = new System.Windows.Forms.Label();
            this.button_pre = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_query = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.componentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel_ljjl = new System.Windows.Forms.TableLayoutPanel();
            this.dgvljjl = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonjl_next = new System.Windows.Forms.Button();
            this.buttonjl_pre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_likekey = new System.Windows.Forms.Label();
            this.textBoxljjl_query = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_likequery = new System.Windows.Forms.Button();
            this.buttonlj_del = new System.Windows.Forms.Button();
            this.buttolj_add = new System.Windows.Forms.Button();
            this.buttonlj_edit = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jilu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl_main.SuspendLayout();
            this.tabPage_lj.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel_configmain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel_ljjl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvljjl)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_lj);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(969, 561);
            this.tabControl_main.TabIndex = 0;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // tabPage_lj
            // 
            this.tabPage_lj.Controls.Add(this.tableLayoutPanel_ljjl);
            this.tabPage_lj.Location = new System.Drawing.Point(4, 22);
            this.tabPage_lj.Name = "tabPage_lj";
            this.tabPage_lj.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_lj.Size = new System.Drawing.Size(961, 535);
            this.tabPage_lj.TabIndex = 0;
            this.tabPage_lj.Text = "零件记录";
            this.tabPage_lj.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel_configmain);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(961, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "零件配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_configmain
            // 
            this.tableLayoutPanel_configmain.ColumnCount = 1;
            this.tableLayoutPanel_configmain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_configmain.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel_configmain.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel_configmain.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel_configmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_configmain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_configmain.Name = "tableLayoutPanel_configmain";
            this.tableLayoutPanel_configmain.RowCount = 3;
            this.tableLayoutPanel_configmain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_configmain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_configmain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_configmain.Size = new System.Drawing.Size(955, 529);
            this.tableLayoutPanel_configmain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_query);
            this.panel1.Controls.Add(this.button_edit);
            this.panel1.Controls.Add(this.button_del);
            this.panel1.Controls.Add(this.button_add);
            this.panel1.Controls.Add(this.textBox_query);
            this.panel1.Controls.Add(this.label_lj);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 34);
            this.panel1.TabIndex = 0;
            // 
            // label_lj
            // 
            this.label_lj.AutoSize = true;
            this.label_lj.Location = new System.Drawing.Point(10, 10);
            this.label_lj.Name = "label_lj";
            this.label_lj.Size = new System.Drawing.Size(29, 12);
            this.label_lj.TabIndex = 0;
            this.label_lj.Text = "零件";
            // 
            // textBox_query
            // 
            this.textBox_query.Location = new System.Drawing.Point(49, 6);
            this.textBox_query.Name = "textBox_query";
            this.textBox_query.Size = new System.Drawing.Size(179, 21);
            this.textBox_query.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.componentId,
            this.name,
            this.jobnum,
            this.ARef,
            this.size,
            this.sm,
            this.photo,
            this.remark});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(949, 443);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_next);
            this.panel2.Controls.Add(this.button_pre);
            this.panel2.Controls.Add(this.label_tot);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 492);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 34);
            this.panel2.TabIndex = 2;
            // 
            // label_tot
            // 
            this.label_tot.AutoSize = true;
            this.label_tot.Location = new System.Drawing.Point(118, 11);
            this.label_tot.Name = "label_tot";
            this.label_tot.Size = new System.Drawing.Size(29, 12);
            this.label_tot.TabIndex = 0;
            this.label_tot.Text = "0/10";
            // 
            // button_pre
            // 
            this.button_pre.Location = new System.Drawing.Point(19, 6);
            this.button_pre.Name = "button_pre";
            this.button_pre.Size = new System.Drawing.Size(75, 23);
            this.button_pre.TabIndex = 1;
            this.button_pre.Text = "上一页";
            this.button_pre.UseVisualStyleBackColor = true;
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(183, 6);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 2;
            this.button_next.Text = "下一页";
            this.button_next.UseVisualStyleBackColor = true;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(347, 6);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "添加";
            this.button_add.UseVisualStyleBackColor = true;
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(437, 6);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(75, 23);
            this.button_del.TabIndex = 3;
            this.button_del.Text = "删除";
            this.button_del.UseVisualStyleBackColor = true;
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(527, 6);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 4;
            this.button_edit.Text = "修改";
            this.button_edit.UseVisualStyleBackColor = true;
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(257, 6);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(75, 23);
            this.button_query.TabIndex = 5;
            this.button_query.Text = "查询";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "导出选中行";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(753, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "从外部导入";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // componentId
            // 
            this.componentId.DataPropertyName = "componentId";
            this.componentId.HeaderText = "id";
            this.componentId.Name = "componentId";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "零件名";
            this.name.Name = "name";
            // 
            // jobnum
            // 
            this.jobnum.DataPropertyName = "jobnum";
            this.jobnum.HeaderText = "jobnum";
            this.jobnum.Name = "jobnum";
            // 
            // ARef
            // 
            this.ARef.DataPropertyName = "ARef";
            this.ARef.HeaderText = "ARef";
            this.ARef.Name = "ARef";
            // 
            // size
            // 
            this.size.DataPropertyName = "size";
            this.size.HeaderText = "尺寸";
            this.size.Name = "size";
            // 
            // sm
            // 
            this.sm.DataPropertyName = "sm";
            this.sm.HeaderText = "数模";
            this.sm.Name = "sm";
            // 
            // photo
            // 
            this.photo.DataPropertyName = "photo";
            this.photo.HeaderText = "photo";
            this.photo.Name = "photo";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "标准管理";
            this.remark.Name = "remark";
            this.remark.Text = "管理";
            // 
            // tableLayoutPanel_ljjl
            // 
            this.tableLayoutPanel_ljjl.ColumnCount = 1;
            this.tableLayoutPanel_ljjl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ljjl.Controls.Add(this.dgvljjl, 0, 1);
            this.tableLayoutPanel_ljjl.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel_ljjl.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel_ljjl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_ljjl.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_ljjl.Name = "tableLayoutPanel_ljjl";
            this.tableLayoutPanel_ljjl.RowCount = 3;
            this.tableLayoutPanel_ljjl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_ljjl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ljjl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_ljjl.Size = new System.Drawing.Size(955, 529);
            this.tableLayoutPanel_ljjl.TabIndex = 0;
            // 
            // dgvljjl
            // 
            this.dgvljjl.AllowUserToAddRows = false;
            this.dgvljjl.AllowUserToDeleteRows = false;
            this.dgvljjl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvljjl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.component,
            this.PN,
            this.Barcode,
            this.jilu});
            this.dgvljjl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvljjl.Location = new System.Drawing.Point(3, 43);
            this.dgvljjl.Name = "dgvljjl";
            this.dgvljjl.RowTemplate.Height = 23;
            this.dgvljjl.Size = new System.Drawing.Size(949, 453);
            this.dgvljjl.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonjl_next);
            this.panel3.Controls.Add(this.buttonjl_pre);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 502);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 24);
            this.panel3.TabIndex = 1;
            // 
            // buttonjl_next
            // 
            this.buttonjl_next.Location = new System.Drawing.Point(174, 0);
            this.buttonjl_next.Name = "buttonjl_next";
            this.buttonjl_next.Size = new System.Drawing.Size(75, 23);
            this.buttonjl_next.TabIndex = 5;
            this.buttonjl_next.Text = "下一页";
            this.buttonjl_next.UseVisualStyleBackColor = true;
            // 
            // buttonjl_pre
            // 
            this.buttonjl_pre.Location = new System.Drawing.Point(10, 0);
            this.buttonjl_pre.Name = "buttonjl_pre";
            this.buttonjl_pre.Size = new System.Drawing.Size(75, 23);
            this.buttonjl_pre.TabIndex = 4;
            this.buttonjl_pre.Text = "上一页";
            this.buttonjl_pre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "0/10";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonlj_edit);
            this.panel4.Controls.Add(this.buttolj_add);
            this.panel4.Controls.Add(this.buttonlj_del);
            this.panel4.Controls.Add(this.button_likequery);
            this.panel4.Controls.Add(this.textBox_type);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.textBoxljjl_query);
            this.panel4.Controls.Add(this.label_likekey);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(949, 34);
            this.panel4.TabIndex = 2;
            // 
            // label_likekey
            // 
            this.label_likekey.AutoSize = true;
            this.label_likekey.Location = new System.Drawing.Point(8, 11);
            this.label_likekey.Name = "label_likekey";
            this.label_likekey.Size = new System.Drawing.Size(41, 12);
            this.label_likekey.TabIndex = 0;
            this.label_likekey.Text = "关键字";
            // 
            // textBoxljjl_query
            // 
            this.textBoxljjl_query.Location = new System.Drawing.Point(56, 7);
            this.textBoxljjl_query.Name = "textBoxljjl_query";
            this.textBoxljjl_query.Size = new System.Drawing.Size(100, 21);
            this.textBoxljjl_query.TabIndex = 1;
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(210, 7);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.Size = new System.Drawing.Size(100, 21);
            this.textBox_type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "类型";
            // 
            // button_likequery
            // 
            this.button_likequery.Location = new System.Drawing.Point(351, 6);
            this.button_likequery.Name = "button_likequery";
            this.button_likequery.Size = new System.Drawing.Size(75, 23);
            this.button_likequery.TabIndex = 4;
            this.button_likequery.Text = "查询";
            this.button_likequery.UseVisualStyleBackColor = true;
            this.button_likequery.Click += new System.EventHandler(this.button_likequery_Click);
            // 
            // buttonlj_del
            // 
            this.buttonlj_del.Location = new System.Drawing.Point(436, 6);
            this.buttonlj_del.Name = "buttonlj_del";
            this.buttonlj_del.Size = new System.Drawing.Size(75, 23);
            this.buttonlj_del.TabIndex = 5;
            this.buttonlj_del.Text = "删除";
            this.buttonlj_del.UseVisualStyleBackColor = true;
            // 
            // buttolj_add
            // 
            this.buttolj_add.Location = new System.Drawing.Point(521, 6);
            this.buttolj_add.Name = "buttolj_add";
            this.buttolj_add.Size = new System.Drawing.Size(75, 23);
            this.buttolj_add.TabIndex = 6;
            this.buttolj_add.Text = "添加";
            this.buttolj_add.UseVisualStyleBackColor = true;
            // 
            // buttonlj_edit
            // 
            this.buttonlj_edit.Location = new System.Drawing.Point(606, 6);
            this.buttonlj_edit.Name = "buttonlj_edit";
            this.buttonlj_edit.Size = new System.Drawing.Size(75, 23);
            this.buttonlj_edit.TabIndex = 7;
            this.buttonlj_edit.Text = "修改";
            this.buttonlj_edit.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // component
            // 
            this.component.DataPropertyName = "componentId";
            this.component.HeaderText = "类型";
            this.component.Name = "component";
            // 
            // PN
            // 
            this.PN.DataPropertyName = "PN";
            this.PN.HeaderText = "零件编号";
            this.PN.Name = "PN";
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "条码";
            this.Barcode.Name = "Barcode";
            // 
            // jilu
            // 
            this.jilu.DataPropertyName = "remark";
            this.jilu.HeaderText = "零件类型基础管理";
            this.jilu.Name = "jilu";
            this.jilu.Width = 150;
            // 
            // BomFrom2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 561);
            this.Controls.Add(this.tabControl_main);
            this.Name = "BomFrom2";
            this.Text = "零件管理";
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_lj.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel_configmain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel_ljjl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvljjl)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_lj;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_configmain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_lj;
        private System.Windows.Forms.TextBox textBox_query;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_tot;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_pre;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARef;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo;
        private System.Windows.Forms.DataGridViewButtonColumn remark;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ljjl;
        private System.Windows.Forms.DataGridView dgvljjl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonjl_next;
        private System.Windows.Forms.Button buttonjl_pre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_likekey;
        private System.Windows.Forms.TextBox textBoxljjl_query;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_likequery;
        private System.Windows.Forms.Button buttonlj_del;
        private System.Windows.Forms.Button buttolj_add;
        private System.Windows.Forms.Button buttonlj_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn jilu;
    }
}