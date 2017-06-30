using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Chat
{
    /*
     * Clase encargada de cargar los datos de un archivo de excel
     * */
    class Datos
    {
        
        Excel._Application xlApp;
        Excel._Workbook xlLibro;
        Excel._Worksheet xlHoja1;
        Excel.Sheets xlHojas;

        private List<String> grupos;
        private List<String> usuarios;

        public Datos(String url)
        {
            //Cargar el archivo
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(url, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja1 = xlLibro.Sheets[1];

            //Se crean las listas para almacenar en memoria los datos
            grupos = new List<string>();
            usuarios = new List<string>();
            Console.WriteLine("Archivo abierto");

            //Extracción de datos de excel
            Excel.Range xlRange = xlHoja1.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            for (int i = 2; i <= rowCount; i++)
            {
                String grupo = (string)xlHoja1.get_Range("A" + i, Missing.Value).Text;
                String usuario = (string)xlHoja1.get_Range("B" + i, Missing.Value).Text;
                if (!"".Equals(grupo))
                {
                    grupos.Add(grupo);
                }

                if (!"".Equals(usuario))
                {
                    usuarios.Add(usuario);
                }
            }

            //Se cierra el documento de excel
            xlLibro.Close(false, Missing.Value, Missing.Value);
            xlApp.Quit();
        }

        //Retorno de los grupos
        public List<String> getGrupos()
        {
            return grupos;
        }

        //Retorno de usuarios
        public List<String> getUsuarios()
        {
            return usuarios;
        }


    }
}
