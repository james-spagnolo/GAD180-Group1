using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public GameObject[] waypoints;

    public float speed;

    private int current = 0;
    private float rotSpeed;
    private float wpRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(waypoints[current].transform.position, transform.position) < wpRadius)
        {
            current = Random.Range(0, waypoints.Length);

            if (current >= waypoints.Length)
            {
                current = 0;
            }

            transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
}
