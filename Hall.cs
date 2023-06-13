using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity;

namespace Theatre
{
    public partial class Hall : Form
    {
        static int N = 1058;
        Button[] but = new Button[N]; // массив кнопок (мест)

        public static int ID = 0; // айди концерта
        public static double money = 0; // стоимость без промокода
        public static int r = 0; // ряд
        public static int m = 0; // место
        public static int NUM = 0; // для билета номер счетчика мест

        bool go = false;

        public Hall(int iD)
        {
            InitializeComponent();
            ID = iD;
            PlaceHall();
        }

        /// <summary>
        /// Метод вывода мест на форму.
        /// </summary>
        private void PlaceHall()
        {
            int y = 90, x = 67; // Начальные координаты
            // размеры кнопок
            int buttonWidth = 20;
            int buttonHeight = 20;

            // создание кнопок //
            for (int i = 0; i < N; i++)
            {
                but[i] = new Button();

                // вывод первых 144 мест //
                // +50% к стоимости //
                if (i < 144)
                {
                    but[i].Location = new Point(x, y);
                    but[i].Size = new Size(buttonWidth, buttonHeight);
                    but[i].BackColor = Color.Red;

                    this.Controls.Add(but[i]);

                    // отступы //
                    if ((i + 1) % 36 == 0)
                    {
                        x = 67;
                        y += 20;
                    }
                    else
                    {
                        if ((i + 1) % 18 == 0)
                            x += 88;
                        else
                            x += 22;
                    }    
                }
                
                // следующие 208 мест //
                // +30% к стоимости //
                if (i >= 144 && i < 354)
                {
                    if (i == 144)
                    {
                        x = 23;
                        y += 20;
                    }
                        
                    but[i].Location = new Point(x, y);
                    but[i].Size = new Size(buttonWidth, buttonHeight);
                    but[i].BackColor = Color.DarkRed;

                    this.Controls.Add(but[i]);

                    // отступы //
                    if ((i + 1 - 144) % 42 == 0)
                    {
                        x = 23;
                        y += 20;
                    }
                    else
                    {
                        if ((i + 1 - 144) % 21 == 0)
                            x += 44;
                        else
                            x += 22;
                    }
                }

                // следующие 215 мест //
                // цена стандартная //
                if (i >= 354 && i < 612)
                {
                    if (i == 354)
                    {
                        x = 23;
                        y += 20;
                    }

                    but[i].Location = new Point(x, y);
                    but[i].Size = new Size(buttonWidth, buttonHeight);
                    but[i].BackColor = Color.Purple;

                    this.Controls.Add(but[i]);

                    // отступы //
                    if ((i + 1 - 354) % 43 == 0)
                    {
                        x = 23;
                        y += 20;
                    }
                    else
                        x += 22;
                }

                // следующие 126 мест //
                // -10% к стоимости //
                if (i >= 612 && i < 738)
                {
                    if (i == 612)
                    {
                        x = 23;
                        y += 40;
                    }

                    but[i].Location = new Point(x, y);
                    but[i].Size = new Size(buttonWidth, buttonHeight);
                    but[i].BackColor = Color.DarkGreen;

                    this.Controls.Add(but[i]);

                    // отступы //
                    if ((i + 1 - 612) % 42 == 0)
                    {
                        x = 23;
                        y += 20;
                    }
                    else
                    {
                        if ((i + 1 - 612) % 14 == 0)
                            x += 33;
                        else
                            x += 22;
                    }
                }

                // оставшиеся места //
                // -20% к стоимости //
                if (i >= 738 && i < 1058)
                {
                    if (i == 738)
                    {
                        x = 18;
                        y += 40;
                    }

                    but[i].Location = new Point(x, y);
                    but[i].Size = new Size(buttonWidth, buttonHeight);
                    but[i].BackColor = Color.Green;

                    this.Controls.Add(but[i]);

                    // отступы //
                    if ((i + 1 - 738) % 40 == 0)
                    {
                        x = 18;
                        y += 20;
                    }
                    else
                    {
                        if ((i + 1 - 738) % 5 == 0)
                            x += 33;
                        else
                            x += 22;
                    }
                }

                foreach (Concert C in Main.db.Concerts.Include(T => T.Tickets))
                {
                    if (ID == C.ConcertID)
                    {
                        foreach (Ticket T in C.Tickets)
                        {
                            if (T.secret == i)
                            {
                                but[i].BackColor = Color.Gray;
                            }
                        }
                    } 
                }

                but[i].Click += new EventHandler(But_Click); // Добавляем событие нажатия для кнопки
            }
        }

        /// <summary>
        /// Событие нажатия на кпноку из массива кнопок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void But_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // выбранная кнопочка

            // если не занято //
            if (button.BackColor != Color.Gray)
            {
                for (int i = 0; i < N; i++)
                {
                    if (button == but[i] && but[i].BackColor != Color.Blue)
                    {
                        but[i].BackColor = Color.Blue;
                        for (int K = 0; K < N; K++)
                        {
                            if (i != K)
                            {
                                if (K < 144 && but[K].BackColor != Color.Gray)
                                    but[K].BackColor = Color.Red;
                                if (K >= 144 && K < 354 && but[K].BackColor != Color.Gray)
                                    but[K].BackColor = Color.DarkRed;
                                if (K >= 354 && K < 612 && but[K].BackColor != Color.Gray)
                                    but[K].BackColor = Color.Purple;
                                if (K >= 612 && K < 738 && but[K].BackColor != Color.Gray)
                                    but[K].BackColor = Color.DarkGreen;
                                if (K >= 738 && K < 1058 && but[K].BackColor != Color.Gray)
                                    but[K].BackColor = Color.Green;
                            }
                        }

                        foreach (Concert C in Main.db.Concerts)
                        {
                            if (ID == C.ConcertID)
                            {
                                if (i < 144)
                                {
                                    money = C.Price + (C.Price * 0.5);
                                    r = i / 36 + 1;
                                    if (r == 1)
                                        m = i + 1;
                                    else
                                        m = i - ((r-1) * 36) + 1;
                                }
                                if (i >= 144 && i < 354)
                                {
                                    money = C.Price + (C.Price * 0.3);
                                    r = (i - 143) / 43 + 5;
                                    m = (i - 143) - ((r - 5) * 42);
                                }  
                                if (i >= 354 && i < 612)
                                {
                                    money = C.Price;
                                    r = (i - 354) / 43 + 10;
                                    m = ((i - 354) - ((r - 9) * 43)) + 44;
                                }
                                    
                                if (i >= 612 && i < 738)
                                {
                                    money = C.Price - (C.Price * 0.1);
                                    r = (i - 612) / 42 + 16;
                                    m = (i - 612) - ((r - 15) * 42) + 43;
                                }   
                                if (i >= 738 && i < 1058)
                                {
                                    money = C.Price - (C.Price * 0.2);
                                    r = (i - 738) / 40 + 19;
                                    m = (i - 738) - ((r - 18) * 40) + 41;
                                }
                                    
                                label4.Text = $"Стоимость: {money} руб.";
                                label5.Text = $"Ряд: {r}, Место: {m}";
                                break;
                            }
                        }
                        go = true;
                        NUM = i;
                        break;
                    }
                    if (button == but[i] && but[i].BackColor == Color.Blue)
                    {
                        if (i < 144 && but[i].BackColor != Color.Gray)
                            but[i].BackColor = Color.Red;
                        if (i >= 144 && i < 354 && but[i].BackColor != Color.Gray)
                            but[i].BackColor = Color.DarkRed;
                        if (i >= 354 && i < 612 && but[i].BackColor != Color.Gray)
                            but[i].BackColor = Color.Purple;
                        if (i >= 612 && i < 738 && but[i].BackColor != Color.Gray)
                            but[i].BackColor = Color.DarkGreen;
                        if (i >= 738 && i < 1058 && but[i].BackColor != Color.Gray)
                            but[i].BackColor = Color.Green;
                        label4.Text = "Стоимость: 0 руб.";
                        label5.Text = "Ряд: 0, Место: 0";
                        NUM = 0;
                        go = false;
                        break;
                    }
                }
            }
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
        /// Кнопка продолжить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ( go == true)
            {
                Promo promo = new Promo();
                promo.ShowDialog();
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