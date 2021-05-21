namespace Platformer.Animation
{
    /// <summary>
    /// Class that reproduce an animation one time
    /// </summary>
    public class OneShotAnimation : SpriteAnimator
    {
        /// <summary>
        /// Variable that checks if reproduce the animation
        /// </summary>
        public bool animationPlaying = false;

        /// <summary>
        /// Method that checks if animationPlaying is true and if that is the case, reproduce the animation
        /// </summary>
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

