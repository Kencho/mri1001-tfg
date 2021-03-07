﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Gameplay;

namespace Platformer.Prueba
{

    public class PlayerController : KinematicObject
    {

        public float maxSpeed = 5f;
        public float speedIncrement = 0.5f;
        public float jumpImpulse = 5f;
        public float maxAirSpeed = 4f;
        public bool jumping = false;
        public bool grounded = true;

        public Health health;
        public AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public AudioClip jumpAudio;
        public AudioClip ouchAudio;
        public AudioClip respawnAudio;

        public PlayerState playerState;

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
            playerState.UpdateState();
            AnimarMovimientoPlayer();
        }

        void FixedUpdate()
        {
            playerState.FixedUpdateState();
        }

        private void AnimarMovimientoPlayer()
        {
            animator.SetFloat("velocityX", Mathf.Abs(rigidBody.velocity.x) / maxSpeed);
            animator.SetFloat("velocityY", rigidBody.velocity.y);

            if(PhisicsControllerPrueba.GetVelocity(this).x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(PhisicsControllerPrueba.GetVelocity(this).x > 0)
            {
                spriteRenderer.flipX = false;
            }
           
        }

        public void jump()
        {
            PlayerJumped ev = Simulation.Schedule<PlayerJumped>();
            ev.player = this;
            jumping = false;
        }

    }

}