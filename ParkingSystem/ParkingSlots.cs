using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    public partial class ParkingSlots : Form
    {
        public string SelectedSlot = "";
        public ParkingSlots()
        {
            InitializeComponent();
        }
        private void LoadSlotStatus()
        {
            var slots = DataBasehelper.GetAllSlots();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    string slotName = btn.Text; // A1, A2, B1 etc.

                    if (slots.ContainsKey(slotName))
                    {
                        int occupied = slots[slotName];

                        if (occupied == 0)
                            btn.BackColor = Color.LightGreen; // Available
                        else
                            btn.BackColor = Color.Red;        // Occupied
                    }
                }
            }
        }
        private void SlotButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Convert btnA1 → A1
            string slotName = btn.Name.Replace("btn", "");

            // Check if slot is free
            if (!DataBasehelper.IsSlotAvailable(slotName))
            {
                MessageBox.Show("Slot already occupied!");
                return;
            }

            // Save selected slot
            SelectedSlot = slotName;

            // Return to previous form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ParkingSlots_Load(object sender, EventArgs e)
        {
            LoadSlotStatus();
        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }

        private void btnB5_Click(object sender, EventArgs e)
        {
            SlotButton_Click(sender, e);
        }
    }
}
