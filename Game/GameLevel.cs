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

        public Dictionary<ZombieType, int> Zombies { get; set; }
        public List<ZombieType> ZombieTypes { get; set; }
        public GameLevel(string name, ImageSource background, Dictionary<ZombieType, int> zombies, List<ZombieType> zombieTypes)
        {
            Name = name;
            Background = background;
            Zombies = zombies;
            ZombieTypes = zombieTypes;
        }

    }
}
