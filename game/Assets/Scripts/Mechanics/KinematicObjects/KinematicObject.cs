using Platformer.Mechanics.Resources;
using Platformer.Mechanics.TimeModifiers;
using UnityEngine;

namespace Platformer.Mechanics.KinematicObjects
{
    /// <summary>
    /// Class associated to objects tah simulates physics
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KinematicObject : TimeAffectedObject
    {

        public Rigidbody2D rigidBody;
        public Collider2D mycollider;
        private KinematicObjectCollisionManager collisionManager;
        private KinematicObjectGravityManager gravityManager;

        /// <summary>
        /// Boolean that specify if simulate or not physics
        /// </summary>
        public bool simulatingPhysics = true;
        /// <summary>
        /// Boolean that specify if KinematicObject is in contact with floor or not
        /// </summary>
        private bool grounded = true;


        public bool Grounded { get => grounded;}

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
            collisionManager = new KinematicObjectCollisionManager(this);
            gravityManager = new KinematicObjectGravityManager(this);
        }

        /// <summary>
        /// Method that manages all the intructions that has to happen every FixedUpdate loop
        /// </summary>
        protected virtual void FixedUpdate()
        {
            if (simulatingPhysics)
            {
                gravityManager.HandleGravity();
                collisionManager.HandleCollision();
                if(PhysicsController.GetVelocity(this).y == 0)
                {
                    grounded = true;
                }
                else
                {
                    grounded = false;
                }

                Move();
            }
            else
            {
                PhysicsController.SetVelocity(this, Vector2.zero);
            }
        }

        /// <summary>
        /// Methods that perform the movement according with TimeAffectedObject features
        /// </summary>
        protected override void Move()
        {
            Vector2 velocity = PhysicsController.GetVelocity(this);
            Vector2 scaledVelocity = velocity * TimeScale;
            PhysicsController.SetVelocity(this, scaledVelocity);
        }

        public override void SetTimeScale(float timeScale)
        {
            base.SetTimeScale(timeScale);
            Move();
        }

        public override void ResetTimeScale()
        {
            Vector2 velocity = PhysicsController.GetVelocity(this);
            Vector2 unScaledVelocity = velocity / TimeScale;
            PhysicsController.SetVelocity(this, unScaledVelocity);
            base.ResetTimeScale();
        }

        public void ApplyGravityAlteration(Vector2 gravityAlteration)
        {
            gravityManager.AddGravityAlteration(gravityAlteration);
        }
    }
}
