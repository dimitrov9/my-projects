namespace Karavas_Stock_Management
{
    partial class NumericLeftRight
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
            this.numValue = new System.Windows.Forms.NumericUpDown();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.btnIncrement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // numValue
            // 
            this.numValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValue.Location = new System.Drawing.Point(35, 0);
            this.numValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(124, 38);
            this.numValue.TabIndex = 0;
            // 
            // btnDecrement
            // 
            this.btnDecrement.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrement.Location = new System.Drawing.Point(0, 0);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(38, 40);
            this.btnDecrement.TabIndex = 1;
            this.btnDecrement.Text = "<";
            this.btnDecrement.UseVisualStyleBackColor = true;
            this.btnDecrement.Click += new System.EventHandler(this.btnDecrement_Click);
            // 
            // btnIncrement
            // 
            this.btnIncrement.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrement.Location = new System.Drawing.Point(139, 0);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(38, 40);
            this.btnIncrement.TabIndex = 2;
            this.btnIncrement.Text = ">";
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // NumericLeftRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnIncrement);
            this.Controls.Add(this.btnDecrement);
            this.Controls.Add(this.numValue);
            this.Name = "NumericLeftRight";
            this.Size = new System.Drawing.Size(177, 40);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numValue;
        public System.Windows.Forms.Button btnDecrement;
        public System.Windows.Forms.Button btnIncrement;
    }
}
