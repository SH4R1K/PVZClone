using Game.CustomUIElements;
using Game.ObjectsBase.Zombies;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Windows
{
    /// <summary>
    /// Логика взаимодействия для LevelChooseWindow.xaml
    /// </summary>
    public partial class LevelChooseWindow : Window
    {
        public LevelChooseWindow()
        {
            InitializeComponent();
            ImageSource background = new BitmapImage(new Uri(@"pack://application:,,,/Game;component\Assets\Images\background.png", UriKind.RelativeOrAbsolute));
            Dictionary<ZombieType, int> zombies = new Dictionary<ZombieType, int>();
            List<ZombieType> types = new List<ZombieType>();
            List<ZombieType> types2 = new List<ZombieType>();
            zombies.Add(ZombieType.BASICZOMBIE, 5);
            types.Add(ZombieType.BASICZOMBIE);
            types2.Add(ZombieType.ARMOREDZOMBIE);
            List<GameLevel> gameLevels = new List<GameLevel>()
            {
            new GameLevel("Level1", background, zombies, types),
            new GameLevel("Level2", background, zombies, types2),
            };
            for (int i = 0; i < gameLevels.Count; i++)
            {
                LevelButton levelButton = new();
                levelButton.Content = gameLevels[i].Name;
                levelButton.GameLevel = gameLevels[i];
                levelButton.Width = levelButton.Height = 50;
                levelButton.Click += (s, e) =>
                {
                    GameWindow gameWindow = new(levelButton.GameLevel);
                    GameData.Lives = 3;
                    GameData.Sun = 100;
                    Hide();
                    gameWindow.ShowDialog();
                    Show();
                };
                levelStackPanel.Children.Add(levelButton);
            }
        }
    }
}
