namespace PlaceHolder
{
    partial class MainForm
    {
        // Designer generated variables
        private System.ComponentModel.IContainer components = null;

        // Dispose method
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Initialize method
        private void InitializeComponent()
        {
            this.btnAllocation = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllocation
            // 
            this.btnAllocation.Location = new System.Drawing.Point(56, 47);
            this.btnAllocation.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllocation.Name = "btnAllocation";
            this.btnAllocation.Size = new System.Drawing.Size(144, 32);
            this.btnAllocation.TabIndex = 1;
            this.btnAllocation.Text = "Alocação de Recursos";
            this.btnAllocation.UseVisualStyleBackColor = true;
            this.btnAllocation.Click += new System.EventHandler(this.btnAllocation_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(56, 119);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(144, 32);
            this.btnOrders.TabIndex = 3;
            this.btnOrders.Text = "Gerir Encomendas";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Location = new System.Drawing.Point(56, 83);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(144, 32);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.Text = "Gerir Armazém";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(56, 11);
            this.btnServices.Margin = new System.Windows.Forms.Padding(2);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(144, 32);
            this.btnServices.TabIndex = 0;
            this.btnServices.Text = "Criar e Gerir Serviços";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.Location = new System.Drawing.Point(56, 155);
            this.btnViewInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(144, 32);
            this.btnViewInvoices.TabIndex = 4;
            this.btnViewInvoices.Text = "Ver Faturas";
            this.btnViewInvoices.UseVisualStyleBackColor = true;
            this.btnViewInvoices.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 198);
            this.Controls.Add(this.btnAllocation);
            this.Controls.Add(this.btnViewInvoices);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.btnServices);
            this.Name = "MainForm";
            this.Text = "PlaceHolder - Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllocation;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnViewInvoices;
    }
}
