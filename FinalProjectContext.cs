using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Entities;

namespace FinalProject
{
    public class FinalProjectContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options) { }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Obiect> Obiects { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ConcertStudent> ConcertsStudents { get; set; }
        public DbSet<StudentGift> StudentsGifts { get; set; }
        public DbSet<StudentSong> StudentsSongs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>
          (b =>
          {
           b.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
            });

         builder.Entity<Role>
            (b =>
            {
             b.HasMany(e => e.UserRoles)
              .WithOne(e => e.Role)
              .HasForeignKey(ur => ur.RoleId)
              .IsRequired();
            });

            //one to one
            builder.Entity<Organizer>()
            .HasOne(org => org.Concert)
            .WithOne(concert => concert.Organizer);

        //one to many
        builder.Entity<Gift>()
             .HasMany(g => g.Obiects)
             .WithOne(o => o.Gift);

        //many to many
        builder.Entity<ConcertStudent>().HasKey(cs => new { cs.ConcertId, cs.StudentId });

        builder.Entity<ConcertStudent>()
            .HasOne<Concert>(cs => cs.Concert)
            .WithMany(c => c.ConcertsStudents)
            .HasForeignKey(cs => cs.ConcertId);

        builder.Entity<ConcertStudent>()
            .HasOne<Student>(cs => cs.Student)
            .WithMany(s => s.ConcertsStudents)
            .HasForeignKey(cs => cs.StudentId);


        builder.Entity<StudentGift>().HasKey(sg => new { sg.StudentId, sg.GiftId });
            
        builder.Entity<StudentGift>()
            .HasOne<Student>(sg => sg.Student)
            .WithMany(s => s.StudentsGifts)
            .HasForeignKey(sg => sg.StudentId);

        builder.Entity<StudentGift>()
            .HasOne<Gift>(sg => sg.Gift)
            .WithMany(g => g.StudentsGifts)
            .HasForeignKey(sg => sg.GiftId);

        builder.Entity<StudentSong>().HasKey(ss => new { ss.StudentId, ss.SongId });
        
        builder.Entity<StudentSong>()
            .HasOne<Student>(ss => ss.Student)
            .WithMany(s => s.StudentsSongs)
            .HasForeignKey(ss => ss.StudentId);

        builder.Entity<StudentSong>()
            .HasOne<Song>(ss => ss.Song)
            .WithMany(s => s.StudentsSongs)
            .HasForeignKey(ss => ss.SongId);

        }
    }
}
