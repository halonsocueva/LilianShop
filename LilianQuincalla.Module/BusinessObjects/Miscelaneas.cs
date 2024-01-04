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
    [NavigationItem("Importados")]
    public class Miscelaneas : BaseObject
    { 
        public Miscelaneas(Session session): base(session)
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

        [Association("Miscelanea-MiscelaneaPaquete")]
        public XPCollection<MiscelaneaPaquete> MiscelaneaPaquete
        {
            get
            {
                return GetCollection<MiscelaneaPaquete>(nameof(MiscelaneaPaquete));
            }
        }

        [Association("Miscelaneas-MiscelaneasDeudas")]
        public XPCollection<MiscelaneaDeuda> MiscelaneaDeuda
        {
            get
            {
                return GetCollection<MiscelaneaDeuda>(nameof(MiscelaneaDeuda));
            }
        }
    }
}