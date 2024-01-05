﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Samplefy.Infrastructure.Data;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240104153349_IsDeleted")]
    partial class IsDeleted
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.Property<Guid>("AlbumsId")
                        .HasColumnType("uuid")
                        .HasColumnName("albums_id");

                    b.Property<Guid>("ArtistsId")
                        .HasColumnType("uuid")
                        .HasColumnName("artists_id");

                    b.HasKey("AlbumsId", "ArtistsId")
                        .HasName("pk_album_artist");

                    b.HasIndex("ArtistsId")
                        .HasDatabaseName("ix_album_artist_artists_id");

                    b.ToTable("album_artist", (string)null);
                });

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.Property<Guid>("ArtistsId")
                        .HasColumnType("uuid")
                        .HasColumnName("artists_id");

                    b.Property<Guid>("SongsId")
                        .HasColumnType("uuid")
                        .HasColumnName("songs_id");

                    b.HasKey("ArtistsId", "SongsId")
                        .HasName("pk_artist_song");

                    b.HasIndex("SongsId")
                        .HasDatabaseName("ix_artist_song_songs_id");

                    b.ToTable("artist_song", (string)null);
                });

            modelBuilder.Entity("Samplefy.Core.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_albums");

                    b.ToTable("albums", (string)null);
                });

            modelBuilder.Entity("Samplefy.Core.Entities.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_artist");

                    b.ToTable("artist", (string)null);
                });

            modelBuilder.Entity("Samplefy.Core.Entities.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uuid")
                        .HasColumnName("album_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_songs");

                    b.HasIndex("AlbumId")
                        .HasDatabaseName("ix_songs_album_id");

                    b.ToTable("songs", (string)null);
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.HasOne("Samplefy.Core.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_album_artist_albums_albums_id");

                    b.HasOne("Samplefy.Core.Entities.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_album_artist_artist_artists_id");
                });

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.HasOne("Samplefy.Core.Entities.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artist_song_artist_artists_id");

                    b.HasOne("Samplefy.Core.Entities.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artist_song_songs_songs_id");
                });

            modelBuilder.Entity("Samplefy.Core.Entities.Song", b =>
                {
                    b.HasOne("Samplefy.Core.Entities.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("fk_songs_albums_album_id");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Samplefy.Core.Entities.Album", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}