using System.Drawing;

namespace Skyrim.Model;

public class Barrier
{
    public Point Position;
    public Size Size;
    public Image Image;
    public int HP;

    public Barrier(Point pos, Size size, Image image, int hp) 
    {
        Position = pos;
        Size = size;
        Image = image;
        HP = hp;
    }
}
