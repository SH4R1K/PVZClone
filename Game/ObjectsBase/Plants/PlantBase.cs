using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.ObjectsBase.Plants
{
    public abstract class PlantBase
    {
        public abstract int Price { get; set; }
        private int _health = 100;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    PlantCell.RemovePlant();
                }
            }
        }
        public abstract ImageSource Image { get; }
        public PlantCell PlantCell { get; set; }
        public double X { get => PlantCell.X; set => PlantCell.X = value; }
        public double Y { get => PlantCell.Y; set => PlantCell.Y = value; }

        public abstract void Action();
    }
}
