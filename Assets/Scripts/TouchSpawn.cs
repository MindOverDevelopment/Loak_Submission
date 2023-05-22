using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainDropGame
{
    public class TouchSpawn : MonoBehaviour
    {
        public GameObject objectPrefab; // The prefab of the object you want to spawn
        public Transform targetTransform; // The target transform where the object will be spawned
        public int maxTriggers = 5; // The maximum number of triggers allowed
        private int currentTriggers = 0; // The current number of active triggers

        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (currentTriggers >= maxTriggers)
                    return;

                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            // Instantiate the object prefab at the target transform's position and rotation
            GameObject spawnedObject = Instantiate(objectPrefab, targetTransform.position, targetTransform.rotation);
            spawnedObject.transform.parent = null;

            currentTriggers++;
        }
    }

}

