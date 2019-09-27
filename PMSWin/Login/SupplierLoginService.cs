using PMSWin.PurchasingOrder;
using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Login
{
    public class SupplierLoginService
    {
        /// <summary>
        /// 驗證帳號密碼
        /// </summary>
        /// <param name="id">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>使用者物件</returns>
        internal Model.SupplierAccount CheckPassword(string id, string password)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            //查詢SupplierAccount資料
            SupplierAccountDao dao = new SupplierAccountDao();
            Model.SupplierAccount supplier = dao.FindSupplierAccountBySupplierAccountID(id);

            if (supplier == null)
            {
                return null;
            }

            string hashPassword = Util.GetHash(password + supplier.PasswordSalt);
            if (hashPassword.Equals(supplier.PasswordHash))
            {
                return supplier;
            }
            return null;
        }
    }
}
