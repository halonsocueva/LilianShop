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
using System.Data;
using System.Linq;
using System.Text;

namespace LilianQuincalla.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Combos")]
    public class Combo : BaseObject
    {
        public Combo(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        bool domicilio;
        bool recogido = false;
        string recolector;
        decimal precioCombo;
        CentroRecolector centroRecolector;
        DateTime fechaDeCompra;
        string numeroOrden;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumeroOrden
        {
            get => numeroOrden;
            set => SetPropertyValue(nameof(NumeroOrden), ref numeroOrden, value);
        }

        public DateTime FechaDeCompra
        {
            get => fechaDeCompra;
            set => SetPropertyValue(nameof(FechaDeCompra), ref fechaDeCompra, value);
        }

        
        public bool Domicilio
        {
            get => domicilio;
            set => SetPropertyValue(nameof(Domicilio), ref domicilio, value);
        }
        public CentroRecolector CentroRecolector
        {
            get => centroRecolector;
            set => SetPropertyValue(nameof(CentroRecolector), ref centroRecolector, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Recolector
        {
            get => recolector;
            set => SetPropertyValue(nameof(Recolector), ref recolector, value);
        }

        public decimal PrecioCombo
        {
            get => precioCombo;
            set => SetPropertyValue(nameof(PrecioCombo), ref precioCombo, value);
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public bool Recogido
        {
            get => recogido;
            set => SetPropertyValue(nameof(Recogido), ref recogido, value);
        }

        [Association("Combo-Productos")]
        public XPCollection<ProductoCombo> Productos
        {
            get
            {
                return GetCollection<ProductoCombo>(nameof(Productos));
            }
        }

        decimal? totalVentaCombo;
        [ModelDefault("AllowEdit", "false")]
        public decimal? TotalVentaCombo
        {
            get => totalVentaCombo;
            set => SetPropertyValue(nameof(TotalVentaCombo), ref totalVentaCombo, value);
        }

        decimal? gananciaCombo;
        [ModelDefault("AllowEdit", "false")]
        public decimal? GananciaCombo
        {
            get => gananciaCombo;
            set => SetPropertyValue(nameof(GananciaCombo), ref gananciaCombo, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            decimal? totalVenta = 0;
            foreach (var item in Productos)
            {
                totalVenta += item.TotalGenerado;
            }
            TotalVentaCombo = totalVenta;
            GananciaCombo = totalVenta - PrecioCombo;
        }

    }


    public enum CentroRecolector
    {
        Boyeros = 0,
        Alamar = 1,
        Veintiseis = 2,
        DiezDeOctubre = 3,
        Cotorro = 4,
    }
}