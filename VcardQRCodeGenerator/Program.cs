using QRCoder;
using static QRCoder.PayloadGenerator;


string file = @"C:\Users\User\Downloads\myVcard.png";

VcardQRCodeGenerator.QRCodeHelper.GenerateToFile(file);

Console.WriteLine($"VCard wurde gesichert bei {file}");