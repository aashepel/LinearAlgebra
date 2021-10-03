using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearAlgebraFormsApp
{
    public partial class Form1 : Form
    {
        private int _idCounter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[index];
            row.Cells[0].Value = ++_idCounter;
            row.Cells[1].Value = "Vector";
            
        }
    }
}
