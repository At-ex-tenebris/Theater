using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
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
        /// Кнопка возврата.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ReturnTicket();
        }

        /// <summary>
        /// Метод удаления билета из БД.
        /// </summary>
        private void ReturnTicket()
        {
            if (textBox1.Text != "")
            {
                foreach (Ticket T in Main.db.Tickets)
                {
                    if (T.ID.ToString() == textBox1.Text)
                    {
                        Main.db.Tickets.Remove(T);
                        MessageBox.Show("Билет упешно возвращен!\n\nДенежные средства вернутся на банковскую карту в течении 24 часов!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                Main.db.SaveChanges();  
            }
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