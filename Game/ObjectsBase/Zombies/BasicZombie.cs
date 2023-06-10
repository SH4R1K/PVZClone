using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Zombies
{
    public class BasicZombie : IZombie
    {
        private int _health;
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
        public ZombieBody ZombieBody { get; set; }
        public double X { get => Canvas.GetLeft(ZombieBody); set => Canvas.SetLeft(ZombieBody, value); }
        public double Y { get => Canvas.GetTop(ZombieBody); set => Canvas.SetTop(ZombieBody, value); }

        public ImageSource Image => new BitmapImage(new Uri(@"pack://application:,,,/Game;component\Assets\Images\BasicZombie.png", UriKind.RelativeOrAbsolute));


        public void Move(UIElement zombieBody)
        {
            X -= 2;
            if (X < 0)
                X = 800;
        }
    }
}
