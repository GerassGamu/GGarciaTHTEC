//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GGarciaTHTECEntities : DbContext
    {
        public GGarciaTHTECEntities()
            : base("name=GGarciaTHTECEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Profesor> Profesors { get; set; }
    
        public virtual int ProfesorAdd(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<decimal> sueldo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var sueldoParameter = sueldo.HasValue ?
                new ObjectParameter("Sueldo", sueldo) :
                new ObjectParameter("Sueldo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProfesorAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, sueldoParameter);
        }
    
        public virtual int ProfesorDelete(Nullable<int> idProfesor)
        {
            var idProfesorParameter = idProfesor.HasValue ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProfesorDelete", idProfesorParameter);
        }
    
        public virtual ObjectResult<ProfesorGetAll_Result> ProfesorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProfesorGetAll_Result>("ProfesorGetAll");
        }
    
        public virtual ObjectResult<ProfesorGetById_Result> ProfesorGetById(Nullable<int> idProfesor)
        {
            var idProfesorParameter = idProfesor.HasValue ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProfesorGetById_Result>("ProfesorGetById", idProfesorParameter);
        }
    
        public virtual int ProfesorUpdate(Nullable<int> idProfesor, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<decimal> sueldo)
        {
            var idProfesorParameter = idProfesor.HasValue ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var sueldoParameter = sueldo.HasValue ?
                new ObjectParameter("Sueldo", sueldo) :
                new ObjectParameter("Sueldo", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProfesorUpdate", idProfesorParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, sueldoParameter);
        }
    }
}
