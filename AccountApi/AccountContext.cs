using AccountApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountApi
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext>options):base(options)
        {

        }

        public DbSet<WordUser> WordUsers { get; set; }
    }
}
