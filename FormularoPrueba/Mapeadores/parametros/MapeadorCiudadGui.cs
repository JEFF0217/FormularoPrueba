using AccesoDeDatos.ModeloDatos;
using FormularoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularoPrueba.Mapeadores.parametros
{
    public class MapeadorCiudadGui : MapeadorBaseGUI<tb_ciudad, ModeloCiudadGUI>
    {
        public override ModeloCiudadGUI MapearTipo1Tipo2(tb_ciudad entrada)
        {
            return new ModeloCiudadGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ModeloCiudadGUI> MapearTipo1Tipo2(IEnumerable<tb_ciudad> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_ciudad MapearTipo2Tipo1(ModeloCiudadGUI entrada)
        {
            return new tb_ciudad()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };

        }

        public override IEnumerable<tb_ciudad> MapearTipo2Tipo1(IEnumerable<ModeloCiudadGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}