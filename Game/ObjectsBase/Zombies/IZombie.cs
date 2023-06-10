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
    public interface IZombie
    {
        public int Health { get; set; }
        public ImageSource Image { get; }
        public ZombieBody ZombieBody { get; set; }
        public double X { get => Canvas.GetLeft(ZombieBody); set => Canvas.SetLeft(ZombieBody, value); }
        public double Y { get => Canvas.GetTop(ZombieBody); set => Canvas.SetTop(ZombieBody, value); }

        public void Move(UIElement zombieBody);
    }
}
