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
        public KinematicObjectCollisionManager collisionManager;

        public bool simulatingPhysics = true;
        private bool grounded = true;

        public bool Grounded { get => grounded;}

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
            collisionManager = new KinematicObjectCollisionManager(this);
        }

        protected virtual void FixedUpdate()
        {
            if (simulatingPhysics)
            {
                PhisicsController.SimulateGarvity(this);
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

    }
}
