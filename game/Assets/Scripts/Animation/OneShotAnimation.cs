namespace Platformer.Animation
{
    public class OneShotAnimation : SpriteAnimator
    {
        public bool animationPlaying = false;

        protected override void Update()
        {
            if (animationPlaying)
            {
                UpdateSprite();
                if(spriteIndex + 1 == spriteSet.Length)
                {
                    animationPlaying = false;
                }
            }
            else
            {
                spriteIndex = 0;
            }
        }
    }
}

