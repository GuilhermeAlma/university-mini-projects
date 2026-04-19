namespace PlaceHolder
{
    partial class InvoicesForm
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
            this.dgvServiceInvoices = new System.Windows.Forms.DataGridView();
            this.dgvOrderInvoices = new System.Windows.Forms.DataGridView();
            this.lblServiceInvoices = new System.Windows.Forms.Label();
            this.lblOrderInvoices = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServiceInvoices
            // 
            this.dgvServiceInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceInvoices.Location = new System.Drawing.Point(12, 30);
            this.dgvServiceInvoices.Name = "dgvServiceInvoices";
            this.dgvServiceInvoices.Size = new System.Drawing.Size(760, 200);
            this.dgvServiceInvoices.TabIndex = 0;
            // 
            // dgvOrderInvoices
            // 
            this.dgvOrderInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderInvoices.Location = new System.Drawing.Point(12, 270);
            this.dgvOrderInvoices.Name = "dgvOrderInvoices";
            this.dgvOrderInvoices.Size = new System.Drawing.Size(760, 200);
            this.dgvOrderInvoices.TabIndex = 1;
            // 
            // lblServiceInvoices
            // 
            this.lblServiceInvoices.AutoSize = true;
            this.lblServiceInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceInvoices.Location = new System.Drawing.Point(12, 9);
            this.lblServiceInvoices.Name = "lblServiceInvoices";
            this.lblServiceInvoices.Size = new System.Drawing.Size(155, 20);
            this.lblServiceInvoices.TabIndex = 2;
            this.lblServiceInvoices.Text = "Faturas de Serviço";
            // 
            // lblOrderInvoices
            // 
            this.lblOrderInvoices.AutoSize = true;
            this.lblOrderInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderInvoices.Location = new System.Drawing.Point(12, 247);
            this.lblOrderInvoices.Name = "lblOrderInvoices";
            this.lblOrderInvoices.Size = new System.Drawing.Size(153, 20);
            this.lblOrderInvoices.TabIndex = 3;
            this.lblOrderInvoices.Text = "Faturas de Pedido";
            // 
            // InvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.lblOrderInvoices);
            this.Controls.Add(this.lblServiceInvoices);
            this.Controls.Add(this.dgvOrderInvoices);
            this.Controls.Add(this.dgvServiceInvoices);
            this.Name = "InvoicesForm";
            this.Text = "InvoicesForm";
            this.Load += new System.EventHandler(this.InvoicesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvServiceInvoices;
        private System.Windows.Forms.DataGridView dgvOrderInvoices;
        private System.Windows.Forms.Label lblServiceInvoices;
        private System.Windows.Forms.Label lblOrderInvoices;
    }
}
