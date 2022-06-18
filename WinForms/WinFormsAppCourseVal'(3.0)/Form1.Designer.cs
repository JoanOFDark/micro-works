namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_choose_the_type = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_list_objects = new System.Windows.Forms.Label();
            this.label_console = new System.Windows.Forms.Label();
            this.listBox_objects = new System.Windows.Forms.ListBox();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 702);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label_choose_the_type, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_type, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_add, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.button_remove, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(703, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 692);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label_choose_the_type
            // 
            this.label_choose_the_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_choose_the_type.AutoSize = true;
            this.label_choose_the_type.Location = new System.Drawing.Point(3, 0);
            this.label_choose_the_type.Name = "label_choose_the_type";
            this.label_choose_the_type.Size = new System.Drawing.Size(288, 48);
            this.label_choose_the_type.TabIndex = 0;
            this.label_choose_the_type.Text = "Выберите тип";
            // 
            // comboBox_type
            // 
            this.comboBox_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "River",
            "Dye",
            "Action Movie",
            "Comedy",
            "Horror",
            "Multiplication"});
            this.comboBox_type.Location = new System.Drawing.Point(3, 53);
            this.comboBox_type.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(288, 33);
            this.comboBox_type.TabIndex = 1;
            // 
            // button_add
            // 
            this.button_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_add.Location = new System.Drawing.Point(3, 122);
            this.button_add.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(288, 59);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click_1);
            // 
            // button_remove
            // 
            this.button_remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_remove.Location = new System.Drawing.Point(3, 191);
            this.button_remove.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(288, 59);
            this.button_remove.TabIndex = 3;
            this.button_remove.Text = "Удалить";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.Controls.Add(this.label_list_objects, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_console, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.listBox_objects, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_console, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 5);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(694, 692);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label_list_objects
            // 
            this.label_list_objects.AutoSize = true;
            this.label_list_objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_list_objects.Location = new System.Drawing.Point(3, 0);
            this.label_list_objects.Name = "label_list_objects";
            this.label_list_objects.Size = new System.Drawing.Size(688, 48);
            this.label_list_objects.TabIndex = 0;
            this.label_list_objects.Text = "Список объектов";
            // 
            // label_console
            // 
            this.label_console.AutoSize = true;
            this.label_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_console.Location = new System.Drawing.Point(3, 379);
            this.label_console.Name = "label_console";
            this.label_console.Size = new System.Drawing.Size(688, 48);
            this.label_console.TabIndex = 1;
            this.label_console.Text = "Консоль";
            // 
            // listBox_objects
            // 
            this.listBox_objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_objects.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listBox_objects.FormattingEnabled = true;
            this.listBox_objects.ItemHeight = 25;
            this.listBox_objects.Location = new System.Drawing.Point(3, 53);
            this.listBox_objects.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.listBox_objects.Name = "listBox_objects";
            this.listBox_objects.Size = new System.Drawing.Size(688, 252);
            this.listBox_objects.TabIndex = 2;
            // 
            // textBox_console
            // 
            this.textBox_console.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_console.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox_console.Location = new System.Drawing.Point(3, 432);
            this.textBox_console.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ReadOnly = true;
            this.textBox_console.Size = new System.Drawing.Size(688, 255);
            this.textBox_console.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_save, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_load, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 315);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(688, 59);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 49);
            this.button4.TabIndex = 0;
            this.button4.Text = "Выполнить метод";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(232, 5);
            this.button_save.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(223, 49);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_load.Location = new System.Drawing.Point(461, 5);
            this.button_load.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(224, 49);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "Загрузить";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 702);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_choose_the_type;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_list_objects;
        private System.Windows.Forms.Label label_console;
        private System.Windows.Forms.ListBox listBox_objects;
        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
    }
}


