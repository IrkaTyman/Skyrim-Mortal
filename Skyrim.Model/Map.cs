using System.Drawing;

namespace Skyrim.Model;

enum CrossingDirection
{
    IncreaseCoord = 0,
    DecreaseCoord = 1,
    None = 2,
}

public class Map
{
    public static BarrierType[,] map = new BarrierType[MapWidth, MapHeight];
    public const int MapWidth = 16;
    public const int MapHeight = 10;
    public static int CellSize = 75;
    public static Barrier?[,] MapThings;
    public static Image MapBackground;

    public static void Init()
    {
        var url = new DirectoryInfo(Directory.GetCurrentDirectory());
        MapBackground = new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\back.jpg"));
        map = GetMap();
        MapThings = GetMapThing(map);
    }

    public static BarrierType[,] GetMap()
    {
        return new BarrierType[,]
        {
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.TreeStump,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.GreyStone,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Tree,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.LittleGreyStone,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
            { BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty,BarrierType.Empty},
        };
    }

    public static Barrier?[,] GetMapThing(BarrierType[,] map)
    {
        var things = new Barrier?[MapHeight, MapWidth];
        for (var i = 0; i < MapHeight; i++)
        {
            for (var j = 0; j < MapWidth; j++)
            {
                var barriers = new Barriers();
                var thing = barriers[map[i, j]];
                if(thing != null )
                    thing.SetPosition(new Point(j * CellSize, i * CellSize));
                things[i, j] = thing;
            }
        }

        return things;
    }

    public static (bool IsCollide, Barrier? Barrier) FindCollide(Player player, Point dir)
    {
        if (player.Position.X + dir.X <= -CellSize
            || player.Position.X + dir.X >= CellSize * (MapWidth - 2)
            || player.Position.Y + dir.Y <= 110
            || player.Position.Y + dir.Y >= CellSize * (MapHeight - 3))
            return (true, null);

        var coordX = (player.Position.X + dir.X + player.Size.Width / 2) / CellSize;
        var coordY = (player.Position.Y + dir.Y + player.Size.Height / 2) / CellSize;

        for (var i = coordY < 2 ? 0 : coordY - 2; i < (coordY + 2 > MapHeight ? MapHeight : coordY + 2); i++)
        {
            for (var j = coordX < 2 ? 0 : coordX - 2; j < (coordX + 2 > MapWidth ? MapWidth : coordX + 2); j++)
            {
                var barrier = MapThings[i, j];
                if (barrier == null || barrier.HP <= 0) continue;
                if (player.IsBarrierCollide(barrier, dir))
                    return (true, barrier);
            }
        }

        return (false, null);
    }
}
