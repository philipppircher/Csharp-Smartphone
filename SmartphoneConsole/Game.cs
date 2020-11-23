using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneConsole
{
    public class Game : BaseApp
    {
        public enum Genre {Platformer, Top_Down, FPS, Isometric, Simulation }
        public enum Rating { Everyone, Teen, Mature, AdultsOnly }

        public Genre GameGenre { get; private set; }
        public Rating GameRating { get; private set; }

        public Game(string name, double megabyte, string description, Rating rating, Genre genre) : base(name, megabyte, description)
        {
            GameRating = rating;
            GameGenre = genre;
        }

        public override string ToString()
        {
            return "Spiel - " + GameGenre;
        }

        public override string Start()
        {
           return base.Start() +  "\nViel Spaß\n";
        }
    }
}
