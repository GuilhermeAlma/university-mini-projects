namespace PlaceHolder
{
    partial class CreateOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtMaterials = new System.Windows.Forms.TextBox();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblMaterials = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(12, 29);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(200, 21);
            this.cbSuppliers.TabIndex = 0;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(12, 68);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderDate.TabIndex = 1;
            // 
            // txtMaterials
            // 
            this.txtMaterials.Location = new System.Drawing.Point(12, 107);
            this.txtMaterials.Name = "txtMaterials";
            this.txtMaterials.Size = new System.Drawing.Size(200, 20);
            this.txtMaterials.TabIndex = 2;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(12, 144);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(200, 23);
            this.btnCreateOrder.TabIndex = 3;
            this.btnCreateOrder.Text = "Criar Encomenda";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(12, 13);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(85, 13);
            this.lblSupplierName.TabIndex = 4;
            this.lblSupplierName.Text = "Nome Fornecedor";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(12, 52);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(66, 13);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Data Encomenda";
            // 
            // lblMaterials
            // 
            this.lblMaterials.AutoSize = true;
            this.lblMaterials.Location = new System.Drawing.Point(12, 91);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(108, 13);
            this.lblMaterials.TabIndex = 6;
            this.lblMaterials.Text = "Materiais (Formato: codigo_material:quantidade,...";
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 181);
            this.Controls.Add(this.lblMaterials);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.txtMaterials);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.cbSuppliers);
            this.Name = "CreateOrderForm";
            this.Text = "Criar Encomenda";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtMaterials;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblMaterials;
    }
}
