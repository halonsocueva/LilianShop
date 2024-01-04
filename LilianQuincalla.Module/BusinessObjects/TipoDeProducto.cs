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
using System.Drawing;
using System.Linq;
using System.Text;

namespace LilianQuincalla.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [NavigationItem("Combos")]
    public class TipoDeProducto : BaseObject
    { 
        public TipoDeProducto(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        Image imagen;
        decimal precioDeCompra;
        decimal precioDeVenta;
        string nombre;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }

        public decimal PrecioDeCompra
        {
            get => precioDeCompra;
            set => SetPropertyValue(nameof(PrecioDeCompra), ref precioDeCompra, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public decimal PrecioDeVenta
        {
            get => precioDeVenta;
            set => SetPropertyValue(nameof(PrecioDeVenta), ref precioDeVenta, value);
        }

        [VisibleInListView(false)]
        public Image Imagen
        {
            get => imagen;
            set => SetPropertyValue(nameof(Imagen), ref imagen, value);
        }

        [Browsable(false)]
        [Association("TipoDeProducto-ProductoCombos")]
        public XPCollection<ProductoCombo> ProductoCombos
        {
            get
            {
                return GetCollection<ProductoCombo>(nameof(ProductoCombos));
            }
        }

        [Browsable(false)]
        [Association("TipoDeProducto-ProductoComboDeuda")]
        public XPCollection<ProductoComboDeuda> ProductoComboDeuda
        {
            get
            {
                return GetCollection<ProductoComboDeuda>(nameof(ProductoComboDeuda));
            }
        }


    }
}