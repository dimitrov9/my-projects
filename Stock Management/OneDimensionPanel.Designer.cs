namespace Karavas_Stock_Management
{
    partial class OneDimensionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDimension = new System.Windows.Forms.Label();
            this.lblAvaliable = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDimension
            // 
            this.lblDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimension.Location = new System.Drawing.Point(0, 0);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(112, 35);
            this.lblDimension.TabIndex = 0;
            this.lblDimension.Text = "label1";
            this.lblDimension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvaliable
            // 
            this.lblAvaliable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvaliable.Location = new System.Drawing.Point(110, 0);
            this.lblAvaliable.Margin = new System.Windows.Forms.Padding(0);
            this.lblAvaliable.Name = "lblAvaliable";
            this.lblAvaliable.Size = new System.Drawing.Size(88, 35);
            this.lblAvaliable.TabIndex = 1;
            this.lblAvaliable.Text = "label1";
            this.lblAvaliable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(201, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(108, 33);
            this.numericUpDown1.TabIndex = 2;
            // 
            // OneDimensionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblAvaliable);
            this.Controls.Add(this.lblDimension);
            this.Name = "OneDimensionPanel";
            this.Size = new System.Drawing.Size(309, 35);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.Label lblAvaliable;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
