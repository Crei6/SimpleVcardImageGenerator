using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace VcardQRCodeGenerator
{
    public static class QRCodeHelper
    {
        public static void GenerateToFile(string filePath)
        {
            Console.WriteLine("Gib deinen Vornamen ein und drück [Enter]");
            string firstName = Console.ReadLine();
            Console.WriteLine("Gib deinen Nachnamen ein und drück [Enter]");
            string lastName = Console.ReadLine();
            Console.WriteLine("Gib deine Telefonnummer ein und drück [Enter]");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Gib deine Emailadresse ein und drück [Enter]");
            string email = Console.ReadLine();


            ContactData generator = new ContactData(ContactData.ContactOutputType.VCard3, firstName, lastName, null, phoneNumber, null, null, email);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);
            

            File.WriteAllBytes(filePath, ImageToByte(qrCodeAsBitmap));
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
