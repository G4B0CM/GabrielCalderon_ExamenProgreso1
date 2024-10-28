using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GabrielCalderon_ExamenProgreso1.Models;

namespace GabrielCalderon_ExamenProgreso1.Data
{
    public class GabrielCalderon_ExamenProgreso1Context : DbContext
    {
        public GabrielCalderon_ExamenProgreso1Context (DbContextOptions<GabrielCalderon_ExamenProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<GabrielCalderon_ExamenProgreso1.Models.GCalderon> GCalderon { get; set; } = default!;
        public DbSet<GabrielCalderon_ExamenProgreso1.Models.Celular> Celular { get; set; } = default!;
    }
}
