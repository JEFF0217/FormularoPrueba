using AccesoDeDatos.ModeloDatos;
using FormularoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularoPrueba.Mapeadores.parametros
{
    public class MapeadorTipoDocGui : MapeadorBaseGUI<tb_TipoDoc, ModeloTipoDocGUI>
    {
        public override ModeloTipoDocGUI MapearTipo1Tipo2(tb_TipoDoc entrada)
        {
            return new ModeloTipoDocGUI()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ModeloTipoDocGUI> MapearTipo1Tipo2(IEnumerable<tb_TipoDoc> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_TipoDoc MapearTipo2Tipo1(ModeloTipoDocGUI entrada)
        {
            return new tb_TipoDoc()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_TipoDoc> MapearTipo2Tipo1(IEnumerable<ModeloTipoDocGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}