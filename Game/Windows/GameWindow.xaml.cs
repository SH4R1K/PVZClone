using Game.ObjectsBase;
using Game.ObjectsBase.Plants;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Game.Windows
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer(DispatcherPriority.Render);
        DispatcherTimer moveTimer = new DispatcherTimer(DispatcherPriority.Render);
        Random random= new Random();
        IPlant ChoosedPlant { get; set; }
        public GameWindow()
        {
            InitializeComponent();
            CreateObjects();
            PlantCell[] gameCanvasChildren = gameCanvas.Children.OfType<PlantCell>().ToArray();
            ZombieBody[] zombieBodies = gameCanvas.Children.OfType<ZombieBody>().ToArray();
            Shell[] shells = gameCanvas.Children.OfType<Shell>().ToArray();

            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += (s, e) =>
            {
                gameCanvasChildren = gameCanvas.Children.OfType<PlantCell>().ToArray();
                for (int i = 0; i < gameCanvasChildren.Length; i++)
                {
                    var item = gameCanvasChildren[i];
                    item.Plant?.Action(gameCanvas);

                }
                ZombieBody zombie = new ZombieBody();
                zombie.X = gameCanvas.Width+zombie.Body.Width;
                zombie.Y = random.Next(4)*100;
                zombie.Parent = gameCanvas;
                gameCanvas.Children.Add(zombie);
            };
            gameTimer.Start();

            moveTimer.Interval = TimeSpan.FromMilliseconds(25);
            moveTimer.Tick += (s, e) =>
            {
                zombieBodies = gameCanvas.Children.OfType<ZombieBody>().ToArray();
                for (int i = 0; i < zombieBodies.Length; i++)
                {
                    var item = zombieBodies[i];
                    item.Zombie?.Move(item);
                }
                shells = gameCanvas.Children.OfType<Shell>().ToArray();
                for (int i = 0; i < shells.Length; i++)
                {
                    var item = shells[i];
                    item.Move(item);

                    for (int j = 0; j < zombieBodies.Length; j++)
                    {
                        if (CheckCollision(shells[i], zombieBodies[j]))
                        {
                            gameCanvas.Children.Remove(shells[i]);
                            zombieBodies[j].Zombie.Health -= shells[i].Damage;
                            break;
                        }
                    }
                }
            };
            moveTimer.Start();
        }

        public void CreateObjects()
        {
            int rowAmount = 4;
            int columnAmount = 8;
            ZombieBody zombie = new ZombieBody();
            zombie.X = 700;
            zombie.Y = 200;
            zombie.Parent = gameCanvas;
            for (int i = 0; i < rowAmount; i++)
            {
                for (int j = 0; j < columnAmount; j++)
                {
                    PlantCell plantCell = new PlantCell();
                    plantCell.X = j * 75;
                    plantCell.Y = i * 100;
                    plantCell.Parent = gameCanvas;
                    plantCell.Click += (s, e) =>
                    {
                        plantCell.PlacePlant(ChoosedPlant);
                        ChoosedPlant = null;
                    };
                    gameCanvas.Children.Add(plantCell);
                }
            }
            gameCanvas.Children.Add(zombie);

            Button peaShooterButton = new Button();
            peaShooterButton.Content = "Горохострел";
            peaShooterButton.Click += (s, e) => ChoosedPlant = new PeashooterPlant();
            plantChoosePanel.Children.Add(peaShooterButton);
            Button sunflowerButton = new Button();
            sunflowerButton.Content = "Подсолнух";
            sunflowerButton.Click += (s, e) => ChoosedPlant = new SunflowerPlant();
            plantChoosePanel.Children.Add(sunflowerButton);
        }

        public bool CheckCollision(Shell object1, ZombieBody object2)
        {
            Rect rect1 = new Rect(object1.X, object1.Y, object1.Body.Width, object1.Body.Height);
            Rect rect2 = new Rect(object2.X, object2.Y, object2.Body.Width, object2.Body.Height);
            return rect1.IntersectsWith(rect2);
        }
    }
}
