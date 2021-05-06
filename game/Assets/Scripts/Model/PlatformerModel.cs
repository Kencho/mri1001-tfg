using UnityEngine;
using Platformer.Player;
using Platformer.Core;

namespace Platformer.Model
{
    /// <summary>
    /// The main model containing needed data to implement a platformer style 
    /// game. This class should only contain data, and methods that operate 
    /// on the data. It is initialised with data in the GameController class.
    /// </summary>
    [System.Serializable]
    public static class PlatformerModel
    {
        /// <summary>
        /// The virtual camera in the scene.
        /// </summary>
        public static Cinemachine.CinemachineVirtualCamera virtualCamera;

        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public static PlayerController player;

        /// <summary>
        /// The spawn point in the scene.
        /// </summary>
        public static Transform spawnPoint;

        public static GameController gameController;

    }
}