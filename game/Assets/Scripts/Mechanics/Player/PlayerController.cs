using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Physics;
using System;
using Platformer.Resources;
using Platformer.Gameplay;

namespace Platformer.Player
{

    public class PlayerController : KinematicObject
    {

        public float maxSpeed = 5f;
        public float speedIncrement = 0.5f;
        public float jumpImpulse = 5f;
        public float maxAirSpeed = 4f;
        public const float DASH_COLDOWN = 0.7f;
        private float timeWithOutFlash = 0;

        public bool controlEnabled = true;
        public bool jumplable = true;
        public bool dashable = true;
        public bool jumping = false;
        public bool dashing = false;
        public float movingDirection = 0;

        public Health health;
        public AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public AudioClip jumpAudio;
        public AudioClip ouchAudio;
        public AudioClip respawnAudio;

        public PlayerState playerState;
        public float n = 0;

        protected override void Awake()
        {
            base.Awake();
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            playerState = new PlayerIdleState(this);
        }

        void Update()
        {
            manageInputs();
            playerState.UpdateState();
            AnimarMovimientoPlayer();
        }

        protected override void FixedUpdate()
        {
            if (controlEnabled)
            {
                playerState.FixedUpdateState();
                manageFlags();
                manageJump();
                manageDash();
                collisionManager.manageCollision();
            }
            base.FixedUpdate();
        }

        private void manageInputs()
        {
            if (Input.GetButton("Jump"))
            {
                jumping = true;
            }
            else
            {
                jumping = false;
            }

            if (Input.GetButton("Dash"))
            {
                dashing = true;
            }
            else
            {
                dashing = false;
            }

            movingDirection = Input.GetAxis("HorizontalMove");
        }

        private void manageFlags()
        {
            if (Grounded)
            {
                jumplable = true;
                if (dashable == false)
                {
                    if (timeWithOutFlash < DASH_COLDOWN)
                    {
                        timeWithOutFlash += Time.fixedDeltaTime;
                    }
                    else
                    {
                        dashable = true;
                        timeWithOutFlash = 0;
                    }
                }
            }
            else
            {
                jumplable = false;
            }
        }

        private void AnimarMovimientoPlayer()
        {
            animator.SetFloat("velocityX", Mathf.Abs(rigidBody.velocity.x) / maxSpeed);
            animator.SetFloat("velocityY", rigidBody.velocity.y);
            animator.SetBool("grounded", Grounded);

            if(PhisicsController.GetVelocity(this).x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(PhisicsController.GetVelocity(this).x > 0)
            {
                spriteRenderer.flipX = false;
            }
           
        }

        private void manageJump()
        {
            
            if(jumping && jumplable)
            {
                jump();
            }
        }

        public void jump()
        {
            jumping = false;
            jumplable = false;
            PhisicsController.ApplyImpulse(this, Vector2.up * jumpImpulse);
            PlayerJumped ev = Simulation.Schedule<PlayerJumped>();
            ev.player = this;
        }

        private void manageDash()
        {
            if(dashing && dashable)
            {
                dash();
            }
        }

        private void dash()
        {
            dashable = false;
            playerState = new PlayerDashingState(this);
        }

    }

}
