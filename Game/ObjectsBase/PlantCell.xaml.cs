using Game.ObjectsBase.Plants;
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
        public IPlant Plant { get; set; }
        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        public Canvas Parent { get; set; }
        public EventHandler Click;
        public PlantCell()
        {
            InitializeComponent();
            DataContext = Plant;
        }

        public void PlacePlant(IPlant newPlant)
        {
            if (Plant != null || newPlant == null)
                return;
            this.Plant = newPlant; // Назначаем свойству
            newPlant.PlantCell = this; // Задаем родителя
            plantImage.Source = Plant.Image; // Задаем картинку?
        }

        private void PlantCell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
