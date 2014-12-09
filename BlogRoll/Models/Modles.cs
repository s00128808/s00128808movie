using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace BlogRoll.Models
{
    internal class MovieSeed : DropCreateDatabaseAlways<MovieDB>
    {
        protected override void Seed(MovieDB context)
        {
#region Seed Actors
            var actors = new List<Actor>
            {
                  new Actor() {ActorName = "Samuel L Jackson", ActorID = 1},
                  new Actor() {ActorName = "Robert Downey Jr", ActorID = 2},
                  new Actor() {ActorName = "Scarlett Johansoon", ActorID = 3},
                  new Actor() {ActorName = "Chris Evans", ActorID = 4},
                  new Actor() {ActorName = "Mark Ruffalo", ActorID = 5},
                  new Actor() {ActorName = "Chris Hemswork", ActorID = 6},
                  new Actor() {ActorName = "Tom Huddleson", ActorID = 7},
                  new Actor() {ActorName = "Jeremy Renner", ActorID = 8},
                  new Actor() {ActorName = "Gwyneth Paltrow", ActorID = 9},
                  new Actor() {ActorName = "Paul Bettany", ActorID = 10},
            };
            actors.ForEach(actor => context.Actors.Add(actor));
            context.SaveChanges();

#endregion

            var film = new List<Movie>

            {
               
               new Movie()
            {
                MovieID = 1,
                MovieName = "Avengers",
                MovieDirector = " Joss Whedon",
                MovieImage = "Content/Images/1.jpg",
                ReleaseDate = DateTime.Parse("4/5/2014"),
                Actors = new List<Actor>()
            {
                new Actor () {ActorName = "Samuel L Jackson", ScreenName = "Nicky Fury"},
                new Actor () {ActorName = "Robert Downey Jr", ScreenName = "Iron Man"},
                new Actor () {ActorName = "Scarlet Johansoon", ScreenName = "Black Widow"},
                new Actor () {ActorName = "Chris Evans", ScreenName = "Captain America"},
                new Actor () {ActorName = "Mark Ruffalo", ScreenName = "Hulk"},
                new Actor () {ActorName = "Chris Hemswork", ScreenName = "Thor"},
                new Actor () {ActorName = "Tom Huddleson", ScreenName = "Loki"},
                new Actor () {ActorName = "Jereemy Rennar", ScreenName = "Hawkeye"},
                new Actor () {ActorName = "Gwyneth Paltrow", ScreenName = "Pepper Potts"},
                new Actor () {ActorName = "Paul Bettany", ScreenName = "Jarvis"},
            
           }
              
            },

            new Movie()
            {
                MovieID = 2,
                MovieName = "Captain America",
                MovieDirector = "Joe Johnston",
                MovieImage = "Content/Images/2.jpg",
                     ReleaseDate = DateTime.Parse("22/7/2011"),
                Actors = new List<Actor>()
                {
                     new Actor () {ActorName = "Scarlet Johansoon", ScreenName = "Black Widow" },
                     new Actor () {ActorName = "Chris Evans", ScreenName = "Captain America"},
                }
               
            },
            new Movie()
            {
                MovieID = 3,
                MovieName = "Iron Man",
                MovieDirector = "Jon Favreau",
                MovieImage = "Content/Images/3.jpg",
                     ReleaseDate = DateTime.Parse("2/5/2008"),
                 Actors = new List<Actor>()
                {
                     new Actor () {ActorName = "Scarlet Johansoon", ScreenName = "Black Widow"},
                     new Actor () {ActorName = "Chris Evans", ScreenName = "Captain America"},
                     new Actor () {ActorName = "Gwyneth Paltrow", ScreenName = "Pepper Potts"},
                     new Actor () {ActorName = "Paul Bettany", ScreenName = "Jarvis"},
                }
                
            },
            new Movie()
            {
                MovieID = 4,
                MovieName = "Thor",
                MovieDirector = "Kenneth Branagh",
                MovieImage = "Content/Images/4.jpg",
                     ReleaseDate = DateTime.Parse("6/5/2011"),
                Actors = new List<Actor>()
                {
                    new Actor () {ActorName = "Chris Hemswork", ScreenName = "Thor"},
                    new Actor () {ActorName = "Tom Huddleson", ScreenName = "Loki"},
                }
                
            },
            new Movie()
            {
                MovieID = 5,
                MovieName = "Fantastic 4",
                MovieDirector = "Tim Story",
                MovieImage = "Content/Images/5.jpg",
                     ReleaseDate = DateTime.Parse("8/7/2005"),
                Actors = new List<Actor>()
                {
                    new Actor () {ActorName = "Chris Evans", ScreenName = "Captain America"},
                }
               

            },

            };

            film.ForEach(flm => context.Movies.Add(flm));
            context.SaveChanges();

            #region Linker Class
            // var cast = new List<ActorMovie>
            //{
            //    new ActorMovie
            //    {
            //        MovieID= 1,
            //        ActorID = 1,
            //        ScreenName ="Nick Fury"
            //    },
            //      new ActorMovie
            //    {
            //        MovieID = 2,
            //        ActorID = 1,
            //        ScreenName ="Nick Fury"
            //    },
            //        new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 2,
            //         ScreenName = "Iron Man"
            //     },
            //     new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 2,
            //         ScreenName = "Iron Man"
            //     },
            //         new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 3,
            //         ScreenName = "Black Widow"
            //     },
            //           new ActorMovie
            //     {
            //         MovieID = 2,
            //         ActorID = 3,
            //         ScreenName = "Black Widow"
            //     },
            //           new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 3,
            //         ScreenName = "Captain America"
            //     },
            //               new ActorMovie
            //     {
            //         MovieID = 2,
            //         ActorID = 3,
            //         ScreenName = "Captain America"
            //     },
            //               new ActorMovie
            //     {
            //         MovieID = 3,
            //         ActorID = 3,
            //         ScreenName = "Captain America"
            //     },
            //               new ActorMovie
            //     {
            //         MovieID = 5,
            //         ActorID = 3,
            //         ScreenName = "Human Torch"
            //     },
            //                  new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 5,
            //         ScreenName = "Hulk"
            //     },
            //                      new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 6,
            //         ScreenName = "Thor"
            //     },
            //                 new ActorMovie
            //     {
            //         MovieID = 4,
            //         ActorID = 6,
            //         ScreenName = "Thor"
            //     },
            //                      new ActorMovie
            //     {
            //         MovieID = 4,
            //         ActorID = 7,
            //         ScreenName = "Loki"
            //     },
            //       new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 8,
            //         ScreenName = "Hawkeye"
            //     },
            //          new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 9,
            //         ScreenName = "Hawkeye"
            //     },
            //      new ActorMovie
            //     {
            //         MovieID = 3,
            //         ActorID = 9,
            //         ScreenName = "Hawkeye"
            //     },
            //      new ActorMovie
            //     {
            //         MovieID = 1,
            //         ActorID = 10,
            //         ScreenName = "Jarvis"
            //     },
            //         new ActorMovie
            //     {
            //         MovieID = 3,
            //         ActorID = 10,
            //         ScreenName = "Jarvis"
            //     },

            //};

            //cast.ForEach(actormovie => context.ActorMovies.Add(actormovie));
            //context.SaveChanges();
            base.Seed(context);
            #endregion
        }  
    }
    

        class MovieDB : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Actor> Actors { get; set; }
            public DbSet<ActorMovie> ActorMovies { get; set; }
            public MovieDB()
                : base("MovieConnString")
            {

            }
        }

        public class Movie
        {
            [Key]
            public int MovieID { get; set; }
            [DisplayName("Title:")]
            public string MovieName { get; set; }
            [DisplayName("Director:")]
            public string MovieDirector { get; set; }
            public string MovieImage { get; set; }
            [DisplayName("Released:"), DataType(DataType.Date),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime ReleaseDate { get; set; } 
            //public int Released { get; set; }
            public Actor Actor { get; set; }
            [DisplayName("Actors:")]
            public virtual List<Actor> Actors { get; set; }
            //public virtual List<ActorMovie> ActorsMoviez {get; set;}
        }

        public class Actor
        {
            public int ActorID { get; set; }
            [DisplayName("Actor's Name")]
            public string ActorName { get; set; }
            public Movie Movie { get; set; }
            [DisplayName("Screen Name")]
            public string ScreenName { get; set; }
            //public virtual List<ActorMovie> ScreenName { get; set; }
           
        }

        public class ActorMovie
        {
            [Key, Column(Order = 0)]
            public int MovieID { get; set; }
            [Key, Column(Order = 1)]
            public int ActorID { get; set; }
           
            public virtual Movie Moive { get; set; }
            public virtual Actor Actor { get; set; }
            
        }
    }
