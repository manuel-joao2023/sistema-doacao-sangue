using DoacaoViva.Domain.Entitys;
using DoacaoViva.Infrastructure.Notification.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DoacaoViva.Database
{
    public class DoacaoVivaContext : DbContext {
        public DoacaoVivaContext(DbContextOptions<DoacaoVivaContext> contextOptions)
            : base(contextOptions) {

        }


        public DbSet<Address> Addresss { get; set; }
        public DbSet<Donations> Donations { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<DonatorHospital> DonatorHospitals { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestBloodType> RequestBloodTypes { get; set; }
        public DbSet<Suport> Suports { get; set; }
        public DbSet<Notifications> Notifications { get; set; }

    }
}