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
    public class MiscelaneaDeuda : BaseObject
    {
        public MiscelaneaDeuda(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Deudores deudor;
        Miscelaneas miscelaneas;

        [Association("Miscelaneas-MiscelaneasDeudas")]
        public Miscelaneas Miscelaneas
        {
            get => miscelaneas;
            set => SetPropertyValue(nameof(Miscelaneas), ref miscelaneas, value);
        }

        int cantidad;
        public int Cantidad
        {
            get => cantidad;
            set => SetPropertyValue(nameof(Cantidad), ref cantidad, value);
        }

        public decimal? DeudaMiscelanea
        {
            get => Miscelaneas?.PrecioDeVenta * Cantidad;
            private set { }
        }


        [Association("Deudores-MiscelaneaDeudas")]
        public Deudores Deudor
        {
            get => deudor;
            set => SetPropertyValue(nameof(Deudor), ref deudor, value);
        }

    }
}