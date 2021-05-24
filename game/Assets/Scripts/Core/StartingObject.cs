using UnityEngine;

namespace Platformer.Core
{
    /// <summary>
    /// Class that clones objects that have to be intantiated when setting starting game state.
    /// </summary>
    public class StartingObject
    {
        /// <summary>
        /// GameObject that will be cloned when instantiate the StartingObject
        /// </summary>
        private GameObject gameObj;
        /// <summary>
        /// Position where the GameObject will be instantiated
        /// </summary>
        private Transform startingPosition;

        public GameObject GameObj { get => gameObj; }
        public Transform StartingPosition { get => startingPosition;}

        public StartingObject(GameObject gameObj, Transform startingPosition)
        {
            this.gameObj = gameObj;
            this.startingPosition = startingPosition;
        }

        /// <summary>
        /// Method that clones a GameObject in the scene
        /// </summary>
        /// <returns>Instantiated GameObject</returns>
        public GameObject Instantiate()
        {
            GameObject instance = MonoBehaviour.Instantiate(GameObj, StartingPosition.position, Quaternion.identity);
            instance.SetActive(true);
            return instance;
        }
    }
}

