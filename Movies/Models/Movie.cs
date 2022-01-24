using System;
namespace Movies.Models
{
    public class Movie
    {
        public string Title { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
