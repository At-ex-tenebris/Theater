using System;
using System.Drawing;
using System.Windows.Forms;


namespace Theatre
{
    public partial class Promo : Form
    {
        public Promo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка назад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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

        /// <summary>
        /// Кнопка далее.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (PromoСode P in Main.db.PromoСodes)
            {
                if (P.NameCode == textBox1.Text && P.DataLive > DateTime.Today)
                {
                    Hall.money = Hall.money - (Hall.money * P.buff);
                    break;
                }
            }
            Decoration decoration = new Decoration();
            decoration.Show();
        }
    }
}