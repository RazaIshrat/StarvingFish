using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Shark : Fish
    {
        private SplashKitSDK.Timer _sharkmovementtimer;
        public Shark(Size s, int score, Player p) : base(s, score, p)
        {
            do
            {
                if (XPosition < 0) { xSpeed = SplashKit.Rnd(0, 20) % 1 + 1; }
                else if (XPosition > 1200) { xSpeed = SplashKit.Rnd(-20, 0) % 1 - 1; }
                ySpeed = SplashKit.Rnd(-20, 20) % 2;
            } while ((xSpeed == 0 && ySpeed == 0));
            if (xSpeed < 0)
            {
                bitmap = new Bitmap("fish7", "sharkleft.png");
            }
            else
            {
                bitmap = new Bitmap("fish8", "sharkright.png");
            }
            _sharkmovementtimer = new SplashKitSDK.Timer("sharkmovementtimer");
            _sharkmovementtimer.Start();
        }

        //This method is responsible for the movement of the fish
        //For the first 7.5 seconds, the shark will track the player before moving off the screen
        public override void Movement()
        {
            if (_sharkmovementtimer.Ticks < 7500)
            {
                double distanceX = Player.X - (XPosition + 125);
                double distanceY = Player.Y - (YPosition + 65);
                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance > 4)
                {
                    xSpeed = 3 * Math.Round(distanceX / distance, 2);
                    ySpeed = 3 * Math.Round(distanceY / distance, 2);
                }
            }
            XPosition += xSpeed;
            YPosition += ySpeed;
            if (xSpeed < 0)
            {
                bitmap = new Bitmap("fish7", "sharkleft.png");
            }
            else
            {
                bitmap = new Bitmap("fish8", "sharkright.png");
            }
        }
        //This method will return an outcome of Eat if the player overlaps with the shark and the player is not invincible
        //Otherwise it will return an outcome of nothing
        public override Outcome EatPlayer()
        {
            if (XPosition + 250 > (Player.X) && YPosition + 130 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y) && !Player.Invincible)
            {
                return Outcome.Eat;
            }
            else { return Outcome.Nothing; }
        }
        //When another fish overlaps with the shark, it will return a value of true which will then remove the fish from the list
        public override bool EatFish(Fish f)
        {
            if (f.size == Size.Small && (f.XPosition + 40) > (XPosition) && (f.XPosition + 40) < (XPosition + 250) && (f.YPosition + 30) < (YPosition + 130) && (f.YPosition + 30) > (YPosition))
            {
                return true;
            }
            else if (f.size == Size.Medium && (f.XPosition + 60) > (XPosition) && (f.XPosition + 60) < (XPosition + 250) && (f.YPosition + 45) < (YPosition + 130) && (f.YPosition + 45) > (YPosition))
            {
                return true;
            }
            else if (f.size == Size.Large && (f.XPosition + 80) > XPosition && (f.XPosition + 80) < (XPosition + 250) && (f.YPosition + 60) < (YPosition + 130) && (f.YPosition + 60) > YPosition)
            {
                return true;
            }
            else { return false; }
        }
    }
}