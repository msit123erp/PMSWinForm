using PMSWin.Dao;
using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Login
{
    public class CreateSupplierAccountService
    {
        /// <summary>
        /// 驗證型別
        /// </summary>
        public enum ValidateType
        {
            None = 0b0000,
            ExistsAccount = 0b0001
        }

        /// <summary>
        /// 驗證供應商帳號資料
        /// </summary>
        /// <param name="SupplierCode">供應商代碼</param>
        /// <returns>驗證結果</returns>
        public ValidateType ValidateUser(string SupplierCode)
        {
            ValidateType vt = ValidateType.None;

            PurchasingOrder.SupplierAccountDao dao = new PurchasingOrder.SupplierAccountDao();
            Model.SupplierAccount sa = dao.FindSupplierAccountBySupplierCode(SupplierCode);
            if (sa != null)
            {
                vt |= ValidateType.ExistsAccount;
            }

            return vt;
        }

        /// <summary>
        /// 建立供應商帳號
        /// </summary>
        /// <param name="Password">程式自動產生的密碼，後續需電郵給供應商</param>
        /// <param name="ContactName">聯絡人</param>
        /// <param name="Email">電子信箱</param>
        /// <param name="Address">地址</param>
        /// <param name="Mobile">手機</param>
        /// <param name="Tel">市話</param>
        /// <param name="SupplierCode">供應商代碼</param>
        /// <param name="AccountStatus">帳號狀態</param>
        /// <param name="CreatorEmployeeID">建立者員工編號</param>
        /// <returns>供應商帳號識別碼</returns>
        public int CreateSupplierAccount(ref string Password, string ContactName, string Email, string Address, string Mobile, string Tel, string SupplierCode, string AccountStatus, string CreatorEmployeeID)
        {
            string salt = Guid.NewGuid().ToString();
            Password = Util.BuildAuthToken();
            string hashPassword = Util.GetHash(Password + salt.ToString());
            PurchasingOrder.SupplierAccountDao dao = new PurchasingOrder.SupplierAccountDao();
            DateTime createDate = DateTime.Now;
            int SupplierAccountOID = dao.CreateSupplierAccount(hashPassword, salt, ContactName, Email, Address, Mobile, Tel, SupplierCode, AccountStatus, createDate, CreatorEmployeeID);
            return SupplierAccountOID;
        }

        /// <summary>
        /// 發送帳號開通郵件
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool SendEnableAccount(Model.SupplierAccount supplier, string password)
        {
            List<string> mailList = new List<string>() { supplier.Email };

            string subject = $"<p>您登入{Properties.Settings.Default.AppName}所需的帳號與密碼</p>";

            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>{supplier.ContactName} 您好</p>");
            sb.Append($"<p>已為您產生一組帳號與密碼用以登入系統</p>");
            sb.Append($"<p>帳號為 {supplier.SupplierAccountID}</p>");
            sb.Append($"<p>{password} 是您的登入密碼</p>");
            sb.Append("<p>謝謝</p>");
            sb.Append($"<p>{Properties.Settings.Default.AppName}</p>");
            string body = sb.ToString();

            return Util.SendMail(mailList, Properties.Settings.Default.AppName, subject, body);
        }

    }
}
