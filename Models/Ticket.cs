namespace Theatre
{
    public class Ticket // Билеты
    {
        public int ID { get; set; } // первичный ключ
        public int IdConcetr { get; set; } // концерт
        public int Row { get; set; } // ряд
        public int Place { get; set; } // место в ряду
        public double Money { get; set; } // стоимость билета
        public string Card { get; set; } // банковская карта для вовзрата средств
        public int secret { get; set; } // для определения занято/свободно место
    }
}