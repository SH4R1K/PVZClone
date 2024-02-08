using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Plants
{
    public class SunflowerPlant : PlantBase
    {
        public override int Price { get; set; } = 50;
        public SunflowerPlant() 
        {
            Health = 50;
        }
        public override ImageSource Image => new BitmapImage(new Uri(@"\Assets\Images\Sunflower.png", UriKind.RelativeOrAbsolute));

        public override void Action()
        {
            GameData.Sun += 10;
        }
    }
}
