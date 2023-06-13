using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class Reported : Form
    {
        public Reported()
        {
            InitializeComponent();

            comboBox1.Items.Add("Персонал");
            comboBox1.Items.Add("Работа приложения");
            comboBox1.Items.Add("Представления");
            comboBox1.Items.Add("Стоимость билетов");
            comboBox1.Items.Add("Зал театра");
            comboBox1.Items.Add("Другое");

            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Кнопка выход.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        /// <summary>
        /// Кнопка жалобы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox1.Text == "Пожалуйста, опишите Вашу проблему!")
                richTextBox1.Text = "Пожалуйста, опишите Вашу проблему!";
            else
            {
                MessageBox.Show("Спасибо за оставленную жалобу!:(", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Report R = new Report()
                {
                    TypeReport = comboBox1.Text,
                    TextReport = richTextBox1.Text,
                    date = DateTime.Today
                };
                Main.db.Reports.Add(R);
                Main.db.SaveChanges();
                Close();
            }
        }

        // анимация кнопок //
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Bisque;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Bisque;
        }
    }
}