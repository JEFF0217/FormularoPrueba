using AccesoDeDatos.ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion
{
    public class ImpCiudadDatos
    {
        /// <summary>
        /// Metodo para listar registros con filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista con el filtro aplicado</returns>
        public IEnumerable<tb_ciudad> ListarRegistros(string filtro)
        {
            var lista = new List<tb_ciudad>();
            using (FormularioDBEntities bd = new FormularioDBEntities())
            {
                if (String.IsNullOrWhiteSpace(filtro))
                {
                    lista = bd.tb_ciudad.ToList();
                }
                else
                {
                    lista = bd.tb_ciudad.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                }
         
            }
            return lista; 
        }


        /// <summary>
        /// metodo para almacenar un registro
        /// </summary>
        /// <param name="registro"> el registro a almacenar </param>
        /// <returns>True cuando se almacena y false cuando ya existe el registro igual o una excepcion</returns>
        public bool GuardarRegistro(tb_ciudad registro) 
        {
            try
            {
                using (FormularioDBEntities bd = new FormularioDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo nombre
                    if (bd.tb_ciudad.Where(x => x.nombre.ToLower().Equals(registro.nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    bd.tb_ciudad.Add(registro);
                    bd.SaveChanges();
                    return true;
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// metodo para realizar la busqueda de un registro
        /// </summary>
        /// <param name="id"> El id del registro a buscar</param>
        /// <returns>retorna el objeto con el id buscado o null cuando no existe    </returns>
        public tb_ciudad BuscarRegistro(int id) 
        {
            using (FormularioDBEntities bd = new FormularioDBEntities()) {
                tb_ciudad registro = bd.tb_ciudad.Find(id);
                return registro;
            }
        }





        /// <summary>
        /// metodo para editar un registro
        /// </summary>
        /// <param name="registro"> el registro a editar </param>
        /// <returns>True cuando se edita y false cuando no exite el registro igual o una excepcion</returns>
        public bool EditarRegistro(tb_ciudad registro)
        {
            try
            {
                using (FormularioDBEntities bd = new FormularioDBEntities())
                {
                    //verificacion de la existencia de un registro con un mismo id
                    if (bd.tb_ciudad.Where(x => x.id==registro.id).Count() == 0)
                    {
                        return false;
                    }

                    bd.Entry(registro).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// metodo para eliminar un registro
        /// </summary>
        /// <param name="id"> identificador del registro a eliminar </param>
        /// <returns>True cuando se elimina y false cuando no exite el registro  o una excepcion</returns>
        public bool ELiminarRegistro(int id)
        {
            try
            {
                using (FormularioDBEntities bd = new FormularioDBEntities())
                {
                    tb_ciudad registro = bd.tb_ciudad.Find(id);
                    //verificacion de la existencia de un registro con un mismo id
                    if (registro == null || registro.tb_usuario.Count() > 0)
                    {
                        return false;
                    }

                    bd.tb_ciudad.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
