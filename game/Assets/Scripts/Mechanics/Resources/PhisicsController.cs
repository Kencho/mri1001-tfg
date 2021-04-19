﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;


namespace Platformer.Physics
{
    public class PhisicsController
    {

        public static void SimulateGarvity(KinematicObject kinematicObj)
        {
            Vector2 restrictedGravity = ApplyKinematicRestrictions(Physics2D.gravity, kinematicObj);
            kinematicObj.rigidBody.velocity += restrictedGravity * Time.deltaTime;
        }

        public static void ApplyForce(KinematicObject kinematicObj, Vector2 force)
        {
            Vector2 restirctedForce = ApplyKinematicRestrictions(force, kinematicObj);
            kinematicObj.rigidBody.velocity += restirctedForce * Time.deltaTime;
        }

        public static void ApplyImpulse(KinematicObject kinematicObj, Vector2 impulse)
        {
            Vector2 restrictedImpulse = ApplyKinematicRestrictions(impulse, kinematicObj);
            kinematicObj.rigidBody.velocity += restrictedImpulse;
        }

        public static void ApplyFriction(KinematicObject kinematicObj, float friction)
        {
            if(kinematicObj.rigidBody.velocity.x != 0)
            {
                if (kinematicObj.rigidBody.velocity.x < 0)
                {
                    kinematicObj.rigidBody.velocity += Vector2.right * friction * Time.deltaTime;
                }
                else
                {
                    kinematicObj.rigidBody.velocity += Vector2.left * friction * Time.deltaTime;
                }
            }
            
        }

        public static void SetVelocityWithRestrictions(KinematicObject kinematicObj, Vector2 newVelocity)
        {
            Vector2 restrictedVector = ApplyKinematicRestrictions(newVelocity, kinematicObj);
            SetVelocity(kinematicObj, restrictedVector);
        }

        public static void SetVelocity(KinematicObject kinematicObj, Vector2 newVelocity)
        {
            kinematicObj.rigidBody.velocity = newVelocity;
        }

        public static Vector2 GetVelocity(KinematicObject kinematicObj)
        {
            return kinematicObj.rigidBody.velocity;
        }

        private static Vector2 ApplyKinematicRestrictions(Vector2 vector, KinematicObject kineObj)
        {
            Vector2 restrictedVector = vector;

            if (kineObj.leftMoveRestriction && vector.x < 0)
            {
                restrictedVector.x = 0;
            }
            if(kineObj.rightMoveRestriction && vector.x > 0)
            {
                restrictedVector.x = 0;
            }
            if(kineObj.upMoveRestriction && vector.y > 0)
            {
                restrictedVector.y = 0;
            }
            if(kineObj.downMoveRestriction && vector.y < 0)
            {
                restrictedVector.y = 0;
            }

            return restrictedVector;
        }
    }
}
