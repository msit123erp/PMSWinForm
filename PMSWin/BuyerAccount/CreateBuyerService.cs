using PMSWin.Dao;
using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Login
{
    public class CreateBuyerService
    {
        /// <summary>
        /// 驗證型別
        /// </summary>
        public enum ValidateType
        {
            None = 0b0000,
            ExistsEmployeeID = 0b0001
        }

        /// <summary>
        /// 驗證採購人員資料
        /// </summary>
        /// <param name="EmployeeID">帳號</param>
        /// <returns>驗證結果</returns>
        public ValidateType ValidateBuyer(string EmployeeID)
        {
            ValidateType vt = ValidateType.None;

            PurchasingOrder.BuyerDao dao = new PurchasingOrder.BuyerDao();
            Buyer buyer = dao.FindBuyerByEmployeeID(EmployeeID);
            if (buyer != null)
            {
                vt |= ValidateType.ExistsEmployeeID;
            }

            return vt;
        }

        /// <summary>
        /// 建立採購人員帳號
        /// </summary>
        /// <param name="id">帳號</param>
        /// <param name="password">密碼</param>
        /// <param name="accountStatus">帳號狀態</param>
        /// <returns>採購人員識別碼</returns>
        public int CreateBuyer(string id, ref string password, string accountStatus)
        {
            Guid salt = Guid.NewGuid();
            password = Util.BuildAuthToken();
            string hashPassword = Util.GetHash(password + salt.ToString());
            PurchasingOrder.BuyerDao dao = new PurchasingOrder.BuyerDao();
            DateTime createDate = DateTime.Now;
            int buyerOID = dao.CreateBuyer(id, hashPassword, salt.ToString(), accountStatus, createDate);
            return buyerOID;
        }

        /// <summary>
        /// 發送帳號開通郵件
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool SendEnableAccount(Buyer buyer, string password)
        {
            Employee emp = buyer.GetEmployee();
            List<string> mailList = new List<string>() { emp.Email };

            string subject = $"<p>您登入{Properties.Settings.Default.AppName}所需的密碼</p>";

            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>{emp.Name} 您好</p>");
            sb.Append($"<p>{password} 是您的登入密碼</p>");
            sb.Append($"<p>帳號為您的員工編號</p>");
            sb.Append("<p>謝謝</p>");
            sb.Append($"<p>{Properties.Settings.Default.AppName}</p>");
            string body = sb.ToString();

            return Util.SendMail(mailList, Properties.Settings.Default.AppName, subject, body);
        }

        //型態用 bool 會重複寄信xd
        internal static bool SendEmailToEmp(string hashPassword, string emailToBlaBla, out string BSendLetterState)
        {
            BSendLetterState = "Y";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(emailToBlaBla);
            msg.From = new MailAddress("CHBike@gmail.com", "昶興自行車", System.Text.Encoding.UTF8);
            /* 上面3個參數分別是發件人地址（可以隨便寫），發件人姓名，編碼*/
            msg.Subject = "請重設您的密碼";//郵件標題
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//郵件標題編碼
            msg.Body = $@"
                            <tbody style='font-family: 'microsoft jhenghei', sans-serif;'>
                              <table style='width: 580px; min-width: 580px; margin: 20px auto; background-color: #eee; padding-bottom: 20px;'>
                                <tr>
                                    <td>
                                        <img src='https://app.flashimail.com/rest/images/5d8108c8e4b0f9c17e91fab7.jpg' alt='昶興自行車'>
                                    </td>
                                </tr>
                                <tr>
                                    <td style='line-height: 2; padding: 10px 38px 30px 38px;'>
                                        <h1 style='color: #3d5f7f; letter-spacing: 1px; margin: 0; font-size: 26px'>重設您的密碼 </h1>
                                        <p style='letter-spacing: 1px; color: #000; margin: 0;font-size: 16px'><strong>您好,</strong></p>
                                        <p style='letter-spacing: 1px; color: #000; margin: 0; font-size: 13px; margin-bottom: 25px; '>您的重設密碼為下，帳號為您的員工編號，請在5分鐘內重新登入:</p>
                                        <p style='letter-spacing: 1px; margin: 0; margin-bottom: 30px; font-size: 16px'><strong>{hashPassword}</strong></p>
                                        <p style='letter-spacing: 1px; margin: 0; color: #aaa;' font-size: 13px>如果這不是您的帳戶，請忽略這封信，感謝您。</p>
                                    </ td>
                                </ tr>
                                </ table>
                            </ tbody> "; //郵件內容
            msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼
                                                         //msg.Attachments.Add(new Attachment(@"D:\test2.docx"));  //附件
            msg.IsBodyHtml = true;//是否是HTML郵件
                                  //msg.Priority = MailPriority.High;//郵件優先級

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("msit123erp@gmail.com", "oymgctceybtlgcyo"); //這裡要填正確的帳號跟密碼
            client.Host = "smtp.gmail.com"; //設定smtp Server
            client.Port = 587; //設定Port
            client.EnableSsl = true; //gmail預設開啟驗證
            try
            {
                client.Send(msg); //寄出信件
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            client.Dispose();
            msg.Dispose();
            return true;
        }
    }
}