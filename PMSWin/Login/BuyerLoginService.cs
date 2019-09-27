using PMSWin.PurchasingOrder;
using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Login
{
    public class BuyerLoginService
    {
        /// <summary>
        /// 驗證帳號密碼
        /// </summary>
        /// <param name="id">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>使用者物件</returns>
        internal Buyer CheckPassword(string id, string password)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            //查詢Buyer資料
            BuyerDao dao = new BuyerDao();
            Buyer buyer = dao.FindBuyerByEmployeeID(id);

            if (buyer == null)
            {
                return null;
            }

            string hashPassword = Util.GetHash(password + buyer.PasswordSalt);
            if (hashPassword.Equals(buyer.PasswordHash))
            {
                return buyer;
            }
            return null;
        }

    }
}
