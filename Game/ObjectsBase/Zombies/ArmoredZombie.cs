using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.ObjectsBase.Zombies
{
    internal class ArmoredZombie : IZombie
    {
        private int _health = 150;
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

        public ImageSource Image => throw new NotImplementedException();

        public ZombieBody ZombieBody { get; set; }
        public double X { get => ZombieBody.X; set => ZombieBody.X = value; }
        public double Y { get => ZombieBody.Y; set => ZombieBody.Y = value; }

        public void Attack(PlantCell plantCell)
        {
            plantCell.Plant.Health -= Damage;
        }

        public void Move(UIElement zombieBody)
        {
            X -= 2;
            if (X < 0)
                X = 800;
        }
    }
}
