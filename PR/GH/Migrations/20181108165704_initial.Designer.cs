﻿// <auto-generated />
using GH.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GH.Migrations
{
    [DbContext(typeof(PreguntasContext))]
    [Migration("20181108165704_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GH.Models.Examen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Examenes");
                });

            modelBuilder.Entity("GH.Models.ExamenPregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamenId");

                    b.Property<int>("PreguntaId");

                    b.HasKey("Id");

                    b.HasIndex("ExamenId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("ExamenPregunta");
                });

            modelBuilder.Entity("GH.Models.Opcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.ToTable("Opciones");
                });

            modelBuilder.Entity("GH.Models.OpcionPregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OpcionId");

                    b.Property<int>("PreguntaId");

                    b.HasKey("Id");

                    b.HasIndex("OpcionId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("OpcionPregunta");
                });

            modelBuilder.Entity("GH.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("GH.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("GH.Models.RespuestaPregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PreguntaId");

                    b.Property<int>("RespuestaId");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.HasIndex("RespuestaId");

                    b.ToTable("RespuestaPregunta");
                });

            modelBuilder.Entity("GH.Models.ExamenPregunta", b =>
                {
                    b.HasOne("GH.Models.Examen", "Examen")
                        .WithMany()
                        .HasForeignKey("ExamenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GH.Models.Pregunta", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GH.Models.OpcionPregunta", b =>
                {
                    b.HasOne("GH.Models.Opcion", "Opcion")
                        .WithMany()
                        .HasForeignKey("OpcionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GH.Models.Pregunta", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GH.Models.RespuestaPregunta", b =>
                {
                    b.HasOne("GH.Models.Pregunta", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GH.Models.Respuesta", "Respuesta")
                        .WithMany()
                        .HasForeignKey("RespuestaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
