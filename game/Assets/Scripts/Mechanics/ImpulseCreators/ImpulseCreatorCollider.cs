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

        private void Awake()
        {
            impulseCollider = GetComponent<Collider2D>();
            impulseCreator = new ImpulseParticle(impulseAplied);
            animator = GetComponent<OneTimeAnimator>();
            audioManager = GetComponent<AudioSource>();
        }

        public void ApplyKinematicObjectCollision(KinematicObject kineObj)
        {
            if (kineObj != null)
            {
                impulseCreator.ImpulseKinematicObject(kineObj);
                audioManager.PlayOneShot(ImpulsePlatformJumpAudio);
                animator.animationReproducton = true;
            }
        }
    }
}

