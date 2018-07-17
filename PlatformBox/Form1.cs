using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformBox
{
    public partial class Form1 : Form
    {
        bool goLeft = false;
        bool goRight = false;
        bool jumping = false;
        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            MovementLogic(e, true);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            MovementLogic(e, false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerPB.Top += jumpSpeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goLeft)
            {
                playerPB.Left -= 5;
            }
            if (goRight)
            {
                playerPB.Left += 5;
            }
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            foreach (Control x in this.Controls)
            {
                bool v = x.Tag == "platform";
                if (x is PictureBox && v)
                {
                    if (playerPB.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        playerPB.Top = x.Top - playerPB.Height;
                    }
                    if (playerPB.Bounds.IntersectsWith(Door.Bounds))
                    {
                        timer1.Stop();
                        MessageBox.Show("You are a winner!!!");
                    }
                }
            }
        }

        private void MovementLogic(KeyEventArgs e, bool status)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = status;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = status;
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = status;
            }
        }
    }
}
