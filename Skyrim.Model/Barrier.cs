using System.Drawing;

namespace Skyrim.Model;

public class Barrier
{
    public PointF Position;
    public Size Size;
    public Image Image;

    public Barrier(PointF pos, Size size, Image image) 
    {
        Position = pos;
        Size = size;
        Image = image;
    }
}
