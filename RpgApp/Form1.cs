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
        private Monster currentMonster;

        public RogueAdventure()
        {
            InitializeComponent();

            player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            lblGold.Text = player.Gold.ToString();
            lblExperience.Text = player.ExperiencePoints.ToString();
            lblLevel.Text = player.Level.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lblGold.Text = "1230";
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {

        }

        private void btnWest_Click(object sender, EventArgs e)
        {

        }

        private void btnSouth_Click(object sender, EventArgs e)
        {

        }

        private void btnEast_Click(object sender, EventArgs e)
        {

        }

        private void MoveTo(Location newLocation)
        {
            if (newLocation.ItemRequiredToEnter != null)
            {
                bool playerHasRequiredItem = false;

                foreach(InventoryItem ii in player.Inventory)
                {
                    if (ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
                    {
                        playerHasRequiredItem = true;
                        break;
                    }
                }

                if (!playerHasRequiredItem)
                {
                    rtbMessages.Text += $@"You must have a { newLocation.ItemRequiredToEnter.Name } to enter this location." + Environment.NewLine;
                    return;
                }
            }

            player.CurrentLocation = newLocation;

            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            player.CurrentHitPoints = player.MaximumHitPoints;

            lblHitPoints.Text = player.CurrentHitPoints.ToString();

        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }
    }
}
