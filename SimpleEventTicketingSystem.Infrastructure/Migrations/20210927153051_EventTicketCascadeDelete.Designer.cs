﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleEventTicketingSystem.Infrastructure.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210927153051_EventTicketCascadeDelete")]
    partial class EventTicketCascadeDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("SimpleEventTicketingSystem.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("TicketPoolPoolCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SimpleEventTicketingSystem.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("SimpleEventTicketingSystem.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("SimpleEventTicketingSystem.Domain.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SimpleEventTicketingSystem.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("TicketId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("Email");

                            b1.HasKey("TicketId");

                            b1.ToTable("Ticket");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("SimpleEventTicketingSystem.Domain.ValueObjects.FirstName", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("TicketId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("FirstName");

                            b1.HasKey("TicketId");

                            b1.ToTable("Ticket");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("SimpleEventTicketingSystem.Domain.ValueObjects.LastName", "LastName", b1 =>
                        {
                            b1.Property<Guid>("TicketId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("LastName");

                            b1.HasKey("TicketId");

                            b1.ToTable("Ticket");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Event");

                    b.Navigation("FirstName");

                    b.Navigation("LastName");
                });

            modelBuilder.Entity("SimpleEventTicketingSystem.Domain.Entities.Event", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
