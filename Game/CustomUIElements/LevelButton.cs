using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.CustomUIElements
{
    public class LevelButton : Button
    {
        public GameLevel GameLevel { get; set; }
    }
}
