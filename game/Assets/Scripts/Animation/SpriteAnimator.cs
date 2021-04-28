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
        private float nextFrameTime;
        protected int spriteIndex;

        private void Awake()
        {
            rendererOfSprites = GetComponent<SpriteRenderer>();
        }

        // Start is called before the first frame update
        void Start()
        {
            spriteIndex = 12;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateSprite();
        }

        protected void UpdateSprite()
        {
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                spriteIndex = ++spriteIndex % spriteSet.Length;
                rendererOfSprites.sprite = spriteSet[spriteIndex];
                nextFrameTime += 1f / frameRate;
            }

        }
    }
}

