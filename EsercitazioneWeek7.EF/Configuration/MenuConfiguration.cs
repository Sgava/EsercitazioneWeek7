using EsercitazioneWeek7.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek7.EF.Configuration
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(x => x.Id);
            builder.HasIndex(m =>m.Nome ).IsUnique();


            builder.HasMany(p => p.Piatti).WithOne(p => p.Menu).HasForeignKey(p => p.MenuId);
        }
    }
}
