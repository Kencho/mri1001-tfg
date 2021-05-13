using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Player
{
    public interface PlayerState
    {
        void EnterPlayerState();

        void UpdateState();

        void FixedUpdateState();

        void ExitPlayerState();
    }
}
