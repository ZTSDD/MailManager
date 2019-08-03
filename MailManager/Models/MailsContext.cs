using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailManager.Models
{
    public class MailsContext : DbContext
    {
        public DbSet<Mail> Mails { get; set; }

        public MailsContext(DbContextOptions<MailsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
