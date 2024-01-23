using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {

        int xPlayer = 0, oPlayer = 0, drawsPoints = 0, rounds = 0;
        bool turn = true, game_end = false;
        string[] text = new string[9];

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && game_end == false)
            {

                if (turn)
                {
                    btn.Text = "X";
                    text[buttonIndex] = btn.Text;
                    rounds++;
                    turn = !turn;
                    Check(1);
                }
                else
                {
                    btn.Text = "O";
                    text[buttonIndex] = btn.Text;
                    rounds++;
                    turn = !turn;
                    Check(2);
                }

            }
        }

        void Winner(int playerWin)
        {
            game_end = true;
            if(playerWin == 1)
            {
                xPlayer++;
                xScore.Text = Convert.ToString(xPlayer);
                MessageBox.Show("Player X won!");
                turn = true;
            }
            else
            {
                oPlayer++;
                oScore.Text = Convert.ToString(oPlayer);
                MessageBox.Show("Player O won!");
                turn = false;
            }
        }

        void Check(int CheckPlayer)
        {
            string suport = "";

            if (CheckPlayer == 1)
            {
                suport = "X";
            }
            else
            {
                suport = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if(suport == text[horizontal])
                {
                    if(text[horizontal] == text[horizontal + 1] && text[horizontal] == text[horizontal + 2])
                    {
                        Winner(CheckPlayer);
                        return;
                    }
                }
            }

            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suport == text[vertical])
                {
                    if (text[vertical] == text[vertical + 3] && text[vertical] == text[vertical + 6])
                    {
                        Winner(CheckPlayer);
                        return;
                    }
                }
            }

            if (text[0] == suport)
            {
                if (text[0] == text[4] && text[0] == text[8])
                {
                    Winner(CheckPlayer);
                    return;
                }
            }

            if (text[2] == suport)
            {
                if (text[0] == text[4] && text[2] == text[6])
                {
                    Winner(CheckPlayer);
                    return;
                }
            }

            if(rounds == 9 && game_end == false)
            {
                drawsPoints++;
                Draws.Text = Convert.ToString(drawsPoints);
                MessageBox.Show("Draw!");
                game_end = true;
                return;
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";


            rounds = 0;
            game_end = false;
            for (int i = 0; i < 9; i++)
            {
                text[i] = "";
            }
        }
    }
}
