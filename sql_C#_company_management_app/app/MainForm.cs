using System.Windows.Forms;
using System;

namespace PlaceHolder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            var servicesForm = new ServicesForm();
            servicesForm.Show();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            var warehouseForm = new WarehouseForm();
            warehouseForm.Show();
        }

        private void btnAllocation_Click(object sender, EventArgs e)
        {
            var allocationForm = new AllocationForm();
            allocationForm.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var ordersForm = new OrdersForm();
            ordersForm.Show();
        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            var invoicesForm = new InvoicesForm();
            invoicesForm.Show();
        }
    }
}
