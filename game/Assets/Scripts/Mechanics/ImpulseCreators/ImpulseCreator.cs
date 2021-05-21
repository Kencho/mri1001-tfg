using Platformer.Mechanics.KinematicObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.ImpulseCreators
{
    public interface ImpulseCreator
    {

        void ImpulseKinematicObject(KinematicObject kineObj);
    }
}

