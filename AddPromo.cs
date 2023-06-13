using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class AddPromo : Form
    {
        public AddPromo()
        {
            InitializeComponent();
        }

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
        /// Кнопка добавить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && numericUpDown1.Value > 0)
                {
                    PromoСode P = new PromoСode()
                    {
                        NameCode = textBox1.Text,
                        buff = (int)numericUpDown1.Value / 100,
                        DataLive = dateTimePicker1.Value
                    };
                    Main.db.PromoСodes.Add(P);
                    Main.db.SaveChanges();
                    Close();
                }
            }
            catch { }         
        }
    }
}