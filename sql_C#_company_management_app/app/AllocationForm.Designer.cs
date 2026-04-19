using System;

namespace PlaceHolder
{
    partial class AllocationForm
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
            this.cbServices = new System.Windows.Forms.ComboBox();
            this.cbEmployees = new System.Windows.Forms.ComboBox();
            this.cbVehicles = new System.Windows.Forms.ComboBox();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.btnAssignEmployee = new System.Windows.Forms.Button();
            this.btnAssignVehicle = new System.Windows.Forms.Button();
            this.btnReserveMaterial = new System.Windows.Forms.Button();
            this.btnRemoveMaterial = new System.Windows.Forms.Button();
            this.btnGoToWarehouse = new System.Windows.Forms.Button();
            this.txtReserveQuantity = new System.Windows.Forms.TextBox();
            this.lblServices = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblVehicles = new System.Windows.Forms.Label();
            this.lblMaterials = new System.Windows.Forms.Label();
            this.lblReserveQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaterials = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWarehouseQuantity = new System.Windows.Forms.TextBox();
            this.btnGetService = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // cbServices
            // 
            this.cbServices.FormattingEnabled = true;
            this.cbServices.Location = new System.Drawing.Point(13, 39);
            this.cbServices.Name = "cbServices";
            this.cbServices.Size = new System.Drawing.Size(212, 21);
            this.cbServices.TabIndex = 0;
            this.cbServices.SelectedIndexChanged += new System.EventHandler(this.cbServices_SelectedIndexChanged);
            // 
            // cbEmployees
            // 
            this.cbEmployees.FormattingEnabled = true;
            this.cbEmployees.Location = new System.Drawing.Point(454, 219);
            this.cbEmployees.Name = "cbEmployees";
            this.cbEmployees.Size = new System.Drawing.Size(212, 21);
            this.cbEmployees.TabIndex = 1;
            // 
            // cbVehicles
            // 
            this.cbVehicles.FormattingEnabled = true;
            this.cbVehicles.Location = new System.Drawing.Point(454, 270);
            this.cbVehicles.Name = "cbVehicles";
            this.cbVehicles.Size = new System.Drawing.Size(212, 21);
            this.cbVehicles.TabIndex = 2;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(10, 308);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.Size = new System.Drawing.Size(740, 167);
            this.dgvMaterials.TabIndex = 3;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(242, 39);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(235, 120);
            this.dgvEmployees.TabIndex = 4;
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Location = new System.Drawing.Point(516, 39);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.Size = new System.Drawing.Size(235, 120);
            this.dgvVehicles.TabIndex = 5;
            // 
            // btnAssignEmployee
            // 
            this.btnAssignEmployee.Location = new System.Drawing.Point(674, 219);
            this.btnAssignEmployee.Name = "btnAssignEmployee";
            this.btnAssignEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnAssignEmployee.TabIndex = 6;
            this.btnAssignEmployee.Text = "Alocar";
            this.btnAssignEmployee.UseVisualStyleBackColor = true;
            this.btnAssignEmployee.Click += new System.EventHandler(this.btnAssignEmployee_Click);
            // 
            // btnAssignVehicle
            // 
            this.btnAssignVehicle.Location = new System.Drawing.Point(674, 270);
            this.btnAssignVehicle.Name = "btnAssignVehicle";
            this.btnAssignVehicle.Size = new System.Drawing.Size(75, 23);
            this.btnAssignVehicle.TabIndex = 7;
            this.btnAssignVehicle.Text = "Alocar";
            this.btnAssignVehicle.UseVisualStyleBackColor = true;
            this.btnAssignVehicle.Click += new System.EventHandler(this.btnAssignVehicle_Click);
            // 
            // btnReserveMaterial
            // 
            this.btnReserveMaterial.Location = new System.Drawing.Point(65, 279);
            this.btnReserveMaterial.Name = "btnReserveMaterial";
            this.btnReserveMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnReserveMaterial.TabIndex = 9;
            this.btnReserveMaterial.Text = "Reservar";
            this.btnReserveMaterial.UseVisualStyleBackColor = true;
            this.btnReserveMaterial.Click += new System.EventHandler(this.btnReserveMaterial_Click);
            // 
            // btnRemoveMaterial
            // 
            this.btnRemoveMaterial.Location = new System.Drawing.Point(146, 279);
            this.btnRemoveMaterial.Name = "btnRemoveMaterial";
            this.btnRemoveMaterial.Size = new System.Drawing.Size(81, 23);
            this.btnRemoveMaterial.TabIndex = 10;
            this.btnRemoveMaterial.Text = "Remover";
            this.btnRemoveMaterial.UseVisualStyleBackColor = true;
            this.btnRemoveMaterial.Click += new System.EventHandler(this.btnRemoveMaterial_Click);
            // 
            // btnGoToWarehouse
            // 
            this.btnGoToWarehouse.Location = new System.Drawing.Point(250, 279);
            this.btnGoToWarehouse.Name = "btnGoToWarehouse";
            this.btnGoToWarehouse.Size = new System.Drawing.Size(100, 23);
            this.btnGoToWarehouse.TabIndex = 11;
            this.btnGoToWarehouse.Text = "Ir para Armazém";
            this.btnGoToWarehouse.UseVisualStyleBackColor = true;
            this.btnGoToWarehouse.Click += new System.EventHandler(this.btnGoToWarehouse_Click);
            // 
            // txtReserveQuantity
            // 
            this.txtReserveQuantity.Location = new System.Drawing.Point(146, 243);
            this.txtReserveQuantity.Name = "txtReserveQuantity";
            this.txtReserveQuantity.Size = new System.Drawing.Size(81, 20);
            this.txtReserveQuantity.TabIndex = 15;
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(10, 21);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(48, 13);
            this.lblServices.TabIndex = 16;
            this.lblServices.Text = "Serviços";
            // 
            // lblEmployees
            // 
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.Location = new System.Drawing.Point(454, 198);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(67, 13);
            this.lblEmployees.TabIndex = 17;
            this.lblEmployees.Text = "Funcionários";
            // 
            // lblVehicles
            // 
            this.lblVehicles.AutoSize = true;
            this.lblVehicles.Location = new System.Drawing.Point(452, 251);
            this.lblVehicles.Name = "lblVehicles";
            this.lblVehicles.Size = new System.Drawing.Size(45, 13);
            this.lblVehicles.TabIndex = 18;
            this.lblVehicles.Text = "Viaturas";
            // 
            // lblMaterials
            // 
            this.lblMaterials.AutoSize = true;
            this.lblMaterials.Location = new System.Drawing.Point(13, 166);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(49, 13);
            this.lblMaterials.TabIndex = 19;
            this.lblMaterials.Text = "Materiais";
            // 
            // lblReserveQuantity
            // 
            this.lblReserveQuantity.AutoSize = true;
            this.lblReserveQuantity.Location = new System.Drawing.Point(15, 250);
            this.lblReserveQuantity.Name = "lblReserveQuantity";
            this.lblReserveQuantity.Size = new System.Drawing.Size(108, 13);
            this.lblReserveQuantity.TabIndex = 20;
            this.lblReserveQuantity.Text = "A Reservar/Remover";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Funcionários";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(520, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Viaturas";
            // 
            // cbMaterials
            // 
            this.cbMaterials.FormattingEnabled = true;
            this.cbMaterials.Location = new System.Drawing.Point(13, 182);
            this.cbMaterials.Name = "cbMaterials";
            this.cbMaterials.Size = new System.Drawing.Size(214, 21);
            this.cbMaterials.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Disponível";
            // 
            // txtWarehouseQuantity
            // 
            this.txtWarehouseQuantity.Location = new System.Drawing.Point(146, 212);
            this.txtWarehouseQuantity.Name = "txtWarehouseQuantity";
            this.txtWarehouseQuantity.Size = new System.Drawing.Size(81, 20);
            this.txtWarehouseQuantity.TabIndex = 23;
            // 
            // btnGetService
            // 
            this.btnGetService.Location = new System.Drawing.Point(12, 66);
            this.btnGetService.Name = "btnGetService";
            this.btnGetService.Size = new System.Drawing.Size(215, 23);
            this.btnGetService.TabIndex = 25;
            this.btnGetService.Text = "Selecionar Serviço";
            this.btnGetService.UseVisualStyleBackColor = true;
            // 
            // AllocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 464);
            this.Controls.Add(this.btnGetService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWarehouseQuantity);
            this.Controls.Add(this.cbMaterials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReserveQuantity);
            this.Controls.Add(this.lblMaterials);
            this.Controls.Add(this.lblVehicles);
            this.Controls.Add(this.lblEmployees);
            this.Controls.Add(this.lblServices);
            this.Controls.Add(this.txtReserveQuantity);
            this.Controls.Add(this.btnGoToWarehouse);
            this.Controls.Add(this.btnRemoveMaterial);
            this.Controls.Add(this.btnReserveMaterial);
            this.Controls.Add(this.btnAssignVehicle);
            this.Controls.Add(this.btnAssignEmployee);
            this.Controls.Add(this.dgvVehicles);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.dgvMaterials);
            this.Controls.Add(this.cbVehicles);
            this.Controls.Add(this.cbEmployees);
            this.Controls.Add(this.cbServices);
            this.Name = "AllocationForm";
            this.Text = "Alocação de Recursos";
            this.Load += new System.EventHandler(this.AllocationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cbServices;
        private System.Windows.Forms.ComboBox cbEmployees;
        private System.Windows.Forms.ComboBox cbVehicles;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.Button btnAssignEmployee;
        private System.Windows.Forms.Button btnAssignVehicle;
        private System.Windows.Forms.Button btnReserveMaterial;
        private System.Windows.Forms.Button btnRemoveMaterial;
        private System.Windows.Forms.Button btnGoToWarehouse;
        private System.Windows.Forms.TextBox txtReserveQuantity;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label lblVehicles;
        private System.Windows.Forms.Label lblMaterials;
        private System.Windows.Forms.Label lblReserveQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaterials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWarehouseQuantity;
        private System.Windows.Forms.Button btnGetService;
    }
}