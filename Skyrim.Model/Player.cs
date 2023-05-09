using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyrim.Model;

public class Player
{
    public int PosX;
    public int PosY;
    public int dX;
    public int dY;
    public bool IsMoving;
    public int Speed;

    public int CurFrame;
    public int CurAnimation;
    public int Flip;

    public Image Sprite;
    public int IdleFrames;
    public int RunFrames;
    public int AttackFrames;
    public int DeathFrames;
    public int CurFrames;
    public int Size;

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

    public Player(int posX, int posY, Image sprite)
    {
        PosX = posX;
        PosY = posY;
        Flip = 1;
        IdleFrames = 7;
        RunFrames = 7;
        AttackFrames = 7;
        DeathFrames = 7;
        CurFrames = 7;
        Sprite = sprite;
        Speed = 10;
        CurAnimation = 0;
        CurFrame = 0;
        HP = 100;
        IsAlive = true;
        CurElement = Element.Fire;
        // Размеры всех спрайтов
        Size = 150;
    }

    public void Move()
    {
        if (!Map.IsCollide(this, new Point(dX, dY)))
        {
            if (IsMoving)
            {
                PosX += dX;
                PosY += dY;
            }
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

    public bool IsCollide(Player enemy)
    {
        PointF delta = FindDelta(enemy);

        if (Math.Abs(delta.X) <= (enemy.Size / 2 + Size / 2) / 1.5)
        {
            if (Math.Abs(delta.Y) <= (enemy.Size / 2 + Size / 2) / 1.5)
            {
                return delta.X != 0
                    ? enemy.PosY + enemy.Size / 2 > PosY && enemy.PosY + enemy.Size / 2 < PosY + Size
                    : delta.Y != 0
                    ? enemy.PosX + enemy.Size / 2 > PosX && enemy.PosX + enemy.Size / 2 < PosX + Size
                    : false;
            }
        }
        return false;
    }

    public void GetDamage()
    {
        HP -= 10;
    }

    public void IsDead()
    {
        IsAlive = false;
        Speed = 0;
        SetAnimationConfiguration(3);
    }

    public bool IsStronger(Player enemy)
    {
        switch (CurElement)
        {
            case Element.Fire:
                return enemy.CurElement == Element.Earth;
            case Element.Earth:
                return enemy.CurElement == Element.Electricity;
            case Element.Electricity:
                return enemy.CurElement == Element.Water;
            case Element.Water:
                return enemy.CurElement == Element.Fire;
        }
        return false;
    }

    private PointF FindDelta(Player enemy)
    {
        var del = new PointF()
        {
            X = (enemy.PosX + enemy.Size / 2) - (PosX + Size / 2),
            Y = (enemy.PosY + enemy.Size / 2) - (PosY + Size / 2)
        };

        return del;
    }
}
