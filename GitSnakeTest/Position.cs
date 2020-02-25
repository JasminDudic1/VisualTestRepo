using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSnakeTest
{
    class Position
    {

        //basic class for remembering a 2d point in space
        //it has the most used methods

        private int x;
        private int y;

        public Position(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void setNewPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position getPosition()
        {
            return this;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void addY(int add)
        {
            y += add;
        }
        public void addX(int add)
        {
            x += add;
        }

        public void setY(int sety)
        {
            y = sety;
        }
        public void setX(int setx)
        {
            x = setx;
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;
            return position != null &&
                   x == position.x &&
                   y == position.y;
        }

        public override string ToString()
        {
            return x + ":" + y;
        }
    }
}
