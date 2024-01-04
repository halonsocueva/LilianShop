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
    public class MiscelaneaPaquete : BaseObject
    {
        public MiscelaneaPaquete(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Paquete paquete;
        Miscelaneas miscelaneas;
        private int cantidad;

        [Association("Miscelanea-MiscelaneaPaquete")]
        public Miscelaneas Miscelaneas
        {
            get => miscelaneas;
            set => SetPropertyValue(nameof(Miscelaneas), ref miscelaneas, value);
        }

        public int Cantidad
        {
            get => cantidad;
            set => SetPropertyValue(nameof(Cantidad), ref cantidad, value);
        }

        public decimal? TotalGenerado
        {
            get
            {
                return (Miscelaneas?.PrecioDeVenta * Cantidad);
            }
            private set { }
        }

        public decimal? GananciaProducto
        {
            get
            {
                return (TotalGenerado - (Miscelaneas?.PrecioDeCompra * Cantidad));
            }
            private set { }
        }


        [Association("Paquete-MiscelaneaPaquete")]
        public Paquete Paquete
        {
            get => paquete;
            set => SetPropertyValue(nameof(Paquete), ref paquete, value);
        }
    }
}