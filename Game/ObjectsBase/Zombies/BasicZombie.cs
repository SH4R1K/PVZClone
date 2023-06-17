using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Zombies
{
    public class BasicZombie : IZombie
    {
        private int _health = 100;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    ZombieBody.Parent.Children.Remove(ZombieBody);
                }
            }
        }

        public int Damage { get; set; } = 5;

        private float _attackCooldown = 1;
        private DateTime _nextAttackTime;

        public ZombieBody ZombieBody { get; set; }
        public double X { get => ZombieBody.X; set => ZombieBody.X = value; }
        public double Y { get => ZombieBody.Y; set => ZombieBody.Y = value; }

        public ImageSource Image => new BitmapImage(new Uri(@"pack://application:,,,/Game;component\Assets\Images\BasicZombie.png", UriKind.RelativeOrAbsolute));

        public void Attack(PlantCell plantCell)
        {
            if (DateTime.Now > _nextAttackTime)
            {
                plantCell.Plant.Health -= Damage;
                _nextAttackTime = DateTime.Now + TimeSpan.FromSeconds(_attackCooldown);
            }
        }

        public void Move(UIElement zombieBody)
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
