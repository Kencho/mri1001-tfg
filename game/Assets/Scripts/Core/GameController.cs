using Cinemachine;
using Platformer.Mechanics.GravityModifiers;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.TimeModifiers;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    /// <summary>
    /// Class in charge of managing the scene and consistence of the game flow
    /// </summary>
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// Player of the escene
        /// </summary>
        public PlayerController player;
        /// <summary>
        /// SpawnPoint of the scene
        /// </summary>
        public Transform spawnPoint;
        /// <summary>
        /// VirtualCamera of the scene
        /// </summary>
        public CinemachineVirtualCamera virtualCamera;
        /// <summary>
        /// GravityInverter of the scene
        /// </summary>
        private GravityInverterManager gravityInverter;
        /// <summary>
        /// TimeManager of the scene
        /// </summary>
        private TimeManager timeManager;
        /// <summary>
        /// Variable used to apply Singleton design pattern to GameObject
        /// </summary>
        private GameController instance;

        /// <summary>
        /// Objects in the scene that exist before the initialization of the scene
        /// </summary>
        public List<GameObject> initialObjects;
        /// <summary>
        /// InitialObjects converted to StartingObjects
        /// </summary>
        private List<StartingObject> initialStartingObjects;
        /// <summary>
        /// List that contains each object that has to be destroyed when reset the scene
        /// </summary>
        private List<GameObject> instancedObjects;

        private void Awake()
        {
            instancedObjects = new List<GameObject>();
            gravityInverter = GetComponent<GravityInverterManager>();
            timeManager = GetComponent<TimeManager>();
            SetStartingObjects();
            SetStartingState();
        }

        /// <summary>
        /// Methods that assign to PlatformerModel the variables of the scene
        /// </summary>
        private void SetModelAttributes()
        {
            PlatformerModel.gameController = GetInstance();
            PlatformerModel.player = player;
            PlatformerModel.spawnPoint = spawnPoint;
            PlatformerModel.virtualCamera = virtualCamera;
            PlatformerModel.gravityInverterManager = gravityInverter;
            PlatformerModel.timeManager = timeManager;
        }

        /// <summary>
        /// Method used tu apply Singleton desing pattern. Makes GameObject only can have a single instance of GameObject
        /// </summary>
        /// <returns>single instance of GameObject</returns>
        public GameController GetInstance()
        {
            
            if (instance == null)
            {
                instance = this;
                SetModelAttributes();
            }

            return instance;
        }

        /// <summary>
        /// Initialize initialStartingObjects
        /// </summary>
        private void SetStartingObjects()
        {
            initialStartingObjects = new List<StartingObject>();

            foreach (GameObject intialObject in initialObjects)
            {
                intialObject.SetActive(false);
                initialStartingObjects.Add(new StartingObject(intialObject, intialObject.transform));
            }
        }

        /// <summary>
        /// Execute queued events 
        /// </summary>
        private void Update()
        {
            if (instance == this)
            {
                Simulation.Tick();
            }
            else
            {
                GetInstance();
            }
        }

        /// <summary>
        /// Method that sets the scene to a starting state
        /// </summary>
        /// <param name="instantiateDelay">time that will pass before instantiate startingObjects</param>
        public void SetStartingState(float instantiateDelay = 0)
        {
            DestroyInstancedObjects();
            gravityInverter.ResetAffectedKinematicObjects();
            timeManager.ResetAffectedObjects();
            timeManager.SetDefaultGlobalTime();
            StartCoroutine(InstanceStartingObjects(instantiateDelay));
        }

        /// <summary>
        /// Corroutine used to wait "delay" time before execute InstanceStatingObjects
        /// </summary>
        /// <param name="delay">time that will pass before execute InstanceStatingObjects</param>
        /// <returns></returns>
        private IEnumerator InstanceStartingObjects(float delay)
        {
            yield return new WaitForSeconds(delay);
            PlatformerModel.player.transform.position = PlatformerModel.spawnPoint.position;
            InstanceStatingObjects();
        }

        /// <summary>
        /// Method that instantiate all StartingObjects in initialStartingObjects
        /// </summary>
        private void InstanceStatingObjects()
        {
            foreach (StartingObject startingObject in initialStartingObjects)
            {
                GameObject gameObj = startingObject.Instantiate();
                instancedObjects.Add(gameObj);
            }
        }

        private void DestroyInstancedObjects()
        {
            foreach(GameObject instancedObject in instancedObjects)
            {
                if(instancedObject != null)
                {
                    Destroy(instancedObject);
                }
            }
            instancedObjects = new List<GameObject>();
        }

        public void AddInstancedObject(GameObject gameObj)
        {
            instancedObjects.Add(gameObj);
        }
    }
}