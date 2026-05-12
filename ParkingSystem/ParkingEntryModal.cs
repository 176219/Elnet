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
    public partial class ParkingEntryModal : Form
    {
        public string SelectedSlot = "";
        private decimal _currentFee = 0;

        public ParkingEntryModal()
        {
            InitializeComponent();
        }

        private void ParkingEntryModal_Load(object sender, EventArgs e)
        {
            button1.Text = "Choose Slot";
            displayFee.Text = "Fee: —";

            // Hook change events to auto-update fee label
            cmbType.SelectedIndexChanged += (s, ev) => UpdateFeeDisplay();
            txtPlate.TextChanged += (s, ev) => UpdateFeeDisplay();
            txtTicket.TextChanged += (s, ev) => UpdateFeeDisplay();
        }

        private void UpdateFeeDisplay()
        {
            string type = cmbType.Text;

            if (string.IsNullOrEmpty(type))
            {
                displayFee.Text = "Fee: —";
                _currentFee = 0;
                return;
            }

            _currentFee = DataBasehelper.CalculateFee(type);

            string wheelLabel;
            switch (type)
            {
                case "2 Wheeler": wheelLabel = "2-Wheeler"; break;
                case "4 Wheeler": wheelLabel = "4-Wheeler"; break;
                case "6 Wheeler": wheelLabel = "6-Wheeler"; break;
                default: wheelLabel = type; break;
            }

            displayFee.Text = $"Fee: ₱{_currentFee} per 8 hours ({wheelLabel})";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ticket = txtTicket.Text;
            string plate = txtPlate.Text;
            string type = cmbType.Text;
            string entryTime = dtpEntryTime.Value.ToString("MM/dd/yyyy hh:mm tt");

            if (ticket == "" || plate == "" || type == "" || SelectedSlot == "")
            {
                MessageBox.Show("Please complete all fields!");
                return;
            }

            // SAVE TO DATABASE
            DataBasehelper.InsertParkingRecord(ticket, plate, type, entryTime, SelectedSlot, _currentFee);

            // MARK SLOT AS OCCUPIED
            DataBasehelper.OccupySlot(SelectedSlot);

            MessageBox.Show($"Vehicle parked successfully!\nFee: ₱{_currentFee} per 8 hours");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParkingSlots slotForm = new ParkingSlots();

            if (slotForm.ShowDialog() == DialogResult.OK)
            {
                SelectedSlot = slotForm.SelectedSlot;
                button1.Text = "Slot: " + SelectedSlot;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Designer-wired stubs
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void displayFee_Click(object sender, EventArgs e) { }
    }
}