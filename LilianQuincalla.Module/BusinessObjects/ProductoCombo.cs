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
    [DefaultProperty(nameof(Producto))]
    [NavigationItem("Combos")]
    public class ProductoCombo : BaseObject
    { 
        public ProductoCombo(Session session): base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        Combo combo;
        int cantidad;
        TipoDeProducto producto;

        [Association("TipoDeProducto-ProductoCombos")]
        public TipoDeProducto Producto
        {
            get => producto;
            set => SetPropertyValue(nameof(Producto), ref producto, value);
        }

        [Browsable(false)]
        [Association("Combo-Productos")]
        public Combo Combo
        {
            get => combo;
            set => SetPropertyValue(nameof(Combo), ref combo, value);
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
                return (Producto?.PrecioDeVenta * Cantidad);
            }
            private set { }
        }

        public decimal? GananciaProducto
        {
            get 
            { 
                return (TotalGenerado - (Producto?.PrecioDeCompra*Cantidad));
            }
            private set { }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            decimal? generado = 0;
            decimal? ganancia = 0;
            generado = Producto?.PrecioDeVenta * Cantidad;
            ganancia = generado - (Producto?.PrecioDeCompra * Cantidad);

            TotalGenerado = generado;
            GananciaProducto = ganancia;
        }

    }
}