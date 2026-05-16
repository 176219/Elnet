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
    public partial class Dashboard : Form
    {
        private Timer _refreshTimer;

        public Dashboard()
        {
            InitializeComponent();
            this.Load += new EventHandler(Dashboard_Load);
            this.FormClosed += new FormClosedEventHandler(Dashboard_FormClosed);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            RefreshDashboard();

            _refreshTimer = new Timer();
            _refreshTimer.Interval = 5000;
            _refreshTimer.Tick += (s, ev) => RefreshDashboard();
            _refreshTimer.Start();
        }

        private void RefreshDashboard()
        {
            UpdateStats();
            LoadRecentTransactions();
            UpdateSlotOverview();
        }

        // ─── STATS ────────────────────────────────────────────────────────────

        private void UpdateStats()
        {
            int occupied = DataBasehelper.GetOccupiedCount();
            int available = DataBasehelper.GetAvailableCount();
            decimal income = DataBasehelper.GetTodaysIncome();

            TotalOcclabel.Text = occupied.ToString();
            totalAvailLabel.Text = available.ToString();
            TdIncomeLabel.Text = income.ToString("N0");
        }

        // ─── RECENT TRANSACTIONS ──────────────────────────────────────────────

        private void SetupDataGridView()
        {
            // Columns already exist in Designer — just configure display settings
            dgvRecentTrans.AutoGenerateColumns = false;
            dgvRecentTrans.RowHeadersVisible = false;
            dgvRecentTrans.AllowUserToAddRows = false;
            dgvRecentTrans.ReadOnly = true;
            dgvRecentTrans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Wire Designer columns to data fields
            ParkingNo.DataPropertyName = "#";
            PlateColumn.DataPropertyName = "Plate";
            SlotColumn.DataPropertyName = "Slot";
            FeeColumn.DataPropertyName = "Fee";
            StatusColumn.DataPropertyName = "Status";
        }

        private void LoadRecentTransactions()
        {
            DataTable dt = DataBasehelper.GetRecentTransactions();
            dgvRecentTrans.DataSource = dt;

            foreach (DataGridViewRow row in dgvRecentTrans.Rows)
            {
                if (row.IsNewRow) continue;

                string status = row.Cells["StatusColumn"].Value?.ToString();

                if (status == "Active")
                {
                    row.Cells["StatusColumn"].Style.ForeColor = Color.LimeGreen;
                    row.Cells["StatusColumn"].Style.Font = new Font(dgvRecentTrans.Font, FontStyle.Bold);
                }
                else if (status == "Exited")
                {
                    row.Cells["StatusColumn"].Style.ForeColor = Color.Red;
                    row.Cells["StatusColumn"].Style.Font = new Font(dgvRecentTrans.Font, FontStyle.Bold);
                }
            }
        }

        // ─── SLOT OVERVIEW ────────────────────────────────────────────────────

        private void UpdateSlotOverview()
        {
            var slots = DataBasehelper.GetAllSlots();

            // panel name → slot key
            var slotControls = new Dictionary<string, Panel>
            {
                { "A1", panel6  },
                { "A2", panel8  },
                { "A3", panel9  },
                { "A4", panel10 },
                { "A5", panel11 },
                { "A6", panel12 },
                { "A7", panel2  },
                { "B1", panel13 },
                { "B2", panel14 },
                { "B3", panel15 },
                { "B4", panel16 },
                { "B5", panel17 },
                { "B6", panel18 },
                { "B7", panel3  }
            };

            foreach (var kvp in slotControls)
            {
                bool occupied = slots.ContainsKey(kvp.Key) && slots[kvp.Key] == 1;
                Color bg = occupied ? Color.Red : Color.LimeGreen;

                // Color the panel itself
                kvp.Value.BackColor = bg;

                // Also color the label inside so it stays visible
                foreach (Control child in kvp.Value.Controls)
                {
                    child.BackColor = bg;
                }
            }
        }

        // ─── FORM CLOSED ──────────────────────────────────────────────────────

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }

        // ─── NAV BUTTONS ──────────────────────────────────────────────────────

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }





        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ─── DESIGNER STUBS ───────────────────────────────────────────────────

        private void label14_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void lblTodaysIncome_Click(object sender, EventArgs e) { }
        private void dgvRecentTrans_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void panel7_Paint(object sender, PaintEventArgs e) { }
        private void totalAvailLabel_Click(object sender, EventArgs e) { }
        private void TotalOccPanel_Paint(object sender, PaintEventArgs e) { }
        private void TotalsltsPanel_Paint(object sender, PaintEventArgs e) { }
        private void TotalOcclabel_Click(object sender, EventArgs e) { }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dgvRecentTrans.SelectedRows.Count > 0)
            {
                // Get the Parking Number (#) from the selected row
                // Make sure "ParkingNo" matches the 'Name' property of your column in the designer
                string parkingNo = dgvRecentTrans.SelectedRows[0].Cells["ParkingNo"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete record {parkingNo}?\nThis will also free up its parking slot.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    if (DataBasehelper.DeleteTransaction(parkingNo))
                    {
                        MessageBox.Show("Record deleted successfully.");
                        RefreshDashboard(); // Update the grid and the colorful slot panels
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the record.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction from the list first.");
            }
        }
    }
}
