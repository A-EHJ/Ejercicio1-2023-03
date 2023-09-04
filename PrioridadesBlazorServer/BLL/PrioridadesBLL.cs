using Microsoft.EntityFrameworkCore;
using PrioridadesBlazorServer.DAL;
using PrioridadesBlazorServer.Models;
using System.Linq.Expressions;

namespace PrioridadesBlazorServer.BLL
{
    public class PrioridadesBLL
    {
        private Contexto _contexto { get; set; }
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int id)
        {
            return _contexto.Prioridades.Any(o => o.PrioridadId == id);
        }
        private bool Insertar(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Prioridades prioridades)
        {
            var PrioridadADesechar = _contexto.Prioridades.Find(prioridades.PrioridadId);
            if (prioridades != null)
            {
                _contexto.Entry(PrioridadADesechar).State = EntityState.Detached;
                _contexto.Entry(prioridades).State = EntityState.Modified;
                return _contexto.SaveChanges() > 0;
            }
            return false;
            
        }

        public bool Guardar(Prioridades prioridades)
        {
            if (_contexto.Prioridades.Any(p => p.PrioridadId != prioridades.PrioridadId && p.Descripcion == prioridades.Descripcion))
            {
                return false;
            }
            if (!Existe(prioridades.PrioridadId))
                return Insertar(prioridades);
            else
                return Modificar(prioridades);
        }

        public bool Eliminar(int id)
        {

            Prioridades prioridades = _contexto.Prioridades.Find(id);
            if (prioridades != null)
            {
                _contexto.Entry(prioridades).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;

        }

        public Prioridades? Buscar(int id)
        {
            return _contexto.Prioridades.Where(o => o.PrioridadId == id).AsNoTracking().SingleOrDefault(); ;
        }

        public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
        {
            return _contexto.Prioridades.AsNoTracking().Where(criterio).ToList();
        }
    }
}
