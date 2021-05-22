using Platformer.Mechanics.KinematicObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    /// <summary>
    /// Class wich modifies gravity of the KinematicObjects
    /// </summary>
    public class GravityInverterManager : MonoBehaviour
    {
        /// <summary>
        /// List of KinematicObjects whose gravities will be inverted
        /// </summary>
        private List<KinematicObject> affectedKineObjs;

        private void Awake()
        {
            affectedKineObjs = new List<KinematicObject>();
        }

        /// <summary>
        /// Invert gravity of affectedKineObjs every FixedUpdate loop
        /// </summary>
        private void FixedUpdate()
        {
            ApplyGravityInversionToAffectedKinematicObjects();
        }

        private void ApplyGravityInversionToAffectedKinematicObjects()
        {
            foreach (KinematicObject kineObj in affectedKineObjs)
            {
                kineObj.ApplyGravityAlteration(-2 * Physics2D.gravity); //from gravity to -gravity -> -2*gravity unities
            }
        }

        /// <summary>
        /// If "kineObj" in affectedKineObjs removes it, if not adds it
        /// </summary>
        /// <param name="kineObj"></param>
        public void InvertGravityOfKinematicObject(KinematicObject kineObj)
        {
            if (affectedKineObjs.Contains(kineObj))
            {
                affectedKineObjs.Remove(kineObj);
            }
            else
            {
                affectedKineObjs.Add(kineObj);
            }
        }

        /// <summary>
        /// Cancel gravity inversion on every inverted KinematicObject
        /// </summary>
        public void ResetAffectedKinematicObjects()
        {
            if(affectedKineObjs != null)
            {
                foreach (KinematicObject kineObj in affectedKineObjs)
                {
                    kineObj.transform.Rotate(new Vector3(180, 0, 0));
                }
            }
            
            affectedKineObjs = new List<KinematicObject>();
        }
    }
}

