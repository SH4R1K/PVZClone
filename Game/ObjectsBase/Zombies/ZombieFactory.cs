using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.ObjectsBase.Zombies
{
    public class ZombieFactory
    {
        public static ZombieBase CreateZombie(ZombieType zombieType)
        {
            ZombieBase zombieBase = null;
            switch (zombieType)
            {
                case ZombieType.BASICZOMBIE:
                    zombieBase = new BasicZombie();
                    break;
                case ZombieType.ARMOREDZOMBIE:
                    zombieBase = new ArmoredZombie();
                    break;
            }
            return zombieBase;
        }
    }
}
