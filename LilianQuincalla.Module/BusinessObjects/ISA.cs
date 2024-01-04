using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LilianQuincalla.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Deudores")]
    public class ISA : BaseObject
    {
        public ISA(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        decimal? deudaTotal = 0;

        [Association("ISA-ProductosComboDeudas")]
        public XPCollection<ProductoComboDeuda> ProductosComboDeudas
        {
            get
            {
                return GetCollection<ProductoComboDeuda>(nameof(ProductosComboDeudas));
            }
        }

        public decimal? DeudaTotal
        {
            get
            {
                foreach (var item in ProductosComboDeudas)
                {
                    deudaTotal = deudaTotal + item.DeudaProducto;
                }
                return deudaTotal;
            }
            private set { }
        }

    }
}