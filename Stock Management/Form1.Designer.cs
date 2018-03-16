namespace Karavas_Stock_Management
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.gbManipulate = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnArhiva = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.bntAddObject = new System.Windows.Forms.Button();
            this.karavasStockManagementDataSet1 = new Karavas_Stock_Management.KaravasStockManagementDataSet();
            this.objectTableAdapter1 = new Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters.ObjectTableAdapter();
            this.stateTableAdapter1 = new Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters.StateTableAdapter();
            this.tableAdapterManager1 = new Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters.TableAdapterManager();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblShowing = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbManipulate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Tan;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 184);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1156, 384);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(8, 6);
            this.panel4.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1100, 56);
            this.panel4.TabIndex = 1;

            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(387, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 57);
            this.label9.TabIndex = 16;
            this.label9.Text = "1\r\n2";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::Karavas_Stock_Management.Properties.Resources.delete;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(1220, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 38);
            this.button7.TabIndex = 14;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Karavas_Stock_Management.Properties.Resources.minus;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(930, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(139, 38);
            this.button6.TabIndex = 13;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Karavas_Stock_Management.Properties.Resources.sign_add;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(785, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 38);
            this.button5.TabIndex = 12;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Karavas_Stock_Management.Properties.Resources.sign_check;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(1075, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 38);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(544, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 57);
            this.label7.TabIndex = 10;
            this.label7.Text = "1\r\n2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(201, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 57);
            this.label6.TabIndex = 9;
            this.label6.Text = "1\r\n2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 57);
            this.label5.TabIndex = 8;
            this.label5.Text = "Сити Мол";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(409, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "ADRESS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(566, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "MOMENT STATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "CONTRACTOR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "NAME";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft PhagsPa", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(69, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(526, 50);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Karavas - Stock management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "State in warehouse:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(25, 100);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(104, 31);
            this.lblState.TabIndex = 5;
            this.lblState.Text = "100000";
            this.lblState.Click += new System.EventHandler(this.lblState_Click);
            this.lblState.MouseLeave += new System.EventHandler(this.lblState_MouseLeave);
            this.lblState.MouseHover += new System.EventHandler(this.lblState_MouseHover);
            // 
            // gbManipulate
            // 
            this.gbManipulate.Controls.Add(this.btnDelete);
            this.gbManipulate.Controls.Add(this.btnArhiva);
            this.gbManipulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbManipulate.Location = new System.Drawing.Point(13, 579);
            this.gbManipulate.Name = "gbManipulate";
            this.gbManipulate.Size = new System.Drawing.Size(249, 80);
            this.gbManipulate.TabIndex = 6;
            this.gbManipulate.TabStop = false;
            this.gbManipulate.Text = "For the selected";
            this.gbManipulate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(124, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 48);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnArhiva
            // 
            this.btnArhiva.Location = new System.Drawing.Point(5, 25);
            this.btnArhiva.Name = "btnArhiva";
            this.btnArhiva.Size = new System.Drawing.Size(113, 48);
            this.btnArhiva.TabIndex = 2;
            this.btnArhiva.Text = "Archive";
            this.btnArhiva.UseVisualStyleBackColor = true;
            this.btnArhiva.Click += new System.EventHandler(this.btnArhiva_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(886, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 48);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnArchive
            // 
            this.btnArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Location = new System.Drawing.Point(896, 130);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(113, 48);
            this.btnArchive.TabIndex = 4;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // bntAddObject
            // 
            this.bntAddObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntAddObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAddObject.Location = new System.Drawing.Point(1005, 611);
            this.bntAddObject.Name = "bntAddObject";
            this.bntAddObject.Size = new System.Drawing.Size(163, 48);
            this.bntAddObject.TabIndex = 7;
            this.bntAddObject.Text = "Add Object";
            this.bntAddObject.UseVisualStyleBackColor = true;
            this.bntAddObject.Click += new System.EventHandler(this.bntAddObject_Click);
            // 
            // karavasStockManagementDataSet1
            // 
            this.karavasStockManagementDataSet1.DataSetName = "KaravasStockManagementDataSet";
            this.karavasStockManagementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // objectTableAdapter1
            // 
            this.objectTableAdapter1.ClearBeforeFill = true;
            // 
            // stateTableAdapter1
            // 
            this.stateTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.ElementsTableAdapter = null;
            this.tableAdapterManager1.ElementTypesTableAdapter = null;
            this.tableAdapterManager1.ObjectTableAdapter = this.objectTableAdapter1;
            this.tableAdapterManager1.StateTableAdapter = this.stateTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.UsersTableAdapter = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Karavas_Stock_Management.Properties.Resources.just_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(1015, 130);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(113, 48);
            this.btnReport.TabIndex = 16;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(891, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Showing ";
            // 
            // lblShowing
            // 
            this.lblShowing.AutoSize = true;
            this.lblShowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowing.Location = new System.Drawing.Point(990, 34);
            this.lblShowing.Name = "lblShowing";
            this.lblShowing.Size = new System.Drawing.Size(66, 25);
            this.lblShowing.TabIndex = 18;
            this.lblShowing.Text = "Active";
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(407, 73);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(299, 30);
            this.tbSearch.TabIndex = 19;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(326, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 25);
            this.label11.TabIndex = 20;
            this.label11.Text = "Search";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 671);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblShowing);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.bntAddObject);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbManipulate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "t";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbManipulate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.GroupBox gbManipulate;
        private System.Windows.Forms.Button btnArhiva;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button bntAddObject;
        private KaravasStockManagementDataSet karavasStockManagementDataSet1;
        private KaravasStockManagementDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private KaravasStockManagementDataSetTableAdapters.StateTableAdapter stateTableAdapter1;
        public KaravasStockManagementDataSetTableAdapters.ObjectTableAdapter objectTableAdapter1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblShowing;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label11;
    }
}

