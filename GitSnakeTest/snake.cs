using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSnakeTest
{
    class Snake
    {

        private List<Position> snakeBody;//snakes body, it is made as a list of its body parts
        //where the first one is its tail and the last one is its head
        //this is so when you move you just add the last one infront of the head
        //and then remove the last one, unless the snake ate

        private Way wayToMove;//this is the way the snake will move next
        private Way bufferedMove;//this is the buffered way she will use next

        private int boxAmount;

        public enum Way
        {
            Up,
            Down,
            Left,
            Right
        }

        public Snake(int boxAmount)
        {
            //spawns the snake in the middle since why not
            this.boxAmount = boxAmount;
            snakeBody = new List<Position>();
            snakeBody.Add(new Position(boxAmount / 2, boxAmount / 2));
            wayToMove = Way.Right;
            bufferedMove = wayToMove;
           
        }

        public void setWay(Way way)
        {

            //bufferedmove is used so you can not move back
            //if you didnt use it you could be movign right
            //and press up left and it would set move to up and then to left
            //since you can go up->left, but with buffered move
            //it remembers the way you were moving
            //and checks if it is the opposite of that way

            if ((this.wayToMove == Way.Left && way == Way.Right) ||
               (this.wayToMove == Way.Right && way == Way.Left) ||
               (this.wayToMove == Way.Up && way == Way.Down) ||
               (this.wayToMove == Way.Down && way == Way.Up)) return;
            //probably a better way to check this but whatever


            bufferedMove = way;//buffer the move
        }

        public bool move(bool isEating=false)
        {

            Position temp = getNextHeadPosition();
            wayToMove = bufferedMove;
            if (snakeBody.Contains(temp)) return false;//since the positions only have 2 variables you can easily check if it already exists
            //in the snakes body, and if the new position already exists the snake
            //ends up eating it self

            snakeBody.Add(temp);//adds the tail infront of the head
            if (!isEating) snakeBody.RemoveAt(0);//and removes it if its not eating

            return true;//for knowing if it ate it self

        }

        public List<Position> getSnakeBody()
        {
            return snakeBody;
        }

        public Position getNextHeadPosition()
        {
            //this is used to check if the snake will eat anything and for the snake to actually move


            //gets the tail since its the first one in the list
            Position temp = new Position(snakeBody.Last().getX(), snakeBody.Last().getY());
            Way tempWay=bufferedMove;
            switch (tempWay)
            {
                //checks if you are going offscreen in either way or direction
                case Way.Down:
                    if (snakeBody.Last().getY() == boxAmount - 1)
                        temp.setY(0);
                    else
                        temp.addY(+1);

                    break;

                case Way.Up:
                    if (snakeBody.Last().getY() == 0)
                        temp.setY(boxAmount - 1);
                    else
                        temp.addY(-1);

                    break;

                case Way.Left:
                    if (snakeBody.Last().getX() == 0)
                        temp.setX(boxAmount - 1);
                    else
                        temp.addX(-1);

                    break;

                case Way.Right:
                    if (snakeBody.Last().getX() == boxAmount - 1)
                        temp.setX(0);
                    else
                        temp.addX(+1);

                    break;
            }
            return temp;

        }


    }
}
