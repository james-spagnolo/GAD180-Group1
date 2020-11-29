﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] public List<Transform> spawnTransforms;
    [SerializeField] public List<GameObject> spawnObjects;

    private int totalObjects;

    // Start is called before the first frame update
    void Start()
    {
        totalObjects = spawnObjects.Count;

        for (int i = 0; i < totalObjects; i++)
        {
            GameObject prefab = spawnObjects[Random.Range(0, spawnObjects.Count)];
            Transform position = spawnTransforms[Random.Range(0, spawnTransforms.Count)];

            Instantiate(prefab, position);

            spawnObjects.Remove(prefab);
            spawnTransforms.Remove(position);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
