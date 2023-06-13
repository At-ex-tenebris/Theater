using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace Theatre
{
    public partial class Main : Form
    {
        // контекст данных //
        public static TheatreContext db = new TheatreContext();

        // ключ для входа в меню администратора //
        public static string KeyAdmin = "12345";

        public Main()
        {
            InitializeComponent();

            int un = 0;
            PrintConcert();
        }

        /// <summary>
        /// Метод вывода информации о концертах в таблицу.
        /// </summary>
        private void PrintConcert()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // закрываем доступ на редактирование таблицы //
            dataGridView1.ReadOnly = true;

            // выравниваем все ячейки в заголовке по центру //
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // создаем столбцы //
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();

            // параметры столбцов //
            column1.HeaderText = "Действие";
            column1.Name = "Column1";
            column2.HeaderText = "Название представления";
            column2.Name = "Column2";
            column3.HeaderText = "Дата";
            column3.Name = "Column3";
            column4.HeaderText = "Время начала";
            column4.Name = "Column4";
            column5.HeaderText = "Продолжительность (мин)";
            column5.Name = "Column5";
            column6.HeaderText = "Композиции";
            column6.Name = "Column5";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5,
                column6 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[5].Width = 150;

            // для того, чтобы был виден весь текст //
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            // наименование стобцов жирным курсивом //
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold | FontStyle.Italic);
            // выравнивание ячеек по центру //
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // стиль шрифта в ячейках //
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);

            // заполняем таблицу данными //
            int i = 0; // счетчик строк
            foreach (Concert C in db.Concerts)
            {
                if (C.DateConcert > DateTime.Today) // только актуальные концерты
                {
                    dataGridView1.Rows.Add(); // добавляем новую строку

                    // вставляем данные в ячейки строки //
                    dataGridView1.Rows[i].Cells[0].Value = "Купить";
                    dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.White;
                    dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                    dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                    dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                    dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();

                    dataGridView1.Rows[i].Cells[5].Value = "Просмотр";
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                    dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                    i++;
                }          
            }
        }

        /// <summary>
        /// Кнопка поиск, при нажатии, вводятся тестовые данные в БД.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            TestContext();
            PrintConcert();
        }

        /// <summary>
        /// Ввод тестовых данных.
        /// </summary>
        private void TestContext()

        {
            Concert C1 = new Concert()
            {
                NameConcert = "Oxxxymiron",
                DateConcert = new DateTime(2022, 10, 10, 12, 00, 00),
                Time = 0,
                Price = 2000
            };

            Concert C2 = new Concert()
            {
                NameConcert = "Осенняя суета",
                DateConcert = new DateTime(2022, 11, 10, 14, 00, 00),
                Time = 0,
                Price = 3200
            };

            Concert C3 = new Concert()
            {
                NameConcert = "Технологический переворот",
                DateConcert = new DateTime(2022, 12, 12, 19, 00, 00),
                Time = 0,
                Price = 100
            };

            Octor A1 = new Octor()
            {
                NameActor = "Oxxxymiron"
            };

            Octor A2 = new Octor()
            {
                NameActor = "MiyaGi"
            };

            Octor A3 = new Octor()
            {
                NameActor = "Макс Корж"
            };

            Octor A4 = new Octor()
            {
                NameActor = "ATL"
            };

            Octor A5 = new Octor()
            {
                NameActor = "Потап и Настя"
            };

            Octor A6 = new Octor()
            {
                NameActor = "Morgenshtern"
            };

            db.Actors.Add(A1);
            db.Actors.Add(A2);
            db.Actors.Add(A3);
            db.Actors.Add(A4);
            db.Actors.Add(A5);
            db.SaveChanges();

            int numActors = 0;
            foreach (Octor A in db.Actors)
            {
                if (A.NameActor == "Oxxxymiron")
                {
                    numActors = A.ID;
                    break;
                }
            }

            Performance P1 = new Performance()
            {
                NamePerformance = "Город под подошвой",
                IdActor = numActors,
                Time = 3.64
            };

            Performance P2 = new Performance()
            {
                NamePerformance = "ОРГАНИЗАЦИЯ",
                IdActor = numActors,
                Time = 2.64
            };

            foreach (Octor A in db.Actors)
            {
                if (A.NameActor == "MiyaGi")
                {
                    numActors = A.ID;
                    break;
                }
            }
            Performance P3 = new Performance()
            {
                NamePerformance = "Рапапам",
                IdActor = numActors,
                Time = 4
            };

            foreach (Octor A in db.Actors)
            {
                if (A.NameActor == "Макс Корж")
                {
                    numActors = A.ID;
                    break;
                }
            }
            Performance P4 = new Performance()
            {
                NamePerformance = "2 типа людей",
                IdActor = numActors,
                Time = 2.3
            };

            foreach (Octor A in db.Actors)
            {
                if (A.NameActor == "Потап и Настя")
                {
                    numActors = A.ID;
                    break;
                }
            }
            Performance P5 = new Performance()
            {
                NamePerformance = "Стиль собачки",
                IdActor = numActors,
                Time = 2.8
            };

            foreach (Octor A in db.Actors)
            {
                if (A.NameActor == "Morgenshtern")
                {
                    numActors = A.ID;
                    break;
                }
            }
            Performance P6 = new Performance()
            {
                NamePerformance = "Каделак",
                IdActor = numActors,
                Time = 1.8
            };

            C1.Performances.Add(P1);
            C1.Performances.Add(P2);
            C2.Performances.Add(P3);
            C2.Performances.Add(P4);
            C3.Performances.Add(P5);
            C3.Performances.Add(P6);

            db.Concerts.Add(C1);
            db.Concerts.Add(C2);
            db.Concerts.Add(C3);
            db.SaveChanges();

            foreach (Concert C in db.Concerts.Include(V => V.Performances))
            {
                foreach (Performance per in db.Performances)
                    C.Time += (int)per.Time;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Клик по ячейке в таблице.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                Hall _Hall = new Hall(ConcertID());
                _Hall.ShowDialog();
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 5) // просмотреть
            {
                string info = "КОМПОЗИЦИИ\n\n\n";
                int i = 1;
                foreach (Concert C in db.Concerts.Include(P=>P.Performances))
                {
                    if (C.ConcertID == ConcertID())
                    {
                        foreach (Performance P in C.Performances)
                        {
                            foreach (Octor O in db.Actors)
                            {
                                if (P.IdActor == O.ID)
                                {
                                    info += $"{i}. {O.NameActor} - {P.NamePerformance}\nпродолжительность: {P.Time} мин.\n\n";
                                    break;
                                }
                            }
                            i++;
                        }
                        break;
                    }
                }
                MessageBox.Show(info);
            }
        }

        /// <summary>
        /// Метод поиска id выбранной записи в БД.
        /// </summary>
        /// <returns></returns>
        private int ConcertID()
        {
            int id = 0;
            try
            {
                string name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string date = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string time = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                foreach (Concert C in db.Concerts)
                {
                    if (name == C.NameConcert && date == C.DateConcert.ToShortDateString() && time == C.DateConcert.ToString("HH:mm"))
                    {
                        id = C.ConcertID;
                        break;
                    }
                }
            }
            catch { }
            return id;
        }

        /// <summary>
        /// Фильтр по представлению.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox2.Text = "";
            textBox3.Text = "";

            if (textBox2.Text == "")
                PrintConcert();
               
            // заполняем таблицу данными //
            int i = 0; // счетчик строк
            foreach (Concert C in db.Concerts)
            {
                if (C.DateConcert > DateTime.Today) // только актуальные концерты
                {
                    if (C.NameConcert == textBox1.Text)
                    {
                        dataGridView1.Rows.Add(); // добавляем новую строку

                        // вставляем данные в ячейки строки //
                        dataGridView1.Rows[i].Cells[0].Value = "Купить";
                        dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.White;
                        dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                        dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                        dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                        dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();

                        dataGridView1.Rows[i].Cells[5].Value = "Просмотр";
                        dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                        dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                        i++;
                    }  
                }
            }
        }

        /// <summary>
        /// Фильтр по артисту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox3.Text = "";

            if (textBox2.Text == "")
                PrintConcert();

            // считаем кол-во концертов для кнопок //
            // и создаем массив кнопок //
            int num = 0;
            foreach (Concert C in db.Concerts.Include(P=>P.Performances))
            {
                int flag = 0;
                foreach (Performance P in C.Performances)
                {
                    foreach (Octor O in db.Actors)
                    {
                        if (textBox2.Text == O.NameActor && O.ID == P.IdActor)
                        {
                            num++;
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                        break;
                }
            }

            // заполняем таблицу данными //
            int i = 0; // счетчик строк
            foreach (Concert C in db.Concerts.Include(P=>P.Performances))
            {
                int flag = 0;
                foreach (Performance P in C.Performances)
                {
                    foreach (Octor O in db.Actors)
                    {
                        if (textBox2.Text == O.NameActor && O.ID == P.IdActor)
                        {
                            if (C.DateConcert > DateTime.Today) // только актуальные концерты
                            {
                                dataGridView1.Rows.Add(); // добавляем новую строку

                                // вставляем данные в ячейки строки //
                                dataGridView1.Rows[i].Cells[0].Value = "Купить";
                                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.White;
                                dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                                dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                                dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                                dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();

                                dataGridView1.Rows[i].Cells[5].Value = "Просмотр";
                                dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                                dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                                i++;
                                flag = 1;
                                break;
                            }
                        }
                    }
                    if (flag == 1)
                        break;
                }
            }
        }

        /// <summary>
        /// Фильтр вывода всех актуальных концертов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            PrintConcert();
        }

        /// <summary>
        /// Фильтр по дате.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox3.Text = "";

            // заполняем таблицу данными //
            int i = 0; // счетчик строк
            foreach (Concert C in db.Concerts)
            {
                if (C.DateConcert > DateTime.Today) // только актуальные концерты
                {
                    if (dateTimePicker1.Value.ToShortDateString() == C.DateConcert.ToShortDateString())
                    {
                        dataGridView1.Rows.Add(); // добавляем новую строку

                        // вставляем данные в ячейки строки //
                        dataGridView1.Rows[i].Cells[0].Value = "Купить";
                        dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.White;
                        dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                        dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                        dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                        dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();

                        dataGridView1.Rows[i].Cells[5].Value = "Просмотр";
                        dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                        dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Фильтр по композициям.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox2.Text = "";

            if (textBox3.Text == "")
                PrintConcert();

            // заполняем таблицу данными //
            int i = 0; // счетчик строк
            foreach (Concert C in db.Concerts.Include(P => P.Performances))
            {
                foreach (Performance P in C.Performances)
                {
                    if (textBox3.Text == P.NamePerformance)
                    {
                        if (C.DateConcert > DateTime.Today) // только актуальные концерты
                        {
                            dataGridView1.Rows.Add(); // добавляем новую строку

                            // вставляем данные в ячейки строки //
                            dataGridView1.Rows[i].Cells[0].Value = "Купить";
                            dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.White;
                            dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                            dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                            dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                            dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();

                            dataGridView1.Rows[i].Cells[5].Value = "Просмотр";
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                            dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Black;

                            i++;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Книга жалоб.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Reported reported = new Reported();
            reported.ShowDialog();
        }

        /// <summary>
        /// Кнопка вернуть билет.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Return _Return = new Return();
            _Return.ShowDialog();
        }

        // анимации кнопок //
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gold;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Bisque;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.Gold;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Bisque;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gold;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Bisque;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Gold;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Bisque;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.Gold;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Bisque;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.Gold;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Bisque;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenAdmin admin = new OpenAdmin();
            admin.ShowDialog();
            PrintConcert();
        }
    }
}