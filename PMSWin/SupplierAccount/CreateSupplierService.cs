using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.SupplierAccount
{
    internal class CreateSupplierService
    {
        internal static bool SendEmailToSup(string hashPassword, string emailToBlaBla, out string BSendLetterState)
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
                                        <p style='letter-spacing: 1px; color: #000; margin: 0;font-size: 16px'><strong>親愛的供應商 您好,</strong></p>
                                        <p style='letter-spacing: 1px; color: #000; margin: 0; font-size: 13px; margin-bottom: 25px; '>您的重設密碼為下，忘記帳號請電洽聯絡人，請在15分鐘內重新登入:</p>
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
            }
            client.Dispose();
            msg.Dispose();
            return true;
        }
    }
}