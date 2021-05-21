using UnityEngine;
using Platformer.Player;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Mechanics.GravityModifiers;

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

        public static TimeManager timeManager;
    }
}