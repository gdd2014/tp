using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace FrbaHotel.Utils {
    
    class GridUtils {

        public static DataRow[] GetSelectedDataRows(DataGridView grid)
        {
            DataRow[] dRows = new DataRow[grid.SelectedRows.Count];
            for (int i = 0; i < grid.SelectedRows.Count; i++)
                dRows[i] = ((DataRowView)grid.SelectedRows[i].DataBoundItem).Row;

            return dRows;
        }

        public static void MoveRows(DataTable src, DataTable dest, DataRow[] rows) {
            
            foreach (DataRow row in rows) {
                // add to dest
                object[] currRows = row.ItemArray;
                dest.Rows.Add(currRows);

                // remove from src
                src.Rows.Remove(row);
            }
        }
    }
}
