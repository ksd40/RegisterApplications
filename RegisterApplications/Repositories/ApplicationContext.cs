using Microsoft.EntityFrameworkCore;
using RegisterApplications.Models;

namespace RegisterApplications.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RegisterAppDB;Trusted_Connection=True;");
        }

        #region Test data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>().HasData(
                new Courier
                {
                    Id = 1,
                    Name = "Валерий",
                },
                new Courier
                {
                    Id = 2,
                    Name = "Антон",

                },
                new Courier
                {
                    Id = 3,
                    Name = "Олег",
                }
            );
            modelBuilder.Entity<Bid>().HasData(
                new Bid
                {
                    Id = 1,
                    Name = "Заявка 1",
                    Status = Status.New,
                    Sender = "Иванов Иван Иванович",
                    Recipient = "Петров Петр Петрович",
                    Cargo = "Коробка"
                },
                new Bid
                {
                    Id = 2,
                    Name = "Заявка 2",
                    Status = Status.Canceled,
                    Sender = "Иванов Владислав Дмитриевич",
                    Recipient = "Мягков Виталий Олегович",
                    Cargo = "Печь для бани",
                    Comment = "Отмена из-за погодных условий",
                    CourierId = 1
                },
                new Bid
                {
                    Id = 3,
                    Name = "Заявка 3",
                    Status = Status.Done,
                    Sender = "Сидоров Олег Дмитриевич",
                    Recipient = "Пупкин Сергей Викторович",
                    Cargo = "Телефон",
                    CourierId = 2
                },
                new Bid
                {
                    Id = 4,
                    Name = "Заявка 4",
                    Status = Status.InProgress,
                    Sender = "Смирнов Юрий Николаевич",
                    Recipient = "Васильев Роман Валерьевич",
                    Cargo = "Трубы",
                    CourierId = 3
                }
            );
        }
        #endregion
    }
}
