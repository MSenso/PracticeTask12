namespace PracticeTask12
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
            this.Array_Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.создатьНеотсортированныйМассивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Array_Label
            // 
            this.Array_Label.AutoSize = true;
            this.Array_Label.BackColor = System.Drawing.Color.Transparent;
            this.Array_Label.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Array_Label.Location = new System.Drawing.Point(12, 43);
            this.Array_Label.Name = "Array_Label";
            this.Array_Label.Size = new System.Drawing.Size(203, 33);
            this.Array_Label.TabIndex = 0;
            this.Array_Label.Text = "Исходный массив: ";
            this.Array_Label.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьНеотсортированныйМассивToolStripMenuItem,
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem,
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // создатьНеотсортированныйМассивToolStripMenuItem
            // 
            this.создатьНеотсортированныйМассивToolStripMenuItem.Name = "создатьНеотсортированныйМассивToolStripMenuItem";
            this.создатьНеотсортированныйМассивToolStripMenuItem.Size = new System.Drawing.Size(221, 20);
            this.создатьНеотсортированныйМассивToolStripMenuItem.Text = "Создать неотсортированный массив";
            this.создатьНеотсортированныйМассивToolStripMenuItem.Click += new System.EventHandler(this.создатьНеотсортированныйМассивToolStripMenuItem_Click);
            // 
            // создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem
            // 
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Enabled = false;
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Name = "создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem";
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Size = new System.Drawing.Size(300, 20);
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Text = "Создать отсортированный по возрастанию массив";
            this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Click += new System.EventHandler(this.создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem_Click);
            // 
            // создатьОтсортированныйПоУбываниюМассивToolStripMenuItem
            // 
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Enabled = false;
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Name = "создатьОтсортированныйПоУбываниюМассивToolStripMenuItem";
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Size = new System.Drawing.Size(286, 20);
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Text = "Создать отсортированный по убыванию массив";
            this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Click += new System.EventHandler(this.создатьОтсортированныйПоУбываниюМассивToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::PracticeTask12.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.Array_Label);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сравнение сортировок";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Array_Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem создатьНеотсортированныйМассивToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтсортированныйПоУбываниюМассивToolStripMenuItem;
    }
}

