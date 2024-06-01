﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourTurnFriend.Infra.Data.Context;

#nullable disable

namespace YourTurnFriend.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240601204733_AddSequence")]
    partial class AddSequence
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

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
