﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;

namespace Task4
{

    public class Cat : Animal
    {
        private int ratio = 7;



        /// <summary>
        /// Creates a new pet object.
        /// </summary>
        /// <param name="race">Race must not be empty.</param>
        /// <param name="sex">Gender.</param>
        /// <param name="personality">Personality must not be empty.</param>



        public Cat(string race, string sex, string personality, int age, string description)
        //Constructor = das, was dem Ding sagt
        //Wenn du dir eine neue Katze kaufst: Hildy2: was muss ich alles wissen, damit ich das Ding bauen kann?
        //Hier definiere ich die Sachen, die ich unten brauche, wenn ich Hildy2 konkret angebe (was übergeben werden muss)
        //Hier kann man auch Checks einbauen, welche Werte definiert werden müssen. 
        {
            if (string.IsNullOrWhiteSpace(race)) throw new ArgumentException("Race must be defined.", nameof(race));
            if (string.IsNullOrWhiteSpace(sex)) throw new ArgumentException("Sex must be defined.", nameof(sex));
            if (string.IsNullOrWhiteSpace(personality)) throw new ArgumentException("Come on, one good trait.", nameof(personality));
            if (age <= 0 && age > 30) throw new ArgumentException("Die Katze ist fix tot. Kontrollier noch einmal.", nameof(age));

            //Ist schön, aber man könnte es auch komplett anders nennen. 
            //Der Großbuchstabe ist, wie man es von außen wahrnimmt;
            //wenn ich zB wissen will was die Hildy für eine Rasse ist, schreibe ich Hildy.Race
            Race = race;
            Sex = sex;
            Personality = personality;
            UpdateAge(age);
            Description = description;

        }




        //Wie man von außen mit dem Zeug interagieren kann
        //Ich kann oben ja auch private setzen und wenn ich trotzdem damit interagieren möchte,
        //kann ich hier rein schreiben ...Race{ get; set;}
        public string Race { get; }
        public string Sex { get; }
        public string Personality { get; }






        override public string ToString()
        {
            return Race + " " + Sex + " " + Personality + " " + Age.ToString() + " " + Description;
        }

        #region Animal implementation

        public void UpdateAge(int newAge)
        {

            if (newAge < 0) throw new ArgumentException("Age must not be negative.", nameof(newAge));

            Age = newAge * ratio;


        }

        public string Description { get; }
        public int Age { get; set; }


        #endregion
    }

    public class Doge : Animal
    {
        private int ratio = 9;

        public Doge(string race, string goodboy, string fluff, int age, string description)

        {
            if (string.IsNullOrWhiteSpace(race)) throw new ArgumentException("Race must be defined.", nameof(race));
            if (string.IsNullOrWhiteSpace(goodboy)) throw new ArgumentException("There are no not good boys.", nameof(goodboy));
            if (string.IsNullOrWhiteSpace(fluff)) throw new ArgumentException("The ultimate fluff level has to be defined.", nameof(fluff));
            if (age <= 0 && age > 30) throw new ArgumentException("Nobody is older than Maggie, think again!", nameof(age));

            Race = race;
            Goodboy = goodboy;
            Fluff = fluff;
            UpdateAge(age);
        }

        public string Race { get; }
        public string Goodboy { get; }
        public string Fluff { get; }

        #region Animal implementation

        public void UpdateAge(int newAge)
        {
            if (newAge < 0) throw new ArgumentException("Age must not be negative.", nameof(newAge));
            Age = newAge * ratio;

        }

        public string Description { get; }
        public int Age { get; private set; }


        #endregion

        override public string ToString()
        {
            return Race + " " + Goodboy + " " + Fluff + " " + Age.ToString() + " " + Description;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            Animal[] Tiergruppe = new Animal[] { new Cat("Siamkatze", "männlich", "lieb", 3, "super fluffy duffy"), new Doge("Golden Retriever,", "Very good boy,", "So fluffy I'm gonna die,", 29, ""), };





            foreach (var x in Tiergruppe)
            {
                Console.WriteLine($"{x.Age} {x.Description}");
            }

            var Hildy = new Cat("Perser", "female", "kaempferisch", 1, "Fleckerlteppich"); // Erstelle eine neue Katze
            var Mittens = new Cat("Siam", "male", "nicht so kaempferisch", 1, "Tiger"); // Erstelle eine neue Katze

            List<Cat> listCats = new List<Cat>(); // Erstelle eine Liste "listCats"
            listCats.Add(Hildy); // Fuege das Objekt "Hildy" der Liste hinzu
            listCats.Add(Mittens); //see above

            string Cat_serial = JsonConvert.SerializeObject(listCats); // Serialisiere die Liste der Katzen zu einem String "Cat_Serial"

            File.WriteAllText(@"C:\Users\Schumpi\oom\myfile.txt", Cat_serial); // Schreibt Cat_Serial String in ein text File im entsprechenden Ordner

            Console.WriteLine(File.ReadAllText(@"C:\Users\Schumpi\oom\myfile.txt")); //Schreibe in die Konsole was aus dem File ausgelesen wird


        }


    }

    public interface Animal
    {
        /// <summary>
        /// Gets a textual description of the animal.
        /// </summary>
        string Description { get; }

        int Age { get; }

        void UpdateAge(int newAge);
        ///man muss die Parameter, die übergeben werden, gleich dazu schreiben
        ///


    }


}