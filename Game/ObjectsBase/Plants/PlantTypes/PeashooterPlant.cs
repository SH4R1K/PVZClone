using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Plants
{
    public class PeashooterPlant : PlantBase
    {

        public override int Price { get; set; } = 100;
        public int Damage { get; set; }
        public PeashooterPlant()
        {
            Health = 5;
            Damage = 100;
        }

        public override ImageSource Image => new BitmapImage(new Uri(@"\Assets\Images\Peashooter.png", UriKind.RelativeOrAbsolute));
        public override void Action()
        {
            Shell shell = new Shell();
            shell.Damage = Damage;
            shell.Radius = 10;
            shell.XSpeed = 5;
            shell.Body.Fill = new SolidColorBrush(Colors.SpringGreen);
            shell.Parent = PlantCell.Parent;
            shell.X = X + 60;
            shell.Y = Y + 35;
            PlantCell.Parent.Children.Add(shell);

        }
    }
}
