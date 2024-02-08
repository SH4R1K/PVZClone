using Game.ObjectsBase;
using Game.ObjectsBase.Plants;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        Random random = new Random();
        PlantBase ChoosedPlant { get; set; }
        PeashooterPlant peashooter = new PeashooterPlant();
        SunflowerPlant sunflower = new SunflowerPlant();
        WallnutPlant wallnutPlant = new WallnutPlant();
        public GameWindow(GameLevel gameLevel)
        {
            InitializeComponent();
            CreateObjects();
            Title = gameLevel.Name;
            gameCanvas.Background = new ImageBrush(gameLevel.Background);
            PlantCell[] gameFieldCanvasChildren = gameFieldCanvas.Children.OfType<PlantCell>().ToArray();
            ZombieBody[] zombieBodies = gameFieldCanvas.Children.OfType<ZombieBody>().ToArray();
            Shell[] shells = gameFieldCanvas.Children.OfType<Shell>().ToArray();

            // Кнопочки пока что так создаем, потом че нить придумаю
            Button peaShooterButton = new Button();
            peaShooterButton.Content = "Горохострел";
            peaShooterButton.Click += (s, e) => ChoosedPlant = new PeashooterPlant();
            plantChoosePanel.Children.Add(peaShooterButton);
            Button sunflowerButton = new Button();
            sunflowerButton.Content = "Подсолнух";
            sunflowerButton.Click += (s, e) => ChoosedPlant = new SunflowerPlant();
            plantChoosePanel.Children.Add(sunflowerButton);
            Button wallNutButton = new Button();
            wallNutButton.Content = "Орех";
            wallNutButton.Click += (s, e) => ChoosedPlant = new WallnutPlant();
            plantChoosePanel.Children.Add(wallNutButton);
            //

            bool isAttack = false;

            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += (s, e) =>
            {
                gameFieldCanvasChildren = gameFieldCanvas.Children.OfType<PlantCell>().ToArray();
                for (int i = 0; i < gameFieldCanvasChildren.Length; i++)
                {
                    var item = gameFieldCanvasChildren[i];
                    item.Plant?.Action();
                }
                ZombieBody zombie = new ZombieBody(gameLevel.ZombieTypes[0]);
                zombie.X = gameFieldCanvas.Width + zombie.Body.Width;
                zombie.Y = random.Next(5) * 80;
                zombie.Parent = gameFieldCanvas;
                gameFieldCanvas.Children.Add(zombie);
            };
            gameTimer.Start();

            moveTimer.Interval = TimeSpan.FromMilliseconds(25);
            moveTimer.Tick += (s, e) =>
            {
                gameFieldCanvasChildren = gameFieldCanvas.Children.OfType<PlantCell>().ToArray();
                zombieBodies = gameFieldCanvas.Children.OfType<ZombieBody>().ToArray();
                shells = gameFieldCanvas.Children.OfType<Shell>().ToArray();
                for (int i = 0; i < zombieBodies.Length; i++)
                {
                    var zombieBody = zombieBodies[i];
                    for (int j = 0; j < gameFieldCanvasChildren.Length; j++)
                    {
                        isAttack = false;
                        if (CheckCollision(zombieBody, gameFieldCanvasChildren[j])) // Проверяем на столкновение цветок и зомби
                        {
                            isAttack = true;
                            zombieBody.Zombie?.Attack(gameFieldCanvasChildren[j]);
                            break;
                        }
                    }
                    if (!isAttack) // Если зомби не атакует, то идет
                        zombieBody.Zombie?.Move();
                }
                for (int i = 0; i < shells.Length; i++)
                {
                    var item = shells[i];
                    item.Move();

                    for (int j = 0; j < zombieBodies.Length; j++)
                    {
                        if (CheckCollision(shells[i], zombieBodies[j]))
                        {
                            gameFieldCanvas.Children.Remove(shells[i]);
                            zombieBodies[j].Zombie.Health -= shells[i].Damage;
                            break;
                        }
                    }
                }
                livesTextBlock.Text = $"Жизни: {GameData.Lives}";
                sunTextBlock.Text = $"Солнышки: {GameData.Sun}";
                peaShooterButton.IsEnabled = peashooter.Price <= GameData.Sun;
                sunflowerButton.IsEnabled = sunflower.Price <= GameData.Sun;
                wallNutButton.IsEnabled = wallnutPlant.Price <= GameData.Sun;
            };
            moveTimer.Start();
        }

        public void CreateObjects()
        {
            int rowAmount = 5;
            int columnAmount = 8;
            for (int i = 0; i < rowAmount; i++)
            {
                for (int j = 0; j < columnAmount; j++)
                {
                    PlantCell plantCell = new PlantCell();
                    plantCell.X = j * (plantCell.Body.Width + 10);
                    plantCell.Y = i * (plantCell.Body.Height + 10);
                    plantCell.Parent = gameFieldCanvas;
                    plantCell.Click += (s, e) =>
                    {
                        plantCell.PlacePlant(ChoosedPlant);
                        ChoosedPlant = null;
                    };
                    gameFieldCanvas.Children.Add(plantCell);
                }
            }
        }


        private bool CheckCollision(ZombieBody object1, PlantCell object2)
        {
            Rect rect1 = new Rect(object1.X, object1.Y, object1.Body.Width, object1.Body.Height);
            Rect rect2 = new Rect(object2.X, object2.Y, object2.Body.Width, object2.Body.Height);
            return object2.Plant != null && rect1.IntersectsWith(rect2);
        }

        private bool CheckCollision(Shell object1, ZombieBody object2)
        {
            Rect rect1 = new Rect(object1.X, object1.Y, object1.Body.Width, object1.Body.Height);
            Rect rect2 = new Rect(object2.X, object2.Y, object2.Body.Width, object2.Body.Height);
            return rect1.IntersectsWith(rect2);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            gameTimer.Stop();
            moveTimer.Stop();
        }
    }
}
