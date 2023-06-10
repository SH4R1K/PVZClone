using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Plants
{
    public class SunflowerPlant : IPlant
    {
        private int _health;
        public int Price => 50;
        public ImageSource Image => new BitmapImage(new Uri(@"\Assets\Images\Sunflower.png", UriKind.RelativeOrAbsolute));

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
        public PlantCell PlantCell { get; set; }
        public double X { get => Canvas.GetLeft(PlantCell); set => Canvas.SetLeft(PlantCell, value); }
        public double Y { get => Canvas.GetTop(PlantCell); set => Canvas.SetTop(PlantCell, value); }

        public void Action(Canvas gameCanvas)
        {
        }
    }
}
