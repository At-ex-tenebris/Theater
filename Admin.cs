using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Entity;

namespace Theatre
{
    public partial class Admin : Form
    {
        bool EditMode = false; // переключатель режимов редактировать-сохранить изменения

        public Admin()
        {
            InitializeComponent();
            textBox1.Text = Main.KeyAdmin;

            comboBox1.Items.Add("Представления");
            comboBox1.Items.Add("Актеры");
            comboBox1.Items.Add("Сценки");
            comboBox1.Items.Add("Билеты");
            comboBox1.Items.Add("Жалобы");
            comboBox1.Items.Add("Промокоды");
            comboBox1.SelectedIndex = 0;

            PrintConcert();
        }

        /// <summary>
        /// Метод вывода информации о концерте
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
            column1.HeaderText = "Id представления";
            column1.Name = "Column1";
            column2.HeaderText = "Название представления";
            column2.Name = "Column2";
            column3.HeaderText = "Дата";
            column3.Name = "Column3";
            column4.HeaderText = "Время начала";
            column4.Name = "Column4";
            column5.HeaderText = "Продолжительность (мин)";
            column5.Name = "Column5";
            column6.HeaderText = "Стоимость билета";
            column6.Name = "Column6";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5, column6 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[5].Width = 180;

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
            foreach (Concert C in Main.db.Concerts)
            {
                if (C.DateConcert > DateTime.Today) // только актуальные концерты
                {
                    dataGridView1.Rows.Add(); // добавляем новую строку

                    // вставляем данные в ячейки строки //
                    dataGridView1.Rows[i].Cells[0].Value = C.ConcertID;
                    dataGridView1.Rows[i].Cells[1].Value = C.NameConcert;
                    dataGridView1.Rows[i].Cells[2].Value = C.DateConcert.ToShortDateString();
                    dataGridView1.Rows[i].Cells[3].Value = C.DateConcert.ToString("HH:mm");
                    dataGridView1.Rows[i].Cells[4].Value = C.Time.ToString();
                    dataGridView1.Rows[i].Cells[5].Value = C.Price.ToString();

                    i++;
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
            button3.BackColor = Color.Red;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Bisque;
            button3.ForeColor = Color.Black;
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
        /// Кнопка обновить ключ админа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SaveAdmin();
        }

        /// <summary>
        /// Метод сохранения ключа админа.
        /// </summary>
        private void SaveAdmin()
        {
            if (textBox1.Text != "")
                Main.KeyAdmin = textBox1.Text;
            textBox1.Text = Main.KeyAdmin;
        }

        /// <summary>
        /// Выборка данных из списка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                PrintConcert();
            if (comboBox1.SelectedIndex == 1)
                PrintActers();
            if (comboBox1.SelectedIndex == 2)
                PrintPerfomance();
            if (comboBox1.SelectedIndex == 3)
                PrintTicket();
            if (comboBox1.SelectedIndex == 4)
                PrintReported();
            if (comboBox1.SelectedIndex == 5)
                PrintCode();
        }

        /// <summary>
        /// Вывод информации о промокодах.
        /// </summary>
        private void PrintCode()
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

            // параметры столбцов //
            column1.HeaderText = "Id промокода";
            column1.Name = "Column1";
            column2.HeaderText = "Промокод";
            column2.Name = "Column2";
            column3.HeaderText = "Процент скидки";
            column3.Name = "Column3";
            column4.HeaderText = "Действует до";
            column4.Name = "Column4";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;

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
            foreach (PromoСode P in Main.db.PromoСodes)
            {
                dataGridView1.Rows.Add(); // добавляем новую строку

                // вставляем данные в ячейки строки //
                dataGridView1.Rows[i].Cells[0].Value = P.ID;
                dataGridView1.Rows[i].Cells[1].Value = P.NameCode;
                dataGridView1.Rows[i].Cells[2].Value = P.buff;
                dataGridView1.Rows[i].Cells[3].Value = P.DataLive;

                i++;
            }
        }

        /// <summary>
        /// Вывод информации о жалобах.
        /// </summary>
        private void PrintReported()
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

            // параметры столбцов //
            column1.HeaderText = "Id жалобы";
            column1.Name = "Column1";
            column2.HeaderText = "Тема жалобы";
            column2.Name = "Column2";
            column3.HeaderText = "Суть жалобы";
            column3.Name = "Column3";
            column4.HeaderText = "Дата оставления жалобы";
            column4.Name = "Column4";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;

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
            foreach (Report R in Main.db.Reports)
            {
                dataGridView1.Rows.Add(); // добавляем новую строку

                // вставляем данные в ячейки строки //
                dataGridView1.Rows[i].Cells[0].Value = R.ID;
                dataGridView1.Rows[i].Cells[1].Value = R.TypeReport;
                dataGridView1.Rows[i].Cells[2].Value = R.TextReport;
                dataGridView1.Rows[i].Cells[3].Value = R.date.ToShortDateString();

                i++;
            }
        }

        /// <summary>
        /// Вывод информации о билетах.
        /// </summary>
        private void PrintTicket()
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
            column1.HeaderText = "Id билета";
            column1.Name = "Column1";
            column2.HeaderText = "Id представления";
            column2.Name = "Column2";
            column3.HeaderText = "Ряд";
            column3.Name = "Column3";
            column4.HeaderText = "Место";
            column4.Name = "Column4";
            column5.HeaderText = "Стоимость билета";
            column5.Name = "Column5";
            column6.HeaderText = "Счет оплаты";
            column6.Name = "Column6";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5, column6 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
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
            foreach (Ticket T in Main.db.Tickets)
            {
                dataGridView1.Rows.Add(); // добавляем новую строку

                // вставляем данные в ячейки строки //
                dataGridView1.Rows[i].Cells[0].Value = T.ID;
                dataGridView1.Rows[i].Cells[1].Value = T.IdConcetr;
                dataGridView1.Rows[i].Cells[2].Value = T.Row;
                dataGridView1.Rows[i].Cells[3].Value = T.Place;
                dataGridView1.Rows[i].Cells[4].Value = T.Money;
                dataGridView1.Rows[i].Cells[5].Value = T.Card;

                i++;
            }  
        }

        /// <summary>
        /// Метод вывода информации об сценках.
        /// </summary>
        private void PrintPerfomance()
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

            // параметры столбцов //
            column1.HeaderText = "Id представления";
            column1.Name = "Column1";
            column2.HeaderText = "Id сцены";
            column2.Name = "Column2";
            column3.HeaderText = "Имя композиции";
            column3.Name = "Column3";
            column4.HeaderText = "Id актера";
            column4.Name = "Column4";
            column5.HeaderText = "Продолжительность в минутах";
            column5.Name = "Column5";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;

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
            foreach (Concert C in Main.db.Concerts.Include(P => P.Performances))
            {
                foreach (Performance P in C.Performances)
                {
                    foreach (Octor O in Main.db.Actors)
                    {
                        if (O.ID == P.IdActor)
                        {
                            dataGridView1.Rows.Add(); // добавляем новую строку

                            // вставляем данные в ячейки строки //
                            dataGridView1.Rows[i].Cells[0].Value = C.ConcertID;
                            dataGridView1.Rows[i].Cells[1].Value = P.ID;
                            dataGridView1.Rows[i].Cells[2].Value = P.NamePerformance;
                            dataGridView1.Rows[i].Cells[3].Value = O.ID;
                            dataGridView1.Rows[i].Cells[4].Value = P.Time;

                            i++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод вывода информации об актерах.
        /// </summary>
        private void PrintActers()
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

            // параметры столбцов //
            column1.HeaderText = "Id представления";
            column1.Name = "Column1";
            column2.HeaderText = "Id Актера";
            column2.Name = "Column2";
            column3.HeaderText = "Имя актера";
            column3.Name = "Column3";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3 });

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;

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
            foreach (Concert C in Main.db.Concerts.Include(P=>P.Performances))
            {
                foreach (Performance P in C.Performances)
                {
                    foreach (Octor O in Main.db.Actors)
                    {
                        if (O.ID == P.IdActor)
                        {
                            dataGridView1.Rows.Add(); // добавляем новую строку

                            // вставляем данные в ячейки строки //
                            dataGridView1.Rows[i].Cells[0].Value = C.ConcertID;
                            dataGridView1.Rows[i].Cells[1].Value = O.ID;
                            dataGridView1.Rows[i].Cells[2].Value = O.NameActor;

                            i++;
                        }
                    }
                }
            }
            foreach (Octor O in Main.db.Actors)
            {
                int J = 0;
                for (int K = 0; K < dataGridView1.Rows.Count - 1; K++) // идем по всей таблице и выводим актеров одиночек
                {
                    if (O.ID != Convert.ToInt32(dataGridView1.Rows[K].Cells[1].Value))
                        J++;     
                }
                if (J == dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.Rows.Add(); // добавляем новую строку

                    // вставляем данные в ячейки строки //
                    dataGridView1.Rows[i].Cells[0].Value = "-";
                    dataGridView1.Rows[i].Cells[1].Value = O.ID;
                    dataGridView1.Rows[i].Cells[2].Value = O.NameActor;

                    i++;
                }
            }
        }

        /// <summary>
        /// Кнопка удалить все.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены, что хотите уничтожить все данные в БД?", "Красная кнопка!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int count = 0;
                // жалоб //
                foreach (Report R in Main.db.Reports)
                    count++;
                while (count != 0)
                {
                    foreach (Report R in Main.db.Reports)
                    {
                        Main.db.Reports.Remove(R);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                // удаление промокодов //
                foreach (PromoСode P in Main.db.PromoСodes)
                    count++;
                while (count != 0)
                {
                    foreach (PromoСode P in Main.db.PromoСodes)
                    {
                        Main.db.PromoСodes.Remove(P);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                // удаление актеров //
                foreach (Octor O in Main.db.Actors)
                    count++;
                while (count != 0)
                {
                    foreach (Octor O in Main.db.Actors)
                    {
                        Main.db.Actors.Remove(O);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                // удаление композиций //
                foreach (Performance p in Main.db.Performances)
                    count++;
                while (count != 0)
                {
                    foreach (Performance p in Main.db.Performances)
                    {
                        Main.db.Performances.Remove(p);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                // удаление билетов //
                foreach (Ticket T in Main.db.Tickets)
                    count++;
                while (count != 0)
                {
                    foreach (Ticket T in Main.db.Tickets)
                    {
                        Main.db.Tickets.Remove(T);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                // удаление представлений //
                foreach (Concert C in Main.db.Concerts)
                    count++;
                while (count != 0)
                {
                    foreach (Concert C in Main.db.Concerts)
                    {
                        Main.db.Concerts.Remove(C);
                        break;
                    }
                    Main.db.SaveChanges();
                    count--;
                }
                Main.db.SaveChanges();
                MessageBox.Show("База данных организации театра успешно удалена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (comboBox1.SelectedIndex == 0)
                    PrintConcert();
                if (comboBox1.SelectedIndex == 1)
                    PrintActers();
                if (comboBox1.SelectedIndex == 2)
                    PrintPerfomance();
                if (comboBox1.SelectedIndex == 3)
                    PrintTicket();
                if (comboBox1.SelectedIndex == 4)
                    PrintReported();
                if (comboBox1.SelectedIndex == 5)
                    PrintCode();
            }
        }

        /// <summary>
        /// Кнопка изменить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (EditMode == false)
            {
                button6.Text = "Сохранить";
                EditMode = true;
                if (comboBox1.SelectedIndex == 0)
                    EditConcert();
                if (comboBox1.SelectedIndex == 1)
                    EditActers();
                if (comboBox1.SelectedIndex == 2)
                    EditPerfomance();
                if (comboBox1.SelectedIndex == 3)
                    EditTicket();
                if (comboBox1.SelectedIndex == 4)
                    EditReported();
                if (comboBox1.SelectedIndex == 5)
                    EditCode();
            }
            else // сохраняем изменения
            {
                button6.Text = "Изменить";
                EditMode = false;
                try
                {
                    if (comboBox1.SelectedIndex == 0)
                        SaveConcert();
                    if (comboBox1.SelectedIndex == 1)
                        SaveActors();
                     if (comboBox1.SelectedIndex == 2)
                         SavePerfomance();
                     if (comboBox1.SelectedIndex == 3)
                         SaveTicket();
                     if (comboBox1.SelectedIndex == 4)
                         SaveReported();
                     if (comboBox1.SelectedIndex == 5)
                         SaveCode();
                }
                catch { }
            }            
        }

        /// <summary>
        /// Метод настрйоки параметров редактирования таблицы для промокодов.
        /// </summary>
        private void EditCode()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все
            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод сохранения изменения таблицы после изменения промокодов.
        /// </summary>
        private void SaveCode()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); // забираем id

                foreach (PromoСode P in Main.db.PromoСodes) // ищем в БД объект с таким же айди
                {
                    if (P.ID == id) // нашли, теперь нужно его обновить
                    {
                        P.NameCode = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        P.buff = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        P.DataLive = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        break;
                    }
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintCode();
        }

        /// <summary>
        /// Метод настройки параметров редактирования таблицы для жалоб.
        /// </summary>
        private void EditReported()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все
            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод сохранения данных о жалобах после изменения таблицы
        /// </summary>
        private void SaveReported()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); // забираем id

                foreach (Report R in Main.db.Reports) // ищем в БД объект с таким же айди
                {
                    if (R.ID == id) // нашли, теперь нужно его обновить
                    {
                        R.TypeReport = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        R.TextReport = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        R.date = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        break;
                    }
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintReported();
        }

        /// <summary>
        /// Метод настройки параметров редактирования таблицы для билетов.
        /// </summary>
        private void EditTicket()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все

            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
            dataGridView1.Columns[1].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод сохранения данных о билетах после изменения таблицы.
        /// </summary>
        private void SaveTicket()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); // забираем id

                foreach (Ticket T in Main.db.Tickets) // ищем в БД объект с таким же айди
                {
                    if (T.ID == id) // нашли, теперь нужно его обновить
                    {
                        T.Row = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        T.Place = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        T.Money = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        T.Card = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        break;
                    }
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintTicket();
        }

        /// <summary>
        /// Метод настройки параметров редактирования таблицы для композиций. 
        /// </summary>
        private void EditPerfomance()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все

            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
            dataGridView1.Columns[1].ReadOnly = true; // id запрещаем редачить
            dataGridView1.Columns[3].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод сохранения данных о композициях после изменения таблицы.
        /// </summary>
        private void SavePerfomance()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); // забираем id

                foreach (Performance P in Main.db.Performances) // ищем в БД объект с таким же айди
                {
                    if (P.ID == id) // нашли, теперь нужно его обновить
                    {
                        P.NamePerformance = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        P.Time = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        break;
                    }
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintPerfomance();
        }

        /// <summary>
        /// Метод сохранения данных о актерах после изменения таблицы.
        /// </summary>
        private void SaveActors()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); // забираем id

                foreach (Octor O in Main.db.Actors) // ищем в БД объект с таким же айди
                {
                    if (O.ID == id) // нашли, теперь нужно его обновить
                    {
                        O.NameActor = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        break;
                    }      
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintActers();
        }

        /// <summary>
        /// Метод настрйоки параметров редактирования таблицы для актеров.
        /// </summary>
        private void EditActers()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все
            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
            dataGridView1.Columns[1].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод настройки параметров редактирования таблицы для концертов.
        /// </summary>
        private void EditConcert()
        {
            dataGridView1.ReadOnly = false; // разрешаем редачить все
            dataGridView1.Columns[0].ReadOnly = true; // id запрещаем редачить
        }

        /// <summary>
        /// Метод сохранения данных о концертах после изменения таблицы.
        /// </summary>
        private void SaveConcert()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // идем по всей таблице и обновляем значения в БД
            {
                int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value); // забираем id концертов

                foreach (Concert C in Main.db.Concerts) // ищем в БД концерт с таким же айди
                {
                    if (C.ConcertID == id) // нашли концерт, теперь нужно его обновить
                    {
                        C.NameConcert = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        C.DateConcert = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        C.DateConcert = DateTime.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        C.Time = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        C.Price = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        break;
                    }
                }
            }
            Main.db.SaveChanges();
            dataGridView1.ReadOnly = true;
            PrintConcert();
        }

        /// <summary>
        /// Кнопка удалить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                    DeleteConcert();
                if (comboBox1.SelectedIndex == 1)
                    DeleteActors();
                if (comboBox1.SelectedIndex == 2)
                    DeletePerformance();
                if (comboBox1.SelectedIndex == 3)
                    DeleteTicket();
                if (comboBox1.SelectedIndex == 4)
                    DeleteReported();
                if (comboBox1.SelectedIndex == 5)
                    DeleteCode();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления промокода по указке из таблицы.
        /// </summary>
        private void DeleteCode()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[0].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (PromoСode P in Main.db.PromoСodes)
                {
                    if (P.ID == (int)id)
                    {
                        Main.db.PromoСodes.Remove(P);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintReported();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления жалобы по указке в таблице.
        /// </summary>
        private void DeleteReported()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[0].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (Report R in Main.db.Reports)
                {
                    if (R.ID == (int)id)
                    {
                        Main.db.Reports.Remove(R);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintReported();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления билета по указке в таблице.
        /// </summary>
        private void DeleteTicket()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[0].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (Ticket T in Main.db.Tickets)
                {
                    if (T.ID == (int)id)
                    {
                        Main.db.Tickets.Remove(T);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintTicket();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления композиции по указке в таблице.
        /// </summary>
        private void DeletePerformance()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[1].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (Performance P in Main.db.Performances)
                {
                    if (P.ID == (int)id)
                    {
                        Main.db.Performances.Remove(P);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintPerfomance();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления актера по указке в таблице.
        /// </summary>
        private void DeleteActors()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[1].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (Octor O in Main.db.Actors)
                {
                    if (O.ID == (int)id)
                    {
                        Main.db.Actors.Remove(O);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintActers();
            }
            catch { }
        }

        /// <summary>
        /// Метод удаления концерта по указке в таблице.
        /// </summary>
        private void DeleteConcert()
        {
            int a = dataGridView1.CurrentRow.Index;
            var id = dataGridView1.Rows[a].Cells[0].Value; // id удаляемого элемента

            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                foreach (Concert C in Main.db.Concerts)
                {
                    if (C.ConcertID == (int)id)
                    {
                        Main.db.Concerts.Remove(C);
                        break;
                    }
                }
                Main.db.SaveChanges();
                PrintConcert();
            }
            catch { }
        }

        /// <summary>
        /// Кнопка добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                AddConcert();
            if (comboBox1.SelectedIndex == 1)
                AddActors();
            if (comboBox1.SelectedIndex == 2)
                AddPerformance();
            if (comboBox1.SelectedIndex == 3)
                MessageBox.Show("Билеты добавляется через главное меню клиентов или кассиром-))");
            if (comboBox1.SelectedIndex == 4)
                MessageBox.Show("Жалуется только кассир или клиент через главное меню :)");
            if (comboBox1.SelectedIndex == 5)
                AddCode();
        }

        /// <summary>
        /// Метод добавления промокода.
        /// </summary>
        private void AddCode()
        {
            AddPromo addPromo = new AddPromo();
            addPromo.ShowDialog();
            PrintCode();
        }

        /// <summary>
        /// Метод добавления новой композиции.
        /// </summary>
        private void AddPerformance()
        {
            AddPerformances addPerformances = new AddPerformances();
            addPerformances.ShowDialog();
            PrintPerfomance();
        }

        /// <summary>
        /// Метод добавления нового концерта.
        /// </summary>
        private void AddConcert()
        {
            AddConcerts addConcerts = new AddConcerts();
            addConcerts.ShowDialog();
            PrintConcert();
        }

        /// <summary>
        /// Метод добавления нового актера.
        /// </summary>
        private void AddActors()
        {
            AddActor addActor = new AddActor();
            addActor.ShowDialog();
            PrintActers();
        }
    }
}