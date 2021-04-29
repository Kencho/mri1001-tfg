using Platformer.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D),typeof(OneTimeAnimator))]
    public class ImpulseCreatorCollider : MonoBehaviour
    {
        private Collider2D impulseCollider;
        private ImpulseCreator impulseCreator;
        private OneTimeAnimator animator;
        private AudioSource audioManager;
        public Vector2 impulseAplied;
        public AudioClip ImpulsePlatformJumpAudio;

        private bool active;
        public const float inactivityTime = 0.5f;
        private float currentInactivityTime = 0f;

        private void Awake()
        {
            impulseCollider = GetComponent<Collider2D>();
            impulseCreator = new ImpulseParticle(impulseAplied);
            animator = GetComponent<OneTimeAnimator>();
            audioManager = GetComponent<AudioSource>();
            active = true;
        }

        private void Update()
        {
            if(active == false)
            {
                if(currentInactivityTime < inactivityTime)
                {
                    currentInactivityTime += Time.deltaTime;
                }
                else
                {
                    active = true;
                    currentInactivityTime = 0;
                }
            }
        }

        public void ApplyKinematicObjectCollision(KinematicObject kineObj)
        {
            if (active)
            {
                if (kineObj != null)
                {
                    active = false;
                    impulseCreator.ImpulseKinematicObject(kineObj);
                    audioManager.PlayOneShot(ImpulsePlatformJumpAudio);
                    animator.animationReproducton = true;
                }
            }
            
        }
    }
}

