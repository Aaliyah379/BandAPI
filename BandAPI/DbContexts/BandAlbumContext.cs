using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.DbContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) :
            base(options)
        {
        }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band()
            {
                Id = Guid.Parse("0fe4776c-dfff-4134-aa03-2b7e31558186"),
                Name = "Metallica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metall"
            },
            new Band
            {
                Id = Guid.Parse("926f664c-930b-49f3-95a0-a4bf241b6c6c"),
                Name = "Guns N Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"

            },
            new Band
            {
                Id = Guid.Parse("3c0da630-dc17-4898-afd4-bbe71f5bb26d"),
                Name = "ABBA",
                Founded = new DateTime(1965, 7, 1),
                MainGenre = "Disco"
            },
            new Band
            {
                Id = Guid.Parse("a024e32a-bda3-404f-8c82-a510a37e67c2"),
                Name = "Oasis",
                Founded = new DateTime(1991, 12, 1),
                MainGenre = "Alternative"

            },
            new Band
            {
                Id = Guid.Parse("5bdb346e-1f26-41be-a7e3-254a4d2a34f4"),
                Name = "A-ha",
                Founded = new DateTime(1981, 6, 1),
                MainGenre = "Pop"
            });

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = Guid.Parse("bf3b11e9-ee82-4ccb-8e9e-5efd82652880"),
                    Title = "Master of Pappets",
                    Description = "One of the best albums ever",
                    BandId = Guid.Parse("0fe4776c-dfff-4134-aa03-2b7e31558186")
                },
                new Album
                {
                    Id = Guid.Parse("b36c8190-2c9a-4e07-817b-ff767d03e856"),
                    Title = "Appetite for Destruction",
                    Description = "Amazing Rock album with a raw sound",
                    BandId = Guid.Parse("926f664c-930b-49f3-95a0-a4bf241b6c6c")
                },
                new Album
                {
                    Id = Guid.Parse("ce41e436-1373-4fdb-9aa3-02759d4a0c63"),
                    Title = "Waterloo",
                    Description = "Very groovy sound",
                    BandId = Guid.Parse("3c0da630-dc17-4898-afd4-bbe71f5bb26d")
                },
                new Album
                {
                    Id = Guid.Parse("94c0e8ac-253c-43c7-9ef9-979d1ecb359e"),
                    Title = "Be here now",
                    Description = "Arguably one of the best albums by Oasis",
                    BandId = Guid.Parse("a024e32a-bda3-404f-8c82-a510a37e67c2")
                },
                new Album
                {
                    Id = Guid.Parse("c4d67114-ec33-494f-a5fc-c85db4dadd05"),
                    Title = "Hunting Hight and Low",
                    Description = "Awesome debut album by A-ha",
                    BandId = Guid.Parse("5bdb346e-1f26-41be-a7e3-254a4d2a34f4")
                  });
            base.OnModelCreating(modelBuilder);
                
    }
}

}
            
