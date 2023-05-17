using System.Drawing;

namespace Skyrim.Model;

public class Player: GameObject
{
    public int dX;
    public int dY;
    public bool IsMoving;
    public int Speed;
    public string Name;

    public int CurFrame;
    public int CurAnimation;
    public int Flip;

    public Image WinImg;
    public Image Sprite;
    public int IdleFrames;
    public int RunFrames;
    public int AttackFrames;
    public int DeathFrames;
    public int CurFrames;

    public int HP;
    public bool IsAlive;
    public Element CurElement;
    public enum Element
    {
        Fire = 0,
        Earth = 8,
        Electricity = 16,
        Water = 24
    }

    public Player(Size size, Point pos, Image sprite, string name, Image winImg): base(size, pos)
    {
        Position = pos;
        Flip = 1;
        IdleFrames = 7;
        RunFrames = 7;
        AttackFrames = 7;
        DeathFrames = 7;
        CurFrames = 7;
        Sprite = sprite;
        Name = name;
        WinImg = winImg;
        Speed = 10;
        CurAnimation = 0;
        CurFrame = 0;
        HP = 100;
        IsAlive = true;
        CurElement = Element.Fire;
        Size = size;
    }

    public void Move()
    {
        if (!Map.FindCollide(this, new Point(dX, dY)).IsCollide && IsMoving)
        {
            Position = Position + new Size(dX, dY);
        }
    }

    public void SetAnimationConfiguration(int curAnimation)
    {
        if (Flip == -1)
            curAnimation += 4;
        CurAnimation = curAnimation;

        switch (curAnimation)
        {
            case 0:
                CurFrames = IdleFrames;
                break;
            case 1:
                CurFrames = RunFrames;
                break;
            case 2:
                CurFrames = AttackFrames;
                break;
            case 3:
                CurFrames = DeathFrames;
                break;
        }
    }

    public bool IsPlayerCollide(Player enemy)
    {
        PointF delta = FindDelta(enemy, new Point(0,0));

        if (Math.Abs(delta.X) <= (enemy.Size.Width / 2 + Size.Width / 2) / 1.5)
        {
            if (Math.Abs(delta.Y) <= (enemy.Size.Height / 2 + Size.Height / 2) / 1.5)
            {
                return delta.X != 0
                    ? enemy.Position.Y + enemy.Size.Height / 2 > Position.Y && enemy.Position.Y + enemy.Size.Height / 2 < Position.Y + Size.Height
                    : delta.Y != 0
                    ? enemy.Position.X + enemy.Size.Width / 2 > Position.X && enemy.Position.X + enemy.Size.Width / 2 < Position.X + Size.Width
                    : false;
            }
        }
        return false;
    }

    public bool IsBarrierCollide(Barrier barrier, Point dir)
    {
        PointF delta = FindDelta(barrier, dir);
        if (Math.Abs(delta.X) <= (Size.Width / 2 + barrier.Size.Width / 2) / 1.7)
        {
            if (Math.Abs(delta.Y) <= ( Size.Height / 2 + barrier.Size.Height / 2) / 1.5)
            {
                if ((delta.X < 0 && dir.X == Speed || delta.X > 0 && dir.X == -Speed)
                && (Position.X + dir.X <= barrier.Position.X && Position.X + dir.X + Size.Width <= barrier.Position.X + barrier.Size.Width
                || Position.X + dir.X <= barrier.Position.X + barrier.Size.Width && Position.X + dir.X + Size.Width >= barrier.Position.X + barrier.Size.Width))
                {
                    return true;
                }
                if ((delta.Y < 0 && dir.Y == Speed || delta.Y > 0 && dir.Y == -Speed)
                && (Position.Y + dir.Y <= barrier.Position.Y && Position.Y + dir.Y + Size.Height <= barrier.Position.Y + barrier.Size.Height
                || Position.Y + dir.Y <= barrier.Position.Y + barrier.Size.Height && Position.Y + dir.Y + Size.Height >= barrier.Position.Y + barrier.Size.Height))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void GetDamage()
    {
        if(HP > 0)
            HP -= 10;
    }

    public void IsDead()
    {
        IsAlive = false;
        Speed = 0;
        SetAnimationConfiguration(3);
    }

    private PointF FindDelta(GameObject gameObject, Point dir)
    {
        var del = new PointF()
        {
            X = (Position.X + dir.X + Size.Width / 2) - (gameObject.Position.X + gameObject.Size.Width / 2) ,
            Y = (Position.Y + dir.Y + Size.Height / 2) - (gameObject.Position.Y + gameObject.Size.Height / 2)
        };

        return del;
    }
}
