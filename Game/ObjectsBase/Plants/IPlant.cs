using System.Windows.Controls;
using System.Windows.Media;

namespace Game.ObjectsBase.Plants
{
    public interface IPlant
    {
        public int Price { get; }
        public int Health { get; set; }
        public ImageSource Image { get; }
        public PlantCell PlantCell { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public void Action(Canvas gameCanvas);

    }
}
