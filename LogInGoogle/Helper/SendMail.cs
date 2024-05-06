using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using MailKit.Security;
using MimeKit;
using System.IO;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Web.Mail;

namespace LogInGoogle.Helper
{
    public static class SendMail
    {
            public static void SendEmail(string to, string subject, string body, string attachFile)
            {
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Thien Huynh", "huynhthienthe@gmail.com"));
                    message.To.Add(new MailboxAddress("Thân Mến", to));
                    message.Subject = subject;
              

                // Tạo phần văn bản và phần HTML
                var plainText = new TextPart("plain")
                    {
                        Text = body
                    };

                    var htmlText = new TextPart("html")
                    {
                        Text = body
                    };

                    // Xây dựng phần thân email với cả phần văn bản và phần HTML
                    var multipart = new Multipart("alternative");
                    multipart.Add(plainText);
                    multipart.Add(htmlText);

                    // Thiết lập phần thân email
                    message.Body = multipart;

                    // Nếu có tệp đính kèm, thêm vào email
                    if (!string.IsNullOrEmpty(attachFile))
                    {
                        var attachment = new MimePart("application", "octet-stream")
                        {
                            Content = new MimeContent(File.OpenRead(attachFile), ContentEncoding.Default),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = Path.GetFileName(attachFile)
                        };
                        message.Body = new Multipart("mixed")
                    {
                        multipart,
                        attachment
                    };
                    }

                    // Kết nối và gửi email
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("huynhthienthe@gmail.com", ""); // email password
                    client.Send(message);
                        client.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
    }
}
    


    //public static void SendEmail(string to, string subject, string body, string attachFile)
    //{
    //    try
    //    { 
    //        var message = new MimeMessage();
    //        message.From.Add(new MailboxAddress("Thien Huynh", "huynhthienthe@gmail.com")); 
    //        message.To.Add(new MailboxAddress("Thân Mến", to));
    //        message.Body = new TextPart(body)
    //        {
    //            Text = body

    //        };

    //        var builder = new BodyBuilder();
    //        builder.HtmlBody = body;

    //        if (!string.IsNullOrEmpty(attachFile))
    //        {
    //            builder.Attachments.Add(attachFile);
    //        }

    //        message.Body = builder.ToMessageBody();

    //        using (var client = new MailKit.Net.Smtp.SmtpClient())
    //        {
    //            client.Connect("smtp.gmail.com", 587, false); 
    //            client.Authenticate("huynhthienthe@gmail.com", "ctdb xiao ittb loru");
    //            client.Send(message);
    //            client.Disconnect(true);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.ToString());
    //    }
    //}
