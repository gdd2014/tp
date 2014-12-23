using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Listado_Estadistico {
    
    public partial class Listados_Estadisticos : Form {
        
        public Listados_Estadisticos() {
            InitializeComponent();

            UIUtils.llenarComboConNumeros(1, 4, comboTrimestre);
            UIUtils.llenarComboConNumeros(DateTime.Today.Year - 2, DateTime.Today.Year + 1, comboAnio);

            List<Item> valoresDeReporte = new List<Item>();
            valoresDeReporte.Add(new Item() { num = "1", desc = "Hoteles con más cancelaciones" });
            valoresDeReporte.Add(new Item() { num = "2", desc = "Hoteles con más consumibles facturados" });
            valoresDeReporte.Add(new Item() { num = "3", desc = "Hoteles con más más días cerrados" });
            valoresDeReporte.Add(new Item() { num = "4", desc = "Habitaciones más ocupadas" });
            valoresDeReporte.Add(new Item() { num = "5", desc = "Clientes con más puntos" });

            comboReporte.DataSource = valoresDeReporte;
            comboReporte.ValueMember = "num";
            comboReporte.DisplayMember = "desc";
            comboReporte.SelectedValue = "";
        }

        private void botonGenerarReporte_Click(object sender, EventArgs e) {
            List<String> errores = validar();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                DateTime primerDiaDelAnio = DateTime.Parse(UIUtils.valorSeleccionado(comboAnio)+ "-01-01");
                int mesesDelTrismestre = Int32.Parse(UIUtils.valorSeleccionado(comboTrimestre)) * 3 - 2;
                String comienzoTrimestre = DBUtils.stringify(ConversionUtils.dateTimeAStr(primerDiaDelAnio.AddMonths(mesesDelTrismestre)));
                String finTrismestre = DBUtils.stringify(ConversionUtils.dateTimeAStr(primerDiaDelAnio.AddMonths(mesesDelTrismestre + 3).AddDays(-1)));

                int codigoDeReporte = Int32.Parse(UIUtils.valorSeleccionado(comboReporte));

                DBUtils.llenarDataGridView(listaDeResultados, HelperDeListados.queryDeReporte(comienzoTrimestre, finTrismestre, codigoDeReporte));
                HelperDeListados.configurarTablaSegunReporte(listaDeResultados, codigoDeReporte);
            }
        }

        private List<String> validar() {
            List<String> errores = new List<String>();

            UIUtils.validarComboCompleto(comboAnio, "Año", errores);
            UIUtils.validarComboCompleto(comboTrimestre, "Trimestre", errores);
            UIUtils.validarComboCompleto(comboReporte, "Reporte", errores);

            return errores;
        }
    }
}
