﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mycookbook.cc.MyCookBook.Base;

namespace mycookbook.cc.Migrations
{
    [DbContext(typeof(MyCookBookDb))]
    [Migration("20190105230234_Users")]
    partial class Users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("mycookbook.cc.MyCookBook.User.Repository.UserModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Blurb");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("ProfilePicture");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
