using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class AddConcerts : Form
    {
        public AddConcerts()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
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
        /// Кнопка добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && numericUpDown1.Value > 0)
                {
                    Concert C = new Concert()
                    {
                        NameConcert = textBox1.Text,
                        DateConcert = dateTimePicker1.Value,
                        Time = 0,
                        Price = Convert.ToDouble(numericUpDown1.Value)
                    };
                    Main.db.Concerts.Add(C);
                    Main.db.SaveChanges();
                    Close();
                }
            }
            catch { }
        }
    }
}