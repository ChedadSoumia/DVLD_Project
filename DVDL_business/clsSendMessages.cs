using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static DVDL_business.clsTestTypes;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_business
{
    public class clsSendMessages
    {

        public void Subscribe(clsTestAppointments testAppointment)
        {
            testAppointment.OnTestBooked += TestAppointment_OnTestBooked;
        }

        private void TestAppointment_OnTestBooked(object sender, TestAppointmentEventArgs e)
        {
            string Body = $"Hello {e.ApplicantName},\n\n" +
             $"Your test appointment has been successfully booked.\n\n" +
             $"Application ID: {e.ApplicationID}\n" +
             $"Test Type: {clsTestTypes.Find((clsTestTypes.enTestType)e.TestTypeID).TestTypeTitle}\n" +
             $"Date: {e.AppointmentDate:yyyy-MM-dd}\n" +
             $"Time: {e.AppointmentDate:HH:mm}\n\n" +
             $"Please arrive on time for your appointment.\n\n" +
             $"Thank you,\n" +
             $"DVLD Management System";

            SendEmail(e.ApplicantEmail, "Test Appointment date", Body);
        }

        public static bool SendEmail(string ToEmail, string EmailSubject,String EmailBody)
        {

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("chedadsoumia4@gmail.com");
                mail.To.Add(ToEmail);
                mail.Subject = EmailSubject;
                mail.Body = EmailBody;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("chedadsoumia4@gmail.com", "avch tzsv xtho xqxt");

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


     
    }
}
