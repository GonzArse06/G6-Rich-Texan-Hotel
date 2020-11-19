﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayer.Datos
{
    public static class Exportar
    {
        public static void ExportarAExcel(List<string[]> listView, string[] headers)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                int col = 0;
                int fila = 1;
                for (int i = 0; i < headers.Length; i++)
                {
                    col++;
                    hoja_trabajo.Cells[fila, col] = headers[i];
                }
               
                foreach (string[] lvi in listView)
                {
                    fila++;
                    col = 0;
                    for (int i = 0; i < lvi.Length; i++)
                    {
                        col++;
                        hoja_trabajo.Cells[fila, col] = lvi[i];
                    }

                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }
    }
}
