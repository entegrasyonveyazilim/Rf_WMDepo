using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace KoctasWM_Project
{
    [DesignTimeVisible(true)]
    class PictureButton : Control
    {
        Image backgroundImage, pressedImage;
        bool pressed = false;
        public Image BackgroundImage
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                this.backgroundImage = value;
            }
        }
        public Image PressedImage
        {
            get
            {
                return this.pressedImage;
            }
            set
            {
                this.pressedImage = value;
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate(); // ekranýn tekrar paint olmasý için
            base.OnMouseDown (e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp (e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bmp = null;
            int x = -1, y = -1; //pressed ve unpressed durumlarýnda resim ve text'in farklý konumlandýrýlmasý için kullanýlan deðiþkenler
            float fx = 0f, fy = 0f;
            SizeF size = e.Graphics.MeasureString(this.Text, this.Font);
            if (this.pressed)
            {
                if (this.pressedImage != null)
                {
                    bmp = new Bitmap(this.pressedImage);
                }
                else if (this.backgroundImage != null)
                {
                    bmp = new Bitmap(this.backgroundImage);
                }
                x = y = -3;
                fx = (this.ClientSize.Width - size.Width + 4) / 2;
                fy = (this.ClientSize.Height - size.Height + 4) / 2;
            }
            else 
            {
                if (this.backgroundImage != null)
                {
                    bmp = new Bitmap(this.backgroundImage);
                }
                x = y = -1;
                fx = (this.ClientSize.Width - size.Width) / 2;
                fy = (this.ClientSize.Height - size.Height) / 2;
            }
            if (bmp != null)
            {
                ImageAttributes attrib = new ImageAttributes();
                Color color = GetTransparentColor(bmp);
                attrib.SetColorKey(color, color);                
                //e.Graphics.DrawImage(this.backgroundImage, 0, 0);
                e.Graphics.DrawImage(bmp, ClientRectangle, x, y, ClientSize.Width, ClientSize.Height, GraphicsUnit.Pixel, attrib);
            }
            
            if (this.Text.Length > 0)
            {
                e.Graphics.DrawString(this.Text,
                    this.Font,
                    new SolidBrush(this.ForeColor), fx,  fy);
            }

            //Border çizgilerinin buttona basýlmýþ gibi görünmesi için pressed ve unpressed durumlarýnda farklý renklerde çizilmesi
            if (pressed)
            {
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 1, 1, 1, this.ClientSize.Height + 1);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 1, 1, this.ClientSize.Width + 1, 1);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 0, 0, 0, this.ClientSize.Height);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 0, 0, this.ClientSize.Width, 0);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 0, this.ClientSize.Height - 1, this.ClientSize.Width, this.ClientSize.Height - 1);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), this.ClientSize.Width - 1, 0, this.ClientSize.Width - 1, this.ClientSize.Height);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 1, this.ClientSize.Height - 2, this.ClientSize.Width - 2, this.ClientSize.Height - 2);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), this.ClientSize.Width - 2, 1, this.ClientSize.Width - 2, this.ClientSize.Height - 2);
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Yellow), 1, 1, 1, this.ClientSize.Height + 1);
                e.Graphics.DrawLine(new Pen(Color.Yellow), 1, 1, this.ClientSize.Width + 1, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, this.ClientSize.Height);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, this.ClientSize.Width, 0);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), 0, this.ClientSize.Height - 1, this.ClientSize.Width, this.ClientSize.Height - 1);
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), this.ClientSize.Width - 1, 0, this.ClientSize.Width - 1, this.ClientSize.Height);
                e.Graphics.DrawLine(new Pen(Color.Yellow), 1, this.ClientSize.Height - 2, this.ClientSize.Width - 2, this.ClientSize.Height - 2);
                e.Graphics.DrawLine(new Pen(Color.Yellow), this.ClientSize.Width - 2, 1, this.ClientSize.Width - 2, this.ClientSize.Height - 2);
            }
            //e.Graphics.DrawRectangle(new Pen(Color.Silver), -1, -1, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            
            base.OnPaint(e);
        }
        
        private Color GetTransparentColor(Bitmap image)
        {
            return image.GetPixel(0, 0);
        }
    }
}
