using Skyrim.Model;
using System.Media;

namespace Skyrim_Mortal
{
    public partial class Form1 : Form
    {
        Player playerFirst;
        Player playerSecond;
        SoundPlayer simpleSound;


        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);
            SetSimpleSound();
            //simpleSound.Play();

            Initialize();
        }

        public void Initialize()
        {
            Map.Init();
            this.BackgroundImage = Map.MapBackground;
            this.Width = Map.CellSize * Map.MapWidth + 15;
            this.Height = Map.CellSize * (Map.MapHeight + 1) + 8;
            labelPlayer1.Text = "Fire";
            labelPlayer2.Text = "Fire";

            playerFirst = new Player(new Point(150,420), Nord.Icon);
            playerSecond = new Player(new Point(1050, 420), Danmer.Icon);

            timer1.Start();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    playerFirst.dY = 0;
                    break;
                case Keys.A:
                    playerFirst.dX = 0;
                    break;
                case Keys.S:
                    playerFirst.dY = 0;
                    break;
                case Keys.D:
                    playerFirst.dX = 0;
                    break;
                case Keys.Up:
                    playerSecond.dY = 0;
                    break;
                case Keys.Left:
                    playerSecond.dX = 0;
                    break;
                case Keys.Down:
                    playerSecond.dY = 0;
                    break;
                case Keys.Right:
                    playerSecond.dX = 0;
                    break;
            }

            if (playerFirst.dY == 0 && playerFirst.dX == 0)
            {
                playerFirst.IsMoving = false;
                playerFirst.SetAnimationConfiguration(0);
            }

            if (playerSecond.dY == 0 && playerSecond.dX == 0)
            {
                playerSecond.IsMoving = false;
                playerSecond.SetAnimationConfiguration(0);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (playerFirst.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        playerFirst.IsMoving = true;
                        playerFirst.SetAnimationConfiguration(1);
                        playerFirst.dY = -playerFirst.Speed;
                        break;
                    case Keys.A:
                        playerFirst.IsMoving = true;
                        playerFirst.Flip = -1;
                        playerFirst.SetAnimationConfiguration(1);
                        playerFirst.dX = -playerFirst.Speed;
                        break;
                    case Keys.S:
                        playerFirst.IsMoving = true;
                        playerFirst.SetAnimationConfiguration(1);
                        playerFirst.dY = playerFirst.Speed;
                        break;
                    case Keys.D:
                        playerFirst.IsMoving = true;
                        playerFirst.Flip = 1;
                        playerFirst.SetAnimationConfiguration(1);
                        playerFirst.dX = playerFirst.Speed;
                        break;
                    case Keys.Space:
                        if (playerFirst.IsCollide(playerSecond) && playerFirst.IsStronger(playerSecond))
                            playerSecond.GetDamage();
                        var (IsCollide, Barrier) = Map.FindCollide(playerFirst, new Point(playerFirst.Speed * playerFirst.Flip, 0));
                        if (Barrier != null)
                            Barrier.GetDamage();
                        playerFirst.dX = 0;
                        playerFirst.dY = 0;
                        playerFirst.SetAnimationConfiguration(2);
                        break;
                    case Keys.F:
                        playerFirst.CurElement = Player.Element.Fire;
                        labelPlayer1.Text = "Fire";
                        break;
                    case Keys.G:
                        playerFirst.CurElement = Player.Element.Earth;
                        labelPlayer1.Text = "Earth";
                        break;
                    case Keys.H:
                        playerFirst.CurElement = Player.Element.Electricity;
                        labelPlayer1.Text = "Electricity";
                        break;
                    case Keys.J:
                        playerFirst.CurElement = Player.Element.Water;
                        labelPlayer1.Text = "Water";
                        break;
                }
            }

            if (playerSecond.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        playerSecond.IsMoving = true;
                        playerSecond.SetAnimationConfiguration(1);
                        playerSecond.dY = -playerSecond.Speed;
                        break;
                    case Keys.Left:
                        playerSecond.IsMoving = true;
                        playerSecond.Flip = -1;
                        playerSecond.SetAnimationConfiguration(1);
                        playerSecond.dX = -playerSecond.Speed;
                        break;
                    case Keys.Down:
                        playerSecond.IsMoving = true;
                        playerSecond.SetAnimationConfiguration(1);
                        playerSecond.dY = playerSecond.Speed;
                        break;
                    case Keys.Right:
                        playerSecond.IsMoving = true;
                        playerSecond.Flip = 1;
                        playerSecond.SetAnimationConfiguration(1);
                        playerSecond.dX = playerSecond.Speed;
                        break;
                    case Keys.Enter:
                        if (playerSecond.IsCollide(playerFirst) && playerSecond.IsStronger(playerFirst))
                            playerFirst.GetDamage();
                        playerSecond.dX = 0;
                        playerSecond.dY = 0;
                        playerSecond.SetAnimationConfiguration(2);
                        break;
                    case Keys.NumPad0:
                        playerSecond.CurElement = Player.Element.Fire;
                        labelPlayer2.Text = "Fire";
                        break;
                    case Keys.NumPad1:
                        playerSecond.CurElement = Player.Element.Earth;
                        labelPlayer2.Text = "Earth";
                        break;
                    case Keys.NumPad2:
                        playerSecond.CurElement = Player.Element.Electricity;
                        labelPlayer2.Text = "Electricity";
                        break;
                    case Keys.NumPad3:
                        playerSecond.CurElement = Player.Element.Water;
                        labelPlayer2.Text = "Water";
                        break;
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            playerFirst.Move();
            playerSecond.Move();

            if (playerFirst.HP < 100 && playerFirst.HP >= 0)
                HPPlayerBar.Value = playerFirst.HP;
            if (playerSecond.HP < 100 && playerSecond.HP >= 0)
                HPEnemyBar.Value = playerSecond.HP;

            if (playerFirst.HP == 0)
            {
                playerFirst.IsDead();
                pictureBox4.Visible = true;
            }

            if (playerSecond.HP == 0)
            {
                playerSecond.IsDead();
                pictureBox3.Visible = true;
            }

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            DrawMap(graphics);
            PlayAnimation(graphics, playerFirst);
            PlayAnimation(graphics, playerSecond);
        }

        private void PlayAnimation(Graphics graphics, Player player)
        {
            if (player.IsAlive == false)
                return;
            if (player.CurFrame < player.CurFrames - 1)
                player.CurFrame++;
            else
                player.CurFrame = 0;

            graphics.DrawImage(player.Sprite,
                    new Rectangle(new Point(player.Position.X, player.Position.Y), new Size(player.Size, player.Size)),
                    150 * player.CurFrame, 150 * player.CurAnimation, player.Size, player.Size, GraphicsUnit.Point);
        }

        private void DrawMap(Graphics graphics)
        {
            for (int i = 0; i < Map.MapHeight; i++)
                for (int j = 0; j < Map.MapWidth; j++)
                {
                    var thing = Map.MapThings[i, j];
                    if (thing == null) continue;
                    if (thing.HP == 0)
                    {
                        Map.MapThings[i, j] = null;
                        continue;
                    }

                    graphics.DrawImage(thing.Image, new Point(j * Map.CellSize, i * Map.CellSize));
                }
        }

        private void SetSimpleSound()
        {
            Uri uri = new Uri(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "music\\base.wav"));
        }

        private void labelPlayer_Click(object sender, EventArgs e)
        {

        }

        private void labelPlayer_Click_1(object sender, EventArgs e)
        {

        }
    }
}
