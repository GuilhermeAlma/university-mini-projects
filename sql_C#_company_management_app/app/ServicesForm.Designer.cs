namespace PlaceHolder
{
    partial class ServicesForm
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
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.cbFilterState = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbClients = new System.Windows.Forms.ComboBox();
            this.btnCreateService = new System.Windows.Forms.Button();
            this.btnCompleteService = new System.Windows.Forms.Button();
            this.btnCancelService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServices
            // 
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(8, 256);
            this.dgvServices.Margin = new System.Windows.Forms.Padding(2);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.Size = new System.Drawing.Size(755, 247);
            this.dgvServices.TabIndex = 0;
            // 
            // cbFilterState
            // 
            this.cbFilterState.FormattingEnabled = true;
            this.cbFilterState.Items.AddRange(new object[] {
            "Em Andamento",
            "Concluído",
            "Cancelado"});
            this.cbFilterState.Location = new System.Drawing.Point(8, 231);
            this.cbFilterState.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterState.Name = "cbFilterState";
            this.cbFilterState.Size = new System.Drawing.Size(108, 21);
            this.cbFilterState.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(120, 232);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(67, 20);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLocation.Location = new System.Drawing.Point(11, 51);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(135, 20);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.Text = "Local";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(167, 52);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(201, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // cbClients
            // 
            this.cbClients.FormattingEnabled = true;
            this.cbClients.Location = new System.Drawing.Point(11, 75);
            this.cbClients.Margin = new System.Windows.Forms.Padding(2);
            this.cbClients.Name = "cbClients";
            this.cbClients.Size = new System.Drawing.Size(148, 21);
            this.cbClients.TabIndex = 5;
            this.cbClients.Text = "Selecionar cliente";
            // 
            // btnCreateService
            // 
            this.btnCreateService.Location = new System.Drawing.Point(167, 76);
            this.btnCreateService.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateService.Name = "btnCreateService";
            this.btnCreateService.Size = new System.Drawing.Size(133, 20);
            this.btnCreateService.TabIndex = 6;
            this.btnCreateService.Text = "Criar Serviço";
            this.btnCreateService.UseVisualStyleBackColor = true;
            this.btnCreateService.Click += new System.EventHandler(this.btnCreateService_Click);
            // 
            // btnCompleteService
            // 
            this.btnCompleteService.Location = new System.Drawing.Point(191, 232);
            this.btnCompleteService.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompleteService.Name = "btnCompleteService";
            this.btnCompleteService.Size = new System.Drawing.Size(133, 20);
            this.btnCompleteService.TabIndex = 8;
            this.btnCompleteService.Text = "Concluir Serviço";
            this.btnCompleteService.UseVisualStyleBackColor = true;
            this.btnCompleteService.Click += new System.EventHandler(this.btnCompleteService_Click);
            // 
            // btnCancelService
            // 
            this.btnCancelService.Location = new System.Drawing.Point(328, 232);
            this.btnCancelService.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelService.Name = "btnCancelService";
            this.btnCancelService.Size = new System.Drawing.Size(133, 20);
            this.btnCancelService.TabIndex = 9;
            this.btnCancelService.Text = "Cancelar Serviço";
            this.btnCancelService.UseVisualStyleBackColor = true;
            this.btnCancelService.Click += new System.EventHandler(this.btnCancelService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Criação de serviço";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mostrar e alterar estado";
            // 
            // ServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 514);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelService);
            this.Controls.Add(this.btnCompleteService);
            this.Controls.Add(this.btnCreateService);
            this.Controls.Add(this.cbClients);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cbFilterState);
            this.Controls.Add(this.dgvServices);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ServicesForm";
            this.Text = "Criar e Gerir Serviços";
            this.Load += new System.EventHandler(this.ServicesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.ComboBox cbFilterState;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cbClients;
        private System.Windows.Forms.Button btnCreateService;
        private System.Windows.Forms.Button btnCompleteService;
        private System.Windows.Forms.Button btnCancelService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
