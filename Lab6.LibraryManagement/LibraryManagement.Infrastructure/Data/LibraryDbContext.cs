using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(
            DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();

        public DbSet<Member> Members => Set<Member>();

        public DbSet<BorrowRecord> BorrowRecords
            => Set<BorrowRecord>();
    }
}
