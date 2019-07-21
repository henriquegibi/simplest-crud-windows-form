using System;
using System.Linq;
using System.Windows.Forms;
using simplest_crud_windows_form.Entities;
using System.Data.Entity;

namespace simplest_crud_windows_form
{
    public partial class Form1 : Form
    {
        Detail MyDetail = new Detail();

        public Form1()
        {
            InitializeComponent();
            PopGridView();
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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            MyDetail.Nome = txtNome.Text;
            MyDetail.Sobrenome = txtSobrenome.Text;
            MyDetail.Idade = Convert.ToInt32(txtIdade.Text);
            MyDetail.Endereco = txtEndereco.Text;
            MyDetail.DataNasc = Convert.ToDateTime(dataNasc.Text);

            using (var MyDbEntities = new MyModel())
            {
                if (MyDetail.ID == 0)
                {
                    MyDbEntities.Details.Add(MyDetail);
                    MyDbEntities.SaveChanges();

                    MessageBox.Show("Informações salvas.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MyDbEntities.Entry(MyDetail).State = EntityState.Modified;
                    MyDbEntities.SaveChanges();

                    btnSalvar.Text = "Salvar";
                    MyDetail.ID = 0;

                    MessageBox.Show("Informações atualizadas.", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            PopGridView();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow.Index != -1)
            {
                MyDetail.ID = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                using (var MyDBEntities = new MyModel())
                {
                    MyDetail = MyDBEntities.Details.Where(x => x.ID == MyDetail.ID).FirstOrDefault();
                    txtNome.Text = MyDetail.Nome;
                    txtSobrenome.Text = MyDetail.Sobrenome;
                    txtIdade.Text = MyDetail.Idade.ToString();
                    txtEndereco.Text = MyDetail.Endereco;
                    dataNasc.Text = MyDetail.DataNasc.ToString();

                    btnSalvar.Text = "Update";
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja deletar as informações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var MyDBEntities = new MyModel())
                {
                    var entry = MyDBEntities.Entry(MyDetail);
                    if (entry.State == EntityState.Detached)
                    {
                        MyDBEntities.Details.Attach(MyDetail);
                        MyDBEntities.Details.Remove(MyDetail);
                        MyDBEntities.SaveChanges();
                        PopGridView();
                        ClearField();
                    }
                }
            }
        }

        void ClearField()
        {
            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtIdade.Text = "";
            txtEndereco.Text = "";
            dataNasc.Text = DateTime.Now.ToString();
        }
    }
}