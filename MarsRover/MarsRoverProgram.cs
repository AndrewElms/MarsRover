using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class MarsRoverProgram
    {

        int _GridX;
        int _GridY;
        int _CurrentX;
        int _CurrentY;
        char _CurrentDirection; // ToDo: Enum N,S,E,W ??

        public void InitialiseGrid(string GridSize)
        {
            try
            {                
                string[] s = GridSize.Split(',');
                int.TryParse(s[0],out _GridX);
                int.TryParse(s[1],out _GridY);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InitialiseStartLocation(string StartLocation)
        {
            try
            {
                string[] s = StartLocation.Split(',');
                int.TryParse(s[0], out _CurrentX);
                int.TryParse(s[1], out _CurrentY);
                _CurrentDirection = s[2].ToUpper().First(); // ToDo: Char or enum??
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CalculateEndPosition(string MovementPath)
        {
            foreach (char c in MovementPath.ToUpper())
            {

                switch (c)
                {
                    case 'M':
                        {
                            MoveForward();
                            break;
                        }
                    case 'L':
                    case 'R':
                        {
                            CalculateNewDirection(c);
                            break;
                        }
                }
            }
            return string.Concat(_CurrentX.ToString(), " ", _CurrentY.ToString(), " ", _CurrentDirection.ToString());
        }

        private void MoveForward()
        {
            //Assume that the square directly North from (x, y) is (x, y+1).
            // ToDo: Check we havent fallen off the grid!
            switch(_CurrentDirection)
            {
                case 'N':
                    {
                        _CurrentY = _CurrentY + 1;
                        break;
                    }
                case 'S':
                    {
                        _CurrentY = _CurrentY - 1;
                        break;
                    }
                case 'E':
                    {
                        _CurrentX = _CurrentX + 1;
                        break;
                    }
                case 'W':
                    {
                        _CurrentX = _CurrentX - 1;
                        break;
                    }

            }
        }

        private void CalculateNewDirection(char RotatationDirection)
        {

            switch (_CurrentDirection)
            {
                case 'N':
                    {
                        if (RotatationDirection == 'L')
                            _CurrentDirection = 'W';
                        else
                            _CurrentDirection = 'E';
                        break;
                    }
                case 'W':
                    {
                        if (RotatationDirection == 'L')
                            _CurrentDirection = 'S';
                        else
                            _CurrentDirection = 'N';
                        break;
                    }
                case 'S':
                    {
                        if (RotatationDirection == 'L')
                            _CurrentDirection = 'E';
                        else
                            _CurrentDirection = 'W';
                        break;
                    }
                case 'E':
                    {
                        if (RotatationDirection == 'L')
                            _CurrentDirection = 'N';
                        else
                            _CurrentDirection = 'S';
                        break;
                    }
            }
        }


    }
}
