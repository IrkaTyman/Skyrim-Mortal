using System.Drawing;

namespace Skyrim.Model
{
    public enum RaceType
    {
        Danmer = 0,
        Nord = 1,
    }

    public class Race
    {
        public string Name;
        public Image Sprite;
        public Image WinImg;

        public Race(string name, Image sprite, Image winImg)
        {
            Name = name;
            Sprite = sprite;
            WinImg = winImg;
        }
    }

    public class Races
    {
        public static DirectoryInfo url = new DirectoryInfo(Directory.GetCurrentDirectory());
        public static Dictionary<RaceType, Race> Data;

        public Races()
        {
            Data = new Dictionary<RaceType, Race>
            {
                [RaceType.Danmer] = new Race("Danmer",
                 new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\Danmer.png")),
                 new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\danmer-win.png"))),
                [RaceType.Nord] = new Race("Nord",
                 new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\Nord.png")),
                 new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\nord-win.png"))),
            };
        }

        public Race this[RaceType type]
        {
            get
            {
                return Data[type];
            }
        }
    }
}
