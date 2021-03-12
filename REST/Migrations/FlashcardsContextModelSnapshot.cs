﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST.Data;

namespace REST.Migrations
{
    [DbContext(typeof(FlashcardsContext))]
    partial class FlashcardsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REST.Model.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeckOfCardsID")
                        .HasColumnType("int");

                    b.Property<string>("TextBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextFront")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardID");

                    b.HasIndex("DeckOfCardsID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("REST.Model.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeckOfCardsID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("DeckOfCardsID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("REST.Model.DeckOfCards", b =>
                {
                    b.Property<int>("DeckOfCardsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DeckOfCardsID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserID");

                    b.ToTable("DecksOfCards");
                });

            modelBuilder.Entity("REST.Model.Like", b =>
                {
                    b.Property<int>("LikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeckOfCardsID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LikeID");

                    b.HasIndex("DeckOfCardsID");

                    b.HasIndex("UserID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("REST.Model.SubComment", b =>
                {
                    b.Property<int>("SubCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentID")
                        .HasColumnType("int");

                    b.Property<int?>("SubCommentedByUserID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCommentID");

                    b.HasIndex("CommentID");

                    b.HasIndex("SubCommentedByUserID");

                    b.ToTable("SubComments");
                });

            modelBuilder.Entity("REST.Model.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("REST.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("REST.Model.Card", b =>
                {
                    b.HasOne("REST.Model.DeckOfCards", "DeckOfCards")
                        .WithMany("Cards")
                        .HasForeignKey("DeckOfCardsID");

                    b.Navigation("DeckOfCards");
                });

            modelBuilder.Entity("REST.Model.Comment", b =>
                {
                    b.HasOne("REST.Model.DeckOfCards", "DeckOfCards")
                        .WithMany("Comments")
                        .HasForeignKey("DeckOfCardsID");

                    b.HasOne("REST.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID");

                    b.Navigation("DeckOfCards");

                    b.Navigation("User");
                });

            modelBuilder.Entity("REST.Model.DeckOfCards", b =>
                {
                    b.HasOne("REST.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID");

                    b.HasOne("REST.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("REST.Model.Like", b =>
                {
                    b.HasOne("REST.Model.DeckOfCards", "DeckOfCards")
                        .WithMany("Likes")
                        .HasForeignKey("DeckOfCardsID");

                    b.HasOne("REST.Model.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserID");

                    b.Navigation("DeckOfCards");

                    b.Navigation("User");
                });

            modelBuilder.Entity("REST.Model.SubComment", b =>
                {
                    b.HasOne("REST.Model.Comment", "Comment")
                        .WithMany("SubComments")
                        .HasForeignKey("CommentID");

                    b.HasOne("REST.Model.User", "SubCommentedBy")
                        .WithMany("SubComments")
                        .HasForeignKey("SubCommentedByUserID");

                    b.Navigation("Comment");

                    b.Navigation("SubCommentedBy");
                });

            modelBuilder.Entity("REST.Model.Comment", b =>
                {
                    b.Navigation("SubComments");
                });

            modelBuilder.Entity("REST.Model.DeckOfCards", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("REST.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("SubComments");
                });
#pragma warning restore 612, 618
        }
    }
}
