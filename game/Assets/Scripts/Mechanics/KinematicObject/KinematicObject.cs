using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Platformer.Mechanics.Resources;
using Platformer.Mechanics.TimeModifiers;

namespace Platformer.Mechanics.KinematicObjects
{

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KinematicObject : TimeAffectedObject
    {

        public Rigidbody2D rigidBody;
        public Collider2D mycollider;
        private KinematicObjectCollisionManager collisionManager;
        private KinematicObjectGravityManager gravityManager;

        public bool simulatingPhysics = true;
        private bool grounded = true;


        public bool Grounded { get => grounded;}

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
            collisionManager = new KinematicObjectCollisionManager(this);
            gravityManager = new KinematicObjectGravityManager(this);
        }

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
