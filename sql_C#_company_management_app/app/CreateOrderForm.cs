using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class CreateOrderForm : Form
    {
        private DatabaseConnection dbConn;

        public CreateOrderForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_fornecedores", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbSuppliers.DataSource = dt;
                cbSuppliers.DisplayMember = "nome";
                cbSuppliers.ValueMember = "nif";
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                string materiais = txtMaterials.Text;
                string nifFornecedor = cbSuppliers.SelectedValue.ToString();

                using (SqlCommand cmd = new SqlCommand("criar_encomenda_com_fatura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nif_fornecedor", nifFornecedor);
                    cmd.Parameters.AddWithValue("@data_encomenda", dtpOrderDate.Value);
                    cmd.Parameters.AddWithValue("@materiais", materiais);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Encomenda criada com sucesso.");
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro ao criar encomenda: " + ex.Message);
                    }
                }
            }
        }
    }
}
