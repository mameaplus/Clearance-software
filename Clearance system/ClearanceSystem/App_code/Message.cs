using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace ClearanceSystem
{
    public class Message
    {
        public void SendEmail(MailMessage msg) {
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("kiotServer@gmail.com", "<123456789>");
          //  smtp.Send(msg);
            //Send to admin with sms or posting on webs
     
        }
        public void SendSms(DataItem di)
        {
            // ../../SendTousers/smsin/MsgGetList.txt

            using (System.IO.StreamWriter ofile = new System.IO.StreamWriter("E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt", true))
            {
                ofile.WriteLine(di.str1+" "+ di.str2);
            }
        }
        public void SendPageNotification() { }
    }
}