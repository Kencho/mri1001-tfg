using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Animation
{
    public class SpriteAnimator : MonoBehaviour
    {
        public Sprite[] spriteSet;
        public float frameRate;
        public SpriteRenderer rendererOfSprites;
        private float lastFrameTime;
        protected int spriteIndex;

        private void Awake()
        {
            rendererOfSprites = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            spriteIndex = 12;
        }

        void Update()
        {
            UpdateSprite();
        }

        protected void UpdateSprite()
        {
            if (Time.time - lastFrameTime > (1f / frameRate))
            {
                spriteIndex = ++spriteIndex % spriteSet.Length;
                rendererOfSprites.sprite = spriteSet[spriteIndex];
                lastFrameTime += 1f / frameRate;
            }

        }
    }
}

