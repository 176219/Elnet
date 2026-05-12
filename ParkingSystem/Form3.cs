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
        public Form3()
        {
            InitializeComponent();
    
        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard f3 = new Dashboard();
            f3.Show();
        }

        private void btnSlot_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();

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
                DataBasehelper.ProcessExit(plate);
                exttimelbl.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                MessageBox.Show("Exit processed successfully!", "Done",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the vehicle log grid
                LoadVehicleLogs();

                // Clear after a short delay so user sees the exit time
                txtbSearchPlate.Clear();
                ClearExitFields();
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
    }
}
