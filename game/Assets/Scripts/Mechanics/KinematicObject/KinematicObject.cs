using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Physics;
using System;

namespace Platformer.Mechanics
{

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KinematicObject : MonoBehaviour
    {

        public Rigidbody2D rigidBody;
        public Collider2D mycollider;
        private KinematicObjectCollisionManager collisionManager;
        private GravityManager gravityManager;

        public bool simulatingPhysics = true;
        private bool grounded = true;


        public bool Grounded { get => grounded;}

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
            collisionManager = new KinematicObjectCollisionManager(this);
            gravityManager = new GravityManager(this);
        }

        protected virtual void FixedUpdate()
        {
            if (simulatingPhysics)
            {
                gravityManager.ManageGravity();
                collisionManager.manageCollision();
                if(PhisicsController.GetVelocity(this).y == 0)
                {
                    grounded = true;
                }
                else
                {
                    grounded = false;
                }
            }
                
        }

        public void ApplyGravityAlteration(Vector2 gravityAlteration)
        {
            gravityManager.addGravityAlteration(gravityAlteration);
        }

    }
}
