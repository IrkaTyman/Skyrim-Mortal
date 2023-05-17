using System.Drawing;

namespace Skyrim.Model
{
    public abstract class GameObject
    {
        public Size Size { get; set; }
        public Point Position { get; set; }

        public GameObject(Size size, Point position)
        {
            Size = size;
            Position = position;
        }

        public GameObject(Size size)
        {
            Size = size;
        }
    }
}
