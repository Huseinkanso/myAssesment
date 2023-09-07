using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAssesment
{
    internal class Rover
    {
        private int X;
        private int Y;
        private Plateau plateau;
        private char Direction;
        public Rover(int x, int y, char direction,Plateau plateau)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.plateau = plateau;
        }


        // check direction type and on the direction we know where to go
        public void GoToLeft()
        {
            switch (this.Direction)
            {
                case 'N':
                    this.Direction = 'W';
                    break;
                case 'W':
                    this.Direction = 'S';
                    break;
                case 'S':
                    this.Direction = 'E';
                    break;
                case 'E':
                    this.Direction = 'N';
                    break;

            }
        }
        public void GoToRight()
        {
            switch (this.Direction)
            {
                case 'N':
                    this.Direction = 'E';
                    break;
                case 'E':
                    this.Direction = 'S';
                    break;
                case 'S':
                    this.Direction = 'W';
                    break;
                case 'W':
                    this.Direction = 'N';
                    break;

            }
        }
        // here we check direction and height and position to see if we ae moving forward or getting back (in horizontal or vertical)
        public void MoveRoverTo()
        {
            if(this.Direction=='N' && this.Y<plateau.height)
            {
                this.Y += 1;
            }else if(this.Direction=='E' && this.X<plateau.width)
            {
                this.X += 1;
            }else if(this.Direction=='S' && this.Y>0)
            {
                this.Y -= 1;
            }else if(this.Direction=='W' && this.X>0)
            {
                this.X -= 1;
            }

        }
        // display info for rover
        public string RoverInfo()
        {
            return $"position:{this.X},{this.Y} , Direction: {this.Direction}";
        }
    }
}
