namespace PlaceHolder
{
    partial class OrdersForm
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.btnViewOrderDetails = new System.Windows.Forms.Button();
            this.btnUpdateOrderStatus = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblOrderDetails = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 30);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(336, 200);
            this.dgvOrders.TabIndex = 0;
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(12, 323);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.Size = new System.Drawing.Size(336, 150);
            this.dgvOrderDetails.TabIndex = 1;
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Items.AddRange(new object[] {
            "Pendente",
            "Em Trânsito",
            "Entregue"});
            this.cbOrderStatus.Location = new System.Drawing.Point(12, 514);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(121, 21);
            this.cbOrderStatus.TabIndex = 2;
            // 
            // btnViewOrderDetails
            // 
            this.btnViewOrderDetails.Location = new System.Drawing.Point(227, 236);
            this.btnViewOrderDetails.Name = "btnViewOrderDetails";
            this.btnViewOrderDetails.Size = new System.Drawing.Size(121, 23);
            this.btnViewOrderDetails.TabIndex = 3;
            this.btnViewOrderDetails.Text = "Ver Detalhes";
            this.btnViewOrderDetails.UseVisualStyleBackColor = true;
            this.btnViewOrderDetails.Click += new System.EventHandler(this.btnViewOrderDetails_Click);
            // 
            // btnUpdateOrderStatus
            // 
            this.btnUpdateOrderStatus.Location = new System.Drawing.Point(227, 487);
            this.btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
            this.btnUpdateOrderStatus.Size = new System.Drawing.Size(121, 23);
            this.btnUpdateOrderStatus.TabIndex = 4;
            this.btnUpdateOrderStatus.Text = "Atualizar Estado";
            this.btnUpdateOrderStatus.UseVisualStyleBackColor = true;
            this.btnUpdateOrderStatus.Click += new System.EventHandler(this.btnUpdateOrderStatus_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(227, 512);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(121, 23);
            this.btnCreateOrder.TabIndex = 4;
            this.btnCreateOrder.Text = "Criar Encomenda";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(8, 7);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(113, 20);
            this.lblOrders.TabIndex = 5;
            this.lblOrders.Text = "Encomendas";
            // 
            // lblOrderDetails
            // 
            this.lblOrderDetails.AutoSize = true;
            this.lblOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDetails.Location = new System.Drawing.Point(8, 300);
            this.lblOrderDetails.Name = "lblOrderDetails";
            this.lblOrderDetails.Size = new System.Drawing.Size(206, 20);
            this.lblOrderDetails.TabIndex = 6;
            this.lblOrderDetails.Text = "Detalhes da Encomenda";
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(12, 497);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(40, 13);
            this.lblOrderStatus.TabIndex = 7;
            this.lblOrderStatus.Text = "Estado";
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 543);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.lblOrderDetails);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnUpdateOrderStatus);
            this.Controls.Add(this.btnViewOrderDetails);
            this.Controls.Add(this.cbOrderStatus);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.dgvOrders);
            this.Name = "OrdersForm";
            this.Text = "Gestão de Encomendas";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.Button btnViewOrderDetails;
        private System.Windows.Forms.Button btnUpdateOrderStatus;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblOrderDetails;
        private System.Windows.Forms.Label lblOrderStatus;
    }
}
