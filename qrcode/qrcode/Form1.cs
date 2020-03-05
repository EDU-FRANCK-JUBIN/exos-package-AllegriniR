using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using QRCoder;

namespace qrcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QRCodeGenerator qrCodeGerGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGerGenerator.CreateQrCode("toto", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeBitmap = qrCode.GetGraphic(100, "#000000", "#FFFFFF");
            pictureBox1.Image = qrCodeBitmap;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfWriter writer = new PdfWriter("toto");
            PdfDocument pdfDocument = new PdfDocument(writer);
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            document.Add(new Paragraph("Hello world!"));
            document.Close();
        }
    }
}
