using DVDL.Dashboard.pages;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Dashboard
{
    public partial class frmMainDashboard : Form
    {
        public frmMainDashboard()
        {
            InitializeComponent();
        }

        private void _LoadForm(object frm) 
        {
            if (this.panel4.Controls.Count > 0)
                this.panel4.Controls.Clear();

            Form f = frm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(f);
            this.panel4.Tag = f;
            f.Show();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmDashboard());
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            _LoadForm(new frmDashboard());
        }
    }
}
