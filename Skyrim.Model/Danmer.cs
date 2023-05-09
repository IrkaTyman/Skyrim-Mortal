using System.Drawing;

namespace Skyrim.Model;

public static class Danmer
{
    public static Image Icon = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Danmer.png"));
}
