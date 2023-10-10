using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backTalaata.Models;

namespace backTalaata.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Employee> tblEmployees { get; set; }

    }
}
