using UnityEngine;
using Platformer.Player;
using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Model
{

    [System.Serializable]
    public static class PlatformerModel
    {

        public static Cinemachine.CinemachineVirtualCamera virtualCamera;

        public static PlayerController player;

        public static Transform spawnPoint;

        public static GameController gameController;

        public static GravityInverterManager gravityInverterManager;
    }
}