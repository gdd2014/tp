using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico {
    
    static class HelperDeListados {

        static String queryBasicaHotel = "SELECT TOP 5 h.Hotel_Nombre AS 'Nombre De Hotel', " + 
		                            " h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS Direccion, ";

        static String groupByBasicoHotel = " GROUP BY h.Hotel_Nombre, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) " +
                                                " ORDER BY 3 DESC ";
        
        public static String queryDeReporte(String desde, String hasta, int reporteId) {
            String q = "";

            switch (reporteId) {
                case 1:
                    q = queryBasicaHotel + 
	                            " COUNT(r.Reserva_Fecha_Cancelacion) AS 'Cantidad de Cancelaciones' " + 
                        " FROM G_N.Hoteles h " +
                          " JOIN G_N.Reservas r ON G_N.Hotel_De_Reserva(r.Reserva_Codigo) = h.Hotel_Id " +
                        " WHERE r.Reserva_Fecha_Cancelacion > " + desde + " AND r.Reserva_Fecha_Cancelacion < " + hasta + 
                          groupByBasicoHotel;
                    break;
                case 2:
                    q = queryBasicaHotel +
                              " SUM(fi.Factura_Item_Cantidad) AS 'Consumibles Facturados' " +
                           " FROM G_N.Hoteles h " +
                             " JOIN G_N.Reservas r ON G_N.Hotel_De_Reserva(r.Reserva_Codigo) = h.Hotel_Id " +
                             " JOIN G_N.Facturas f ON f.Factura_Estadia_Reserva_Codigo = r.Reserva_Codigo" +
                             " JOIN G_N.Factura_Items fi ON fi.Factura_Item_Factura_Nro = f.Factura_Nro " +
                         " WHERE f.Factura_Fecha > " + desde + " AND f.Factura_Fecha < " + hasta +
                              groupByBasicoHotel;
                        
                    break;
                case 3:
                    q = queryBasicaHotel +
                             " SUM(DATEDIFF(DAY, G_N.Fecha_Max(hc.Desde_Fecha, " + desde + "), G_N.Fecha_Min(hc.Hasta_Fecha, " + hasta + "))) AS 'Días Cerrado' " +
                                " FROM G_N.Hoteles h " +
                                " JOIN G_N.Hoteles_Cerrados hc ON h.Hotel_Id = hc.Hotel_Id " +
                            " WHERE (hc.Desde_Fecha BETWEEN " + desde + " AND " + hasta + ") OR " +
                                 " (hc.Hasta_Fecha BETWEEN " + desde + " AND " + hasta + ") OR " +
                                 " (hc.Desde_Fecha < " + desde + " AND hc.Hasta_Fecha > " + hasta + ") " + 
                                 groupByBasicoHotel;
	
                    break;
                case 4:
                    q = "SELECT TOP 5 h.Hotel_Nombre AS 'Nombre De Hotel', " +
                                " h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) AS Direccion, " +
		                        " hab.Habitacion_Numero AS 'Numero de habitación', " +
                                " SUM(DATEDIFF(DAY, G_N.Fecha_Max(r.Reserva_Fecha_Inicio, " + desde + "), G_N.Fecha_Min(r.Reserva_Fecha_Fin, " + hasta + "))) AS 'Días Reservada', " +
			                    " COUNT(hab.Habitacion_Numero) AS 'Cantidad de reservas' " +
		                    " FROM G_N.Hoteles h " +
		                    " JOIN G_N.Habitaciones hab ON hab.Habitacion_Hotel_Id = h.Hotel_Id " +
		                    " JOIN G_N.Reservas_Habitaciones rh ON rh.Habitacion_Id = hab.Habitacion_Id " +
		                    " JOIN G_N.Reservas r ON r.Reserva_Codigo = rh.Reserva_Codigo " +
                        " WHERE (r.Reserva_Fecha_Inicio BETWEEN " + desde + " AND" + hasta + ") OR " +
                             "  (r.Reserva_Fecha_Fin BETWEEN " + desde + " AND " + hasta + ") OR " +
                             "  (r.Reserva_Fecha_Inicio < " + desde + " AND r.Reserva_Fecha_Fin > " + hasta + ") " +
                        " GROUP BY h.Hotel_Nombre, hab.Habitacion_Numero, h.Hotel_Dom_Calle + ' ' + CAST(h.Hotel_Dom_Nro AS NVARCHAR) " +
	                    " ORDER BY 4 DESC";
                    break;
                case 5:
                    q = " SELECT TOP 5 c.Cliente_Nombre + ' ' + c.Cliente_Apellido  AS Nombre,  " +
		                             " dt.Documento_Tipo_Descripcion AS 'Tipo de documento', " +
		                             " c.Cliente_Documento_Nro AS 'Numero de documento', " +
		                             " SUM(G_N.Puntos_Por_Estadia(fi.Factura_Item_Monto, fi.Factura_Item_Consumible_Codigo)) +  " +
		                             " SUM(G_N.Puntos_Por_Consumibles(fi.Factura_Item_Monto, fi.Factura_Item_Consumible_Codigo)) AS Puntos " +
		                        " FROM G_N.Clientes c " +
	                                " JOIN G_N.Documento_Tipos dt ON c.Cliente_Documento_Tipo_Id = dt.Documento_Tipo_Id " +
	                                " JOIN G_N.Reservas r ON r.Reserva_Cliente_Id = c.Cliente_Id " +
	                                " JOIN G_N.Facturas f ON f.Factura_Estadia_Reserva_Codigo = r.Reserva_Codigo " +
	                                " JOIN G_N.Factura_Items fi ON f.Factura_Nro = fi.Factura_Item_Factura_Nro " +
                                " WHERE (f.Factura_Fecha BETWEEN " + desde + " AND " + hasta + ") " +
                                " GROUP BY c.Cliente_Nombre + ' ' + c.Cliente_Apellido, dt.Documento_Tipo_Descripcion, c.Cliente_Documento_Nro " +
                                " ORDER BY 4 DESC ";
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
                    listaDeResultados.Columns[0].Width = 155;
                    listaDeResultados.Columns[1].Width = 220;
                    listaDeResultados.Columns[2].Width = 80;
                    listaDeResultados.Columns[3].Width = 90;
                    listaDeResultados.Columns[4].Width = 90;
                    break;
                case 5:
                    listaDeResultados.Columns[0].Width = 255;
                    listaDeResultados.Columns[1].Width = 140;
                    listaDeResultados.Columns[2].Width = 90;
                    listaDeResultados.Columns[2].Width = 140;
                    break;

            }
        
        }
    }
}
