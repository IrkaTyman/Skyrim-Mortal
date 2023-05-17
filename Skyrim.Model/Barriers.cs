using System.Drawing;

namespace Skyrim.Model;

public enum BarrierType
{
    Empty = 0,
    Tree = 1,
    TreeStump = 2,
    BrokenTree = 3,
    GreyStone = 4,
    LittleGreyStone = 5,
    RedStone = 6,
}

public class Barrier: GameObject
{
    public Image Image;
    public int HP;

    public Barrier(Size size, Image image, int hp): base(size)
    {
        Size = size;
        Image = image;
        HP = hp;
    }

    public void GetDamage()
    {
        HP -= 1;
    }

    public void SetPosition(Point pos)
    {
        Position = pos;
    }

}

public class Barriers
{
    public static DirectoryInfo url = new DirectoryInfo(Directory.GetCurrentDirectory());
    public static Dictionary<BarrierType, Barrier?> Data;

    public Barriers()
    {
        Data = new Dictionary<BarrierType, Barrier?>
        {
            [BarrierType.Empty] = null,
            [BarrierType.Tree] = new Barrier(new Size(120, 100),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\tree3.png")), 15),
            [BarrierType.TreeStump] = new Barrier(new Size(30, 30),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\tree1.png")), 5),
            [BarrierType.BrokenTree] = new Barrier(new Size(60, 30),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\tree2.png")), 10),
            [BarrierType.GreyStone] = new Barrier(new Size(75, 60),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\stone1.png")), 100),
            [BarrierType.LittleGreyStone] = new Barrier(new Size(45, 45),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\stone3.png")), 50),
            [BarrierType.RedStone] = new Barrier(new Size(75, 60),
             new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\barries\\stone2.png")), 100),
        };
    }

    public Barrier? this[BarrierType type]
    {
        get
        {
            return Data[type];
        }
    }
}
