using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class Player
    {
        private double _x;
        private double _y;
        private int _h;
        private int _w;
        private int _lives;
        private int _points;
        private Size _size;
        private Bitmap _bitmap;
        private SplashKitSDK.Timer _invincibilitytimer;
        private SplashKitSDK.Timer _speedtimer;
        private bool _invincible;
        private bool _speed;
        private bool playGrow1 = false;
        private bool playGrow2 = false;
        public Player()
        {
            _x = 100;
            _y = 100;
            _h = 50;
            _w = 38;
            _lives = 3;
            _points = 0;
            _size = Size.Small;
            _bitmap = new Bitmap("player", "playerleftsmall.png");
            _invincibilitytimer = new SplashKitSDK.Timer("invincibility");
            _speedtimer = new SplashKitSDK.Timer("speedup");
            _invincible = false;
            _speed = false;
            _invincibilitytimer.Start();
            _speedtimer.Start();
        }
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        public SplashKitSDK.Timer invincible_timer
        {
            get { return _invincibilitytimer; }
        }
        public SplashKitSDK.Timer speed_timer
        {
            get { return _speedtimer; }
        }
        public Size Size
        {
            get { return _size; }
        }
        public double X
        {
            get { return _x + _w; }
            set { _x = value; }
        }
        public double Y
        {
            get { return _y + _h; }
            set { _y = value; }
        }
        public bool Invincible
        {
            get { return _invincible; }
        }
        public bool Speed
        {
            get { return _speed; }
        }
        public void Draw()
        {
            _bitmap.Draw(_x, _y);
        }
        public Bitmap bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        public void Movement()
        {
            if ((SplashKit.KeyDown(KeyCode.WKey) || SplashKit.KeyDown(KeyCode.UpKey)) && _y >= 90)
            {
                if (!_speed)
                {
                    _y -= 4;
                }
                else { _y -= 7; }
            }
            if ((SplashKit.KeyDown(KeyCode.SKey) || SplashKit.KeyDown(KeyCode.DownKey)) && _y <= 650)
            {
                if (!_speed)
                {
                    _y += 4;
                }
                else { _y += 7; }
            }
            if ((SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.LeftKey)) && _x >= -10)
            {
                if (_size == Size.Small)
                {
                    _bitmap = new Bitmap("player", "playerleftsmall.png");
                }
                else if (_size == Size.Medium)
                {
                    _bitmap = new Bitmap("player3", "playerleftmedium.png");
                }
                else if (_size >= Size.Large)
                {
                    _bitmap = new Bitmap("player5", "playerleftlarge.png");
                }
                if (!_speed)
                {
                    _x -= 4;
                }
                else { _x -= 7; }
            }
            if ((SplashKit.KeyDown(KeyCode.DKey) || SplashKit.KeyDown(KeyCode.RightKey)) && _x <= 1200)
            {
                if (_size == Size.Small)
                {
                    _bitmap = new Bitmap("player2", "playerrightsmall.png");
                }
                else if (_size == Size.Medium)
                {
                    _bitmap = new Bitmap("player4", "playerrightmedium.png");
                }
                else if (_size >= Size.Large)
                {
                    _bitmap = new Bitmap("player6", "playerrightlarge.png");
                }
                if (!_speed)
                {
                    _x += 4;
                }
                else { _x += 7; }
            }
            if (SplashKit.KeyDown(KeyCode.BackspaceKey))
            {
                _points += 500;
            }
            if (SplashKit.KeyDown(KeyCode.Num1Key))
            {
                _points = 0;
            }
            if (SplashKit.KeyDown(KeyCode.Num2Key))
            {
                _points = 1200;
            }
            if (SplashKit.KeyDown(KeyCode.Num3Key))
            {
                _points = 6000;
            }

        }
        public bool CheckWin()
        {
            if (_points >= 12000)
            {
                _points = 12500;
                _invincible = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            _lives--;
            _x = 600;
            _y = 110;
            if (Lives > 0)
            {
                SplashKit.PlaySoundEffect("loselife");
            }
            if (_size == Size.Small)
            {
                _points = 0;
            }
            else if (_size == Size.Medium)
            {
                _points = 1200;
            }
            else if (_size == Size.Large)
            {
                _points = 6000;
            }
            _invincibilitytimer.Reset();
            Invincibility();
            if (_lives < 0)
            {
                _x = -200;
                _y = -200;
                _invincible = true;
            }
        }
        public void Grow()
        {
            if (_points < 1200)
            {
                _w = 50;
                _h = 38;
                _size = Size.Small;
            }
            if (_points >= 1200)
            {
                if (!playGrow1)
                    SplashKit.PlaySoundEffect("grow");
                playGrow1 = true;
                _w = 70;
                _h = 53;
                _size = Size.Medium;
            }
            if (_points >= 6000)
            {
                if (!playGrow2)
                    SplashKit.PlaySoundEffect("grow");
                playGrow2 = true;
                _w = 90;
                _h = 77;
                _size = Size.Large;
            }
        }
        public void Invincibility()
        {
            if (_invincibilitytimer.Ticks < 3000)
            {
                _invincible = true;
            }
            else
            {
                _invincible = false;
            }
        }
        public void SpeedUp()
        {
            if (_speedtimer.Ticks < 4000)
            {
                _speed = true;
            }
            else
            {
                _speed = false;
            }
        }
        public void Restart()
        {
            _lives = 3;
            _points = 0;
            _size = Size.Small;
            _x = 100;
            _y = 100;
            _bitmap = new Bitmap("player", "playerleftsmall.png");
            playGrow1 = false;
            playGrow2 = false;
        }
    }
}