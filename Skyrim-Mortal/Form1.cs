using Skyrim.Model;
using System.Media;

namespace Skyrim_Mortal
{
    public partial class Form1 : Form
    {
        Player player;
        Player enemy;
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
            labelPlayer.Text = "Fire";
            labelEnemy.Text = "Fire";

            player = new Player(0,120, Hero.Icon);
            enemy = new Player(1050, 420, Danmer.Icon);

            timer1.Start();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dY = 0;
                    break;
                case Keys.A:
                    player.dX = 0;
                    break;
                case Keys.S:
                    player.dY = 0;
                    break;
                case Keys.D:
                    player.dX = 0;
                    break;
                case Keys.Up:
                    enemy.dY = 0;
                    break;
                case Keys.Left:
                    enemy.dX = 0;
                    break;
                case Keys.Down:
                    enemy.dY = 0;
                    break;
                case Keys.Right:
                    enemy.dX = 0;
                    break;
            }

            if (player.dY == 0 && player.dX == 0)
            {
                player.IsMoving = false;
                player.SetAnimationConfiguration(0);
            }

            if (enemy.dY == 0 && enemy.dX == 0)
            {
                enemy.IsMoving = false;
                enemy.SetAnimationConfiguration(0);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (player.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        player.IsMoving = true;
                        player.SetAnimationConfiguration(1);
                        player.dY = -player.Speed;
                        break;
                    case Keys.A:
                        player.IsMoving = true;
                        player.Flip = -1;
                        player.SetAnimationConfiguration(1);
                        player.dX = -player.Speed;
                        break;
                    case Keys.S:
                        player.IsMoving = true;
                        player.SetAnimationConfiguration(1);
                        player.dY = player.Speed;
                        break;
                    case Keys.D:
                        player.IsMoving = true;
                        player.Flip = 1;
                        player.SetAnimationConfiguration(1);
                        player.dX = player.Speed;
                        break;
                    case Keys.Space:
                        if (player.IsCollide(enemy) && player.IsStronger(enemy))
                            enemy.GetDamage();
                        player.dX = 0;
                        player.dY = 0;
                        player.SetAnimationConfiguration(2);
                        break;
                    case Keys.F:
                        player.CurElement = Player.Element.Fire;
                        labelPlayer.Text = "Fire";
                        break;
                    case Keys.G:
                        player.CurElement = Player.Element.Earth;
                        labelPlayer.Text = "Earth";
                        break;
                    case Keys.H:
                        player.CurElement = Player.Element.Electricity;
                        labelPlayer.Text = "Electricity";
                        break;
                    case Keys.J:
                        player.CurElement = Player.Element.Water;
                        labelPlayer.Text = "Water";
                        break;
                }
            }

            if (enemy.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        enemy.IsMoving = true;
                        enemy.SetAnimationConfiguration(1);
                        enemy.dY = -enemy.Speed;
                        break;
                    case Keys.Left:
                        enemy.IsMoving = true;
                        enemy.Flip = -1;
                        enemy.SetAnimationConfiguration(1);
                        enemy.dX = -enemy.Speed;
                        break;
                    case Keys.Down:
                        enemy.IsMoving = true;
                        enemy.SetAnimationConfiguration(1);
                        enemy.dY = enemy.Speed;
                        break;
                    case Keys.Right:
                        enemy.IsMoving = true;
                        enemy.Flip = 1;
                        enemy.SetAnimationConfiguration(1);
                        enemy.dX = enemy.Speed;
                        break;
                    case Keys.Enter:
                        if (enemy.IsCollide(player) && enemy.IsStronger(player))
                            player.GetDamage();
                        enemy.dX = 0;
                        enemy.dY = 0;
                        enemy.SetAnimationConfiguration(2);
                        break;
                    case Keys.NumPad0:
                        enemy.CurElement = Player.Element.Fire;
                        labelEnemy.Text = "Fire";
                        break;
                    case Keys.NumPad1:
                        enemy.CurElement = Player.Element.Earth;
                        labelEnemy.Text = "Earth";
                        break;
                    case Keys.NumPad2:
                        enemy.CurElement = Player.Element.Electricity;
                        labelEnemy.Text = "Electricity";
                        break;
                    case Keys.NumPad3:
                        enemy.CurElement = Player.Element.Water;
                        labelEnemy.Text = "Water";
                        break;
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            player.Move();
            enemy.Move();

            if (player.HP < 100 && player.HP >= 0)
                HPPlayerBar.Value = player.HP;
            if (enemy.HP < 100 && enemy.HP >= 0)
                HPEnemyBar.Value = enemy.HP;

            if (player.HP == 0)
            {
                player.IsDead();
                pictureBox4.Visible = true;
            }

            if (enemy.HP == 0)
            {
                enemy.IsDead();
                pictureBox3.Visible = true;
            }

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            DrawMap(graphics);
            PlayAnimation(graphics, player);
            PlayAnimation(graphics, enemy);
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
                    new Rectangle(new Point(player.PosX, player.PosY), new Size(player.Size, player.Size)),
                    150 * player.CurFrame, 150 * player.CurAnimation, player.Size, player.Size, GraphicsUnit.Point);
        }

        private void DrawMap(Graphics graphics)
        {
            for (int i = 0; i < Map.MapHeight; i++)
                for (int j = 0; j < Map.MapWidth; j++)
                {
                    var thing = Map.MapThings[i, j];
                    if(thing == null) continue;
                    graphics.DrawImage(thing.Image, new Point(j * Map.CellSize, i * Map.CellSize));
                }
        }

        private void SetSimpleSound()
        {
            Uri uri = new Uri(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "music\\base.wav"));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
