using UnityEngine;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Physics;
using Platformer.Gameplay;
using Platformer.Model;
using Platformer.Mechanics.KinematicObjects;
using Platformer.Mechanics.Player.PlayerMechanics;

namespace Platformer.Player
{

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

        private PlayerState playerState;

        public bool Jumping { get => jump.Jumping;}
        public bool Dashing { get => dash.Dashing;}
        public float MovingDirection { get => movingDirection;}
        public bool ApplingBulletTime { get => bulletTime.ApplingBulletTime;}

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
                jump.ExecuteMechanic();
                dash.ExecuteMechanic();
                bulletTime.ExecuteMechanic();
            }
            base.FixedUpdate();
        }

        private void manageInputs()
        {
            jump.ManageInput();
            dash.ManageInput();
            bulletTime.ManageInput();
            movingDirection = Input.GetAxis("HorizontalMove");
        }

        private void manageFlags()
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
