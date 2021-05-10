using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class GravityInverterManager : MonoBehaviour
    {
        private List<KinematicObject> AfectedKineObjs;

        private void Awake()
        {
            AfectedKineObjs = new List<KinematicObject>();
        }

        private void FixedUpdate()
        {
            ApplyGravityInversionToAfectedKineObjs();
        }

        private void ApplyGravityInversionToAfectedKineObjs()
        {
            foreach (KinematicObject kineObj in AfectedKineObjs)
            {
                kineObj.ApplyGravityAlteration(-2 * Physics2D.gravity); //from gravity to -gravity -> -2*gravity unities
            }
        }

        public void InverGravityOfKinematicObject(KinematicObject kineObj)
        {
            if (AfectedKineObjs.Contains(kineObj))
            {
                AfectedKineObjs.Remove(kineObj);
            }
            else
            {
                AfectedKineObjs.Add(kineObj);
            }
        }

        public void ResetAfectedKineObjs()
        {
            if(AfectedKineObjs != null)
            {
                foreach (KinematicObject kineObj in AfectedKineObjs)
                {
                    kineObj.transform.Rotate(new Vector3(180, 0, 0));
                }
            }
            
            AfectedKineObjs = new List<KinematicObject>();
        }
    }
}

