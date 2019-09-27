using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    public static class UtilWinForm
    {
        /// <summary>
        /// 取得欄位名稱的索引
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dataPropertyName"></param>
        /// <returns></returns>
        public static int GetColumnIndex(this DataGridView dgv, string dataPropertyName)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.DataPropertyName == dataPropertyName)
                {
                    return col.Index;
                }
            }
            return -1;
        }


    }
}
