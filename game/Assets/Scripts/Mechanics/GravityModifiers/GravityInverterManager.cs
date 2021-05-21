using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.GravityModifiers
{
    public class GravityInverterManager : MonoBehaviour
    {
        private List<KinematicObject> affectedKineObjs;

        private void Awake()
        {
            affectedKineObjs = new List<KinematicObject>();
        }

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

