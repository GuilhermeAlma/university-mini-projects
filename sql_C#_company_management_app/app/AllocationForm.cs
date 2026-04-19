using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class AllocationForm : Form
    {
        private DatabaseConnection dbConn;

        public AllocationForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void AllocationForm_Load(object sender, EventArgs e)
        {
            LoadServices();
            LoadEmployees();
            LoadVehicles();
            LoadMaterialsList();
            LoadMaterialQuantity();

            cbMaterials.SelectedIndexChanged += cbMaterials_SelectedIndexChanged;
            cbServices.SelectedIndexChanged += cbServices_SelectedIndexChanged;
        }

        private void LoadServices()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_servicos_andamento", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbServices.DataSource = dt;
                cbServices.DisplayMember = "display";
                cbServices.ValueMember = "no_interno";

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Não existem serviços em andamento.");
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_funcionarios", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbEmployees.DataSource = dt;
                cbEmployees.DisplayMember = "display";
                cbEmployees.ValueMember = "no_funcionario";
            }
        }

        private void LoadVehicles()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_veiculos", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbVehicles.DataSource = dt;
                cbVehicles.DisplayMember = "display";
                cbVehicles.ValueMember = "matricula";
            }
        }

        private void LoadMaterialsList()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("listar_materiais", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("display", typeof(string), "codigo + ' - ' + nome");
                cbMaterials.DataSource = dt;
                cbMaterials.DisplayMember = "display";
                cbMaterials.ValueMember = "codigo";
            }
        }

        private void cbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaterialQuantity();
        }

        private void LoadMaterialQuantity()
        {
            if (cbMaterials.SelectedValue != null)
            {
                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("carregar_quantidade_material", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@codigo_material", cbMaterials.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    txtWarehouseQuantity.Text = dt.Rows[0]["qnt_armazem"].ToString();
                }
            }
        }

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("alocar_funcionario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_funcionario", cbEmployees.SelectedValue);
                    cmd.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("Funcionário já alocado ao serviço"))
                        {
                            MessageBox.Show("Funcionário já alocado ao serviço.");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alocar funcionário: " + ex.Message);
                        }
                    }

                    LoadServiceEmployees();
                }
            }
        }

        private void btnAssignVehicle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("alocar_veiculo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                    cmd.Parameters.AddWithValue("@matricula", cbVehicles.SelectedValue);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("Viatura já alocada ao serviço"))
                        {
                            MessageBox.Show("Viatura já alocada ao serviço.");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alocar viatura: " + ex.Message);
                        }
                    }

                    LoadServiceVehicles();
                }
            }
        }

        private void btnSelectService(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void LoadMaterials()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_materiais_servico", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMaterials.DataSource = dt;
            }
        }

        private void btnReserveMaterial_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("mover_material_armazem_servico", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                    cmd.Parameters.AddWithValue("@codigo_material", cbMaterials.SelectedValue);
                    cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtReserveQuantity.Text));
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("Quantidade insuficiente no armazém"))
                        {
                            MessageBox.Show("Quantidade insuficiente no armazém.");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao reservar material: " + ex.Message);
                        }
                    }
                }

                LoadMaterials();
            }
        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("mover_material_servico_armazem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                    cmd.Parameters.AddWithValue("@codigo_material", cbMaterials.SelectedValue);
                    cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(txtReserveQuantity.Text));

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("Quantidade insuficiente no serviço"))
                        {
                            MessageBox.Show("Quantidade insuficiente no serviço.");
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

        private void btnGetService_Click(object sender, EventArgs e) // Get Service selected in the ComboBox
        {
            LoadServiceEmployees();
            LoadServiceVehicles();
            LoadMaterials();
        }

        private void btnGoToWarehouse_Click(object sender, EventArgs e)
        {
            var warehouseForm = new WarehouseForm();
            warehouseForm.Show();
        }

        private void LoadServiceEmployees()
        {
            if (cbServices.SelectedValue != null)
            {
                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("carregar_funcionarios_servico", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmployees.DataSource = dt;
                }
            }
        }

        private void LoadServiceVehicles()
        {
            if (cbServices.SelectedValue != null)
            {
                using (SqlConnection conn = dbConn.getSGBDConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("carregar_veiculos_servico", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@no_servico", cbServices.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvVehicles.DataSource = dt;
                }
            }
        }

        private void cbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbServices.SelectedValue is DataRowView)
            {
                DataRowView drv = (DataRowView)cbServices.SelectedValue;
                string serviceValue = drv["no_interno"].ToString();
                Console.WriteLine("Selected Service: " + serviceValue);
                LoadServiceEmployees(serviceValue);
                LoadServiceVehicles(serviceValue);
                LoadMaterials(serviceValue);
            }
            else if (cbServices.SelectedValue != null)
            {
                string serviceValue = cbServices.SelectedValue.ToString();
                Console.WriteLine("Selected Service: " + serviceValue);
                LoadServiceEmployees(serviceValue);
                LoadServiceVehicles(serviceValue);
                LoadMaterials(serviceValue);
            }
        }

        private void LoadServiceEmployees(string serviceValue)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_funcionarios_servico", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@no_servico", serviceValue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployees.DataSource = dt;
            }
        }

        private void LoadServiceVehicles(string serviceValue)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_veiculos_servico", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@no_servico", serviceValue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVehicles.DataSource = dt;
            }
        }

        private void LoadMaterials(string serviceValue)
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_materiais_servico", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@no_servico", serviceValue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMaterials.DataSource = dt;
            }
        }
    }
}
