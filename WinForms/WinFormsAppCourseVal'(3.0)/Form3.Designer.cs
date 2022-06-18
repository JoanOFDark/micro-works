namespace WindowsFormsApp1
{
    partial class Form3
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
            this.button_OK_Metod = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_Metod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_OK_Metod
            // 
            this.button_OK_Metod.Location = new System.Drawing.Point(97, 126);
            this.button_OK_Metod.Name = "button_OK_Metod";
            this.button_OK_Metod.Size = new System.Drawing.Size(75, 23);
            this.button_OK_Metod.TabIndex = 0;
            this.button_OK_Metod.Text = "Ок";
            this.button_OK_Metod.UseVisualStyleBackColor = true;
            this.button_OK_Metod.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(70, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_Metod
            // 
            this.label_Metod.AutoSize = true;
            this.label_Metod.Location = new System.Drawing.Point(67, 44);
            this.label_Metod.Name = "label_Metod";
            this.label_Metod.Size = new System.Drawing.Size(115, 16);
            this.label_Metod.TabIndex = 2;
            this.label_Metod.Text = "Выберите метод";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 217);
            this.Controls.Add(this.label_Metod);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_OK_Metod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK_Metod;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Metod;
    }
}