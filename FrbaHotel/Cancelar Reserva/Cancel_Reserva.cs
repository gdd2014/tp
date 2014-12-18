using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.Cancelar_Reserva {
    
    public partial class Cancel_Reserva : Form {

        String reservaId;
        String usuarioId;
        
        public Cancel_Reserva(String reservaId, String usId) {
            this.reservaId = reservaId;

            if (usId == null || usId == "") {
                usuarioId = "2"; // --> usuario guest generico
            } else {
                usuarioId = usId;
            }
            
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e) {
            List<String> errores = UIUtils.validarTextboxCompleto(motivoTextbox, "Motivo", new List<String>());
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                DBUtils.actualizar("Reservas", campos(), valores(), "Reserva_Codigo", reservaId);
                MessageBox.Show("Reserva cancelada exitosamente.");
                this.Close();
            }
        }

        private List<String> campos() {
            List<String> campos = new List<String>();

            campos.Add("Reserva_Motivo_Cancelacion");
            campos.Add("Reserva_Fecha_Cancelacion");
            campos.Add("Reserva_Usuario_Id");

            return campos;
        }

        private List<String> valores() {
            List<String> valores = new List<String>();

            valores.Add(DBUtils.stringify(motivoTextbox.Text));
            valores.Add(DBUtils.stringify(ConversionUtils.dateTimeAStr(DateTime.Today)));
            valores.Add(usuarioId);

            return valores;
        }
    }
}
