using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin
{
    class Util
    {
        public static void CreateSession() {
            Session = new Dictionary<string, object>();
        }
        private static Dictionary<string, object> Session { get; set; }
        /// <summary>
        /// 儲存暫存內容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSessionValue(string key, object value)
        {
            if (Session == null)
            {
                Session = new Dictionary<string, object>();
            }
            if (Session.ContainsKey(key))
            {
                //重覆的Key會被取代
                Session.Remove(key);
            }
            Session.Add(key, value);
        }
        /// <summary>
        /// 取得暫存內容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSessionValue(string key)
        {
            if (Session.ContainsKey(key))
            {
                object value = Session[key];
                return value;
            }
            return null;
        }
        /// <summary>
        /// 取得暫存內容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSessionValueThenRemove(string key)
        {
            if (Session.ContainsKey(key))
            {
                object value = Session[key];
                Session.Remove(key);
                return value;
            }
            return null;
        }

        /// <summary>
        /// 取得雜湊值
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetHash(string txt)
        {
            byte[] bytesTxt = Encoding.Unicode.GetBytes(txt);
            SHA256Managed algorithm = new SHA256Managed();
            bytesTxt = algorithm.ComputeHash(bytesTxt);
            string hashTxt = Convert.ToBase64String(bytesTxt);
            return hashTxt;
        }

        /// <summary>
        /// 產生驗證碼
        /// 格式：4碼數字字母混合內容 (1A2B)
        /// </summary>
        /// <param name="oldToken">先前產生的驗證碼</param>
        /// <returns>驗證碼</returns>
        public static string BuildAuthToken(string oldToken = "")
        {
            //產生數字List
            List<char> chars = new List<char>();
            for (int i = 48; i <= 57; i++)
            {
                chars.Add(Convert.ToChar(i));
            }
            //產生字母List
            for (int i = 65; i <= 90; i++)
            {
                chars.Add(Convert.ToChar(i));
            }
            //先前已產生驗證碼則需排除相同值
            if (!string.IsNullOrEmpty(oldToken))
            {
                //比對字元
                foreach (char chr in oldToken)
                {
                    chars.Remove(chr);
                }
            }
            //產生隨機驗證碼
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                char chr = chars[rnd.Next(chars.Count)];
                sb.Append(chr);
                chars.Remove(chr);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 發信
        /// </summary>
        /// <param name="mailList">收件者清單</param>
        /// <param name="fromDisplayName">寄件者顯示名稱</param>
        /// <param name="subject">主旨</param>
        /// <param name="body">本文內容</param>
        /// <returns>發信結果 true/false 成功/失敗</returns>
        public static bool SendMail(List<string> mailList, string fromDisplayName, string subject, string body)
        {
            return SendMail(string.Join(",", mailList.ToArray()), fromDisplayName, subject, body);
        }
        /// <summary>
        /// 發信
        /// </summary>
        /// <param name="mailList">收件者清單</param>
        /// <param name="fromDisplayName">寄件者顯示名稱</param>
        /// <param name="subject">主旨</param>
        /// <param name="body">本文內容</param>
        /// <returns>發信結果 true/false 成功/失敗</returns>
        public static bool SendMail(string mailList, string fromDisplayName, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
            msg.To.Add(mailList);
            msg.From = new MailAddress($"{Properties.Settings.Default.SendMailAddress}", fromDisplayName, System.Text.Encoding.UTF8);
            //郵件標題
            msg.Subject = subject;
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = body;
            msg.IsBodyHtml = true;
            //郵件內容編碼
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //郵件優先級
            msg.Priority = MailPriority.Normal;
            //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port
            #region 其它 Host
            /*
             *  outlook.com smtp.live.com port:25
             *  yahoo smtp.mail.yahoo.com.tw port:465
            */
            #endregion
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //設定你的帳號密碼
            smtp.Credentials = new System.Net.NetworkCredential($"{Properties.Settings.Default.SendMailAddress}", $"{Properties.Settings.Default.SendMailPassword}");
            //Gmial 的 smtp 使用 SSL
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
