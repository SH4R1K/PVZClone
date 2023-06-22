using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Zombies
{
    public class ArmoredZombie : ZombieBase
    {
        private float _attackCooldown = 1;
        private DateTime _nextAttackTime;
        public override ImageSource Image => new BitmapImage(new Uri(@"pack://application:,,,/Game;component\Assets\Images\ArmoredZombie.png", UriKind.RelativeOrAbsolute));

        public ArmoredZombie()
        {
            Damage = 5;
            Health = 1000;
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
