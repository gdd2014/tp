﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Utils;

namespace FrbaHotel.ABM_de_Hotel {
    
    public partial class B_Hotel : Form {

        String hotelId;

        public B_Hotel(String hotelId) {
            this.hotelId = hotelId;

            InitializeComponent();
        }

        private void botonCerrarHotel_Click(object sender, EventArgs e) {
              
            List<String> errores = validarForm();
            UIUtils.mostrarErrores(errores);

            if (errores.Count == 0) {
                List<String> pars = new List<String>() { "@Hotel_Id", "@Desde", "@Hasta", "@Motivo" };
                List<String> vals = new List<String>() { hotelId, 
                                                         ConversionUtils.dateTimeAStr(desdeDTP.Value),
                                                         ConversionUtils.dateTimeAStr(hastaDTP.Value),
                                                         motivoTextbox.Text
                                                        };
                
                DBUtils.ejecutarSP("Baja_Momentanea_Hotel", pars, vals);

                MessageBox.Show("Hotel cerrado exitosamente para las fechas seleccionadas...");
                
                this.Close();
            }
        }


        private List<String> validarForm() {
            List<String> errores = new List<String>();

            UIUtils.validarTextboxCompleto(motivoTextbox, "Motivo", errores);
            UIUtils.validarFechaAnteriorAOtra(desdeDTP, hastaDTP, "Desde", "Hasta", errores);
            UIUtils.validarFechaPosteriorAAyer(desdeDTP, "Cierre", errores);

            // Valido que no haya reservas en el rango de fechas
            int tieneReservas = DBUtils.queryRetornaInts("SELECT G_N.Hot_Tiene_Reservas_en_Periodo(" + hotelId + "," +
                                                                                                       DBUtils.stringify(ConversionUtils.dateTimeAStr(desdeDTP.Value))  + "," +
                                                                                                       DBUtils.stringify(ConversionUtils.dateTimeAStr(hastaDTP.Value)) + ")").First();

            if (ConversionUtils.IntABool(tieneReservas)) {
                errores.Add("El hotel tiene reservas entre las fechas seleccionadas");
            }

            return errores;
        }

    }
}
