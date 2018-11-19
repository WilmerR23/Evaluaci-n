using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Models
{
    public class PreguntasContext : DbContext
    {
        public PreguntasContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        public DbSet<ExamenPregunta> ExamenPregunta { get; set; }
        public DbSet<OpcionPregunta> OpcionPregunta { get; set; }
        public DbSet<RespuestaPregunta> RespuestaPregunta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamenPregunta>()
                .HasKey(t => new { t.ExamenId, t.PreguntaId });

            modelBuilder.Entity<ExamenPregunta>()
                .HasOne(pt => pt.Examen)
                .WithMany(p => p.ExamenPregunta)
                .HasForeignKey(pt => pt.ExamenId);

            modelBuilder.Entity<ExamenPregunta>()
                .HasOne(pt => pt.Pregunta)
                .WithMany(t => t.ExamenPregunta)
                .HasForeignKey(pt => pt.PreguntaId);

            modelBuilder.Entity<Examen>()
                .HasMany(x => x.ExamenPregunta)
                .WithOne(c => c.Examen);
        }

    }
}
