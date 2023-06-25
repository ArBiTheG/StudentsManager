﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentsManagerData;

#nullable disable

namespace StudentsManagerData.Migrations
{
    [DbContext(typeof(StudentsContext))]
    partial class StudentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("StudentsManagerData.Tables.Curator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Exp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("PersonId");

                    b.ToTable("Curators");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Decree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeDecree")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Decrees");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<int>("CuratorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReasonDeleted")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("TypeTraining")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CuratorId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EducationDateFinish")
                        .HasColumnType("TEXT");

                    b.Property<string>("EducationDocumentType")
                        .HasColumnType("TEXT");

                    b.Property<string>("EducationNumber")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EducationSchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationSeries")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("INN")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportCountry")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PassportDateGiven")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportGiven")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportSeries")
                        .HasColumnType("TEXT");

                    b.Property<string>("SNILS")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EducationSchoolId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeRelation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ParentId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReasonDeleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateEntry")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateEscaped")
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEscaped")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReasonEscaped")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("PersonId");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Curator", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Person", "Person")
                        .WithOne("Curator")
                        .HasForeignKey("StudentsManagerData.Tables.Curator", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Decree", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Student", "Student")
                        .WithMany("Decrees")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Email", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Person", "Person")
                        .WithMany("Emails")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Group", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Curator", "Curator")
                        .WithMany()
                        .HasForeignKey("CuratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsManagerData.Tables.Specialty", "Specialty")
                        .WithMany("Groups")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curator");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Hobby", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Person", "Person")
                        .WithMany("Hobbies")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Person", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.School", "EducationSchool")
                        .WithMany("Persons")
                        .HasForeignKey("EducationSchoolId");

                    b.Navigation("EducationSchool");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Phone", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Relation", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Person", "Child")
                        .WithMany("Childs")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsManagerData.Tables.Person", "Parent")
                        .WithMany("Parents")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Student", b =>
                {
                    b.HasOne("StudentsManagerData.Tables.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsManagerData.Tables.Person", "Person")
                        .WithMany("Students")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Person", b =>
                {
                    b.Navigation("Childs");

                    b.Navigation("Curator");

                    b.Navigation("Emails");

                    b.Navigation("Hobbies");

                    b.Navigation("Parents");

                    b.Navigation("Phones");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.School", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Specialty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("StudentsManagerData.Tables.Student", b =>
                {
                    b.Navigation("Decrees");
                });
#pragma warning restore 612, 618
        }
    }
}
