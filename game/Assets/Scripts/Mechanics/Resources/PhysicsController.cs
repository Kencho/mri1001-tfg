using Platformer.Mechanics.KinematicObjects;
using UnityEngine;

namespace Platformer.Mechanics.Resources
{
    /// <summary>
    /// Class formed by the methods that simulates the physics applied to KinematicObjects
    /// </summary>
    public class PhysicsController
    {

        public static void SimulateGravity(KinematicObject kinematicObj, Vector2 gravityModifier)
        {
            Vector2 gravityEffect = Physics2D.gravity + gravityModifier;
            kinematicObj.rigidBody.velocity += gravityEffect * Time.deltaTime;
        }

        /// <summary>
        /// Changes velocity of KinematicObjects in a time period
        /// </summary>
        /// <param name="kinematicObj"></param>
        /// <param name="force"></param>
        /// <returns>fragment of the force applied this instant</returns>
        public static Vector2 ApplyForce(KinematicObject kinematicObj, Vector2 force)
        {
            Vector2 forceTick = force * Time.deltaTime;
            kinematicObj.rigidBody.velocity += forceTick;
            return forceTick;
        }

        /// <summary>
        /// Changes velocity of KinematicObjects instantly
        /// </summary>
        /// <param name="kinematicObj"></param>
        /// <param name="impulse"></param>
        /// <returns>velocity modification applied in this instant</returns>
        public static Vector2 ApplyImpulse(KinematicObject kinematicObj, Vector2 impulse)
        {
            kinematicObj.rigidBody.velocity += impulse;
            return impulse;
        }

        /// <summary>
        /// Reduces positive horizontal velocity of KinematicObjects in order to reduce it to zero
        /// </summary>
        /// <param name="kinematicObj"></param>
        /// <param name="friction"></param>
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
