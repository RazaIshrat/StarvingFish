using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class MediumFish : Fish
    {
        public MediumFish(Size s, int score, Player p) : base(s, score, p)
        {
            do
            {
                if (XPosition < 0)
                {
                    xSpeed = SplashKit.Rnd(0, 20) % 2 + 1;
                }
                else if (XPosition > 1200)
                {
                    xSpeed = SplashKit.Rnd(-20, 0) % 2 - 1;
                }
                ySpeed = SplashKit.Rnd(-20, 20) % 2;
            } while ((xSpeed == 0 && ySpeed == 0));
            if (xSpeed < 0)
            {
                bitmap = new Bitmap("fish3", "mediumleft.png");
            }
            else
            {
                bitmap = new Bitmap("fish4", "mediumright.png");
            }
        }
        //This method is responsible for the movement of the fish
        public override void Movement()
        {
            XPosition += xSpeed;
            YPosition += ySpeed;
        }
        //This method will check if the player is small in size. If the player is and the positions overlap  and the player is not invincible, it will return outcome Eat 
        //otherwise if the position overlap and the size is not small, the fish will get eaten, returning outcome Eaten and removed from the list, as well as add a score to the player's points
        //otherwise it will return outcome nothing
        public override Outcome EatPlayer()
        {
            if (XPosition + 120 > (Player.X) && YPosition + 90 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y) && Player.Size == Size.Small && !Player.Invincible)
            {
                return Outcome.Eat;
            }
            else if (XPosition + 120 > (Player.X) && YPosition + 90 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y) && Player.Size != Size.Small)
            {
                Player.Points = Player.Points + Score;
                SplashKit.PlaySoundEffect("eatmedium");
                return Outcome.Eaten;
            }
            else { return Outcome.Nothing; }
        }
        //If the fish overlaps with another fish that has a size of small, it will return true and remove the other fish from the list of fishes
        //Otherwise it will return false
        public override bool EatFish(Fish f)
        {
            if (f.size == Size.Small && (f.XPosition + 40) > (XPosition) && (f.XPosition + 40) < (XPosition + 120) && (f.YPosition + 30) < (YPosition + 90) && (f.YPosition + 30) > (YPosition))
            {
                return true;
            }
            else { return false; }
        }
    }
}