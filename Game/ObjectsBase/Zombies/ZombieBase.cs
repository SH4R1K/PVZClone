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
    public abstract class ZombieBase
    {

        public ZombieBody ZombieBody { get; set; }
        public abstract ImageSource Image { get; }
        public double X { get => ZombieBody.X; set => ZombieBody.X = value; }
        public double Y { get => ZombieBody.Y; set => ZombieBody.Y = value; }


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

        public abstract void Attack(PlantCell plantCell);

        public abstract void Move();
    }
}
