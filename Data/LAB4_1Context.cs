using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LAB4_1.Models;

namespace LAB4_1.Data
{
    public class LAB4_1Context : DbContext
    {
        public LAB4_1Context (DbContextOptions<LAB4_1Context> options)
            : base(options)
        {

        }

        public DbSet<LAB4_1.Models.Weather> Weather { get; set; } = default!;
    }
}
