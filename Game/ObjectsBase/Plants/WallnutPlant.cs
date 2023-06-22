using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.ObjectsBase.Plants
{
    public class WallnutPlant : PlantBase
    {
        public override int Price { get; set; } = 150;

        public override ImageSource Image => new BitmapImage(new Uri(@"\Assets\Images\Wallnut.png", UriKind.RelativeOrAbsolute));

        public override void Action()
        {
        }
    }
}
