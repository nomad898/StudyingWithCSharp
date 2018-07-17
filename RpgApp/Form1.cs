using RpgLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgApp
{
    public partial class RogueAdventure : Form
    {
        private Player player;

        public RogueAdventure()
        {
            InitializeComponent();

            Location location = new Location(1, "Home", "This is your home");
            player = new Player(10, 10, 20, 0, 1);

            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            lblGold.Text = player.Gold.ToString();
            lblExperience.Text = player.ExperiencePoints.ToString();
            lblLevel.Text = player.Level.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lblGold.Text = "1230";
        }
    }
}
