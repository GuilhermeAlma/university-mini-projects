namespace PlaceHolder
{
    partial class WarehouseForm
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
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.btnRemoveMaterial = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(12, 12);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.Size = new System.Drawing.Size(539, 350);
            this.dgvMaterials.TabIndex = 0;
            // 
            // btnRemoveMaterial
            // 
            this.btnRemoveMaterial.Location = new System.Drawing.Point(442, 375);
            this.btnRemoveMaterial.Name = "btnRemoveMaterial";
            this.btnRemoveMaterial.Size = new System.Drawing.Size(109, 23);
            this.btnRemoveMaterial.TabIndex = 1;
            this.btnRemoveMaterial.Text = "Remover Material";
            this.btnRemoveMaterial.UseVisualStyleBackColor = true;
            this.btnRemoveMaterial.Click += new System.EventHandler(this.btnRemoveMaterial_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(120, 375);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(109, 23);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Text = "Criar Encomenda";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(80, 377);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(34, 20);
            this.txtQuantity.TabIndex = 4;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 380);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantidade";
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 406);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnRemoveMaterial);
            this.Controls.Add(this.dgvMaterials);
            this.Name = "WarehouseForm";
            this.Text = "Gerir Armazém";
            this.Load += new System.EventHandler(this.WarehouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.Button btnRemoveMaterial;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
    }
}
