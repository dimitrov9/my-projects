namespace Karavas_Stock_Management
{
    partial class AddState
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNameObject = new System.Windows.Forms.Label();
            this.lblNameContractor = new System.Windows.Forms.Label();
            this.lblAdress = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddElement = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMomentState = new System.Windows.Forms.Label();
            this.elementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.karavasStockManagementDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.karavasStockManagementDataSet = new Karavas_Stock_Management.KaravasStockManagementDataSet();
            this.elementsTableAdapter = new Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters.ElementsTableAdapter();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.elementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(13, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1159, 59);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1071, 661);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 38);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(930, 661);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(135, 38);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Montage";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "OBJECT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "CONTRACTOR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(609, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "ADRESS";
            // 
            // lblNameObject
            // 
            this.lblNameObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameObject.Location = new System.Drawing.Point(19, 113);
            this.lblNameObject.Name = "lblNameObject";
            this.lblNameObject.Size = new System.Drawing.Size(262, 65);
            this.lblNameObject.TabIndex = 7;
            this.lblNameObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameContractor
            // 
            this.lblNameContractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameContractor.Location = new System.Drawing.Point(287, 113);
            this.lblNameContractor.Name = "lblNameContractor";
            this.lblNameContractor.Size = new System.Drawing.Size(224, 65);
            this.lblNameContractor.TabIndex = 8;
            this.lblNameContractor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdress
            // 
            this.lblAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdress.Location = new System.Drawing.Point(545, 113);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(224, 65);
            this.lblAdress.TabIndex = 9;
            this.lblAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 246);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1149, 403);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnAddElement
            // 
            this.btnAddElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddElement.Location = new System.Drawing.Point(33, 201);
            this.btnAddElement.Name = "btnAddElement";
            this.btnAddElement.Size = new System.Drawing.Size(198, 38);
            this.btnAddElement.TabIndex = 11;
            this.btnAddElement.Text = "Add Element";
            this.btnAddElement.UseVisualStyleBackColor = true;
            this.btnAddElement.Click += new System.EventHandler(this.btnAddElement_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(845, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "STATE";
            // 
            // lblMomentState
            // 
            this.lblMomentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMomentState.Location = new System.Drawing.Point(775, 113);
            this.lblMomentState.Name = "lblMomentState";
            this.lblMomentState.Size = new System.Drawing.Size(224, 65);
            this.lblMomentState.TabIndex = 13;
            this.lblMomentState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elementsBindingSource
            // 
            this.elementsBindingSource.DataMember = "Elements";
            this.elementsBindingSource.DataSource = this.karavasStockManagementDataSetBindingSource;
            // 
            // karavasStockManagementDataSetBindingSource
            // 
            this.karavasStockManagementDataSetBindingSource.DataSource = this.karavasStockManagementDataSet;
            this.karavasStockManagementDataSetBindingSource.Position = 0;
            // 
            // karavasStockManagementDataSet
            // 
            this.karavasStockManagementDataSet.DataSetName = "KaravasStockManagementDataSet";
            this.karavasStockManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // elementsTableAdapter
            // 
            this.elementsTableAdapter.ClearBeforeFill = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(237, 207);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(61, 24);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "DATE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(304, 201);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 30);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.Value = new System.DateTime(2017, 9, 2, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(499, 207);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Date checked";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AddState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMomentState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddElement);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblAdress);
            this.Controls.Add(this.lblNameContractor);
            this.Controls.Add(this.lblNameObject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelTitle);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "AddState";
            this.Text = "AddState";
            this.Load += new System.EventHandler(this.AddState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.karavasStockManagementDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNameObject;
        private System.Windows.Forms.Label lblNameContractor;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddElement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMomentState;
        private System.Windows.Forms.BindingSource karavasStockManagementDataSetBindingSource;
        private KaravasStockManagementDataSet karavasStockManagementDataSet;
        private System.Windows.Forms.BindingSource elementsBindingSource;
        private KaravasStockManagementDataSetTableAdapters.ElementsTableAdapter elementsTableAdapter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}