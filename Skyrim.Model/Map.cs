using Microsoft.VisualBasic;
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
    public static int[,] map = new int[MapWidth, MapHeight];
    public const int MapWidth = 17;
    public const int MapHeight = 10;
    public static int CellSize = 75;
    public static Bitmap MapSprite;
    public static Barrier?[,] MapThings;
    public static Image MapBackground;

    public static void Init()
    {
        var url = new DirectoryInfo(Directory.GetCurrentDirectory());
        MapBackground = new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\back.jpg"));
        MapSprite = new Bitmap(Path.Combine(url.Parent.Parent.Parent.FullName.ToString(), "Sprites\\sprites.png"));

        map = GetMap();
        MapThings = GetMapThing(map);
    }

    public static int[,] GetMap()
    {
        return new int[,]
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0},
            { 0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
    }

    public static Barrier?[,] GetMapThing(int[,] map)
    {
        var things = new Barrier?[MapHeight, MapWidth];
        for (var i = 0; i < MapHeight; i++)
        {
            for (var j = 0; j < MapWidth; j++)
            {
                Barrier? thing = null;
                Image? image = null;

                switch (map[i, j])
                {
                    case 1:
                        image = MapSprite.Clone(new Rectangle(0, 0, 75, 60), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(75, 60), image, 100);
                        break;
                    case 2:
                        image = MapSprite.Clone(new Rectangle(75, 0, 45, 45), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(45, 45), image, 100);
                        break;
                    case 3:
                        image = MapSprite.Clone(new Rectangle(0, 60, 75, 60), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(75, 60), image, 100);
                        break;
                    case 4:
                        image = MapSprite.Clone(new Rectangle(75, 45, 30, 30), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(30, 30), image, 10);
                        break; 
                    case 5:
                        image = MapSprite.Clone(new Rectangle(75, 75, 60, 30), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(30, 30), image, 5);
                        break;
                    case 6:
                        image = MapSprite.Clone(new Rectangle(135, 0, 100, 120), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(120, 130), image, 5);
                        break;
                }
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
            return (IsCollide: true, Barrier: null);

        var coordX = (player.Position.X + dir.X + player.Size / 2) / CellSize;
        var coordY = (player.Position.Y + dir.Y + player.Size / 2) / CellSize;

        for (var i = coordY < 2 ? 0 : coordY - 2; i < (coordY + 2 > MapHeight ? MapHeight : coordY + 2); i++)
        {
            for (var j = coordX < 2 ? 0 : coordX - 2; j < (coordX + 2 > MapWidth ? MapWidth : coordX + 2); j++)
            {
                var curObject = MapThings[i, j];
                if (curObject == null || curObject.HP <= 0) continue;

                PointF delta = FindDelta(player, curObject, dir);
                if (Math.Abs(delta.X) <= (player.Size / 2 + curObject.Size.Width / 2) / 1.7)
                {
                    if (Math.Abs(delta.Y) <= (player.Size / 2 + curObject.Size.Height / 2) / 1.5)
                    {
                        if ((delta.X < 0 && dir.X == player.Speed || delta.X > 0 && dir.X == -player.Speed)
                            && (player.Position.X + dir.X <= curObject.Position.X && player.Position.X + dir.X + player.Size <= curObject.Position.X + curObject.Size.Width
                            || player.Position.X + dir.X <= curObject.Position.X + curObject.Size.Width && player.Position.X + dir.X + player.Size >= curObject.Position.X + curObject.Size.Width))
                        {
                            return (IsCollide: true, Barrier: curObject);
                        }

                        if ((delta.Y < 0 && dir.Y == player.Speed || delta.Y > 0 && dir.Y == -player.Speed)
                           && (player.Position.Y + dir.Y <= curObject.Position.Y && player.Position.Y + dir.Y + player.Size <= curObject.Position.Y + curObject.Size.Height
                           || player.Position.Y + dir.Y <= curObject.Position.Y + curObject.Size.Height && player.Position.Y + dir.Y + player.Size >= curObject.Position.Y + curObject.Size.Height))
                        {
                            return (IsCollide: true, Barrier: curObject);
                        }
                    }
                }
            }
        }

        return (IsCollide: false, Barrier: null);
    }

    private static PointF FindDelta(Player player, Barrier curObject, Point dir)
    {
        var delta = new PointF
        {
            X = (player.Position.X + dir.X + player.Size / 2) - (curObject.Position.X + curObject.Size.Width / 2),
            Y = (player.Position.Y + dir.Y + player.Size / 2) - (curObject.Position.Y + curObject.Size.Height / 2)
        };
        return delta;
    }
}
