﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextQuest.Data;

namespace TextQuest.Data.Migrations
{
    [DbContext(typeof(TextQuestDbContext))]
    [Migration("20190220073310_added spawn")]
    partial class addedspawn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TextQuest.Data.Interaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InteractingInventoryObjectId");

                    b.Property<int?>("InteractingObjectId");

                    b.Property<bool>("IsAllowed");

                    b.Property<bool>("IsSpawn");

                    b.Property<int?>("NextInteractionId");

                    b.Property<string>("Sound");

                    b.Property<string>("SpecialEvent");

                    b.Property<int?>("TargetInventoryObjectId");

                    b.Property<int?>("TargetObjectId");

                    b.HasKey("Id");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("TextQuest.Data.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("TextQuest.Data.InventoryObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Decription")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsInfinite");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("InventoryObjects");
                });

            modelBuilder.Entity("TextQuest.Data.Models.Inventory_InventoryObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventoryId");

                    b.Property<int>("InventoryObjectId");

                    b.HasKey("Id");

                    b.ToTable("Inventory_InventoryObjects");
                });

            modelBuilder.Entity("TextQuest.Data.Scene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundImageUrl")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("TextQuest.Data.SceneObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssociatedInventoryObjectId");

                    b.Property<int?>("AssociatedSceneObjectId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("HasAction");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("InnerPassSceneID");

                    b.Property<bool>("IsInnerPass");

                    b.Property<bool>("IsPickable");

                    b.Property<bool>("IsSpawned");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SceneId");

                    b.Property<int>("x");

                    b.Property<int>("y");

                    b.Property<int>("z");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedInventoryObjectId");

                    b.HasIndex("AssociatedSceneObjectId");

                    b.HasIndex("SceneId");

                    b.ToTable("SceneObjects");
                });

            modelBuilder.Entity("TextQuest.Data.SceneObject", b =>
                {
                    b.HasOne("TextQuest.Data.InventoryObject", "AssociatedInventoryObject")
                        .WithMany()
                        .HasForeignKey("AssociatedInventoryObjectId");

                    b.HasOne("TextQuest.Data.SceneObject", "AssociatedSceneObject")
                        .WithMany()
                        .HasForeignKey("AssociatedSceneObjectId");

                    b.HasOne("TextQuest.Data.Scene")
                        .WithMany("SceneObjects")
                        .HasForeignKey("SceneId");
                });
#pragma warning restore 612, 618
        }
    }
}
