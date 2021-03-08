using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Prueba
{

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class KinematicObject : MonoBehaviour
    {

        public Rigidbody2D rigidBody;
        public Collider2D mycollider;

        public bool leftMoveRestriction = false;
        public bool rightMoveRestriction = false;
        public bool upMoveRestriction = false;
        public bool downMoveRestriction = false;

        public bool grounded = true;

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            mycollider = GetComponent<Collider2D>();
        }

        protected virtual void FixedUpdate()
        {
            if (grounded)
            {
                downMoveRestriction = true;
            }
            else
            {
                downMoveRestriction = false;
            }
            PhisicsControllerPrueba.SimulateGarvity(this);
            
        }

        public void EnableAllMove()
        {
            leftMoveRestriction = false;
            rightMoveRestriction = false;
            upMoveRestriction = false;
            downMoveRestriction = false;
        }

        public void disableAllMove()
        {
            leftMoveRestriction = true;
            rightMoveRestriction = true;
            upMoveRestriction = true;
            downMoveRestriction = true;
        }

        public void disableMove(Vector2 disbleDirection)
        {
            if (disbleDirection.x < 0)
            {
                leftMoveRestriction = true;
            }
            if (disbleDirection.x > 0)
            {
                rightMoveRestriction = true;
            }

            if (disbleDirection.y < 0)
            {
                downMoveRestriction = true;
            }
            if (disbleDirection.y > 0)
            {
                upMoveRestriction = true;
            }
        }

    }
}
