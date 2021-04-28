using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Animation
{
    public class OneTimeAnimator : SpriteAnimator
    {
        public bool animationReproducton = false;

        private void Update()
        {
            if (animationReproducton)
            {
                UpdateSprite();
                if(spriteIndex + 1 == spriteSet.Length)
                {
                    animationReproducton = false;
                }
            }
            else
            {
                spriteIndex = 0;
            }
        }
    }
}

