using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Prueba
{
    public interface PlayerState
    {
        void UpdateState();

        void FixedUpdateState();
    }
}
