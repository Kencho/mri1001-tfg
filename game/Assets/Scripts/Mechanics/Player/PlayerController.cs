using UnityEngine;
using Platformer.Mechanics;
using Platformer.Core;
using Platformer.Physics;
using Platformer.Gameplay;
using Platformer.Model;

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
        public const float TIME_SCALE = 0.4f;
        private float timeWithOutBulletTime = 0;
        private Vector2 JumpDirection = Vector2.up;

        public bool controlEnabled = true;
        public bool dashable = true;
        private bool bulletTimeAbble = true;
        private bool dashing = false;
        private bool applingBulletTime = false;
        private float movingDirection = 0;

        private Jump jump;
        private Dash dash;
        public Health health;
        public AudioSource audioSource;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public AudioClip jumpAudio;
        public AudioClip ouchAudio;
        public AudioClip respawnAudio;

        public PlayerState playerState;

        public bool Jumping { get => jump.Jumping;}
        public bool Dashing { get => dashing;}
        public float MovingDirection { get => movingDirection;}
        public bool ApplingBulletTime { get => applingBulletTime;}

        protected override void Awake()
        {
            base.Awake();
            jump = new Jump(JUMP_IMPULSE, JumpDirection, this);
            dash = new Dash(DASH_COLDOWN, this);
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
                jump.ExecuteMechanic();
                dash.ExecuteMechanic();
                manageBulletTime();
            }
            base.FixedUpdate();
        }

        private void manageInputs()
        {
            jump.ManageInput();
            dash.ManageInput();

            if (Input.GetButton("BulletTime"))
            {
                applingBulletTime = true;
            }
            else
            {
                applingBulletTime = false;
            }

            movingDirection = Input.GetAxis("HorizontalMove");
        }

        private void manageFlags()
        {
            jump.ManageFlags();
            dash.ManageFlags();

            if (bulletTimeAbble == false)
            {
                if (timeWithOutBulletTime < BULLET_TIME_COLDOWN)
                {
                    timeWithOutBulletTime += Time.fixedDeltaTime;
                }
                else
                {
                    bulletTimeAbble = true;
                    timeWithOutBulletTime = 0;
                }
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

        private void manageBulletTime()
        {
            if(applingBulletTime && bulletTimeAbble)
            {
                PlatformerModel.timeManager.ScaleGlobalTime(TIME_SCALE, BULLET_TIME_DURATION);
                bulletTimeAbble = false;
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
