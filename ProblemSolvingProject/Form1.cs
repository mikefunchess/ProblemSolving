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
        int[] columns = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] rows = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

        Player player;
        Computer computer;
        Logic logic;
     //private System.Drawing.Bitmap myBitmap; // Our Bitmap declaration
        
        public Form1()
        {
            InitializeComponent();

            this.player = new Player();
            this.player.BoardPiece = BoardPiece.Red;

            this.computer = new Computer();
            this.computer.BoardPiece = BoardPiece.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.pictureBox1.Location = new Point(0, 0);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //radioButton1.Dispose();

            pick_side_label.Dispose();
            Red_choice.Dispose();
            Green_choice.Dispose();
            color_pick.Dispose();

            pick_turn_label.Show();
            Turn_pick.Show();
            Player_first.Show();
            Comp_first.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //48, 40 are the starting coordinates of a1.
            //add 48 to each in order to move to the next square.
            //MessageBox.Show(Move_enter.Text);
            string move = Move_enter.Text;

            GamePiece start = new GamePiece();
            start.Row = (move[0] - 'a');
            start.Col = (int)Char.GetNumericValue(move[1]);

            GamePiece end = new GamePiece();
            end.Row = move[2] - 'a';
            end.Col = (int)Char.GetNumericValue(move[3]);

            Move playerMove = new Move(start, end);

            if (logic.MakePlayerMove(playerMove))
            {
                MakeMove(playerMove);
            }
            else
            {
                MessageBox.Show("Invalid Move");
            }

            Move_enter.Text = "";
        }

        private void move_enter_TextChanged(object sender, EventArgs e)
        {
            //move text box
            //string move = Move_enter.Text;
        }

        private void Turn_pick_Click_1(object sender, EventArgs e)
        {
            pick_turn_label.Dispose();
            Turn_pick.Dispose();
            Player_first.Dispose();
            Comp_first.Dispose();

            Move_ex.Show();
            Move_enter.Show();
            move_button.Show();

            logic = new Logic(this.player, this.computer);

            if (this.computer.IsTurn)
            {
                Move logicMove = logic.GetNextMove();
            }
        }

        public void MakeMove(Move move)
        {
            GamePiece start = move.MoveFrom;
            GamePiece end = move.MoveTo;

            int i = 40 + (48 * start.Row);
            int j = start.Col;
            j = j * 48;
            int k = 40 + (48 * end.Row);
            int l = end.Col;
            l = l * 48;
            Point check = new Point(j, i);

            if (Green1.Location == check)
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
        }

        private void Green_choice_CheckedChanged(object sender, EventArgs e)
        {
            this.player.BoardPiece = BoardPiece.Green;
            this.computer.BoardPiece = BoardPiece.Red;
        }

        private void Red_choice_CheckedChanged(object sender, EventArgs e)
        {
            this.player.BoardPiece = BoardPiece.Red;
            this.computer.BoardPiece = BoardPiece.Green;
        }

        private void Player_first_CheckedChanged(object sender, EventArgs e)
        {
            this.player.IsTurn = true;
            this.computer.IsTurn = false;
        }

        private void Comp_first_CheckedChanged(object sender, EventArgs e)
        {
            this.player.IsTurn = false;
            this.computer.IsTurn = true;
        }
    }
}