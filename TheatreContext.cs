using System.Data.Entity;

namespace Theatre
{
    public class TheatreContext : DbContext
    {
        // контекст данных //
        public TheatreContext() : base("baseNv9")
        { }

        // концерты //
        public DbSet<Concert> Concerts { get; set; }
        // исполнитель //
        public DbSet<Octor> Actors { get; set; }
        // Музыка //
        public DbSet<Performance> Performances { get; set; }
        // билеты //
        public DbSet<Ticket> Tickets { get; set; }
        // промокоды //
        public DbSet<PromoСode> PromoСodes { get; set; }
        // жалобы //
        public DbSet<Report> Reports { get; set; }
    }
}