using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Global_Classes
{
    public partial class Design : Form
    {
        public Design()
        {
            InitializeComponent();
        }
        public static void LinkLabelStyle(LinkLabel linkLabel1)
        {
            linkLabel1.LinkColor = ColorTranslator.FromHtml("#004a77");
            linkLabel1.ActiveLinkColor = ColorTranslator.FromHtml("#00a8cc");
            linkLabel1.VisitedLinkColor = ColorTranslator.FromHtml("#006699");

            linkLabel1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.BackColor = Color.Transparent;
        }
        public static void ButtonCloseStyle(Button btnClose)
        {
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.ForeColor = ColorTranslator.FromHtml("#1e2a38");
            btnClose.BackColor = Color.Transparent;

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.Cursor = Cursors.Hand;
        }
        public static void labelDesign(Label label1)
        {
            label1.ForeColor = ColorTranslator.FromHtml("#1e2a38");
            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        public static void NormallabelDesign(Label label1)
        {
            label1.ForeColor = ColorTranslator.FromHtml("#1e2a38");
            label1.Font = new Font("Segoe UI", 10);
        }
        public static void DataGridViewDesign(DataGridView dataGridView1)
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#004a77");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#00a8cc");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f4f7fb");
        }


        public static void MenuStripDesign(MenuStrip menuStrip1)
        {
            menuStrip1.BackColor = ColorTranslator.FromHtml("#1E2A38");
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
        }
        public static void DataButtonDesign(Button button1)
        {
            button1.BackColor = ColorTranslator.FromHtml("#004a77");
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;
        }
        public static void DataTextBoxDesign(TextBox textBox1)
        {
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10);
            textBox1.BackColor = Color.White;
        }
        public static void StyleComboBox( ComboBox comboBox1)
        {
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI", 10);
            comboBox1.BackColor = Color.White;
            comboBox1.ForeColor = ColorTranslator.FromHtml("#1e2a38");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Popup;

        }
        public static void MainLabelTitleDesign(Label labelTitle)
        {
            labelTitle.Location = new Point(30, 20); 
            labelTitle.Margin = new Padding(10);
            labelTitle.ForeColor = Color.Transparent;

            labelTitle.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    labelTitle.ClientRectangle,
                    ColorTranslator.FromHtml("#004a77"),
                    ColorTranslator.FromHtml("#00a8cc"),
                    0f))
                {
                    e.Graphics.DrawString(labelTitle.Text, labelTitle.Font, brush, 0, 0);
                }
            };
            labelTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            labelTitle.AutoSize = true;
        }
    }
}
