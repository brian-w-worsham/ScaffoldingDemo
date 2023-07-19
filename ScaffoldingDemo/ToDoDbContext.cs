using Microsoft.EntityFrameworkCore;
using ScaffoldingDemo.Models;

namespace ScaffoldingDemo
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {

        }

        public ToDoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ScaffoldingDemo.Models.ToDoListModel>? ToDoListModel { get; set; }

        public DbSet<ScaffoldingDemo.Models.Friend>? Friend { get; set; }

    }
}
