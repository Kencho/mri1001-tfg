using Platformer.Animation;
using Platformer.Mechanics.KinematicObjects;
using System;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// General class ImpulseCreators uses to manage collisión with KinematicObjects and impulse applied accordingly
    /// </summary>
    [RequireComponent(typeof(Collider2D),typeof(OneShotAnimation))]
    public abstract class ImpulseCreatorCollider : MonoBehaviour
    {
        private Collider2D impulseCollider;
        /// <summary>
        /// field that will apply the impulse
        /// </summary>
        protected ImpulseCreator impulseCreator;
        private OneShotAnimation animator;
        private AudioSource audioManager;
        /// <summary>
        /// Sound applied when KinematicObject collides with the ImpulseCreator
        /// </summary>
        public AudioClip ImpulseCreatorAudio;

        private bool active;
        /// <summary>
        /// Time that takes reactivate ImpulseCreator after apply a impulse
        /// </summary>
        public const float inactivityTime = 0.5f;
        /// <summary>
        /// Used to count inactivity time elapsed
        /// </summary>
        private float currentInactivityTime = 0f;

        private void Awake()
        {
            impulseCollider = GetComponent<Collider2D>();
            SetImpulseCreator();
            animator = GetComponent<OneShotAnimation>();
            audioManager = GetComponent<AudioSource>();
            active = true;
        }

        /// <summary>
        /// Instantiates impulseCreator with the appropiate ImpulseCreator
        /// </summary>
        protected virtual void SetImpulseCreator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If the ImpulseCreatorCollider is inactive manages if it have to be reactived or not
        /// </summary>
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

        /// <summary>
        /// Apply the impulse to a KinematicObject
        /// </summary>
        /// <param name="kineObj">KinematicObject in contact with ImpulseCreatorCollider</param>
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

