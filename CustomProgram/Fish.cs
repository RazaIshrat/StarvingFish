using System;
using SplashKitSDK;

#nullable disable

namespace CustomProgram
{
    public abstract class Fish
    {
        private double _posX;
        private double _posY;
        private double _xSpeed;
        private double _ySpeed;
        private Size _size;
        private int _score;
        private Player _player;
        private Bitmap _bitmap;

        public Fish(Size s, int score, Player p)
        {
            if (s == Size.Garbage)
            {
                _posX = SplashKit.Rnd(100, 1200);
                _posY = -105;
            }
            else
            {
                if (SplashKit.Rnd(0, 1200) > 600)
                {
                    _posX = 1300;
                }
                else
                {
                    _posX = -50;
                }
                _posY = SplashKit.Rnd(50, 700);
            }
            _size = s;
            _score = score;
            _player = p;
        }

        public abstract Outcome EatPlayer();

        //This method draws the fish
        public void Draw()
        {
            _bitmap.Draw(_posX, _posY);
        }

        public abstract void Movement();
        public abstract bool EatFish(Fish f);
        public double XPosition
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public double YPosition
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public Size size
        {
            get { return _size; }
        }
        public int Score
        {
            get { return _score; }
        }
        public Player Player
        {
            get { return _player; }
        }
        public Bitmap bitmap
        {
            set { _bitmap = value; }
        }
        public double xSpeed
        {
            get { return _xSpeed; }
            set { _xSpeed = value; }
        }
        public double ySpeed
        {
            get { return _ySpeed; }
            set { _ySpeed = value; }
        }
    }
}