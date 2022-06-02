using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class Seat
    {
        private int _seatNum;
        private char[][] SeatBoard;
        internal int AvailableSpaces;

        internal int SeatNum
        {
            get // A visual representation of the state of a seat
            {
                return this._seatNum;
            }
            set // A visual representation of the state of a seat being changed
            {
                _seatNum = value;
            }
        }

        internal Seat()
        {
            // Creation seats
            this.SeatBoard = new char[5][];
            for (int i = 0; i < this.SeatBoard.Length; i++)
            {
                this.SeatBoard[i] = new char[5];
            }
            // Place holders on the board (empty spaces)
            for (int i = 0; i < this.SeatBoard.Length; i++)
            {
                for (int j = 0; j < this.SeatBoard[i].Length; j++)
                {
                    this.SeatBoard[i][j] = ' ';
                }
            }
            this.AvailableSpaces = 25;
        }

        internal void showSeatState(char[][] seatBoard)
        {
            string state = $"[{this.SeatBoard[0][0]}] [{this.SeatBoard[0][1]}] [{this.SeatBoard[0][2]}] [{this.SeatBoard[0][3]}] [{this.SeatBoard[0][4]}]" +
                                  $"[{this.SeatBoard[1][0]}] [{this.SeatBoard[1][1]}] [{this.SeatBoard[1][2]}] [{this.SeatBoard[1][3]}] [{this.SeatBoard[1][4]}]" +
                                  $"[{this.SeatBoard[2][0]}] [{this.SeatBoard[2][1]}] [{this.SeatBoard[2][2]}] [{this.SeatBoard[2][3]}] [{this.SeatBoard[2][4]}] " +
                                  $"[{this.SeatBoard[3][0]}] [{this.SeatBoard[3][1]}] [{this.SeatBoard[3][2]}] [{this.SeatBoard[3][3]}] [{this.SeatBoard[3][4]}] " +
                                  $"[{this.SeatBoard[4][0]}] [{this.SeatBoard[4][1]}] [{this.SeatBoard[4][2]}] [{this.SeatBoard[4][3]}] [{this.SeatBoard[4][4]}] ";
            Console.WriteLine(state);
        }
    }
}
