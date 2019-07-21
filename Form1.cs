using System;
using System.Linq;
using System.Windows.Forms;
using simplest_crud_windows_form.Entities;

namespace simplest_crud_windows_form
{
    public partial class Form1 : Form
    {
        Detail MyDetail = new Detail();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopGridView();
        }

        private void PopGridView()
        {
            using (var MyModelEntities = new MyModel())
            {
                dataGridView.DataSource = MyModelEntities.Details.ToList<Detail>();
            }
        }
    }
}