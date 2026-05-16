using DVDL.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.People
{
    public partial class frmFindPerson : Form
    {




        private void _LoadDesign()
        {
            Design.ButtonCloseStyle(btnClose);
            Design.MainLabelTitleDesign(lblMainTitle);

        }


        public frmFindPerson()
        {
            InitializeComponent();
            _LoadDesign();
        }



    }
}
