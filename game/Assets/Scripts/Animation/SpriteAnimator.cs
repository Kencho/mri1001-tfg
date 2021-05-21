using UnityEngine;

namespace Platformer.Animation
{
    public class SpriteAnimator : MonoBehaviour
    {
        public Sprite[] spriteSet;
        public float frameRate;
        public SpriteRenderer spriteRenderer;
        private float lastFrameTime;
        protected int spriteIndex;

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

