using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace ParkingSystem
{
    public partial class Receipt : Form
    {
        private string _parkingNo;
        private string _plate;
        private string _type;
        private string _slot;
        private string _entryTime;
        private string _exitTime;
        private decimal _amount;
        private PrintDocument _printDoc;

        // Constructor that accepts all parking data
        public Receipt(string parkingNo, string plate, string type,
                       string slot, string entryTime, string exitTime, decimal amount)
        {
            InitializeComponent();
            _parkingNo = parkingNo;
            _plate = plate;
            _type = type;
            _slot = slot;
            _entryTime = entryTime;
            _exitTime = exitTime;
            _amount = amount;

            PopulateLabels();
            SetupPrint();
        }

        // ── Populate the labels on your Receipt form ──────────────────────────
        private void PopulateLabels()
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblPlateNumber.Text = _plate;
            lblFromTime.Text = _entryTime;
            lblToTime.Text = _exitTime;
            lblAmount.Text = "" + _amount.ToString("F2");

            // If you have extra labels for these, assign them too:
            // lblParkingNo.Text = _parkingNo;
            // lblType.Text      = _type;
            // lblSlot.Text      = _slot;
        }

        // ── Print setup ───────────────────────────────────────────────────────
        private void SetupPrint()
        {
            _printDoc = new PrintDocument();
            _printDoc.DefaultPageSettings.PaperSize =
                new PaperSize("Receipt", 315, 600); // ~80 mm wide thermal paper
            _printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DrawReceipt(e.Graphics, e.MarginBounds.Left, e.MarginBounds.Top, 280);
        }

        // ── Draw the receipt on the Graphics surface ──────────────────────────
        private void DrawReceipt(Graphics g, float startX, float startY, float width)
        {
            float x = startX;
            float y = startY;

            var fTitle = new Font("Courier New", 13, FontStyle.Bold);
            var fHeader = new Font("Courier New", 10, FontStyle.Bold);
            var fBody = new Font("Courier New", 9);
            var fSmall = new Font("Courier New", 8);
            var fBig = new Font("Courier New", 12, FontStyle.Bold);
            var brush = Brushes.Black;

            var sfCenter = new StringFormat { Alignment = StringAlignment.Center };
            var sfRight = new StringFormat { Alignment = StringAlignment.Far };

            // ── Header ──
            g.DrawString("CITYPARK CO.", fTitle, brush,
                         new RectangleF(x, y, width, 22), sfCenter);
            y += 22;
            g.DrawString("123 Main Street, Downtown", fSmall, brush,
                         new RectangleF(x, y, width, 16), sfCenter);
            y += 16;
            g.DrawString("Tel: (032) 123-4567", fSmall, brush,
                         new RectangleF(x, y, width, 16), sfCenter);
            y += 20;

            DashedLine(g, x, y, x + width, y); y += 10;

            g.DrawString("PAID PARKING RECEIPT", fHeader, brush,
                         new RectangleF(x, y, width, 18), sfCenter);
            y += 22;

            DashedLine(g, x, y, x + width, y); y += 10;

            // ── Details ──
            Row(g, fBody, brush, x, y, width, "DATE   :", DateTime.Now.ToString("MM/dd/yyyy")); y += 18;
            Row(g, fBody, brush, x, y, width, "PARK # :", _parkingNo); y += 18;
            Row(g, fBody, brush, x, y, width, "PLATE  :", _plate); y += 18;
            Row(g, fBody, brush, x, y, width, "TYPE   :", _type); y += 18;
            Row(g, fBody, brush, x, y, width, "SLOT   :", _slot); y += 18;
            Row(g, fBody, brush, x, y, width, "FROM   :", _entryTime); y += 18;
            Row(g, fBody, brush, x, y, width, "TO     :", _exitTime);
            Row(g, fBody, brush, x, y, width, "TO     :", _exitTime); y += 18;

            DashedLine(g, x, y, x + width, y); y += 10;

            // ── Amount ──
            Row(g, fBig, brush, x, y, width, "AMOUNT PAID:", "₱ " + _amount.ToString("F2"));
            y += 28;

            DashedLine(g, x, y, x + width, y); y += 10;

            // ── Barcode placeholder (text) ──
            string barcode = "|||| ||| |||| || ||| |||| ||| ||||";
            g.DrawString(barcode, new Font("Courier New", 7), brush,
                         new RectangleF(x, y, width, 16), sfCenter);
            y += 16;
            g.DrawString(_parkingNo + "-" + DateTime.Now.ToString("yyyyMMddHHmm"),
                         fSmall, brush, new RectangleF(x, y, width, 14), sfCenter);
            y += 18;

            DashedLine(g, x, y, x + width, y); y += 8;

            g.DrawString("THANK YOU AND LUCKY ROAD!", fSmall, brush,
                         new RectangleF(x, y, width, 14), sfCenter);

            // Cleanup fonts
            fTitle.Dispose(); fHeader.Dispose(); fBody.Dispose();
            fSmall.Dispose(); fBig.Dispose();
        }

        private void DashedLine(Graphics g, float x1, float y1, float x2, float y2)
        {
            using (var pen = new Pen(Color.Black, 1f))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void Row(Graphics g, Font font, Brush brush,
                         float x, float y, float width, string label, string value)
        {
            g.DrawString(label, font, brush, x, y);
            g.DrawString(value, font, brush,
                         new RectangleF(x, y, width, 20),
                         new StringFormat { Alignment = StringAlignment.Far });
        }

        // ── Button events ─────────────────────────────────────────────────────

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var pd = new PrintDialog { Document = _printDoc };
            if (pd.ShowDialog() == DialogResult.OK)
                _printDoc.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var ppd = new PrintPreviewDialog { Document = _printDoc };
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Existing empty handlers (keep as-is) ──────────────────────────────
        private void pbReceipt_Click(object sender, EventArgs e) { }
        private void lblDate_Click(object sender, EventArgs e) { }
        private void lblFromTime_Click(object sender, EventArgs e) { }
        private void lblPlateNumber_Click(object sender, EventArgs e) { }
        private void lblToTime_Click(object sender, EventArgs e) { }
        private void lblAmount_Click(object sender, EventArgs e) { }
    }
}