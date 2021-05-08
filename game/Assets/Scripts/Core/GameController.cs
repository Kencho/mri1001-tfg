using Cinemachine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Platformer.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    public class GameController : MonoBehaviour
    {
        public PlayerController player;
        public Transform spawnPoint;
        public CinemachineVirtualCamera virtualCamera;
        private GravityInverterManager gravityInverter;
        private GameController instance;

        public List<GameObject> initialObjects;
        private List<StartingObject> initialStartingObjects;
        private List<GameObject> instancedObjects;

        private void Awake()
        {
            instancedObjects = new List<GameObject>();
            gravityInverter = GetComponent<GravityInverterManager>();
            SetStartingObjects();
            SetStartingState();
        }

        private void SetPlatformerVariables()
        {
            PlatformerModel.gameController = GetInstance();
            PlatformerModel.player = player;
            PlatformerModel.spawnPoint = spawnPoint;
            PlatformerModel.virtualCamera = virtualCamera;
            PlatformerModel.gravityInverterManager = gravityInverter;
        }

        public GameController GetInstance()
        {
            if (instance == null)
            {
                SetPlatformerVariables();
                instance = this;
            }

            return instance;
        }

        private void SetStartingObjects()
        {
            initialStartingObjects = new List<StartingObject>();

            foreach (GameObject intialObject in initialObjects)
            {
                intialObject.SetActive(false);
                initialStartingObjects.Add(new StartingObject(intialObject, intialObject.transform));
            }
        }

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

        public void SetStartingState(float instantiateDelay = 0)
        {
            DestroyInstancedObjects();
            gravityInverter.ResetAfectedKineObjs();
            StartCoroutine(InstanceStatingObjects(instantiateDelay));
        }

        private IEnumerator InstanceStatingObjects(float delay)
        {
            yield return new WaitForSeconds(delay);
            PlatformerModel.player.transform.position = PlatformerModel.spawnPoint.position;
            InstanceStatingObjects();
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

        private void InstanceStatingObjects()
        {
            foreach(StartingObject startingObject in initialStartingObjects)
            {
                GameObject gameObj = startingObject.Instantiate();
                instancedObjects.Add(gameObj);
            }
        }

        public void AddInstancedObject(GameObject gameObj)
        {
            instancedObjects.Add(gameObj);
        }
    }
}