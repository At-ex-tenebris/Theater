using System;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class Decoration : Form
    {
        public Decoration()
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
        /// Кнопка оплатить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Payment();
        }

        /// <summary>
        /// Метод оплаты билета.
        /// </summary>
        private void Payment()
        {
            // валидация //
            if (maskedTextBox1.MaskCompleted && maskedTextBox2.MaskCompleted
                && maskedTextBox3.MaskCompleted || pictureBox1.BackgroundImage != null)
            {
                Ticket T = new Ticket()
                {
                    IdConcetr = Hall.ID,
                    Row = Hall.r,
                    Place = Hall.m,
                    Money = Hall.money,
                    Card = maskedTextBox1.Text,
                    secret = Hall.NUM
                };
                foreach (Concert C in Main.db.Concerts)
                {
                    if (Hall.ID == C.ConcertID)
                    {
                        C.Tickets.Add(T);
                        break;
                    }
                }
                Main.db.SaveChanges();

                foreach (Concert C in Main.db.Concerts)
                {
                    if (C.ConcertID == T.IdConcetr)
                    {
                        MessageBox.Show($"Представление: {C.NameConcert};\nДата и время начала: {C.DateConcert};\n\nРяд: {T.Row};\nМесто: {T.Place};" +
                            $"\nСтоимость билета: {T.Money};", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }   
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

        /// <summary>
        /// Проверка при вводе данных в поле.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            int flag = 0; // для определения, если ни одна из ниже карт, то убрать картинку
            // карта мир 2202 //
            if (maskedTextBox1.Text[0].ToString() == 2.ToString() && maskedTextBox1.Text[1].ToString() == 2.ToString()
                    && maskedTextBox1.Text[2].ToString() == 0.ToString() && maskedTextBox1.Text[3].ToString() == 2.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.mir;
                flag = 1;
            }

            // карта виза 459 //
            if (maskedTextBox1.Text[0].ToString() == 4.ToString() && maskedTextBox1.Text[1].ToString() == 5.ToString()
                    && maskedTextBox1.Text[2].ToString() == 9.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.visa;
                flag = 1;
            }

            // карта мастеркард 54 //
            if (maskedTextBox1.Text[0].ToString() == 5.ToString() && maskedTextBox1.Text[1].ToString() == 4.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.mastercard;
                flag = 1;
            }

            // карта маестро 356 //
            if (maskedTextBox1.Text[0].ToString() == 3.ToString() && maskedTextBox1.Text[1].ToString() == 5.ToString()
                && maskedTextBox1.Text[2].ToString() == 6.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.maestro;
                flag = 1;
            }

            // ни одна из карт //
            if (flag == 0)
                pictureBox1.BackgroundImage = null;
        }
    }
}