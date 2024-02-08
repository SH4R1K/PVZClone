using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Zombies
{
    public class BasicZombie : ZombieBase
    {
        private float _attackCooldown = 1;
        private DateTime _nextAttackTime;
        public override ImageSource Image => new BitmapImage(new Uri(@"pack://application:,,,/Game;component\Assets\Images\BasicZombie.png", UriKind.RelativeOrAbsolute));

        public BasicZombie()
        {
            Damage = 5;
            Health = 100;
        }

        public override void Attack(PlantCell plantCell)
        {
            if (DateTime.Now > _nextAttackTime)
            {
                plantCell.Plant.Health -= Damage;
                _nextAttackTime = DateTime.Now + TimeSpan.FromSeconds(_attackCooldown);
            }
        }

        public override void Move()
        {
            X -= 2;
            if (X < 0)
            {
                GameData.Lives--;
                Health = 0;
            }
        }
    }
}
