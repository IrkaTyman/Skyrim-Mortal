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
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
    }

    public static Barrier?[,] GetMapThing(int[,] map)
    {
        var things = new Barrier?[MapHeight,MapWidth];
        for (var i = 0; i < MapHeight; i++)
        {
            for (var j = 0; j < MapWidth; j++)
            {
                Barrier? thing = null;
                switch (map[i, j])
                {
                    case 1:
                        var image = MapSprite.Clone(new Rectangle(0,0, 75,75), MapSprite.PixelFormat);
                        thing = new Barrier(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize), image);
                        break;
                }
                things[i, j] = thing;
            }
        }

        return things;
    }

    public static bool IsCollide(Player player, Point dir)
    {
        if (player.PosX + dir.X <= -5 || player.PosX + dir.X >= CellSize * (MapWidth - 1.65) || player.PosY + dir.Y <= 110 || player.PosY + dir.Y >= CellSize * (MapHeight - 1.85))
            return true;

       var coordX = (player.PosX + player.dX + player.Size/2) / CellSize;
       var coordY = (player.PosY + player.dY + player.Size / 2) / CellSize;

        for (var i = coordY < 2 ? 0 : coordY - 2; i < coordY + 2; i++)
        {
            for (var j = coordX < 2 ? 0 : coordX - 2; j < coordX + 2; j++)
            {
                var curObject = MapThings[i,j];
                if(curObject == null) continue;
                PointF delta = FindDelta(player, curObject);
                if (Math.Abs(delta.X) <= (player.Size / 2 + curObject.Size.Width / 2) / 1.7)
                {
                    if (Math.Abs(delta.Y) <= (player.Size / 2 + curObject.Size.Height / 2) / 1.5)
                    {
                        if ((delta.X < 0 && dir.X == player.Speed || delta.X > 0 && dir.X == -player.Speed)
                            && (player.PosX + player.dX <= curObject.Position.X && player.PosX + player.dX + player.Size <= curObject.Position.X + curObject.Size.Width
                            || player.PosX + player.dX <= curObject.Position.X + curObject.Size.Width && player.PosX + player.dX + player.Size >= curObject.Position.X + curObject.Size.Width))
                        {
                            return true;
                        }

                        if ((delta.Y < 0 && dir.Y == player.Speed || delta.Y > 0 && dir.Y == -player.Speed)
                           && (player.PosY + player.dY <= curObject.Position.Y && player.PosY + player.dY + player.Size <= curObject.Position.Y + curObject.Size.Height
                           || player.PosY + player.dY <= curObject.Position.Y + curObject.Size.Height && player.PosY + player.dY + player.Size >= curObject.Position.Y + curObject.Size.Height))
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private static PointF FindDelta(Player player, Barrier curObject)
    {
        var delta = new PointF
        {
            X = (player.PosX + player.dX + player.Size / 2) - (curObject.Position.X + curObject.Size.Width / 2),
            Y = (player.PosY + player.dY + player.Size / 2) - (curObject.Position.Y + curObject.Size.Height / 2)
        };
        return delta;
    }
}
