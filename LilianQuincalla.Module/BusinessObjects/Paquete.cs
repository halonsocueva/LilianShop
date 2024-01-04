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
    [NavigationItem("Importados")]
    public class Paquete : BaseObject
    { 
        public Paquete(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IdentificadorEnvio
        {
            get => identificadorEnvio;
            set => SetPropertyValue(nameof(IdentificadorEnvio), ref identificadorEnvio, value);
        }

        decimal costoCompraEnTienda;
        decimal costoEnvio;
        string identificadorEnvio;
        DateTime fechaRecogida;
        DateTime fechaCompra;

        public DateTime FechaCompra
        {
            get => fechaCompra;
            set => SetPropertyValue(nameof(FechaCompra), ref fechaCompra, value);
        }

        public DateTime FechaRecogida
        {
            get => fechaRecogida;
            set => SetPropertyValue(nameof(FechaRecogida), ref fechaRecogida, value);
        }

        
        public decimal CostoCompraEnTienda
        {
            get => costoCompraEnTienda;
            set => SetPropertyValue(nameof(CostoCompraEnTienda), ref costoCompraEnTienda, value);
        }

        public decimal CostoEnvio
        {
            get => costoEnvio;
            set => SetPropertyValue(nameof(CostoEnvio), ref costoEnvio, value);
        }

        [Association("Paquete-CosmeticoPaquete")]
        public XPCollection<CosméticoPaquete> CosmeticoPaquete
        {
            get
            {
                return GetCollection<CosméticoPaquete>(nameof(CosmeticoPaquete));
            }
        }

        [Association("Paquete-MiscelaneaPaquete")]
        public XPCollection<MiscelaneaPaquete> MiscelaneaPaquete
        {
            get
            {
                return GetCollection<MiscelaneaPaquete>(nameof(MiscelaneaPaquete));
            }
        }

        decimal costoPaquete = 0;
        public decimal CostoPaquete
        {
            get
            {
                return CostoCompraEnTienda + CostoEnvio;
            }
            private set { }
        }

        decimal? totalVentaPaquete = 0;
        public decimal? TotalVentaPaquete
        {
            get
            {
                totalVentaPaquete = 0;
                if (CosmeticoPaquete != null)
                {
                    foreach (var item in CosmeticoPaquete)
                    {
                        totalVentaPaquete += item.TotalGenerado;
                    }
                }
                if(MiscelaneaPaquete != null)
                {
                    foreach(var item in MiscelaneaPaquete)
                    {
                        totalVentaPaquete += item.TotalGenerado;
                    }
                }
                
                return totalVentaPaquete;
            }
            private set { }
        }

        decimal? gananciaPaquete = 0;
        public decimal? GananciaPaquete
        {
            get
            {
                gananciaPaquete = 0;
                if (CosmeticoPaquete != null)
                {
                    foreach (var item in CosmeticoPaquete)
                    {
                        gananciaPaquete += item.GananciaProducto;
                    }
                }
                if (MiscelaneaPaquete != null)
                {
                    foreach (var item in MiscelaneaPaquete)
                    {
                        gananciaPaquete += item.GananciaProducto;
                    }
                }

                return gananciaPaquete;
            }
            private set { }
        }
    }
}