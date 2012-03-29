using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //private System.Drawing.Bitmap myBitmap; // Our Bitmap declaration
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label12.Hide();
            textBox1.Hide();
            button2.Hide();

            //this.pictureBox1.Location = new Point(0, 0);
            
            /*Graphics graphicsObj;
            myBitmap = new Bitmap(this.ClientRectangle.Width,
               this.ClientRectangle.Height,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            graphicsObj = Graphics.FromImage(myBitmap);

            graphicsObj.Dispose();*/
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //radioButton1.Dispose();
            radioButton2.Dispose();
            radioButton3.Dispose();
            button1.Dispose();
            label12.Show();
            textBox1.Show();
            button2.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //pictureBox8.ImageLocation 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //48, 40 are the starting coordinates of a1.
            //add 48 to each in order to move to the next square.

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //move text box
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}