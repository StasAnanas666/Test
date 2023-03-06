using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //создание области рисования
            Graphics g = e.Graphics;
            //выбор областью всего окна формы, для размещения изображения на всей форме
            Rectangle windowRect = this.ClientRectangle;
            //метод FromFile позволяет указать файл изображения, не только формата bmp
            Image image = Image.FromFile("bg.png");
            g.DrawImage(image, windowRect);
            
            //инструмент карандаш/ручка, цвет синий, размер 5
            Pen pen = new Pen(Brushes.Blue, 5);
            //тип рисования пунктирная линия
            pen.DashStyle = DashStyle.Solid;
            //рисуем созданным карандашом овал
            //отступ слева экрана 50, отступ сверху 100, ширина и высота 100
            g.DrawEllipse(pen, 50, 100, 100, 100);
            pen = new Pen(Brushes.Black, 5);
            g.DrawEllipse(pen, 160, 100, 100, 100);
            pen = new Pen(Brushes.Red, 5);
            g.DrawEllipse(pen, 270, 100, 100, 100);
            pen = new Pen(Brushes.Yellow, 5);
            g.DrawEllipse(pen, 105, 160, 100, 100);
            pen = new Pen(Brushes.Green, 5);
            g.DrawEllipse(pen, 215, 160, 100, 100);
            

            //создаем 3 прямоугольника
            //отступ слева экрана 400, отступ сверху 50, ширина 200, высота 50
            Rectangle rect = new Rectangle(500, 50, 500, 100);
            Rectangle rect2 = new Rectangle(500, 200, 500, 100);
            Rectangle rect3 = new Rectangle(500, 350, 500, 100);
            //создаем градиентную кисть для заливки прямоугольника
            //параметры: объект заливки, 1 цвет градиента, 2 цвет, угол заливки
            LinearGradientBrush lgBrush = new LinearGradientBrush(rect, Color.DarkOrange, Color.LightSkyBlue, 45f);
            //заливаем прямоугольник градиентной кистью
            g.FillRectangle(lgBrush, rect);
            //узорная кисть. первый параметр задает узор, второй цвет
            HatchBrush hBrush = new HatchBrush(HatchStyle.Plaid, Color.IndianRed);
            g.FillRectangle(hBrush, rect2);
            //создаем текстурную кисть, содержимым которой является изображение в формате .bmp
            //изображения размещать в ..\source\repos\projectName\projectName\bin\Debug
            TextureBrush tBrush = new TextureBrush(new Bitmap("img.bmp"));
            g.FillRectangle(tBrush, rect3);

            //создаем текстовый объект. задаем название шрифта (берутся из папки C:\Windows\Fonts), размер шрифта в пикселях, стиль написания(берется из enum FontStyle)
            Font font = new Font("Comic Sans MS", 40, FontStyle.Bold | FontStyle.Italic);
            //отрисовываем строку. задаем текст, объект для рисования, кисть и цвет, отступ слева и сверху
            g.DrawString("Hello world!", font, Brushes.LimeGreen, 50, 300);

            //очищаем область рисования
            g.Dispose();
        }
    }
}
