using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class AddActor : Form
    {
        public AddActor()
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
                if (textBox1.Text != "")
                {
                    Octor O = new Octor()
                    {
                        NameActor = textBox1.Text
                    };
                    Main.db.Actors.Add(O);
                    Main.db.SaveChanges();
                    Close();
                }
            }
            catch { }
        }
    }
}