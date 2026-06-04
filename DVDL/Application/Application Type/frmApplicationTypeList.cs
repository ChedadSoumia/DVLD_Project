using DVDL.Application.Application_Type;
using DVDL.Global_Classes;
using DVDL_business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVDL.Application
{
    public partial class frmApplicationTypeList : Form
    {

        private DataTable _dtAllApplicationTypes;

        public frmApplicationTypeList()
        {
            InitializeComponent();
            _MyDesign();
        }

        private void _MyDesign()
        {
            Design.DataGridViewDesign(dgvApplicationTypes);
            Design.MainLabelTitleDesign(lblMainTitle);
            Design.labelDesign(label2);
            Design.labelDesign(lblRecordsCount);

        }

        private void dgvApplicationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditApplicationType EditAppType = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            EditAppType.ShowDialog();
            frmApplicationTypeList_Load(null, null);
        }

        private void frmApplicationTypeList_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationType();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();


            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 110;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 400;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType EditAppType = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            EditAppType.ShowDialog();
            frmApplicationTypeList_Load(null, null);
        }
    }
}
