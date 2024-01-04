using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using LilianQuincalla.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LilianQuincalla.Module.Controllers
{
    public partial class CombosRecogidosController : ViewController<ListView>
    {
        SimpleAction QuitarRecogida;
        public CombosRecogidosController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Combo);
            TargetViewId = "Combo_ListView_Recogidos";
            QuitarRecogida = new SimpleAction(this, "QuitarRecogida", PredefinedCategory.Edit)
            {
                Caption = "Quitar recogida",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };
            QuitarRecogida.Execute += QuitarRecogida_Execute;
        }

        private void QuitarRecogida_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (Combo obj in e.SelectedObjects)
            {
                obj.Recogido = false;
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
