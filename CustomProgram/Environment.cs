using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Environment
    {
        private Player _player;
        private List<Fish> _fishes;
        private SplashKitSDK.Timer _spawntimer;
        private SplashKitSDK.Timer _invinciblefishtimer;
        private SplashKitSDK.Timer _speedfishtimer;
        private SplashKitSDK.Timer _sharktimer;
        private Difficulty _difficulty;
        private SplashKitSDK.Timer _gametimer;
        private SplashKitSDK.Timer _garbagetimer;
        private double timer;
        private bool win;
        private bool lose;
        public Environment(Difficulty d)
        {
            _player = new Player();
            _fishes = new List<Fish>();
            _spawntimer = new SplashKitSDK.Timer("timer");
            _invinciblefishtimer = new SplashKitSDK.Timer("invinciblefishtimer");
            _speedfishtimer = new SplashKitSDK.Timer("speedfishtimer");
            _sharktimer = new SplashKitSDK.Timer("sharktimer");
            _spawntimer.Start();
            _invinciblefishtimer.Start();
            _speedfishtimer.Start();
            _sharktimer.Start();
            _difficulty = d;
            _gametimer = new SplashKitSDK.Timer("gametimer");
            _gametimer.Start();
            _garbagetimer = new SplashKitSDK.Timer("garbagetimer");
            _garbagetimer.Start();
            timer = 800;
            win = false;
            lose = false;
        }
        public List<Fish> Fish
        {
            get { return _fishes; }
        }
        public void AddFish(Fish f)
        {
            _fishes.Add(f);
        }
        public void RemoveFish(Fish f)
        {
            _fishes.Remove(f);
        }
        public Difficulty difficulty
        {
            set { _difficulty = value; }
        }
        public Player player
        {
            get { return _player; }
        }
        public void Draw()
        {
            _player.Draw();
            foreach (Fish f in _fishes)
            {
                f.Draw();
            }
            if (_player.Size == Size.Small)
            {
                SplashKit.DrawBitmap("topsmall.png", 0, 0);
            }
            else if (_player.Size == Size.Medium)
            {
                SplashKit.DrawBitmap("topmedium.png", 0, 0);
            }
            else if (_player.Size == Size.Large)
            {
                SplashKit.DrawBitmap("toplarge.png", 0, 0);
            }
            SplashKit.DrawText("Lives: " + _player.Lives, Color.White, "RAVIE.TTF", 24, 1100, 50);
            if (_player.Invincible)
            {
                SplashKit.DrawText("Invincible!", Color.White, "RAVIE.TTF", 24, 650, 50);
            }
            if (_player.Speed)
            {
                SplashKit.DrawText("Speed UP!", Color.White, "RAVIE.TTF", 24, 870, 50);
            }
            if (_difficulty == Difficulty.Hard)
            {
                SplashKit.DrawText("Time: " + timer, Color.White, "RAVIE.TTF", 24, 1100, 10);
            }
            SplashKit.FillRectangle(Color.Yellow, 199, 50, _player.Points / 30, 26);
            SplashKit.DrawBitmap("scoretracker.png", 0, 0);
        }
        public void Movement()
        {
            _player.Movement();
            foreach (Fish f in _fishes)
            {
                f.Movement();
            }
        }
        public void AddFishes()
        {
            if (_invinciblefishtimer.Ticks / 1000 % 300 == 2)
            {
                if (SplashKit.Rnd(0, 30) == 2)
                {
                    InvincibilityFish f = new InvincibilityFish(Size.Small, 350, _player);
                    AddFish(f);
                }
                _invinciblefishtimer.Reset();
            }
            if (_speedfishtimer.Ticks / 1000 % 300 == 1)
            {
                if (SplashKit.Rnd(0, 20) == 2)
                {
                    SpeedFish f = new SpeedFish(Size.Small, 350, _player);
                    AddFish(f);
                }
                _speedfishtimer.Reset();
            }
            if (_difficulty == Difficulty.Easy)
            {
                if (((_spawntimer.Ticks / 1000) % 300) == 1 && _fishes.Count() < 15)
                {
                    int fish = SplashKit.Rnd(1, 100) % 3;
                    if (fish == 0)
                    {
                        SmallFish f = new SmallFish(Size.Small, 150, _player);
                        AddFish(f);
                    }
                    else if (fish == 1)
                    {
                        MediumFish f = new MediumFish(Size.Medium, 250, _player);
                        AddFish(f);
                    }
                    else if (fish == 2 && _player.Size != Size.Small)
                    {
                        LargeFish f = new LargeFish(Size.Large, 400, _player);
                        AddFish(f);
                    }
                    _spawntimer.Reset();
                }

                if (_sharktimer.Ticks > 16000 && _player.Size == Size.Large)
                {
                    Shark f = new Shark(Size.Shark, 0, _player);
                    AddFish(f);
                    SplashKit.PlaySoundEffect("sharkspawn");
                    _sharktimer.Reset();
                }
                if (_garbagetimer.Ticks > 7000)
                {
                    Garbage f = new Garbage(Size.Garbage, 100, _player);
                    AddFish(f);
                    _garbagetimer.Reset();
                }

            }
            else if (_difficulty == Difficulty.Medium)
            {
                if (((_spawntimer.Ticks / 1000) % 300) == 1 && _fishes.Count() < 16)
                {
                    int fish = SplashKit.Rnd(1, 100) % 3;
                    if (fish == 0)
                    {
                        SmallFish f = new SmallFish(Size.Small, 150, _player);
                        AddFish(f);
                    }
                    else if (fish == 1)
                    {
                        MediumFish f = new MediumFish(Size.Medium, 250, _player);
                        AddFish(f);
                    }
                    else if (fish == 2)
                    {
                        LargeFish f = new LargeFish(Size.Large, 350, _player);
                        AddFish(f);
                    }
                    _spawntimer.Reset();
                }

                if (_sharktimer.Ticks > 16000 && _player.Size != Size.Small)
                {
                    Shark f = new Shark(Size.Shark, 0, _player);
                    AddFish(f);
                    SplashKit.PlaySoundEffect("sharkspawn");
                    _sharktimer.Reset();
                }
                if (_garbagetimer.Ticks > 6500)
                {
                    Garbage f = new Garbage(Size.Garbage, 150, _player);
                    AddFish(f);
                    _garbagetimer.Reset();
                }

            }
            else if (_difficulty == Difficulty.Hard)
            {
                if (((_spawntimer.Ticks / 1000) % 300) == 1 && _fishes.Count() < 17)
                {
                    int fish = SplashKit.Rnd(1, 100) % 3;
                    if (fish == 0)
                    {
                        SmallFish f = new SmallFish(Size.Small, 100, _player);
                        AddFish(f);
                    }
                    else if (fish == 1)
                    {
                        MediumFish f = new MediumFish(Size.Medium, 200, _player);
                        AddFish(f);
                    }
                    else if (fish == 2)
                    {
                        LargeFish f = new LargeFish(Size.Large, 300, _player);
                        AddFish(f);
                    }
                    _spawntimer.Reset();
                }

                if (_sharktimer.Ticks > 15000 && _player.Size != Size.Small)
                {
                    Shark f = new Shark(Size.Shark, 0, _player);
                    AddFish(f);
                    SplashKit.PlaySoundEffect("sharkspawn");
                    _sharktimer.Reset();
                }
                if (_garbagetimer.Ticks > 6000)
                {
                    Garbage f = new Garbage(Size.Garbage, 200, _player);
                    AddFish(f);
                    _garbagetimer.Reset();
                }
            }

        }
        public void Remove()
        {
            foreach (Fish f in _fishes)
            {
                if (f.XPosition < -100 || f.XPosition > 1320 || f.YPosition < -120 || f.YPosition > 800)
                {
                    RemoveFish(f);
                    break;
                }
                if (f.EatPlayer() == Outcome.Eaten)
                {
                    RemoveFish(f);
                    break;
                }
                else if (f.EatPlayer() == Outcome.Eat)
                {
                    _player.Reset();
                }
                if (FishCollision(f))
                {
                    break;
                }

            }
        }
        public bool FishCollision(Fish f)
        {
            foreach (Fish i in _fishes)
            {
                if (f.EatFish(i))
                {
                    RemoveFish(i);
                    return true;
                }
            }
            return false;

        }
        public bool Checks()
        {
            _player.Grow();
            _player.Invincibility();
            _player.SpeedUp();
            if (_difficulty == Difficulty.Hard && !_player.CheckWin() && _player.Lives >= 0)
            {
                timer = 800 - _gametimer.Ticks / 1000;
            }

            if (_player.CheckWin())
            {
                SplashKit.DrawText("YOU WIN!", Color.White, "RAVIE.TTF", 120, 280, 200);
                SplashKit.DrawText("Press ENTER to return to menu", Color.White, "RAVIE.TTF", 36, 270, 400);
                if (!win)
                    SplashKit.PlaySoundEffect("win");
                win = true;
                _sharktimer.Reset();
                _garbagetimer.Reset();
                return true;

            }
            else if (_player.Lives < 0 || timer <= 0)
            {
                SplashKit.DrawText("YOU LOSE!", Color.White, "RAVIE.TTF", 120, 270, 200);
                SplashKit.DrawText("Press ENTER to return to menu", Color.White, "RAVIE.TTF", 36, 270, 400);
                if (!lose)
                    SplashKit.PlaySoundEffect("lose");
                lose = true;
                _sharktimer.Reset();
                _garbagetimer.Reset();
                return true;
            }
            else
                return false;
        }
        public void Restart()
        {
            foreach (Fish f in _fishes)
            {
                RemoveFish(f);
                break;
            }
            _spawntimer.Reset();
            _invinciblefishtimer.Reset();
            _speedfishtimer.Reset();
            _sharktimer.Reset();
            _gametimer.Reset();
            _garbagetimer.Reset();
            timer = 800;
            win = false;
            lose = false;
        }
    }
}