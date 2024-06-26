﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourTurnFriend.Infra.Data.Context;

#nullable disable

namespace YourTurnFriend.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("YTF_USER_ROLE", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("RolesId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("YTF_USER_ROLE");
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.Event.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("DateOfLastEvent")
                        .HasColumnType("TEXT")
                        .HasColumnName("DATE_LAST_EVENT");

                    b.Property<string>("DateOfNextEvent")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DATE_NEXT_EVENT");

                    b.Property<string>("Frequence")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IdOfNextMemberInTurn")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID_NEXT_MEMBER_IN_TURN");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID_OWNER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.ToTable("YTF_EVENT", (string)null);
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.Event.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID_EVENT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("NAME");

                    b.Property<int?>("SequenceInEvent")
                        .HasColumnType("INTEGER")
                        .HasColumnName("SEQUENCE_IN_EVENT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("YTF_MEMBER", (string)null);
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.Role.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("YTF_ROLE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f4706406-9ef9-4b13-a137-43d04a0ba009",
                            Name = "DEFAULT"
                        },
                        new
                        {
                            Id = "63b4e757-6e24-4507-8f47-9030b17d85bd",
                            Name = "ADMIN"
                        });
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("CREATED_AT");

                    b.Property<string>("LastUpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("LAST_UPDATED_AT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.ToTable("YTF_USER", (string)null);
                });

            modelBuilder.Entity("YourTurnFriend.Infra.Data.OutBox.OutBoxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("CONTENT");

                    b.Property<string>("OcurredOn")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("OCURRED_ON");

                    b.Property<string>("ProcessedOn")
                        .HasColumnType("TEXT")
                        .HasColumnName("PROCESSED_ON");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("TYPE");

                    b.HasKey("Id");

                    b.ToTable("YTF_OUT_BOX_MESSAGE", (string)null);
                });

            modelBuilder.Entity("YTF_USER_ROLE", b =>
                {
                    b.HasOne("YourTurnFriend.Domain.Entities.Role.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourTurnFriend.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.Event.Member", b =>
                {
                    b.HasOne("YourTurnFriend.Domain.Entities.Event.Event", null)
                        .WithMany("Members")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourTurnFriend.Domain.Entities.Event.Event", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
