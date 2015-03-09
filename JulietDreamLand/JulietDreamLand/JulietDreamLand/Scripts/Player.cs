using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JulietDreamLand.Animation;

namespace JulietDreamLand.Scripts
{
    class Player
    {
        //public Texture2D PlayerTexture;
        public Vector2 Position;
        public bool Active;
        public AnimationController PlayerAnimation;
        public int Width
        {
            get { return PlayerAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return PlayerAnimation.FrameHeight; }
        }

        public void Initialize(AnimationController animation, Vector2 position)
        {
            PlayerAnimation = animation;
            //PlayerTexture = texture;
            Position = position;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);
            //spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
