using First_RegistroJ.DAL;
using First_RegistroJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace First_RegistroJ.BLL
{
    public class RegistroBLL
    {
        public static bool Modificar(Registro registro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(registro).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool insertar(Registro registro)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Registros.Add(registro);
                paso = db.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        
        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.Registros.Any(p => p.RegistroId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;
        }


        public static bool Guardar(Registro registro)
        {
            if (!Existe(registro.RegistroId))
                return insertar(registro);
            else
                return Modificar(registro);
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var registro = db.Registros.Find(id);
                if(registro != null)
                {
                    db.Registros.Remove(registro);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Registro Buscar(int id)
        {
            Contexto db = new Contexto();
            Registro registro;

            try
            {
                registro = db.Registros.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return registro;
        }
        public static List<Registro> GetPersonas()
        {
            List<Registro> lista = new List<Registro>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Registros.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<Registro> GetList(Expression<Func<Registro, bool>> criterio)
        {
            List<Registro> lista = new List<Registro>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Registros.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }


























    }
}
