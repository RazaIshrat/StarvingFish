using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class LargeFish : Fish
    {
        public LargeFish(Size s, int score, Player p) : base(s, score, p)
        {
            do
            {
                if (XPosition < 0) { xSpeed = SplashKit.Rnd(0, 20) % 1 + 1; }
                else if (XPosition > 1200) { xSpeed = SplashKit.Rnd(-20, 0) % 1 - 1; }
                ySpeed = SplashKit.Rnd(-20, 20) % 2;
            } while ((xSpeed == 0 && ySpeed == 0));
            if (xSpeed < 0)
            {
                bitmap = new Bitmap("fish5", "largeleft.png");
            }
            else
            {
                bitmap = new Bitmap("fish6", "largeright.png");
            }
        }
        //This method is responsible for the movement of the fish
        //When the fish is close to the player, it will move towards the player
        public override void Movement()
        {
            double distanceX = Player.X - (XPosition + 80);
            double distanceY = Player.Y - (YPosition + 60);
            double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            if (distance < 200)
            {
                xSpeed = 1.1 * Math.Round(distanceX / distance, 2);
                ySpeed = 1.1 * Math.Round(distanceY / distance, 2);
                if (xSpeed < 0)
                {
                    bitmap = new Bitmap("fish5", "largeleft.png");
                }
                else
                {
                    bitmap = new Bitmap("fish6", "largeright.png");
                }
            }
            XPosition += xSpeed;
            YPosition += ySpeed;
        }
        //If the size of the player is not large and positions overlap  and the player is not invincible, it will return an outcome of eat which will then call the reset method of the player
        //If the size of the player is large and positions overlap, it will return an outcome of Eaten which will then remove the fish from the list of fishes as well as add a score to the player's points
        //otherwise it will return outcome Nothing
        public override Outcome EatPlayer()
        {
            if (XPosition + 160 > (Player.X) && YPosition + 120 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y) && Player.Size != Size.Large && !Player.Invincible)
            {
                return Outcome.Eat;
            }
            else if (XPosition + 160 > (Player.X) && YPosition + 120 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y) && Player.Size == Size.Large)
            {
                Player.Points = Player.Points + Score;
                SplashKit.PlaySoundEffect("eatlarge");
                return Outcome.Eaten;
            }
            else { return Outcome.Nothing; }
        }

        //If the size of the fish is small or medium, it will return a value of true which will then remove the fish from the list of fishes
        //otherwise it will return false
        public override bool EatFish(Fish f)
        {
            if (f.size == Size.Small && (f.XPosition + 40) > (XPosition) && (f.XPosition + 40) < (XPosition + 160) && (f.YPosition + 30) < (YPosition + 120) && (f.YPosition + 30) > (YPosition))
            {
                return true;
            }
            else if (f.size == Size.Medium && (f.XPosition + 60) > (XPosition) && (f.XPosition + 60) < (XPosition + 160) && (f.YPosition + 45) < (YPosition + 120) && (f.YPosition + 45) > (YPosition))
            {
                return true;
            }
            else { return false; }
        }
    }
}