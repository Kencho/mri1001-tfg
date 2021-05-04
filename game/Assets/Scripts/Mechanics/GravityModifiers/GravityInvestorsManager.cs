using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class GravityInvestorsManager : MonoBehaviour
    {
        private List<KinematicObject> AfectedKineObjs;

        private void Awake()
        {
            AfectedKineObjs = new List<KinematicObject>();
        }

        private void FixedUpdate()
        {
            ApplyGravityInvestedToAfectedKineObjs();
        }

        private void ApplyGravityInvestedToAfectedKineObjs()
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
            AfectedKineObjs = new List<KinematicObject>();
        }
    }
}

