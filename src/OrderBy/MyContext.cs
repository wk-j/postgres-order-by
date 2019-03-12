using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderBy {
    class Text {
        public static string[] A = new[] {
            "กตเวทิตา",
            "กตเวที",
            "กบฏ",
            "กรมขุน",
            "กรมคลัง",
            "กรมท่า",
            "กรมธรรม์",
            "กรมนา",
            "กรมพระ",
            "กรมวัง",
            "กรมเวียง",
            "กรมหมื่น",
            "กรมหลวง",
            "กรรมวิธี",
            "กรรมาธิการ",
            "กลวิธี",
            "กลอักษร",
            "กาลสมัย",
            "กาฬโรค",
            "กำเนิด",
            "กุลธิดา",
            "กุลสตรี",
            "เกษตรกรรม"
        };
    }

    public class Student {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string TA { set; get; } = Text.A[new Random().Next(Text.A.Length)];

        [Column("TB", TypeName = "Text COLLATE \"C\"")]
        public string TB { set; get; } = Text.A[new Random().Next(Text.A.Length)];
        public string TC { set; get; } = Text.A[new Random().Next(Text.A.Length)];
    }

    public class MyContext : DbContext {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>()
                .Property(x => x.TA)
                .HasAnnotation("COLLATE", "th-TH-x-icu");
        }

    }
}