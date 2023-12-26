﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteVariacaoAtivo.Infra.Data;

#nullable disable

namespace TesteVariacaoAtivo.Infra.Migrations
{
    [DbContext(typeof(TestAssetContext))]
    partial class TestAssetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TesteVariacaoAtivo.Domain.Entities.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("DataAsset")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
