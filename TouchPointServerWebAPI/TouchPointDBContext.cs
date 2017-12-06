namespace TouchPointServerWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TouchPointDBContext : DbContext
    {
        public TouchPointDBContext()
            : base("name=TouchPointDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<CourseDB> CourseDBs { get; set; }
        public virtual DbSet<StudentDB> StudentDBs { get; set; }
        public virtual DbSet<TeacherDB> TeacherDBs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDB>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<CourseDB>()
                .Property(e => e.Teacher_ID)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDB>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDB>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDB>()
                .Property(e => e.E_Mail)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherDB>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherDB>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherDB>()
                .Property(e => e.E_Mail)
                .IsUnicode(false);
        }
    }
}
