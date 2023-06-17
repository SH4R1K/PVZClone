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
    /// Логика взаимодействия для ZombieBody.xaml
    /// </summary>
    public partial class ZombieBody : UserControl
    {
        public IZombie Zombie = new BasicZombie();
        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        public Canvas Parent { get; set; }
        public Shape Body { get => zombie; }
        public ZombieBody()
        {
            InitializeComponent();
            Zombie.ZombieBody = this;
            zombie.Fill = new ImageBrush(Zombie.Image);
        }
    }
}
