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
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;

namespace LilianQuincalla.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ProductoComboDeuda : BaseObject
    { 
        public ProductoComboDeuda(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        ISA iSA;
        Deudores deudor;
        int cantidad;

        TipoDeProducto producto;
        [Association("TipoDeProducto-ProductoComboDeuda")]
        [DisplayName("Tipo de Producto")]
        public TipoDeProducto Producto
        {
            get => producto;
            set => SetPropertyValue(nameof(Producto), ref producto, value);
        }

        public int Cantidad
        {
            get => cantidad;
            set => SetPropertyValue(nameof(Cantidad), ref cantidad, value);
        }

        public decimal? DeudaProducto
        {
            get => Producto?.PrecioDeVenta * Cantidad;
            private set { }
        }


        [Browsable(false)]
        [Association("Deudores-ProductosComboDeudas")]
        public Deudores Deudor
        {
            get => deudor;
            set => SetPropertyValue(nameof(Deudor), ref deudor, value);
        }


        [Browsable(false)]
        [Association("ISA-ProductosComboDeudas")]
        public ISA ISA
        {
            get => iSA;
            set => SetPropertyValue(nameof(ISA), ref iSA, value);
        }
    }
}