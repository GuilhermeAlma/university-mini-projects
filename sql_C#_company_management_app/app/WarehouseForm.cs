using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class WarehouseForm : Form
    {
        private DatabaseConnection dbConn;

        public WarehouseForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_materiais", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMaterials.DataSource = dt;
            }
        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count > 0)
            {
                int codigo_material = Convert.ToInt32(dgvMaterials.SelectedRows[0].Cells["codigo"].Value);

                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("remover_material", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", codigo_material);
                        cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtQuantity.Text));

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Material removido com sucesso do armazém.");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("Quantidade insuficiente no armazém"))
                            {
                                MessageBox.Show("Quantidade insuficiente no armazém.");
                            }
                            else
                            {
                                MessageBox.Show("Erro ao remover material: " + ex.Message);
                            }
                        }
                    }
                    LoadMaterials();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um material para remover.");
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var createOrderForm = new OrdersForm();
            createOrderForm.ShowDialog();
            LoadMaterials();
        }
    }
}
