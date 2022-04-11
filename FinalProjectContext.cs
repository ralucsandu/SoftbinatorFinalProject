using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class FinalProjectContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Obiect> Obiects { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ConcertStudent> ConcertsStudents { get; set; }
        public DbSet<StudentGift> StudentsGifts { get; set; }
        public DbSet<StudentSong> StudentsSongs { get; set; }

    public FinalProjectContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

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

        base.OnModelCreating(builder);
        }
    }
}
