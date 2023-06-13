using System;

namespace Theatre
{
    public class PromoСode // скидочки и бонусы //
    {
        public int ID { get; set; } // первичный ключ
        public string NameCode { get; set; } // промокод
        public double buff { get; set; } // процент скидки в процентах
        public DateTime DataLive { get; set; } // Действителен до...
    }
}