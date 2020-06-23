//Marc Lladó Maldonado                                      ITAcademy (Prof. Jake Petrulla)
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Videos.Lib.Models;

namespace Videos
{
    class Program
    {
        public static void FirstPage()
        {
            Console.WriteLine("************** WELCOME TO MYTUBE CLOUD PLATFORM **************");
            Console.WriteLine("<<< Store your videos on the cloud and watch them wherever >>> \n");

        }

        public static bool CheckPassword(string username, string password, List<User> userList)
        {
            foreach (var User in userList)
            {
                if (User.UserID == username)
                {
                    if (User.Password == password)
                    {
                        Console.WriteLine("Login successful \n");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("The password you have entered is wrong");
                        return false;
                    }
                }
            }
            Console.WriteLine("The username you have entered doesn't exist");
            return false;
        }

        public static User Login(string username, List<User> userList)
        {
            foreach (var User in userList)
            {
                if (User.UserID == username)
                    return User;
            }
            return null;
        }

        public enum Reproducer
        {
            Play = 1,     
            Pause = 2,    
            Stop = 3     
        }

        public static void MediaPlayer()
        {
            Console.WriteLine("MyTube Media Player");
            Console.WriteLine("1 = Play Video, 2 = Pause , 3 = Stop,  0 = Back");
            int hostkey = Convert.ToInt32(Console.ReadLine());
            while (hostkey != 0)
            {
                switch (hostkey)
                {
                    case 1:
                        Console.WriteLine(Reproducer.Play + ". The video is being played");
                        break;
                    case 2:
                        Console.WriteLine(Reproducer.Pause + ". The video has been paused");
                        break;
                    case 3:
                        Console.WriteLine(Reproducer.Stop + ". Video stopped");
                        break;
                }
                hostkey = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static string NotEmpty(string input)
        {
            while (input == "")
            {
                Console.WriteLine("Cannot leave empty fields");
                input = Console.ReadLine();
              
            }
            return input;
        }

        // ******************************************************************************************-
        public static void Main(string[] args)
        {
            var Manolo = new User
            {
                UserID = "manolito38",
                Name = "Manolo",
                Surname = "Hernandez",
                Password = "123456",
            };

            var Marilyn = new User
            {
                UserID = "blonde_mary",
                Name = "Marilyn",
                Surname = "Monroe",
                Password = "teamrocket",
            };

            List<User> userList = new List<User>();      //list where all users are stored
            User LoggedUser = null;
            userList.Add(Manolo);
            userList.Add(Marilyn);
            Manolo.CreateVideo("Hello Mytube! My first video :D", "https:///www.mytube.com/watch?v=o9P-manolo38"); ;
            Marilyn.CreateVideo("Build me up a Buttercup - First video :D", "https:///www.mytube.com/watch?v=o4P-blonde_mary"); 
            Video CurrentVideo = null;

            string u, p;
            FirstPage();
            Console.WriteLine("******* Log in ************************ \n");
            Console.WriteLine("Username: ");
            u = Console.ReadLine();
            Console.WriteLine("Password: ");
            p = Console.ReadLine();

            while (!CheckPassword(u, p, userList))
            {
                Console.WriteLine("Username: ");
                u = Console.ReadLine();
                Console.WriteLine("Password: ");
                p = Console.ReadLine();

            }
            LoggedUser = Login(u, userList);     //Current user stored in LoggedUser 
            LoggedUser.ShowInfo();

            Console.WriteLine("What do you want to do? \n");

            Console.WriteLine("1) Create new video");
            Console.WriteLine("2) See my list of videos");
            Console.WriteLine("3) Change user \n");
            Console.WriteLine("0) Exit");

            string title, url;



            int x = Convert.ToInt32(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Create your new video");
                        Console.WriteLine("Title: ");
                        title = Console.ReadLine();
                        title = NotEmpty(title);
                        Console.WriteLine("Url: ");
                        url = Console.ReadLine();
                        url = NotEmpty(url);
                        LoggedUser.CreateVideo(title, url);
                        break;

                    case 2:
                        Console.WriteLine("************* " + LoggedUser.Name + " LIST OF VIDEOS *************");
                        LoggedUser.ShowVideos();
                        Console.WriteLine("*************************************************\n");

                        Console.WriteLine("Select video from the list by its number or type 0 to go back");
                        int y = Convert.ToInt32(Console.ReadLine());
                        if (y != 0  &&  y <= LoggedUser.Videos_List.Count) { 
                            CurrentVideo = LoggedUser.Videos_List[y-1];
                            Console.WriteLine("Selected video: " + CurrentVideo.Title + ' ' + CurrentVideo.Url);
                            
                            Console.WriteLine("1) Play video");
                            Console.WriteLine("2) Add tags to selected video \n");
                            Console.WriteLine("0) Back");

                            int z = Convert.ToInt32(Console.ReadLine());
                            while (z != 0)
                            {
                                switch (z)
                                {
                                    case 1:
                                        MediaPlayer();
                                        break;


                                    case 2:
                                        Console.WriteLine("Type tags to add and write finish once you're done");
                                        string tag = Console.ReadLine();
                                        tag = NotEmpty(tag);
                                        while (tag != "finish")
                                        {
                                            CurrentVideo.AddTag(tag);
                                            tag = Console.ReadLine();
                                            tag = NotEmpty(tag);
                                        }
                                        break;

                                }
                                Console.WriteLine("1) Play video");
                                Console.WriteLine("2) Add tags to selected video \n");
                                Console.WriteLine("0) Back");
                                z = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        break;
                    
                    case 3:
                        Console.WriteLine("Logged Out \n");

                        FirstPage();
                        Console.WriteLine("***** Log in ************************ \n");
                        Console.WriteLine("Username: ");
                        u = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        p = Console.ReadLine();

                        while (!CheckPassword(u, p, userList))
                        {
                            Console.WriteLine("Username: ");
                            u = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            p = Console.ReadLine();

                        }
                        LoggedUser = Login(u, userList);
                        LoggedUser.ShowInfo();
                        break;

                }
                Console.WriteLine("What do you want to do? \n");
                Console.WriteLine("1) Create new video");
                Console.WriteLine("2) See my list of videos");
                Console.WriteLine("3) Change user \n");
                Console.WriteLine("0) Exit");
                x = Convert.ToInt32(Console.ReadLine());
            }



        }
    }
}
