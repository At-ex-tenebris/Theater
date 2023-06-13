using System;

namespace Theatre
{
    public class Report
    {
        public int ID { get; set; } // первичный ключ
        public string TypeReport { get; set; } // тема жалобы
        public string TextReport { get; set; } // текст жалобы
        public DateTime date { get; set; } // дата оставления жалобы
    }
}