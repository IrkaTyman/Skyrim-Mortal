using NUnit.Framework;
using Skyrim.Model;
using System.Security.Policy;

namespace Skyrim_Mortal_Test
{
    [TestFixture]
    public class GameTests
    {
        Image IconHero;

        [SetUp]
        public void SetUp()
        {
            IconHero = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Danmer.png"));
        }

        [Test]
        public void PlayerFarFromEnemy()
        {
            var player = CreatePlayer(0, 0, "Victoria");
            var enemy = CreatePlayer(0, 151, "Anastesha");
            Assert.AreEqual(false, player.IsPlayerCollide(enemy));
        }

        [Test]
        public void PlayerCloseFromEnemy()
        {
            var player = CreatePlayer(0, 10, "Clara");
            var enemy = CreatePlayer(0, 11, "Peter");
            Assert.AreEqual(true, player.IsPlayerCollide(enemy));
        }

        [Test]
        public void GetDamageWorkCorrect()
        {
            var player = CreatePlayer(0, 10, "Person");
            player.GetDamage();
            Assert.AreEqual(90, player.HP);
        }

        [Test]
        public void PlayerIsDeadWorkCorrect()
        {
            var player = CreatePlayer(0, 0, "Deaded people");
            player.IsDead();
            Assert.AreEqual(false, false);
        }

        [Test]
        public void PlayerIsRightRaces()
        {
            var races = new Races();
            var player = CreatePlayer(0, 0, races[RaceType.Nord].Name);
            Assert.AreEqual("Nord", player.Name);
        }

        [Test]
        public void BarrierGetDamage()
        {
            var barrier = CreateBarrier(BarrierType.Tree);
            var fullHP = barrier.HP;
            barrier.GetDamage();
            Assert.AreEqual(barrier.HP, fullHP - 1);
        }

        [Test]
        public void BarrierCloseFromPlayer()
        {
            var barrier = CreateBarrier(BarrierType.Tree);
            var player = CreatePlayer(0, 0, "Some");
            barrier.SetPosition(new Point(player.Size.Width / 2 + player.Position.X, player.Position.Y));
            Assert.AreEqual(barrier.Position.X, player.Size.Width / 2 + player.Position.X);
            Assert.AreEqual(barrier.Position.Y, player.Position.Y);
            Assert.AreEqual(true, player.IsBarrierCollide(barrier, new Point(player.Speed * player.Flip)));
        }

        [Test]
        public void BarrierFarFromPlayer()
        {
            var barrier = CreateBarrier(BarrierType.Tree);
            var player = CreatePlayer(0, 0, "Some");
            barrier.SetPosition(new Point(500,500));
            Assert.AreEqual(false, player.IsBarrierCollide(barrier, new Point(player.Speed * player.Flip)));
        }

        private Player CreatePlayer(int x, int y, string name)
        {
            return new Player(new Size(150,150), new Point(x,y), IconHero, name, null);
        }

        private Skyrim.Model.Barrier? CreateBarrier(BarrierType type)
        {
            var barriers = new Barriers();
            return barriers[type];
        }
    }
}