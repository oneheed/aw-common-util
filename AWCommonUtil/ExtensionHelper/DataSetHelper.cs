using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCommonUtil
{
    /// <summary>
    /// Some extension methods for DataSet/DataTable/DataRow
    /// </summary>
    public static class DataSetHelper
    {
        private static bool IsValidDataRow(DataRow row)
        {
            if (row == null || row.Table == null)
                return false;

            if (row.Table.Columns == null || row.Table.Columns.Count < 1)
                return false;

            return true;
        }

        private static bool IsValidDataTable(DataTable table)
        {
            if (table == null)
                return false;

            if (table.Rows == null || table.Rows.Count < 1)
                return false;

            return true;
        }

        private static bool IsValidDataTables(DataTableCollection tables)
        {
            if (tables == null || tables.Count < 1)
                return false;

            return true;
        }

        /// <summary>
        /// Try get value from datarow by the column name
        /// If cannot get value, will return null
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static object TryGetValue(this DataRow row, string columnName)
        {
            if (IsValidDataRow(row))
            {
                if (row.Table.Columns.Contains(columnName))
                {
                    return row[columnName];
                }
            }

            return null;
        }

        /// <summary>
        /// Try get value from the row by the column index
        /// If cannot get value, will return null
        /// </summary>
        /// <param name="row"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static object TryGetValue(this DataRow row, int idx)
        {
            if (IsValidDataRow(row))
            {
                return row[idx];
            }

            return null;
        }

        /// <summary>
        /// Try get row from the table by the row index
        /// If cannot get row, will return null
        /// </summary>
        /// <param name="table"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static DataRow TryGetRow(this DataTable table, int idx)
        {
            if (IsValidDataTable(table))
            {
                return table.Rows[idx];
            }

            return null;
        }

        /// <summary>
        /// Try get table from the tables by the table index
        /// If cannot get table, will return null
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static DataTable TryGetTable(this DataTableCollection tables, int idx)
        {
            if (IsValidDataTables(tables))
            {
                return tables[idx];
            }

            return null;
        }
    }
}
