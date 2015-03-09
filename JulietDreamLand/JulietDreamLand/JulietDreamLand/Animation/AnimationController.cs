using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JulietDreamLand.Animation
{
    class AnimationController
    {
        private Texture2D _spriteSheet;
        private float _scale;
        private int _elapsedTime;
        private int _frameTime;
        private int _frameCount;
        private int _currentFrame;
        private Color _color;
        private Rectangle _sourceRect = new Rectangle();
        Rectangle _destinationRect = new Rectangle();
        public int FrameWidth;
        public int FrameHeight;
        public bool Active;
        public bool Looping;
        public Vector2 Position;

        public void Initialize(Texture2D texture, Vector2 position, 
            int frameWidth, int frameHeight, int frameCount, 
            int frameTime, Color color, float scale, bool looping )
        {
            _color = color;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            _frameCount = frameTime;
            _frameTime = frameTime;
            _scale = scale;

            Looping = looping;
            Position = position;
            _spriteSheet = texture;

            _elapsedTime = 0;
            _currentFrame = 0;

            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (Active == false)
                return;
            _elapsedTime += (int) gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTime > _frameTime)
            {
                _currentFrame++;
                if (_currentFrame == _frameCount)
                {
                    _currentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }

                _elapsedTime = 0;
            }

            _sourceRect = new Rectangle(0, _currentFrame * FrameWidth, FrameWidth, FrameHeight);
            _destinationRect = new Rectangle(
                (int)Position.X - (int)(FrameWidth * _scale) / 2,
                (int)Position.Y - (int)(FrameHeight * _scale) / 2,
                (int)(FrameWidth * _scale),
                (int)(FrameHeight * _scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(_spriteSheet, _destinationRect, _sourceRect, _color);
            }
        }

    }
}
