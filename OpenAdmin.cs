using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class OpenAdmin : Form
    {
        public OpenAdmin()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;

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
        /// Кнопка вход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Main.KeyAdmin == textBox1.Text)
            {
                Admin admin = new Admin();
                admin.ShowDialog();
            }
            else
                MessageBox.Show("Неверный ключ!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Переключатель показать пароль.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false; // открываем пароль
            }
            else
                textBox1.UseSystemPasswordChar = true; // скрываем пароль
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Bisque;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Bisque;
        }
    }
}