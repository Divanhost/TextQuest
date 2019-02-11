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
    [Migration("20190211103950_initial migration")]
    partial class initialmigration
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

                    b.Property<int>("InventoryObjectId");

                    b.Property<int>("NextInteractionId");

                    b.Property<int>("SceneObjectId");

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

                    b.Property<int?>("InventoryId");

                    b.Property<bool>("IsInfinite");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryObjects");
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

                    b.Property<int>("DownSceneId");

                    b.Property<int>("InnerSceneId");

                    b.Property<int>("LeftSceneId");

                    b.Property<int>("RightSceneId");

                    b.Property<int>("UpperSceneId");

                    b.HasKey("Id");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("TextQuest.Data.SceneObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssociatedInventoryObjectId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("HasAction");

                    b.Property<bool>("IsPickable");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SceneId");

                    b.Property<int>("x");

                    b.Property<int>("y");

                    b.Property<int>("z");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedInventoryObjectId");

                    b.HasIndex("SceneId");

                    b.ToTable("SceneObjects");
                });

            modelBuilder.Entity("TextQuest.Data.InventoryObject", b =>
                {
                    b.HasOne("TextQuest.Data.Inventory")
                        .WithMany("InventoryObjects")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("TextQuest.Data.SceneObject", b =>
                {
                    b.HasOne("TextQuest.Data.InventoryObject", "AssociatedInventoryObject")
                        .WithMany()
                        .HasForeignKey("AssociatedInventoryObjectId");

                    b.HasOne("TextQuest.Data.Scene")
                        .WithMany("SceneObjects")
                        .HasForeignKey("SceneId");
                });
#pragma warning restore 612, 618
        }
    }
}
