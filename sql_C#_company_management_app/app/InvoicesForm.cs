using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlaceHolder
{
    public partial class InvoicesForm : Form
    {
        private DatabaseConnection dbConn;

        public InvoicesForm()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            LoadServiceInvoices();
            LoadOrderInvoices();
        }

        private void LoadServiceInvoices()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_faturas_servico", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvServiceInvoices.DataSource = dt;
            }
        }

        private void LoadOrderInvoices()
        {
            using (SqlConnection conn = dbConn.getSGBDConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("carregar_faturas_encomenda", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvOrderInvoices.DataSource = dt;
            }
        }
    }
}
