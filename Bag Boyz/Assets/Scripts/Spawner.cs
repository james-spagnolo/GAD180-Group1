using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] public List<Transform> produceTransforms;
    [SerializeField] public List<GameObject> produceObjects;

    private int totalObjects;

    // Start is called before the first frame update
    void Start()
    {
        totalObjects = produceObjects.Count;

        for (int i = 0; i < totalObjects; i++)
        {
            GameObject prefab = produceObjects[Random.Range(0, produceObjects.Count)];
            Transform position = produceTransforms[Random.Range(0, produceTransforms.Count)];

            Instantiate(prefab, position);

            produceObjects.Remove(prefab);
            produceTransforms.Remove(position);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
