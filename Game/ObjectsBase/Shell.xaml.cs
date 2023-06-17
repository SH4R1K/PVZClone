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
    /// Логика взаимодействия для Shell.xaml
    /// </summary>
    public partial class Shell : UserControl
    {
        public int XSpeed { get; set; }
        public int Damage { get; set; }
        public double Radius { get => bullet.Width; set => bullet.Width = bullet.Height = value; }
        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        public Canvas Parent { get; set; }
        public Shape Body { get => bullet; }

        public Shell()
        {
            InitializeComponent();
            bullet.Fill = new SolidColorBrush(Colors.Red);
        }
        
        public void Move(UIElement shell)
        {
            X += XSpeed;
            if (X >= Parent.Width) 
                Parent.Children.Remove(shell);
        }
    }
}
