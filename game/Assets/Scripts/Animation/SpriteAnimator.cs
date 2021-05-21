using UnityEngine;

namespace Platformer.Animation
{
    /// <summary>
    /// Class that reproduce an animation in a loop
    /// </summary>
    public class SpriteAnimator : MonoBehaviour
    {
        /// <summary>
        /// Set that contains all the Sprites that make up the animation
        /// </summary>
        public Sprite[] spriteSet;
        protected int spriteIndex;
        public float frameRate;
        public SpriteRenderer spriteRenderer;
        /// <summary>
        /// Variable that stores the last moment of the time whitch the Sprite of the animation was updated
        /// </summary>
        private float lastFrameTime;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            spriteIndex = spriteSet.Length;
        }

        protected virtual void Update()
        {
            UpdateSprite();
        }

        /// <summary>
        /// Method that updates the Spite of the animation with the next Sprite of the spriteSet
        /// </summary>
        protected void UpdateSprite()
        {
            if (Time.timeSinceLevelLoad - lastFrameTime > (1f / frameRate))
            {
                spriteIndex = ++spriteIndex % spriteSet.Length;
                spriteRenderer.sprite = spriteSet[spriteIndex];
                lastFrameTime += 1f / frameRate;
            }

        }
    }
}

