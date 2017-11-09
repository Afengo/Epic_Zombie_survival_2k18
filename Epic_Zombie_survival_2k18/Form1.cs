using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epic_Zombie_survival_2k18
{
    public partial class Form1 : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        string facing = "up";
        double playerHealth;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if(e.KeyCode == Keys.A)
            {
                goleft = true;
                facing = "left";
                Player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;
                facing = "right";
                Player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.W)
            {
                goup = true;
                facing = "up";
                Player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = true;
                facing = "down";
                Player.Image = Properties.Resources.down;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if (e.KeyCode == Keys.A)
            {
                goleft = false;
                facing = "left";
                Player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = false;
                facing = "right";
                Player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.W)
            {
                goup = false;
                facing = "up";
                Player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = false;
                facing = "down";
                Player.Image = Properties.Resources.down;
            }
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                Fire(/*facing*/);
                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
        }

        private void GameEngine(object sender, EventArgs e)
        {
            if (goleft && Player.Left > 0)
            {
                Player.Left -= speed;
            }
            if (goright && Player.Left + Player.Width < 930)
            {
                Player.Left += speed;
            }
            if (goup && Player.Top > 60)
            {
                Player.Top -= speed;
            }
            if (godown && Player.Top + Player.Height < 700)
            {
                Player.Top += speed;
            }
        }
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            Player.BringToFront();
        }
        private void Fire()
        {
            Bullet shoot = new Bullet();
            Fire.direction = direct;
            shoot.bulletLeft = Player.Left + (Player.Width / 2);
            shoot.bulletTop = Player.Top + (Player.Height / 2);
            shoot.mkBullet(this);
        }
        private void SpawnZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Image = Properties.Resources.zdown;
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.Left = rnd.Next(0, 900);
            zombie.Top = rnd.Next(0, 800);
            zombie.Tag = "zombie";
            this.Controls.Add(zombie);
        }
    }
}
