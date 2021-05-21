using Platformer.Core;
using Platformer.Mechanics.GravityModifiers;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.TimeModifiers;
using UnityEngine;

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