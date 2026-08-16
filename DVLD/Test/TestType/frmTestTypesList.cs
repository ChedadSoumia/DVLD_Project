using DVDL.Global_Classes;
using DVDL.Test.TestType;
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


namespace DVDL.Test
{
    public partial class frmTestTypesList : Form
    {
        private DataTable _AllTestTypesList;

        public frmTestTypesList()
        {
            InitializeComponent();
            _MyDesign();
        }
        private void _MyDesign()
        {
            clsDesign.DataGridViewDesign(dgvTestTypes);
            clsDesign.MainLabelTitleDesign(lblMainTitle);
            clsDesign.labelDesign(label2);
            clsDesign.labelDesign(lblRecordsCount);

        }

        private void frmTestTypesList_Load(object sender, EventArgs e)
        {
            _AllTestTypesList = clsTestTypes.GetAllTestTypes();
            dgvTestTypes.DataSource = _AllTestTypesList;

            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 120;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 200;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 400;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType EditTestType = new frmEditTestType((clsTestTypes.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            EditTestType.ShowDialog();
            frmTestTypesList_Load(null, null);
        }



    }
}
