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
    internal class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(t => t.Id);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Ruolo).IsRequired();
        }
    }
}
