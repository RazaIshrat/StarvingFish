using System;
using SplashKitSDK;

namespace CustomProgram
{
    public enum Difficulty
    {
        Easy, Medium, Hard, None, Quit
    }
    public class Program
    {
        public static void Main()
        {
            Window game = new Window("Starving Fish", 1280, 720);


            SplashKit.LoadMusic("music", "background.flac");

            SplashKit.LoadSoundEffect("yuk", "Yuk.wav");
            SplashKit.LoadSoundEffect("win", "win.wav");
            SplashKit.LoadSoundEffect("grow", "grow.wav");
            SplashKit.LoadSoundEffect("lose", "lose.wav");
            SplashKit.LoadSoundEffect("select", "select.wav");
            SplashKit.LoadSoundEffect("speedup", "speedup.wav");
            SplashKit.LoadSoundEffect("loselife", "loselife.wav");
            SplashKit.LoadSoundEffect("eatsmall", "eatsmall.wav");
            SplashKit.LoadSoundEffect("eatmedium", "eatmedium.wav");
            SplashKit.LoadSoundEffect("eatlarge", "eatlarge.wav");
            SplashKit.LoadSoundEffect("sharkspawn", "sharkspawn.wav");
            SplashKit.LoadSoundEffect("invincibility", "invincible.wav");


            bool menu = true;
            bool playing = false;
            Difficulty d = Difficulty.None;

            Bitmap background = new Bitmap("backgroundmenu", "backgroundmenu.png");
            // if (menu)
            // {

            // }
            // else if (playing)
            // {

            // }

            Menu mainmenu = new Menu();
            Environment env = new Environment(d);
            SplashKit.PlayMusic("music", -1);
            do
            {
                SplashKit.ClearScreen();
                SplashKit.ProcessEvents();
                SplashKit.DrawBitmapOnWindow(game, background, 0, 0);
                if (menu)
                {
                    background = new Bitmap("backgroundmenu", "backgroundmenu.png");
                    env.Restart();
                    env.player.Restart();
                    d = mainmenu.Draw();
                    if (d == Difficulty.Easy)
                    {
                        env.difficulty = Difficulty.Easy;
                        menu = false;
                        playing = true;
                    }
                    else if (d == Difficulty.Medium)
                    {
                        env.difficulty = Difficulty.Medium;
                        menu = false;
                        playing = true;
                    }
                    else if (d == Difficulty.Hard)
                    {
                        env.difficulty = Difficulty.Hard;
                        menu = false;
                        playing = true;
                    }
                    else if (d == Difficulty.Quit)
                    {
                        menu = false;
                        playing = false;
                        game.Close();
                    }
                }
                if (playing)
                {
                    background = new Bitmap("background", "background.png");
                    env.Draw();
                    env.Movement();
                    env.AddFishes();
                    env.Remove();

                    if (env.Checks() && SplashKit.KeyDown(KeyCode.ReturnKey))
                    {
                        menu = true;
                        SplashKit.PlaySoundEffect("select");
                        d = Difficulty.None;
                        playing = false;
                    }
                }
                game.Refresh();
                SplashKit.Delay(16);
            }
            while (!SplashKit.WindowCloseRequested("Starving Fish"));
        }
    }
}
