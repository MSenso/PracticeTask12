using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTask12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажат энтер
            {
                if (int.TryParse((sender as TextBox).Text, out Form1.size)) // Введено целое число
                {
                    if (Form1.size >= 1 && Form1.size <= 100) // Размер от 1 до 100
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Размер должен быть от 1 до 100!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Form1.size = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Введите натуральное число от 1 до 100!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form1.size = 0;
                }
            }
        }
    }
}
