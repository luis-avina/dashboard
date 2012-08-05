﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("Model1", "ProductoVenta", "Producto", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(MsftDashboard.Web.Models.Producto), "Venta", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MsftDashboard.Web.Models.Venta))]

#endregion

namespace MsftDashboard.Web.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Model1Container : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Model1Container object using the connection string found in the 'Model1Container' section of the application configuration file.
        /// </summary>
        public Model1Container() : base("name=Model1Container", "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Model1Container object.
        /// </summary>
        public Model1Container(string connectionString) : base(connectionString, "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Model1Container object.
        /// </summary>
        public Model1Container(EntityConnection connection) : base(connection, "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Producto> Producto
        {
            get
            {
                if ((_Producto == null))
                {
                    _Producto = base.CreateObjectSet<Producto>("Producto");
                }
                return _Producto;
            }
        }
        private ObjectSet<Producto> _Producto;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Venta> Venta
        {
            get
            {
                if ((_Venta == null))
                {
                    _Venta = base.CreateObjectSet<Venta>("Venta");
                }
                return _Venta;
            }
        }
        private ObjectSet<Venta> _Venta;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Producto EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProducto(Producto producto)
        {
            base.AddObject("Producto", producto);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Venta EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVenta(Venta venta)
        {
            base.AddObject("Venta", venta);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="Producto")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Producto : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Producto object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Producto CreateProducto(global::System.Int32 id, global::System.String name)
        {
            Producto producto = new Producto();
            producto.Id = id;
            producto.Name = name;
            return producto;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model1", "ProductoVenta", "Venta")]
        public EntityCollection<Venta> Ventas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Venta>("Model1.ProductoVenta", "Venta");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Venta>("Model1.ProductoVenta", "Venta", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="Venta")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Venta : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Venta object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="idProducto">Initial value of the IdProducto property.</param>
        /// <param name="vent">Initial value of the Vent property.</param>
        public static Venta CreateVenta(global::System.Int32 id, global::System.Int32 idProducto, global::System.Double vent)
        {
            Venta venta = new Venta();
            venta.Id = id;
            venta.IdProducto = idProducto;
            venta.Vent = vent;
            return venta;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IdProducto
        {
            get
            {
                return _IdProducto;
            }
            set
            {
                OnIdProductoChanging(value);
                ReportPropertyChanging("IdProducto");
                _IdProducto = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IdProducto");
                OnIdProductoChanged();
            }
        }
        private global::System.Int32 _IdProducto;
        partial void OnIdProductoChanging(global::System.Int32 value);
        partial void OnIdProductoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Double Vent
        {
            get
            {
                return _Vent;
            }
            set
            {
                OnVentChanging(value);
                ReportPropertyChanging("Vent");
                _Vent = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Vent");
                OnVentChanged();
            }
        }
        private global::System.Double _Vent;
        partial void OnVentChanging(global::System.Double value);
        partial void OnVentChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model1", "ProductoVenta", "Producto")]
        public Producto Producto
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Producto>("Model1.ProductoVenta", "Producto").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Producto>("Model1.ProductoVenta", "Producto").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Producto> ProductoReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Producto>("Model1.ProductoVenta", "Producto");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Producto>("Model1.ProductoVenta", "Producto", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
