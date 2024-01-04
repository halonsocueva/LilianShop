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
using DisplayNameAttribute = System.ComponentModel.DisplayNameAttribute;

namespace LilianQuincalla.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Deudores")]
    [DisplayName("Otros Deudores")]
    public class Deudores : BaseObject
    { 
        public Deudores(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        decimal? deudaTotal = 0;
        string nombre;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }

        [Association("Deudores-ProductosComboDeudas")]
        public XPCollection<ProductoComboDeuda> ProductosComboDeudas
        {
            get
            {
                return GetCollection<ProductoComboDeuda>(nameof(ProductosComboDeudas));
            }
        }

        [Association("Deudores-CosmeticoDeudas")]
        public XPCollection<CosmeticoDeuda> CosmeticoDeuda
        {
            get
            {
                return GetCollection<CosmeticoDeuda>(nameof(CosmeticoDeuda));
            }
        }

        [Association("Deudores-MiscelaneaDeudas")]
        public XPCollection<MiscelaneaDeuda> MiscelaneaDeudas
        {
            get
            {
                return GetCollection<MiscelaneaDeuda>(nameof(MiscelaneaDeudas));
            }
        }

        public decimal? DeudaTotal
        {
            get
            {
                deudaTotal = 0;
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