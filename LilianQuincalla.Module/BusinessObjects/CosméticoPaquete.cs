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
    public class CosméticoPaquete : BaseObject
    { 
        public CosméticoPaquete(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Paquete paquete;
        Cosméticos cosmetico;
        private int cantidad;

        [Association("Cosmetico-CosmeticoPaquete")]
        public Cosméticos Cosmetico
        {
            get => cosmetico;
            set => SetPropertyValue(nameof(Cosmetico), ref cosmetico, value);
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
                return (Cosmetico?.PrecioDeVenta * Cantidad);
            }
            private set { }
        }

        public decimal? GananciaProducto
        {
            get
            {
                return (TotalGenerado - (Cosmetico?.PrecioDeCompra * Cantidad));
            }
            private set { }
        }


        [Association("Paquete-CosmeticoPaquete")]
        public Paquete Paquete
        {
            get => paquete;
            set => SetPropertyValue(nameof(Paquete), ref paquete, value);
        }
    }
}