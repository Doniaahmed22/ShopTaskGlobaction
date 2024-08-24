
using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using DevFluentDesign.UI.Modules;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevFluentDesign
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private DatabaseManager dbManager;

        public frmMain()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            // التأكد من أن تنفيذ هذه العملية يتم في خيط واجهة المستخدم الرئيسي
            if (!fluentDesignFormContainer.Controls.ContainsKey(module.Name))
            {
                TutorialControlBase control = null;

                // تحقق من نوع الوحدة وأنشئ الوحدة المناسبة
                if (module.Name == "ucCategory")
                {
                    control = new ucCategory(dbManager);
                }
                else if (module.Name == "ucCustomer")
                {
                    control = new ucCustomer(dbManager);
                }
                else if (module.Name == "ucProduct")
                {
                    control = new ucProduct(dbManager);
                }
                else if (module.Name == "ucOrder")
                {
                    control = new ucOrder(dbManager);
                }
                else if (module.Name == "ucOrderDetails")
                {
                    control = new ucOrderDetails(dbManager);
                }
                else if (module.Name == "ucProductCategory")
                {
                    control = new ucProductCategory(dbManager);
                }
                else if (module.Name == "ucInvoice")
                {
                    control = new ucInvoice(dbManager);
                }
                else if (module.Name == "ucOrderDetailsAndInvoiceByOrder")
                {
                    control = new ucOrderDetailsAndInvoiceByOrder(dbManager);
                }

                if (control != null)
                {
                    control.Dock = DockStyle.Fill;

                    // إضافة الوحدة إلى الحاوية في الخيط الرئيسي
                    fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
                    {
                        fluentDesignFormContainer.Controls.Add(control);
                        control.BringToFront();
                    }));
                }
            }
            else
            {
                var control = fluentDesignFormContainer.Controls.Find(module.Name, true);
                if (control.Length == 1)
                {
                    fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
                    {
                        if (control[0] is ucProductCategory productCategoryControl)
                        {
                            productCategoryControl.BindTreeList(dbManager);
                        }
                        else if (control[0] is ucCategory CategoryControl)
                        {
                            CategoryControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucCustomer CustomerControl)
                        {
                            CustomerControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucInvoice InvoiceControl)
                        {
                            InvoiceControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucOrder OrderControl)
                        {
                            OrderControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucOrderDetails OrderDetailControl)
                        {
                            OrderDetailControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucProduct ProductControl)
                        {
                            ProductControl.LoadData(dbManager);
                        }
                        else if (control[0] is ucOrderDetailsAndInvoiceByOrder orderDetailsAndInvoiceControl)
                        {
                            // Reinitialize the TreeList to refresh data
                            dbManager.RefreshData(); // تحديث البيانات في DatabaseManager
                            orderDetailsAndInvoiceControl.InitializeTreeList();
                        }

                        control[0].BringToFront();
                    }));
                }
            }
        }

        private async void accordionControlElementCategory_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlElementCategory.Text}";
            if (ModulesInfo.GetItem("ucCategory") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucCategory", "DevFluentDesign.UI.Modules.ucCategory"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucCategory"));
        }

        private async void accordionControlElementCustomers_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlElementCustomers.Text}";
            if (ModulesInfo.GetItem("ucCustomer") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucCustomer", "DevFluentDesign.UI.Modules.ucCustomer"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucCustomer"));
        }

        private async void accordionControlProduct_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlProduct.Text}";
            if (ModulesInfo.GetItem("ucProduct") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucProduct", "DevFluentDesign.UI.Modules.ucProduct"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucProduct"));
        }

        private async void accordionControlElementOrder_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlElementOrder.Text}";
            if (ModulesInfo.GetItem("ucOrder") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucOrder", "DevFluentDesign.UI.Modules.ucOrder"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucOrder"));
        }

        private async void accordionControlElementOrderDetails_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlElementOrderDetails.Text}";
            if (ModulesInfo.GetItem("ucOrderDetails") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucOrderDetails", "DevFluentDesign.UI.Modules.ucOrderDetails"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucOrderDetails"));
        }

        private async void accordionControlElementProductsByCategory_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/{accordionControlElementProductsByCategory.Text}";
            if (ModulesInfo.GetItem("ucProductCategory") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucProductCategory", "DevFluentDesign.UI.Modules.ucProductCategory"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucProductCategory"));

        }

        private async void accordionControlInvoice_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/Invoice";
            if (ModulesInfo.GetItem("ucInvoice") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucInvoice", "DevFluentDesign.UI.Modules.ucInvoice"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucInvoice"));
        }

        private async void accordionControlElementOrderDetailsAndInvoicePerOrder_Click(object sender, EventArgs e)
        {
            this.itemNav.Caption = $"{accordionControlElementCategories.Text}/OrderDetailsAndInvoicePerOrder";
            if (ModulesInfo.GetItem("ucOrderDetailsAndInvoiceByOrder") == null)
            {
                ModulesInfo.Add(new ModuleInfo("ucOrderDetailsAndInvoiceByOrder", "DevFluentDesign.UI.Modules.ucOrderDetailsAndInvoiceByOrder"));
            }
            await LoadModuleAsync(ModulesInfo.GetItem("ucOrderDetailsAndInvoiceByOrder"));
        }
    
}
}
