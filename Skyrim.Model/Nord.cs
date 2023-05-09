using System.Drawing;

namespace Skyrim.Model;

public static class Hero
{
    public static Image Icon = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Nord.png"));
}
