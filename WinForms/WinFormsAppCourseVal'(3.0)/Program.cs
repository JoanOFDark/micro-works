using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    interface ICurse
    {
        List<Func<string>> GenerateDelegateList();

        byte[] GetByteArray();
    }

    interface IWaterable
    {
        bool HasWater { get; set; }

        string RecieveWater();
    }

    interface IWatchable
    {
        string RateTheMovie();
        string WhatchMovie();
        string EatPopcorn();
        string EatPopcorn(int bags_of_pops);
        string Start();
        string ToString();
        string GetClassName();

    }

    [Serializable]
    class River : IWaterable, ICurse
    {
        public string Name { get; set; }
        public bool HasWater { get; set; } = true;

        public string RecieveWater()
        {
            if (HasWater)
            {
                HasWater = false;
                return "Water occupied";
            }
            else
                return "There is no water!";
        }

        public River()
        {
            this.Name = "Don";
            HasWater = true;
        }
        public River(string name, bool water_check)
        {
            this.Name = name;
            HasWater = water_check;
        }

        public override string ToString()
        {
            return String.Format("{2}\n Name: {0}. Has a Water? {1}", Name, HasWater ? "Yes" : "no", GetType().Name);
        }

        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { RecieveWater };
        }

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

    }

    [Serializable]
    class DryDye : IWatchable, ICurse
    {
        public string RateTheMovie()
        {
            return String.Format("U don't want nothing");
        }
        public string WhatchMovie()
        {
            return String.Format("You are watching the {0}, it is the best movie you ever seen " +
                                              "in your short marvelous life. " +
                                                "\nSlowly you fall asleep... (-,-)**Zzz", GetClassName());
        }
        public string EatPopcorn()
        {
            return String.Format("You are looking " + GetClassName() + " enough long. In your fluffy mind born " +
            "the thought about absorbation corrupted corns. " +
            "\nYou ate them all *('/./')*");
        }
        public string EatPopcorn(int bags_of_pops)
        {
            return String.Format("You are watching " + GetClassName() + " enough long. In your fluffy mind born " +
            "the thought about absorbation corrupted corns. " + "At least " + bags_of_pops + " bags!!!" +
            "\nYou ate them all *('/./')*");
        }
        public string Start()
        {
            return String.Format("You are not Andrew, ok?");
            Thread.Sleep(799);
        }
        public override string ToString()
        {
            return "Nothing interesting, just dye";
        }
        public string GetClassName()
        {
            return "DryDye";
        }
        public string Die()
        {
            return ("U just die from dye");
        }

        public string PrintInfo()
        {
            return "Its dye..";
        }

        public List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { PrintInfo, Die, GetClassName, Start, EatPopcorn, WhatchMovie, RateTheMovie };
        }

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }

        }
    }

    [Serializable]
    abstract class Movie : IWatchable
    {
        private string country_;
        private string movie_name_;
        private string director_;
        private int duration_;
        public readonly string Title = "Simple movie";

        public string Country                   //друзь€ конструктора
        {
            get => country_;
            set => country_ = value;
        }

        public string Naming
        {
            get => movie_name_;
            set => movie_name_ = value;
        }

        public string Director
        {
            get => director_;
            set => director_ = value;
        }

        public int Duration
        {
            get => duration_;
            set => duration_ = value;
        }
        //методы
        public abstract string RateTheMovie();  //переопределить
        public virtual string WhatchMovie()
        {
            return (String.Format("You are watching the {0}, it is the best movie you ever seen " +
                                              "in your short marvelous life. " +
                                                "\nSlowly you fall asleep... (-,-)**Zzz", this.Naming));
        }   //не переопределить
        public virtual string EatPopcorn()
        {
            return String.Format("You are looking " + this.movie_name_ + " enough long. In your fluffy mind born " +
            "the thought about absorbation corrupted corns. " +
            "\nYou ate them all *('/./')*");
        }
        public virtual string EatPopcorn(int bags_of_pops)
        {
            return String.Format("You are watching " + this.movie_name_ + " enough long. In your fluffy mind born " +
            "the thought about absorbation corrupted corns. " + "At least " + bags_of_pops + " bags!!!" +
            "\nYou ate them all *('/./')*");
        }
        public virtual string GetClassName()
        {
            return Title;
        }
        public static void ReadGenre()
        {
            Console.WriteLine("You are trying to overpower the letters in front of you eyes. "
                                  + "After all you decided that it is to much for you.");
        }
        public string Start()
        {
            return String.Format("Attention! If you are Andrey Zencoff, please leave the programm!");
            Thread.Sleep(999);
        }

        public Movie()                        //сами конструктора
        {
            Start();
        }
        public Movie(string country, string movie)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
        }
        public Movie(string country, string movie, int duration, string creator)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
            this.Duration = duration;
            this.Director = creator;
        }

        public override string ToString()       //собственно перегрузка
        {                                       //возвращает строку, представл€ющую текущий объект
            return String.Format("Movie: {0} || Origin: {1} || Director: {2} || Duration: {3}",
            this.Naming, this.Country, this.Director, this.Duration);
        }


    }

    [Serializable]
    class ActionMovie : Movie, ICurse
    {
        public int objective_action_movie_rating = 2;

        string Naming = "Terminator 12";
        string Country = "North Korea";
        string Director = "Kim Chin Yn";
        int Duration = 12;
        public ActionMovie() : base()                    //сами конструктора
        {
            Start();
        }
        public ActionMovie(string country, string movie)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
        }
        public ActionMovie(string country, string movie, int duration, string creator)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
            this.Duration = duration;
            this.Director = creator;
        }

        int rating = 2;
        public override string RateTheMovie()
        {
            return String.Format("Meh... You don't like " + this.GetClassName() + ". You always know that " + objective_action_movie_rating +
                " is honest rating of it." + " Certainly not " + rating);
        }

        public String MaybeItIsGoodMovie()
        {
            return String.Format("Of cource it is not!");
        }

        public override string ToString()       //собственно перегрузка
        {                                       //возвращает строку, представл€ющую текущий объект
            return String.Format("Movie: {0} || Origin: {1} || Director: {2} || Duration: {3}",
            this.Naming, this.Country, this.Director, this.Duration);
        }

        public override string GetClassName()
        {
            return "ActionMovie";
        }

        public new List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { MaybeItIsGoodMovie, GetClassName, RateTheMovie };
        }

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }
    }

    [Serializable]
    class Comedy : Movie, ICurse
    {
        public int objective_comedy_rating = 9;

        string Naming = "Rotanimret 21";
        string Country = "South Korea";
        string Director = "Pak Chon Hi";
        int Duration = 0;
        public Comedy() : base()                      //сами конструктора
        {
            Start();
        }
        public Comedy(string country, string movie)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
        }
        public Comedy(string country, string movie, int duration, string creator)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
            this.Duration = duration;
            this.Director = creator;
        }

        int rating = 2;
        public override string RateTheMovie()
        {
            return String.Format("Haha! You love " + this.GetClassName() + " so much, cause it is so funny! You always know that " + objective_comedy_rating + " is honest rating of it." +
                " Certainly not " + rating);
        }

        public string MaybeItIsBadMovie()
        {
            return String.Format("What are you just saying?!! Get out of here!");
        }

        public override string ToString()       //собственно перегрузка
        {                                       //возвращает строку, представл€ющую текущий объект
            return String.Format("Movie: {0} || Origin: {1} || Director: {2} || Duration: {3}",
            this.Naming, this.Country, this.Director, this.Duration);
        }

        public override string GetClassName()
        {
            return "Comedy";
        }

        public new List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { MaybeItIsBadMovie, GetClassName, RateTheMovie };
        }

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }
    }

    [Serializable]
    class Horror : Movie, ICurse
    {
        public int objective_horror_movie_rating = 6;

        string Naming = "Maria & The Bear";
        string Country = "Ukraine";
        string Director = "Bondarchuk";
        int Duration = 228;
        public Horror() : base()                   //сами конструктора
        {
            Start();
        }
        public Horror(string country, string movie)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
        }
        public Horror(string country, string movie, int duration, string creator)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
            this.Duration = duration;
            this.Director = creator;
        }

        int rating = 10;
        public override string RateTheMovie()
        {
            return String.Format("This is so spooky! You always was scared by " + this.GetClassName() +
                ". You always know that " + objective_horror_movie_rating + " is honest rating of it." +
                " Certainly not " + rating);
        }

        public string RatingEnoughHonest()
        {
            return String.Format("Nah... What a stupid question, of course it is");
        }

        public override string ToString()       //собственно перегрузка
        {                                       //возвращает строку, представл€ющую текущий объект
            return String.Format("Movie: {0} || Origin: {1} || Director: {2} || Duration: {3}",
            this.Naming, this.Country, this.Director, this.Duration);
        }

        public override string GetClassName()
        {
            return "Horror";
        }

        public new List<Func<string>> GenerateDelegateList()
        {
            return new List<Func<string>>() { RatingEnoughHonest, GetClassName, RateTheMovie };
        }

        public byte[] GetByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }
    }

    [Serializable]
    sealed class Multiks : Horror, ICurse
    {
        string Naming = "Beer & Masha";
        string Country = "Russia";
        string Director = "Balabanov";
        int Duration = 322;
        public Multiks() : base()                      //сами конструктора
        {
            Start();
        }
        public Multiks(string country, string movie)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
        }
        public Multiks(string country, string movie, int duration, string creator)
        {
            Start();
            this.Country = country;
            this.Naming = movie;
            this.Duration = duration;
            this.Director = creator;
        }

        public void MultiksOrHorrorCheck()
        {
            Console.WriteLine("You're really know the difference?");
        }

        public override string ToString()       //собственно перегрузка
        {                                       //возвращает строку, представл€ющую текущий объект
            return String.Format("Movie: {0} || Origin: {1} || Director: {2} || Duration: {3}",
            this.Naming, this.Country, this.Director, this.Duration);
        }

        public override string GetClassName()
        {
            return "Multiks";
        }
    }





    internal static class Program
    {
        /// <summary>
        /// √лавна€ точка входа дл€ приложени€.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}