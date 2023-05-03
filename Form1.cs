using Csharp_WS_CLIENT;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using WINFORMS_teset.Controllers;
using WINFORMS_teset.Entites;
using WINFORMS_teset.Entities;
using WINFORMS_teset.Models;
using WebSocket = WebSocketSharp.WebSocket;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Media;



namespace WINFORMS_teset
{


    public partial class Form1 : Form
    {
        //declare new Entity object player
        public Entity player;

        public Image knightRSheet;

        public Image knightBSheet;

        public Image enemy1Sheet;
        private Point delta;

        private SoundPlayer Mplayer = new SoundPlayer(@"D:\Computer Science\ER MUSIC\18_Subterranean Shunning-Grounds.wav");

        public Entity player2;
        public Rival enemy;

        public bool facingLeft;
        public bool facingUp;

        public int playerHealth = 100;
        public int playerStamina = 100;
        public bool gameOver;

        public bool isCollide = false;
        private Random random = new Random();
        private Point bitmapPosition;
        public PictureBox pictureBox;
        private Point player1Location;
        private Point player2Location;

        private int playerNumber;
        private bool isConnected;


        public Form1()
        {
            InitializeComponent();

            timer1.Interval =30;

            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

       // public void MainTimerEvent
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    facingUp = true;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    facingUp = false;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    facingLeft = true;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    facingLeft = false;
                    break;
            }

            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                if (player.dirFlip == 1)
                    player.SetAnimationConfiguration(2);
                else player.SetAnimationConfiguration(0);
            }

        }




        public void Init()
        {
            //WS UI


            // Program.pictureBox1_MouseMove():
                
            //map
            Map.Init();
            RivalController.Init();
              this.Width = Map.GetWidth();
              this.Height = Map.GetHeight();

            //player
            knightBSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\knightBlue.png"));

            player = new Entity(320, 425, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, knightBSheet);

            //second player

            //enemy
            enemy1Sheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\test_enemy.png"));

            enemy = new Rival(240, 260, EnemyAni.idleFrames, EnemyAni.runFrames, EnemyAni.attackFrames, EnemyAni.deathFrames, enemy1Sheet);
            timer1.Start();
            if (playerHealth > 1)
            {
                progressBar1.Value = playerHealth;
            }


            playerHealth = 100;
            bitmapPosition = new Point(50, 50);
            WebSocket wsc = new WebSocket("ws://localhost:7456/BitmapPosition");
            wsc.OnMessage += (sender, e) =>
            {
                bitmapPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<Point>(e.Data);
                UpdatePictureBox(bitmapPosition);


            };
            wsc.Connect();
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (sender, e) =>
            {
                bitmapPosition.Y += 1;
                bitmapPosition.X += 1;
                UpdatePictureBox(bitmapPosition);
                if (wsc.ReadyState == WebSocketState.Open)
                {
                    wsc.Send(data: Newtonsoft.Json.JsonConvert.SerializeObject(bitmapPosition));
                }
            };
            timer.Start();

            
            UpdatePictureBox(bitmapPosition);

            void StartSendingLocationUpdates()
            {


                timer1.Tick += (sender, e) =>
                {
                    var locationMessage = new
                    {
                        type = "location",
                        //     x = pictureBox1.Location.X,
                        //  y = pictureBox1.Location.Y
                    };

                    string jsonMessage = Newtonsoft.Json.JsonConvert.SerializeObject(locationMessage);
                    wsc.Send(jsonMessage);
                };

            }


            //enemy
            enemy1Sheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\test_enemy.png"));

            enemy = new Rival(240, 260, EnemyAni.idleFrames, EnemyAni.runFrames, EnemyAni.attackFrames, EnemyAni.deathFrames, enemy1Sheet);
            timer1.Start();
            if (playerHealth > 1)
            {
                progressBar1.Value = playerHealth;
            }
            else gameOver = true;

            playerHealth = 100;
        }




        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -3;
                    player.isMoving = true;

                    if (player.dirFlip == 1)
                        player.SetAnimationConfiguration(8);
                    else player.SetAnimationConfiguration(0);
                    break;
                case Keys.S:
                    player.dirY = 3;
                    player.isMoving = true;
                    if (player.dirFlip == 1)
                        player.SetAnimationConfiguration(10);
                    else player.SetAnimationConfiguration(2);
                    break;
                case Keys.A:
                    player.dirX = -3;
                    player.isMoving = true;
                    if (player.dirY != 0)
                    {
                        if (player.dirFlip == 1)
                            player.SetAnimationConfiguration(8);
                        else player.SetAnimationConfiguration(0);
                    }
                    else
                    {
                        player.SetAnimationConfiguration(9);
                        player.dirFlip = -1;
                    }
                    break;
                case Keys.D:
                    player.dirX = 3;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(11);
                    player.dirFlip = 1;
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    if (player.dirFlip == 1)
                    {
                        player.SetAnimationConfiguration(16);

                    }
                    else player.SetAnimationConfiguration(14);
                    break;
            }

        }


        public void Update(object sender, EventArgs e)
        {
            //PhysicsController.IsCollide(player);
            if (playerHealth > 1)
            {
                 progressBar1.Value = playerHealth;

            }
            else
            {
                gameOver = true;
                //player death animation
                timer1.Stop();
            }
            if (!PhysicsController.IsCollide(player, new Point(player.dirX, player.dirY)))
            {
                if (player.isMoving)
                    player.Move();

            }

            if (Form1.HitboxCollision(player, enemy))
            {

                playerHealth -= 1;
            }
        

            Invalidate();
            
        }
        public static bool HitboxCollision(Entity entity, Rival rival)
        {

            Rectangle playerHitbox = new Rectangle(new Point(entity.posX, entity.posY), new System.Drawing.Size(entity.size, entity.size));
            Rectangle rivalHitbox = new Rectangle(new Point(rival.posX, rival.posY), new System.Drawing.Size(32, 32));

            if (playerHitbox.IntersectsWith(rivalHitbox))
            {
                return true;
                
            }
            return false;
        }




        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Map.DrawMap(g);
            player.PlayAnimation(g);
            RivalController.DrawRival(g);
            enemy.PlayAnimation(g);
           
          

        }
        

        private void UpdatePictureBox(Point bitmapPosition)
        {
          //  pictureBox1.Location = new Point(bitmapPosition.X - (pictureBox1.Width / 2), bitmapPosition.Y - (pictureBox1.Height / 2));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        sbyte progressBarRed = 2;
        //sbyte progressBarYellow = 3;
        private void progressBar1_Click(object sender, EventArgs e)
        {
            ModifyProgressBarColor.SetState(progressBar1, progressBarRed);
            // ModifyProgressBarColor.SetState(progressBar2, progressBarYellow);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

  



    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }


}
