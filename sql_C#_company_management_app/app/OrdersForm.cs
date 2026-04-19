using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class OrdersForm : Form
    {
        private DatabaseConnection dbConn;

        public OrdersForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_encomendas", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvOrders.DataSource = dt;
            }
        }

        private void btnViewOrderDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int no_encomenda = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["no_encomenda"].Value);
                LoadOrderDetails(no_encomenda);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma encomenda para ver os detalhes.");
            }
        }

        private void LoadOrderDetails(int no_encomenda)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_detalhes_encomenda", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@no_encomenda", no_encomenda);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvOrderDetails.DataSource = dt;
            }
        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int no_encomenda = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["no_encomenda"].Value);
                string newStatus = cbOrderStatus.SelectedItem.ToString();

                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("atualizar_estado_encomenda", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@no_encomenda", no_encomenda);
                        cmd.Parameters.AddWithValue("@novo_estado", newStatus);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Estado da encomenda atualizado com sucesso.");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar estado: " + ex.Message);
                        }
                    }
                }

                LoadOrders();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma encomenda para atualizar o estado.");
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            // Open the form to create a new order
            var createOrderForm = new CreateOrderForm();
            createOrderForm.ShowDialog();
            // Reload the orders after creating a new one
            LoadOrders();
        }
    }
}
