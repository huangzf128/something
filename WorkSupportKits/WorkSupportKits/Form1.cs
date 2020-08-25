using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FetchRepository;

namespace WorkSupportKits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFetchSVN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FetchRepository.Form1().ShowDialog();
            this.Show();
        }

        private void butTable_Click(object sender, EventArgs e)
        {

        }

        private void butProcedure_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SymfoTools.StoredWatcherForm().ShowDialog();
            this.Show();
        }

        private void butSymfoTable_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SymfoTools.TableWatcherForm().ShowDialog();
            this.Show();
        }
    }
}
