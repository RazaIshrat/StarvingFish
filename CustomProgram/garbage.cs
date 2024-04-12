using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Garbage : Fish
    {
        public Garbage(Size s, int score, Player p) : base(s, score, p)
        {
            do
            {
                xSpeed = SplashKit.Rnd(-20, 20) % 2;
                ySpeed = SplashKit.Rnd(0, 20) % 3;
            } while ((xSpeed == 0 && ySpeed == 0));
            int temp = SplashKit.Rnd(0, 2);
            if (temp == 0)
            {
                bitmap = new Bitmap("can", "garbage1.png");
            }
            else if (temp == 1)
            {
                bitmap = new Bitmap("bottle", "garbage2.png");
            }
            else if (temp == 2)
            {
                bitmap = new Bitmap("bag", "garbage3.png");
            }
        }
        //This method is responsible for the movement of the garbage
        public override void Movement()
        {
            XPosition += xSpeed;
            YPosition += ySpeed;
        }
        //This method will check if the position of the player overlaps and if it does, it will return an outcome of eaten as well as subtract the score from the player's points
        //Otherwise, it will return an outcome of nothing
        public override Outcome EatPlayer()
        {
            if (XPosition + 100 > (Player.X) && YPosition + 70 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y))
            {
                Player.Points = Player.Points - Score;
                SplashKit.PlaySoundEffect("yuk");
                return Outcome.Eaten;
            }
            else { return Outcome.Nothing; }
        }
        //Since this is garbage and it cannot eat the fishes, it will always return false
        public override bool EatFish(Fish f)
        {
            return false;
        }
    }
}