using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSnakeTest
{
    public partial class SnakeGame : Form
    {
        public SnakeGame()
        {
            InitializeComponent();
        }

        private int boxAmount = 19;
        private PictureBox[][] boxesList;
        private Snake snake;
        private Color boxBackgroundColor;
        private Color snakeColor;
        private Color foodColor;
        private Position foodPosition;
        private bool isStarted;
        

        private void SnakeGame_Load(object sender, EventArgs e)
        {

            int screenSize = this.ClientSize.Height;
            int offsetX = (this.Height - ClientRectangle.Height) / 2;
            int offsetY = (this.Width - ClientRectangle.Width) / 2;//sets the variables for
            //screen size and offset so it centers the boxes


            int imageSize = screenSize / (boxAmount + 1);//makes boxes little bit smaller
            //so you can see where they are
            int imageLocation = screenSize / (boxAmount);//since the boxes are smaller
            //this gets the right positions where they should be

            boxesList = new PictureBox[boxAmount][];

            for(int i = 0; i < boxAmount; i++)
            {

                boxesList[i] = new PictureBox[boxAmount];

                for(int j = 0; j < boxAmount; j++)
                {

                    //creates a picture with the size, position and color red
                    //when the game starts the color will go from red to gray to indicate it has started
                    boxesList[i][j] = new PictureBox();
                    boxesList[i][j].Location = new Point(imageLocation*i+offsetX,imageLocation*j+offsetY);
                    boxesList[i][j].Size = new Size(imageSize,imageSize);
                    boxesList[i][j].BackColor = Color.Red;
                    boxesList[i][j].Show();
                    Controls.Add(boxesList[i][j]);


                }

            }

            //creates the snake and sets colors for food, backgrund and the snake
            //so you can customise it and or probabbly set images
            //so you can have a cool looking snake
            // //to set images just instead of setting the color for the snake set an image

            isStarted = false;

            snake = new Snake(boxAmount);
            snakeColor = Color.Green;
            foodColor = Color.Blue;
            boxBackgroundColor = Color.Gray;
            boxesList[boxAmount / 2][boxAmount / 2].BackColor = snakeColor;
            foodPosition = new Position(0, 0);
            spawnFood();

        }

        private void SnakeGame_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {

                case (Keys.Space)://if the game didnt start, start it
                    if (isStarted)
                    {
                        isStarted = false;
                     moveTimer.Stop();
                    }
                    else
                    {
                        isStarted = true;
                        moveTimer.Start();
                    }
                    
                    break;

                case (Keys.W)://if the game started buffer up
                    if (isStarted)
                    snake.setWay(Snake.Way.Up);
                    break;

                case (Keys.S):// -//-
                    if (isStarted)
                    snake.setWay(Snake.Way.Down);
                    break;

                case (Keys.D):// -//-
                    if (isStarted)
                    snake.setWay(Snake.Way.Right);
                    break;

                case (Keys.A):// -//-
                    if (isStarted)
                    snake.setWay(Snake.Way.Left);
                    break;

            }


        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {

            if (errorLab.Text == "1")
                errorLab.Text = "2";
            else errorLab.Text = "1";

            //checks if it eats and moves it
            if (snake.getNextHeadPosition().Equals(foodPosition))
            {

                snake.move(true);
                /*MessageBox.Show(s+"and the head is now at "+snake.getSnakeBody().Last().ToString()+"\n" +
                    " and the next move is at "+snake.getNextHeadPosition().ToString());*/
                spawnFood();

            }
            else
            {
                if (!snake.move())
                {
                    moveTimer.Stop();
                    isStarted = false;
                   // MessageBox.Show("EAting one self and head is at "+snake.getNextHeadPosition().ToString());
                }
            }

            refreshBoxes();//then redraws it
        }

        private void refreshBoxes()
        {
            //removes all colors form the boxes
            for (int i = 0; i < boxesList.Count(); i++)
                for (int j = 0; j < boxesList[i].Count(); j++)
                    boxesList[i][j].BackColor = boxBackgroundColor;

            //and then sets the snakes body again
            foreach (Position p in snake.getSnakeBody())
                boxesList[p.getX()][p.getY()].BackColor = snakeColor;

            boxesList[foodPosition.getX()][foodPosition.getY()].BackColor = foodColor;

        }

        private void spawnFood()
        {

            Random random = new Random();

            for (int i = 0; i < boxesList.Count(); i++)
            {

                for (int j = 0; j < boxesList[i].Count(); j++)
                {
                    if (boxesList[foodPosition.getX()][foodPosition.getY()].BackColor != snakeColor)
                        break;

                    //if it didnt find an empty place end the game
                    if (i == j  && i== boxesList.Count()-1)
                    {
                        //moveTimer.Stop();
                        return;
                    }

                }

                

            }
           

            //randomize untill it finds a place to spawn food
            while (true)
            {

                foodPosition.setNewPosition(random.Next(boxAmount),random.Next(boxAmount));
                // if it finds a place it can spawn food
                //it spawns the food there
                if (boxesList[foodPosition.getX()][foodPosition.getY()].BackColor != snakeColor)
                    return;
                


            }

        }

    }
}
