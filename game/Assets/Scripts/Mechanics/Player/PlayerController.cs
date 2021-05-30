using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Player.PlayerMechanics;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Mechanics.Resources;
using UnityEngine;

namespace Platformer.Mechanics.Player
{
    /// <summary>
    /// Class that manages Player behaviour
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public const float MAX_SPEED = 5f;
        public const float JUMP_IMPULSE = 5f;
        public const float MAX_AIR_SPEED = 4f;
        public const float DASH_COLDOWN = 0.7f;
        public const float BULLET_TIME_COLDOWN = 5f;
        public const float BULLET_TIME_DURATION = 1f;
        public const float BULLET_TIME_SCALE = 0.4f;
        private Vector2 JumpDirection = Vector2.up;

        public bool controlEnabled = true;
        private float movingDirection = 0;

        private Jump jump;
        private Dash dash;
        private BulletTime bulletTime;
        public Health health;
        public AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public AudioClip jumpAudio;
        public AudioClip ouchAudio;
        public AudioClip respawnAudio;
        public AudioClip dashAudio;

        private PlayerState playerState;

        public bool Jumping { get => jump.Jumping;}
        public bool Dashing { get => dash.Dashing;}
        public float MovingDirection { get => movingDirection;}
        public bool BulletTimeActive { get => bulletTime.BulletTimeActive;}

        protected override void Awake()
        {
            base.Awake();
            InstantiateMechanics();
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            ChangeState(new PlayerIdleState(this));
        }

        private void InstantiateMechanics()
        {
            jump = new Jump(JUMP_IMPULSE, JumpDirection, this);
            dash = new Dash(DASH_COLDOWN, this);
            bulletTime = new BulletTime(BULLET_TIME_COLDOWN, BULLET_TIME_DURATION, BULLET_TIME_SCALE, this);
        }

        void Update()
        {
            ManageInputs();
            playerState.UpdateState();
            AnimateMovement();
        }

        protected override void FixedUpdate()
        {
            if (controlEnabled)
            {
                playerState.FixedUpdateState();
                ManageFlags();
                jump.ExecuteMechanic();
                dash.ExecuteMechanic();
                bulletTime.ExecuteMechanic();
            }
            base.FixedUpdate();
        }

        /// <summary>
        /// Checks if all the Inputs used are being pressed or not
        /// </summary>
        private void ManageInputs()
        {
            jump.ManageInput();
            dash.ManageInput();
            bulletTime.ManageInput();
            movingDirection = Input.GetAxis("HorizontalMove");
        }

        /// <summary>
        /// Update flags relating to be performing a mechanic
        /// </summary>
        private void ManageFlags()
        {
            jump.ManageFlags();
            dash.ManageFlags();
            bulletTime.ManageFlags();
        }

        public void ChangeState(PlayerState playerState)
        {
            if(this.playerState != null)
            {
                this.playerState.ExitPlayerState();
            }
            this.playerState = playerState;
            this.playerState.EnterPlayerState();
        }

        /// <summary>
        /// Update animations according to movement is being performed
        /// </summary>
        private void AnimateMovement()
        {
            animator.SetFloat("velocityX", Mathf.Abs(rigidBody.velocity.x) / MAX_SPEED);
            animator.SetFloat("velocityY", rigidBody.velocity.y);
            animator.SetBool("grounded", Grounded);

            if(PhysicsController.GetVelocity(this).x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(PhysicsController.GetVelocity(this).x > 0)
            {
                spriteRenderer.flipX = false;
            }
           
        }

        public override void SetTimeScale(float timeScale)
        {
            base.SetTimeScale(timeScale);
            animator.speed = timeScale;
        }

        public override void ResetTimeScale()
        {
            animator.speed = 1;
            base.ResetTimeScale();
        }
    }

}
