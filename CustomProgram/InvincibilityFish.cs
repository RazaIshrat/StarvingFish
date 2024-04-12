using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class InvincibilityFish : Fish
    {
        public InvincibilityFish(Size s, int score, Player p) : base(s, score, p)
        {
            do
            {
                if (XPosition < 0) { xSpeed = 7; }
                else if (XPosition > 1200) { xSpeed = -7; }
                ySpeed = SplashKit.Rnd(-20, 20) % 3;
            } while ((xSpeed == 0 && ySpeed == 0));
            if (xSpeed < 0)
            {
                bitmap = new Bitmap("fish9", "invincibilityleft.png");
            }
            else
            {
                bitmap = new Bitmap("fish10", "invincibilityright.png");
            }
        }
        //This method is responsible for the movement of the fish
        public override void Movement()
        {
            XPosition += xSpeed;
            YPosition += ySpeed;
        }
        //This method will check if the position of the player overlaps and if it does, it will return an outcome of eaten as well as add a score to the player's points
        //The player's invincibility method will also get called.
        //Otherwise, it will return an outcome of nothing
        public override Outcome EatPlayer()
        {
            if (XPosition + 80 > (Player.X) && YPosition + 60 > (Player.Y) && XPosition < (Player.X) && YPosition < (Player.Y))
            {
                Player.Points = Player.Points + Score;
                SplashKit.PlaySoundEffect("invincibility");
                SplashKit.PlaySoundEffect("eatsmall");
                Player.invincible_timer.Reset();
                Player.Invincibility();
                return Outcome.Eaten;
            }
            else { return Outcome.Nothing; }
        }
        //Since this fish cannot eat the larger fishes, it will always return false
        public override bool EatFish(Fish f)
        {
            return false;
        }
    }
}