using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class ServicesForm : Form
    {
        private DatabaseConnection dbConn;

        public ServicesForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {
            LoadAllServices();
            LoadClients();
        }

        private void LoadAllServices()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_todos_servicos", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvServices.DataSource = dt;
            }
        }

        private void LoadClients()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_clientes", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbClients.DataSource = dt;
                cbClients.DisplayMember = "nome";
                cbClients.ValueMember = "no_cliente";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string estado = cbFilterState.SelectedItem.ToString();
            LoadServicesByState(estado);
        }

        private void LoadServicesByState(string estado)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("listar_servicos_por_estado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@estado", estado);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvServices.DataSource = dt;
                }
            }
        }

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("criar_servico", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_cliente", cbClients.SelectedValue);
                    cmd.Parameters.AddWithValue("@local_servico", txtLocation.Text);
                    cmd.Parameters.AddWithValue("@estado_atual", "Em Andamento");
                    cmd.Parameters.AddWithValue("@data_hora_i", dtpStartDate.Value);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Serviço criado com sucesso.");
                        LoadAllServices();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro ao criar serviço: " + ex.Message);
                    }
                }
            }
        }

        private void btnCompleteService_Click(object sender, EventArgs e)
        {
            UpdateServiceState("Concluído");
        }

        private void btnCancelService_Click(object sender, EventArgs e)
        {
            UpdateServiceState("Cancelado");
        }

        private void UpdateServiceState(string newState)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                int no_servico = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["no_interno"].Value);

                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("atualizar_estado_servico", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@estado_atual", newState);
                        cmd.Parameters.AddWithValue("@data_hora_f", DateTime.Now);
                        cmd.Parameters.AddWithValue("@no_interno", no_servico);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Serviço {newState.ToLower()} com sucesso.");
                            LoadAllServices();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar estado do serviço: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um serviço para atualizar o estado.");
            }
        }
    }
}
