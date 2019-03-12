using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderBy {
    class Program {

        static bool Insert(DbContextOptions options) {
            using (var context = new MyContext(options)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var data = Enumerable.Range(1, 10).Select(x => new Student());
                context.Students.AddRange(data);
                context.SaveChanges();
            }
            return true;
        }

        static bool Order(DbContextOptions options) {
            using (var context = new MyContext(options)) {
                var rs = context.Students.OrderBy(x => x.ThaiText).Select(x => new { Text = x.ThaiText });
                DynamicTables.DynamicTable.From(rs).Write();
            }
            return true;
        }

        static void Main(string[] args) {
            var command = args[0];
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql("Host=localhost;User Id=postgres;Password=1234;Database=OrderBy");
            var options = builder.Options;

            var rs = command switch
            {
                "--insert" => Insert(options),
                "--order" => Order(options),
                _ => true
            };
        }
    }
}
