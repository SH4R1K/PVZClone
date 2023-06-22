using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    static class GameData
    {
        private static int _lives = 3;
        public static int Lives { get => _lives; set
            {
                _lives = value;
                if (_lives == 0)
                    MessageBox.Show("Вы проиграли");
            } 
        }
        public static int Sun { get; set; } = 100;
    }
}
