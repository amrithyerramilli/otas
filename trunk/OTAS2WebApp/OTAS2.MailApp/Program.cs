using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Repository;

namespace OTAS2.MailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository students = new StudentRepository();
            ValidSRepository valids = new ValidSRepository();
            var student = (from i in students.GetAllStudents()
                           select i).ToList();
            var valid = (from i in valids.GetAllValidS()
                         select i).ToList();
            var studpass = (from i in student
                            join j in valid on i.USN equals j.USN
                            where i.email != null
                            select new StudentPassword { USN = j.USN, Password = j.PassGen, Email = i.email.ToLower() }).ToList();
            Attachment picture = new Attachment("Appraisal.gif");
            //i = 1350;
            for (int i = 2250; i < studpass.Count; i++)
            {
                MailAddress to;
                if (studpass[i].Email != "")
                {
                    Console.WriteLine("Mail To");
                    to = new MailAddress(studpass[i].Email);
                }
                else
                {
                    continue;
                }

                Console.WriteLine("Mail From");
                MailAddress from = new MailAddress("otas@rnsit.ac.in");

                MailMessage mail = new MailMessage(from, to);

                Console.WriteLine("Subject");
                mail.Subject = "RNSIT Appraisal";

                Console.WriteLine("Your Message");
                mail.Body = "ನಮಸ್ಕಾರ,\n Your Password for teachers appraisal is : " + studpass[i].Password + " , please note it down and arrive on May 2nd/May 3rd.\n Pass on this link to who ever hasn't provided us with their details the first time around https://docs.google.com/forms/d/1LSIUQKa9bgGx7E3TlkUhktkXP80rAPtcnRdu6ltIIrY/viewform \n Best,\n Aikya Dev Team";
                mail.Attachments.Add(picture);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential(
                    "anirudh.kkw@gmail.com", "wa3002-g1");
                smtp.EnableSsl = true;
                Console.WriteLine("Sending email...");
                smtp.Send(mail);
                Console.WriteLine("" + i);
            }
        }
    }
}
