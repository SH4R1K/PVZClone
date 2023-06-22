using Game.ObjectsBase.Plants;
using Game.ObjectsBase.Zombies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game.ObjectsBase
{
    /// <summary>
    /// Логика взаимодействия для PlantCell.xaml
    /// </summary>
    public partial class PlantCell : UserControl
    {
        public PlantBase Plant { get; set; }
        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        public Canvas Parent { get; set; }
        public Shape Body { get => plantCell; }

        public EventHandler Click;
        public PlantCell()
        {
            InitializeComponent();
            DataContext = Plant;
        }

        public void PlacePlant(PlantBase newPlant)
        {
            if (Plant != null || newPlant == null)
                return;
            GameData.Sun -= newPlant.Price;
            this.Plant = newPlant; // Назначаем свойству
            newPlant.PlantCell = this; // Задаем родителя
            plantImage.Source = Plant.Image; // Задаем картинку?
        }

        public void RemovePlant()
        {
            plantImage.Source = null;
            Plant = null;
        }

        private void PlantCell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
