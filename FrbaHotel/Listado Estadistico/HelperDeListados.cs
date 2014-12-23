﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico {
    
    static class HelperDeListados {

        static String queryBasicaHotel = "SELECT TOP 5 h.Hotel_Nombre AS 'Nombre De Hotel', " + 
		                            " h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS Direccion, ";

        public static String queryDeReporte(String desde, String hasta, int reporteId) {
            String q = "";

            switch (reporteId) {
                case 1:
                    q = queryBasicaHotel + 
	                            " COUNT(r.Reserva_Fecha_Cancelacion) AS 'Cantidad de Cancelaciones' " + 
                        " FROM G_N.Hoteles h " +
                          " JOIN G_N.Reservas r ON G_N.Hotel_De_Reserva(r.Reserva_Codigo) = h.Hotel_Id " +
                        " WHERE r.Reserva_Fecha_Cancelacion > " + desde + " AND r.Reserva_Fecha_Cancelacion < " + hasta + 
                          " GROUP BY h.Hotel_Nombre, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) " +
                          " ORDER BY 3 DESC ";
                    break;
                case 2:
                    q = queryBasicaHotel +
                              " SUM(fi.Factura_Item_Cantidad) AS 'Consumibles Facturados' " +
                           " FROM G_N.Hoteles h " +
                             " JOIN G_N.Reservas r ON G_N.Hotel_De_Reserva(r.Reserva_Codigo) = h.Hotel_Id " +
                             " JOIN G_N.Facturas f ON f.Factura_Estadia_Reserva_Codigo = r.Reserva_Codigo" +
                             " JOIN G_N.Factura_Items fi ON fi.Factura_Item_Factura_Nro = f.Factura_Nro " +
                         " WHERE f.Factura_Fecha > " + desde + " AND f.Factura_Fecha < " + hasta +
                         " GROUP BY h.Hotel_Nombre, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) " +
                         " ORDER BY 3 DESC ";
                    break;
                case 3:
                    q = queryBasicaHotel +
                                 "COUNT ";
                    break;
                case 4:
                    q = queryBasicaHotel +
                                 "COUNT ";
                    break;
                case 5:
                    q = queryBasicaHotel +
                                 "COUNT ";
                    break;
            }
            
            return q;
        }

        public static void configurarTablaSegunReporte(DataGridView listaDeResultados, int codigoDeReporte) {
            switch (codigoDeReporte) {
                case 1:
                    listaDeResultados.Columns[0].Width = 180;
                    listaDeResultados.Columns[1].Width = 290;
                    listaDeResultados.Columns[2].Width = 165;
                    break;
                case 2:
                    listaDeResultados.Columns[0].Width = 180;
                    listaDeResultados.Columns[1].Width = 290;
                    listaDeResultados.Columns[2].Width = 165;
                    break;
                case 3:
                    listaDeResultados.Columns[0].Width = 180;
                    listaDeResultados.Columns[1].Width = 290;
                    listaDeResultados.Columns[2].Width = 165;
                    break;
                case 4:
                    listaDeResultados.Columns[0].Width = 180;
                    listaDeResultados.Columns[1].Width = 290;
                    listaDeResultados.Columns[2].Width = 165;
                    break;
                case 5:
                    listaDeResultados.Columns[0].Width = 180;
                    listaDeResultados.Columns[1].Width = 290;
                    listaDeResultados.Columns[2].Width = 165;
                    break;

            }
        
        }
    }
}