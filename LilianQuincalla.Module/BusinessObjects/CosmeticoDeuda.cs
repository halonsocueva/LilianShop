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
    public class CosmeticoDeuda : BaseObject
    {
        public CosmeticoDeuda(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Deudores deudor;
        Cosméticos cosmeticos;

        [Association("Cosméticos-CosmeticoDeudas")]
        public Cosméticos Cosmeticos
        {
            get => cosmeticos;
            set => SetPropertyValue(nameof(Cosmeticos), ref cosmeticos, value);
        }

        int cantidad;
        public int Cantidad
        {
            get => cantidad;
            set => SetPropertyValue(nameof(Cantidad), ref cantidad, value);
        }

        public decimal? DeudaCosmetico
        {
            get => Cosmeticos?.PrecioDeVenta * Cantidad;
            private set { }
        }


        [Association("Deudores-CosmeticoDeudas")]
        public Deudores Deudor
        {
            get => deudor;
            set => SetPropertyValue(nameof(Deudor), ref deudor, value);
        }
    }
}