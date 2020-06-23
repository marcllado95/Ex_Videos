using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Videos.Lib.Models
{
    public class User : Entity
    {                                                        //properties of the class: User
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime Register_date { get; set; }
        public List<Video> Videos_List { get; set; }        //list of videos that each user has

        public User()
        {
            this.Videos_List = new List<Video>();
        }
        public User(string userid, string name, string surname, string password)      //esto es un constructor
        {
            this.UserID = userid;
            this.Name = name;
            this.Surname = surname;
            this.Password = password;
            this.Register_date = DateTime.Now;
            this.Videos_List = new List<Video>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("The person with name: " + this.Name + " and surname: " + this.Surname + " has an account " +
                "with name user " + this.UserID + " and password: " + this.Password + " \n Register date: " + this.Register_date);
        }



        public void CreateVideo(string t, string u)            //title,  url
        {                        
            Video clip = new Video(t, u);    
            Videos_List.Add(clip);
        }

        public void ShowVideos()
        {
            int cont = 1;
            foreach (var video in Videos_List)
            {

                Console.WriteLine(cont + "]");
                Console.WriteLine("Title:  " + video.Title.ToString());
                //    Console.WriteLine(video.Url.ToString());
                Console.WriteLine("Url: " + video.Url);
                Console.Write("Tags:  ");

                if (video.Tags != null)
                {
                    foreach (string tag in video.Tags)
                        Console.Write("#" + tag + ' ');
                }

                Console.WriteLine("\n");
                cont++;
            }   
        }

        public override string ToString()  //no se como hacer que funcione ToString override
        {
            return "User ID: " + this.UserID + " Password: " + this.Password;
        }

    } 
}
