using Skyrim.Model;
using System.Media;
using System.Security.Policy;

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
            winScreen.Visible = false;
            repeatButton.Visible = false;

            var data = new Races();
            playerFirst = new Player(new Point(150, 420), data[RaceType.Nord].Sprite, data[RaceType.Nord].Name, data[RaceType.Nord].WinImg);
            playerSecond = new Player(new Point(150, 500), data[RaceType.Danmer].Sprite, data[RaceType.Danmer].Name, data[RaceType.Danmer].WinImg);

            labelPlayer1.Text = playerFirst.Name;
            labelPlayer2.Text = playerSecond.Name;

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
                        if (playerFirst.IsCollide(playerSecond))
                            playerSecond.GetDamage();
                        var (IsCollide, Barrier) = Map.FindCollide(playerFirst, new Point(playerFirst.Speed * playerFirst.Flip, 0));
                        if (Barrier != null)
                            Barrier.GetDamage();
                        playerFirst.dX = 0;
                        playerFirst.dY = 0;
                        playerFirst.SetAnimationConfiguration(2);
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
                        if (playerSecond.IsCollide(playerFirst))
                            playerFirst.GetDamage();
                        var (IsCollide, Barrier) = Map.FindCollide(playerFirst, new Point(playerFirst.Speed * playerFirst.Flip, 0));
                        if (Barrier != null)
                            Barrier.GetDamage();
                        playerSecond.dX = 0;
                        playerSecond.dY = 0;
                        playerSecond.SetAnimationConfiguration(2);
                        break;
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            playerFirst.Move();
            playerSecond.Move();

            if (playerFirst.HP <= 100 && playerFirst.HP >= 0 && HPPlayer1Bar != null)
                HPPlayer1Bar.Value = playerFirst.HP;
            if (playerSecond.HP <= 100 && playerSecond.HP >= 0 && HPPlayer2Bar != null)
            {
                var v = playerSecond.HP;
                HPPlayer2Bar.Value = playerSecond.HP;
            }
                

            if (playerFirst.HP == 0)
            {
                playerFirst.IsDead();
                repeatButton.Visible = true;
                winScreen.Visible = true;
                winScreen.Image = playerSecond.WinImg;
            }

            if (playerSecond.HP == 0)
            {
                playerSecond.IsDead();
                repeatButton.Visible = true;
                winScreen.Visible = true;
                winScreen.Image = playerFirst.WinImg;
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

            if (player.CurFrame < player.CurFrames - 1)
                player.CurFrame++;
            else if(player.IsAlive)
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

        private void repeatButton_Click(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}
