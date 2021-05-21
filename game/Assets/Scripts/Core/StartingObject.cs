using UnityEngine;

namespace Platformer.Core
{
    public class StartingObject
    {
        private GameObject gameObj;
        private Transform startingPosition;

        public GameObject GameObj { get => gameObj; }
        public Transform StartingPosition { get => startingPosition;}

        public StartingObject(GameObject gameObj, Transform startingPosition)
        {
            this.gameObj = gameObj;
            this.startingPosition = startingPosition;
        }

        public GameObject Instantiate()
        {
            GameObject instance = MonoBehaviour.Instantiate(GameObj, StartingPosition.position, Quaternion.identity);
            instance.SetActive(true);
            return instance;
        }
    }
}

