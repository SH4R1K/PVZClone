using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Plants
{
    public class PeashooterPlant : IPlant
    {
        private int _health;
        public int Price => 100;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    PlantCell.Parent.Children.Remove(PlantCell);
                }
            }
        }

        public ImageSource Image => new BitmapImage(new Uri(@"\Assets\Images\Peashooter.png", UriKind.RelativeOrAbsolute));

        public PlantCell PlantCell { get; set; }
        public double X { get => Canvas.GetLeft(PlantCell); set => Canvas.SetLeft(PlantCell, value); }
        public double Y { get => Canvas.GetTop(PlantCell); set => Canvas.SetTop(PlantCell, value); }

        public void Action(Canvas gameCanvas)
        {
            Shell shell = new Shell();
            shell.Damage = 5;
            shell.Radius = 5;
            shell.XSpeed = 5;
            shell.Parent = PlantCell.Parent;
            shell.X = X + 60;
            shell.Y = Y + 35;
            gameCanvas.Children.Add(shell);

        }
    }
}
