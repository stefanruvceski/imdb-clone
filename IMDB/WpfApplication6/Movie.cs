using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication6
{
    [Serializable]
    public class Movie
    {
        private int id;
        private string name;
        private int year;
        private string genre;
        private string producent;
        private float score;
        private string breaf;
        private string description;
        private string image1;
        private string image2;
        private string trailer;
        private string movieVideo;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        public string Producent
        {
            get
            {
                return producent;
            }

            set
            {
                producent = value;
            }
        }



        public float Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public string Breaf
        {
            get
            {
                return breaf;
            }

            set
            {
                breaf = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Image1
        {
            get
            {
                return image1;
            }

            set
            {
                image1 = value;
            }
        }

        public string Image2
        {
            get
            {
                return image2;
            }

            set
            {
                image2 = value;
            }
        }

        public string Trailer
        {
            get
            {
                return trailer;
            }

            set
            {
                trailer = value;
            }
        }

        public string MovieVideo
        {
            get
            {
                return movieVideo;
            }

            set
            {
                movieVideo = value;
            }
        }

        public Movie(int iii = 0, string s1 = "", string t = "", string m = "", int ii = 0, string ss = "", string s2 = "", int i = 0, string s3 = "", string s4 = "", string s5 = "", string s6 = "")
        {
            ID = iii;
            Name = s1;
            Year = ii;
            Genre = ss;
            Producent = s2;
            Score = i;
            Breaf = s6;
            description = s4;
            Image1 = s5;
            Image2 = s3;
            Trailer = t;
            movieVideo = m;
        }

        public Movie()
        {
            ID = 0;
            Name = "";
            Year = 0;
            Genre = "";
            Producent = "";
            Score = 0;
            Breaf = "";
            description = "";
            Image1 = "";
            Image2 = "";
            Trailer = "";
            MovieVideo = "";
        }
    }
}
