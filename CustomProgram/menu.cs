using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Menu
    {
        private double mouseX;
        private double mouseY;
        private bool clickedStart;
        private bool clickedInstruction;
        public Menu()
        {
            mouseX = 0;
            mouseY = 0;
            clickedStart = false;
            clickedInstruction = false;
        }
        public Difficulty Draw()
        {
            mouseX = SplashKit.MouseX();
            mouseY = SplashKit.MouseY();
            if (!clickedStart && !clickedInstruction)
                SplashKit.DrawBitmap("menu.png", 0, 0);
            else
                SplashKit.DrawBitmap("menuhover.png", 0, 0);

            if (mouseX > 140 && mouseX < 650 && mouseY > 300 && mouseY < 410)
            {
                SplashKit.DrawText("START", Color.DimGray, "RAVIE.TTF", 50, 260, 335);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    SplashKit.PlaySoundEffect("select");
                    clickedStart = true;
                    clickedInstruction = false;
                }
            }
            else
                SplashKit.DrawText("START", Color.White, "RAVIE.TTF", 50, 260, 335);

            if (mouseX > 140 && mouseX < 650 && mouseY > 435 && mouseY < 545)
            {
                SplashKit.DrawText("INSTRUCTIONS", Color.DimGray, "RAVIE.TTF", 50, 156, 470);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    SplashKit.PlaySoundEffect("select");
                    clickedInstruction = true;
                    clickedStart = false;
                }
            }
            else
                SplashKit.DrawText("INSTRUCTIONS", Color.White, "RAVIE.TTF", 50, 156, 470);

            if (mouseX > 140 && mouseX < 650 && mouseY > 560 && mouseY < 670)
            {
                SplashKit.DrawText("QUIT", Color.DimGray, "RAVIE.TTF", 50, 290, 593);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    SplashKit.PlaySoundEffect("select");
                    clickedInstruction = false;
                    clickedStart = false;
                    return Difficulty.Quit;
                }
            }
            else
                SplashKit.DrawText("QUIT", Color.White, "RAVIE.TTF", 50, 290, 593);

            if (clickedStart && !clickedInstruction)
            {
                if (mouseX > 700 && mouseX < 1200 && mouseY > 310 && mouseY < 440)
                {
                    SplashKit.DrawText("Easy", Color.DimGray, "RAVIE.TTF", 50, 770, 340);
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        SplashKit.PlaySoundEffect("select");
                        return Difficulty.Easy;
                    }
                }
                else
                    SplashKit.DrawText("Easy", Color.White, "RAVIE.TTF", 50, 770, 340);
                if (mouseX > 700 && mouseX < 1200 && mouseY > 450 && mouseY < 570)
                {
                    SplashKit.DrawText("Medium", Color.DimGray, "RAVIE.TTF", 50, 750, 460);
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        SplashKit.PlaySoundEffect("select");
                        return Difficulty.Medium;
                    }
                }
                else
                    SplashKit.DrawText("Medium", Color.White, "RAVIE.TTF", 50, 750, 460);
                if (mouseX > 700 && mouseX < 1200 && mouseY > 580 && mouseY < 750)
                {
                    SplashKit.DrawText("Hard", Color.DimGray, "RAVIE.TTF", 50, 770, 590);
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        SplashKit.PlaySoundEffect("select");
                        return Difficulty.Hard;
                    }
                }
                else
                    SplashKit.DrawText("Hard", Color.White, "RAVIE.TTF", 50, 770, 590);
            }
            if (clickedInstruction && !clickedStart)
            {
                SplashKit.DrawText("Use W,A,S,D or arrow keys to move.", Color.White, "RAVIE.TTF", 16, 720, 320);
                SplashKit.DrawText("Your goal is to eat enough fishes to", Color.White, "RAVIE.TTF", 16, 720, 380);
                SplashKit.DrawText("grow in the seas. What you can eat is", Color.White, "RAVIE.TTF", 16, 720, 440);
                SplashKit.DrawText("shown at the top. As you grow, more", Color.White, "RAVIE.TTF", 16, 720, 500);
                SplashKit.DrawText("fishes enter the feeding space. Some", Color.White, "RAVIE.TTF", 16, 720, 560);
                SplashKit.DrawText("fishes may give you powerups.", Color.White, "RAVIE.TTF", 16, 720, 620);
            }
            return Difficulty.None;
        }
    }
}