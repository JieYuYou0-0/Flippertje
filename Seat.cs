using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class Seat
    {
        private char _seatSym;
        private bool _isChosen;

        internal char SeatSym
        {
            get // A visual representation of the state of a seat
            {
                return this._seatSym;
            }
            set // A visual representation of the state of a seat being changed
            {
                _seatSym = value;
            }
        }

        internal bool IsChosen
        {
            get // Has the seat been chosen?
            {
                return this._isChosen;
            }
            set // Seat gets chosen
            {
                _isChosen = value;
            }
        }

        internal Seat()
        {

            this._seatSym = ' ';
            this._isChosen = false;
        }
    }
}
