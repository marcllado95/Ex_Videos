using System.Collections.Generic;

namespace Videos.Lib.Models
{
    public class Video : Entity
    {                                                           //properties of the class: Video
        public string Url { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }

        public Video()
        {
            this.Tags = new List<string>();
        }

        public Video(string title, string url)
        {
            this.Title = title;
            this.Url = url;
            this.Tags = new List<string>();
        }
        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }
        /*
        public enum Mediaplayer
        {
            Play = 'p',
            Pause = 'k',
            Stop = 's'
        }
        */

    }
}



