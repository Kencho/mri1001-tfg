using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Player.PlayerMechanics
{
    public interface PlayerMechanic
    {
        void ManageInput();
        void ManageFlags();
        void ExecuteMechanic();
    }
}

