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

        public const float MAX_SPEED = 5f;
        public const float JUMP_IMPULSE = 5f;
        public const float MAX_AIR_SPEED = 4f;
        public const float DASH_COLDOWN = 0.7f;
        private float timeWithOutFlash = 0;

        public bool controlEnabled = true;
        public bool jumplable = true;
        public bool dashable = true;
        private bool jumping = false;
        private bool dashing = false;
        private float movingDirection = 0;

        public Health health;
        public AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public AudioClip jumpAudio;
        public AudioClip ouchAudio;
        public AudioClip respawnAudio;

        public PlayerState playerState;

        public bool Jumping { get => jumping;}
        public bool Dashing { get => dashing;}
        public float MovingDirection { get => movingDirection;}

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
            animator.SetFloat("velocityX", Mathf.Abs(rigidBody.velocity.x) / MAX_SPEED);
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
            PhisicsController.ApplyImpulse(this, Vector2.up * JUMP_IMPULSE);
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
