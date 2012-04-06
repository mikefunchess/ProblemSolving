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
            Move_ex.Hide();
            Move_enter.Hide();
            move_button.Hide();
            Turn_pick.Hide();
            Player_first.Hide();
            Comp_first.Hide();

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
            Red_choice.Dispose();
            Green_choice.Dispose();
            color_pick.Dispose();
            Turn_pick.Show();
            Player_first.Show();
            Comp_first.Show();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //pictureBox8.ImageLocation 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //48, 40 are the starting coordinates of a1.
            //add 48 to each in order to move to the next square.
            //MessageBox.Show(Move_enter.Text);
            string move = Move_enter.Text;
            char index = move[0];
            int i = 40 + (48 * (index - 'a'));
            int j = (int)Char.GetNumericValue(move[1]);
            j = j * 48;
            index = move[2];
            int k = 40 + (48 * (index - 'a'));
            int l = (int)Char.GetNumericValue(move[3]);
            l = l * 48;
            Point check = new Point (j, i);
            
            MessageBox.Show("Moving "+move);
            if(Green1.Location == check )
            {
                Green1.Location = new Point(l, k);
            }
            else if (Green2.Location == check)
            {
                Green2.Location = new Point(l, k);
            }
            else if (Green3.Location == check)
            {
                Green3.Location = new Point(l, k);
            }
            else if (Green4.Location == check)
            {
                Green4.Location = new Point(l, k);
            }
            else if (Green5.Location == check)
            {
                Green5.Location = new Point(l, k);
            }
            else if (Green6.Location == check)
            {
                Green6.Location = new Point(l, k);
            }
            else if (Green7.Location == check)
            {
                Green7.Location = new Point(l, k);
            }
            else if (Red1.Location == check)
            {
                Red1.Location = new Point(l, k);
            }
            else if (Red2.Location == check)
            {
                Red2.Location = new Point(l, k);
            }
            else if (Red3.Location == check)
            {
                Red3.Location = new Point(l, k);
            }
            else if (Red4.Location == check)
            {
                Red4.Location = new Point(l, k);
            }
            else if (Red5.Location == check)
            {
                Red5.Location = new Point(l, k);
            }
            else if (Red6.Location == check)
            {
                Red6.Location = new Point(l, k);
            }
            else if (Red7.Location == check)
            {
                Red7.Location = new Point(l, k);
            }
            //move[0]
            /*
             * 
             * 
             * 
             * 
             * ***********************************************************************************/
        }

        private void move_enter_TextChanged(object sender, EventArgs e)
        {
            //move text box
            //string move = Move_enter.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Turn_pick_Click(object sender, EventArgs e)
        {
            Turn_pick.Dispose();
            Player_first.Dispose();
            Comp_first.Dispose();
            Move_ex.Show();
            Move_enter.Show();
            move_button.Show();
        }
    }
}