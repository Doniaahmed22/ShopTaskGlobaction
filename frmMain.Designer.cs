namespace DevFluentDesign
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElementCategories = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementCustomers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementCategory = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlProduct = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementOrders = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementOrderDetails = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementProductsByCategory = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.itemNav = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.accordionControlElementOrderDetailsAndInvoicePerOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer
            // 
            this.fluentDesignFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer.Location = new System.Drawing.Point(330, 46);
            this.fluentDesignFormContainer.Margin = new System.Windows.Forms.Padding(4);
            this.fluentDesignFormContainer.Name = "fluentDesignFormContainer";
            this.fluentDesignFormContainer.Size = new System.Drawing.Size(419, 448);
            this.fluentDesignFormContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementCategories});
            this.accordionControl1.Location = new System.Drawing.Point(0, 46);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(330, 448);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElementCategories
            // 
            this.accordionControlElementCategories.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementCustomers,
            this.accordionControlElementCategory,
            this.accordionControlProduct,
            this.accordionControlElementOrders,
            this.accordionControlElementProductsByCategory,
            this.accordionControlInvoice,
            this.accordionControlElementOrderDetailsAndInvoicePerOrder});
            this.accordionControlElementCategories.Expanded = true;
            this.accordionControlElementCategories.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementCategories.Name = "accordionControlElementCategories";
            this.accordionControlElementCategories.Text = "Sections";
            // 
            // accordionControlElementCustomers
            // 
            this.accordionControlElementCustomers.Name = "accordionControlElementCustomers";
            this.accordionControlElementCustomers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementCustomers.Text = "Customer";
            this.accordionControlElementCustomers.Click += new System.EventHandler(this.accordionControlElementCustomers_Click);
            // 
            // accordionControlElementCategory
            // 
            this.accordionControlElementCategory.Name = "accordionControlElementCategory";
            this.accordionControlElementCategory.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementCategory.Text = "Categories";
            this.accordionControlElementCategory.Click += new System.EventHandler(this.accordionControlElementCategory_Click);
            // 
            // accordionControlProduct
            // 
            this.accordionControlProduct.Name = "accordionControlProduct";
            this.accordionControlProduct.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlProduct.Text = "Products";
            this.accordionControlProduct.Click += new System.EventHandler(this.accordionControlProduct_Click);
            // 
            // accordionControlElementOrders
            // 
            this.accordionControlElementOrders.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementOrder,
            this.accordionControlElementOrderDetails});
            this.accordionControlElementOrders.Name = "accordionControlElementOrders";
            this.accordionControlElementOrders.Text = "Orders";
            // 
            // accordionControlElementOrder
            // 
            this.accordionControlElementOrder.Name = "accordionControlElementOrder";
            this.accordionControlElementOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementOrder.Text = "Order";
            this.accordionControlElementOrder.Click += new System.EventHandler(this.accordionControlElementOrder_Click);
            // 
            // accordionControlElementOrderDetails
            // 
            this.accordionControlElementOrderDetails.Name = "accordionControlElementOrderDetails";
            this.accordionControlElementOrderDetails.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementOrderDetails.Text = "OrderDetails";
            this.accordionControlElementOrderDetails.Click += new System.EventHandler(this.accordionControlElementOrderDetails_Click);
            // 
            // accordionControlElementProductsByCategory
            // 
            this.accordionControlElementProductsByCategory.Name = "accordionControlElementProductsByCategory";
            this.accordionControlElementProductsByCategory.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementProductsByCategory.Text = "ProductsByCategory";
            this.accordionControlElementProductsByCategory.Click += new System.EventHandler(this.accordionControlElementProductsByCategory_Click);
            // 
            // accordionControlInvoice
            // 
            this.accordionControlInvoice.Name = "accordionControlInvoice";
            this.accordionControlInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlInvoice.Text = "Invoice";
            this.accordionControlInvoice.Click += new System.EventHandler(this.accordionControlInvoice_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.itemNav});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(749, 46);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.itemNav);
            // 
            // itemNav
            // 
            this.itemNav.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.itemNav.Caption = "???";
            this.itemNav.Id = 0;
            this.itemNav.Name = "itemNav";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.itemNav});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // accordionControlElementOrderDetailsAndInvoicePerOrder
            // 
            this.accordionControlElementOrderDetailsAndInvoicePerOrder.Name = "accordionControlElementOrderDetailsAndInvoicePerOrder";
            this.accordionControlElementOrderDetailsAndInvoicePerOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementOrderDetailsAndInvoicePerOrder.Text = "OrderDetailsAndInvoicePerOrder";
            this.accordionControlElementOrderDetailsAndInvoicePerOrder.Click += new System.EventHandler(this.accordionControlElementOrderDetailsAndInvoicePerOrder_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 494);
            this.ControlContainer = this.fluentDesignFormContainer;
            this.Controls.Add(this.fluentDesignFormContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SHOP";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCategories;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCustomers;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCategory;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlProduct;
        private DevExpress.XtraBars.BarStaticItem itemNav;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementOrders;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementOrder;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementOrderDetails;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementProductsByCategory;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementOrderDetailsAndInvoicePerOrder;
    }
}