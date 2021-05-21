using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Mechanics.KinematicObjects;

namespace Platformer.Physics
{
    public class PhisicsController
    {

        public static void SimulateGarvity(KinematicObject kinematicObj, Vector2 gravityModifier)
        {
            Vector2 gravityEffect = Physics2D.gravity + gravityModifier;
            kinematicObj.rigidBody.velocity += gravityEffect * Time.deltaTime;
        }

        public static Vector2 ApplyForce(KinematicObject kinematicObj, Vector2 force)
        {
            Vector2 forceTick = force * Time.deltaTime;
            kinematicObj.rigidBody.velocity += forceTick;
            return forceTick;
        }

        public static Vector2 ApplyImpulse(KinematicObject kinematicObj, Vector2 impulse)
        {
            kinematicObj.rigidBody.velocity += impulse;
            return impulse;
        }

        public static void ApplyFriction(KinematicObject kinematicObj, float friction)
        {
            Vector2 newVelocity = kinematicObj.rigidBody.velocity;
            float movingDirection = newVelocity.x;

            if (newVelocity.x != 0)
            {
                if (newVelocity.x < 0)
                {
                    newVelocity += Vector2.right * friction * Time.deltaTime;
                }
                else
                {
                    newVelocity += Vector2.left * friction * Time.deltaTime;
                }
            }
            if(movingDirection > 0 && newVelocity.x < 0)
            {
                newVelocity.x = 0;
            }else if (movingDirection < 0 && newVelocity.x > 0)
            {
                newVelocity.x = 0;
            }
            kinematicObj.rigidBody.velocity = newVelocity;


        }

        public static void SetVelocity(KinematicObject kinematicObj, Vector2 newVelocity)
        {
            kinematicObj.rigidBody.velocity = newVelocity;
        }

        public static Vector2 GetVelocity(KinematicObject kinematicObj)
        {
            return kinematicObj.rigidBody.velocity;
        }
    }
}
