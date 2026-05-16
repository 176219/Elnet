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
    public partial class Form3 : Form
    {
        private Form _previousForm;
        public Form3(Form previousForm = null)
        {
            InitializeComponent();
            _previousForm = previousForm;
            this.FormClosed += (s, e) => _previousForm?.Show();

        }

        private void btnParking_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSlot_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            ParkingEntryModal form = new ParkingEntryModal();

            // open as modal dialog
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadVehicleLogs(); // refresh the DataGridView after saving
            }
        }

        private void dgvVehicleLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadVehicleLogs()
        {
            dgvVehicleLog.DataSource = DataBasehelper.GetVehicleLogs();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadVehicleLogs();
        }

        private void txtbSearchPlate_TextChanged(object sender, EventArgs e)
        {
            string plate = txtbSearchPlate.Text.Trim();

            if (plate.Length < 2)
            {
                ClearExitFields();
                return;
            }

            DataRow row = DataBasehelper.GetActiveRecordByPlate(plate);

            if (row != null)
            {
                prklbl.Text = row["ParkingNumber"].ToString();
                platelbl.Text = row["Plate"].ToString();
                typelbl.Text = row["Type"].ToString();
                slotlbl.Text = row["Slot"].ToString();
                entrytimelbl.Text = row["EntryTime"].ToString();
                exttimelbl.Text = "";
            }
            else
            {
                ClearExitFields();
            }
        }

        private void prcsBtn_Click(object sender, EventArgs e)
        {
            string plate = txtbSearchPlate.Text.Trim();

            if (string.IsNullOrEmpty(plate))
            {
                MessageBox.Show("Please enter a plate number.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(slotlbl.Text))
            {
                MessageBox.Show("No active record found for this plate.", "Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Process exit for plate " + plate + "?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Capture data BEFORE processing exit
                string parkingNo = prklbl.Text;
                string plateNo = platelbl.Text;
                string type = typelbl.Text;
                string slot = slotlbl.Text;
                string entryTime = entrytimelbl.Text;
                string exitTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                // ── Calculate parking fee ──────────────────────────────────────
                decimal amount = CalculateFee(entryTime, exitTime, type);

                // Process the exit in the database
                bool success = DataBasehelper.ProcessExit(plate, exitTime, amount);

                exttimelbl.Text = exitTime;

                // ── Open the Receipt form ─────────────────────────────────────
                Receipt receipt = new Receipt(parkingNo, plateNo, type,
                                              slot, entryTime, exitTime, amount);
                receipt.ShowDialog();  // ShowDialog so it blocks until user closes/prints

                // Refresh and clear
                LoadVehicleLogs();
                txtbSearchPlate.Clear();
                ClearExitFields();
            }

        }

        // ── Fee calculator ────────────────────────────────────────────────────────────
        private decimal CalculateFee(string entryTimeStr, string exitTimeStr, string vehicleType)
        {
            // 1. Get the Base Rate from DataBasehelper (matching your Modal logic)
            decimal baseRate = DataBasehelper.CalculateFee(vehicleType);

            try
            {
                DateTime entry = DateTime.Parse(entryTimeStr);
                DateTime exit = DateTime.Parse(exitTimeStr);

                double totalHours = (exit - entry).TotalHours;

                // If they stayed less than 8 hours, they pay the base rate
                if (totalHours <= 8)
                {
                    return baseRate;
                }
                else
                {
                    // Example: ₱20 for every additional 8 hours (or part thereof)
                    // Adjust the '20m' to whatever your overtime rate is
                    int extraBlocks = (int)Math.Ceiling((totalHours - 8) / 8.0);
                    return baseRate + (extraBlocks * 20m);
                }
            }
            catch
            {
                return baseRate; // Fallback to base rate if dates are messy
            }
        }

        private void platelbl_Click(object sender, EventArgs e)
        {

        }

        private void exttimelbl_Click(object sender, EventArgs e)
        {

        }

        private void entrytimelbl_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void typelbl_Click(object sender, EventArgs e)
        {

        }

        private void slotlbl_Click(object sender, EventArgs e)
        {

        }

        private void prklbl_Click(object sender, EventArgs e)
        {

        }

        private void ClearExitFields()
        {
            prklbl.Text = "";
            platelbl.Text = "";
            typelbl.Text = "";
            slotlbl.Text = "";
            entrytimelbl.Text = "";
            exttimelbl.Text = "";
        }

        private void txtbSearchVehicle_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
