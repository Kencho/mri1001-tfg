using Platformer.Animation;
using Platformer.Mechanics.KinematicObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    [RequireComponent(typeof(Collider2D),typeof(OneShotAnimation))]
    public abstract class ImpulseCreatorCollider : MonoBehaviour
    {
        private Collider2D impulseCollider;
        protected ImpulseCreator impulseCreator;
        private OneShotAnimation animator;
        private AudioSource audioManager;
        public AudioClip ImpulseCreatorAudio;

        private bool active;
        public const float inactivityTime = 0.5f;
        private float currentInactivityTime = 0f;

        private void Awake()
        {
            impulseCollider = GetComponent<Collider2D>();
            SetImpulseCreator();
            animator = GetComponent<OneShotAnimation>();
            audioManager = GetComponent<AudioSource>();
            active = true;
        }

        protected virtual void SetImpulseCreator()
        {
            throw new NotImplementedException();
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
                    audioManager.PlayOneShot(ImpulseCreatorAudio);
                    animator.animationPlaying = true;
                }
            }
            
        }
    }
}

