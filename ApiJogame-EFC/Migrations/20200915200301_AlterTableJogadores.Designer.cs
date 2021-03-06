﻿// <auto-generated />
using System;
using ApiJogame_EFC.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiJogame_EFC.Migrations
{
    [DbContext(typeof(JogadorContext))]
    [Migration("20200915200301_AlterTableJogadores")]
    partial class AlterTableJogadores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiJogame_EFC.Domains.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("ApiJogame_EFC.Domains.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("JogadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("ApiJogame_EFC.Domains.JogosJogadores", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJogador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdJogo")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdJogador");

                    b.ToTable("JogosJogadores");
                });

            modelBuilder.Entity("ApiJogame_EFC.Domains.Jogo", b =>
                {
                    b.HasOne("ApiJogame_EFC.Domains.Jogador", null)
                        .WithMany("JogadorJogos")
                        .HasForeignKey("JogadorId");
                });

            modelBuilder.Entity("ApiJogame_EFC.Domains.JogosJogadores", b =>
                {
                    b.HasOne("ApiJogame_EFC.Domains.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("IdJogador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiJogame_EFC.Domains.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("IdJogador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
