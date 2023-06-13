using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class AddPerformances : Form
    {
        public AddPerformances()
        {
            InitializeComponent();

            foreach (Concert C in Main.db.Concerts)
                comboBox1.Items.Add(C.ConcertID);
            foreach (Octor O in Main.db.Actors)
                comboBox2.Items.Add(O.NameActor);
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
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && numericUpDown1.Value > 0)
            {
                int id = 0;
                foreach (Octor O in Main.db.Actors)
                {
                    if (O.NameActor == comboBox2.Text)
                    {
                        id = O.ID;
                        break;
                    }    
                }    
                Performance P = new Performance()
                {
                    NamePerformance = textBox1.Text,
                    IdActor = id,
                    Time = Convert.ToDouble(numericUpDown1.Value)
                };
                foreach (Concert C in Main.db.Concerts)
                {
                    if (C.ConcertID.ToString() == comboBox1.Text)
                    {
                        C.Performances.Add(P);
                        break;
                    }
                }
                Main.db.SaveChanges();
                Close();
            }
        }
    }
}