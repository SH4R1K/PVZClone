using Game.ObjectsBase.Zombies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game
{
    public class GameLevel
    {
        public string Name { get; set; }
        public ImageSource Background { get; set; }

        public Dictionary<string, int> Zombies { get; set; } = new Dictionary<string, int>();

        public GameLevel(string name, ImageSource background, Dictionary<string, int> zombies)
        {
            Name = name;
            Background = background;
            Zombies = zombies;
        }

    }
}
