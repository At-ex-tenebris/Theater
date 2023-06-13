using System;
using System.Collections.Generic;

namespace Theatre
{
    public class Concert // концерты //
    {
        public int ConcertID { get; set; } // первичный ключ
        public string NameConcert { get; set; } // наименование концерта
        public DateTime DateConcert { get; set; } // дата и время начала
        public int Time { get; set; } // продолжительность, складывается из всех представлений входящий в концерт
        public double Price { get; set; } // стоимость обычного места (вип-места и ужасные места будут вычисляться исходя из стоимости стандартного билета)

        public ICollection<PromoСode> PromoСodes { get; set; } // промо-коллекция
        public ICollection<Performance> Performances { get; set; } // коллекция музыки
        public ICollection<Ticket> Tickets { get; set; } // коллекция билетов

        // конструктор //
        // при создании объекта даем ему возможность хранить в себе список музыки и промокода для скидки и билеты //
        public Concert()
        {
            PromoСodes = new List<PromoСode>();
            Performances = new List<Performance>();
            Tickets = new List<Ticket>();
        }
    }
}