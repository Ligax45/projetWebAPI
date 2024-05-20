﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetWebApi.Data.DbContext;

#nullable disable

namespace ProjetWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240520090605_UpdateReference")]
    partial class UpdateReference
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjetWebApi.Models.Profil", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("Utilisateurid")
                        .HasColumnType("integer");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Utilisateurid");

                    b.ToTable("profil");
                });

            modelBuilder.Entity("ProjetWebApi.Models.Utilisateur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mdp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("utilisateur");
                });

            modelBuilder.Entity("ProjetWebApi.Models.Profil", b =>
                {
                    b.HasOne("ProjetWebApi.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("Utilisateurid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
