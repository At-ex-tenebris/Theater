namespace Theatre
{
    public class Performance // музыка //
    {
        public int ID { get; set; } // первичный ключ
        public string NamePerformance { get; set; } // имя композиции
        public int IdActor { get; set; } // айди артиста
        public double Time { get; set; } // продолжительность композиции в минутах
    }
}