using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float speed;
	private Waypoints Wpoints;

	private int waypointIndex;
	public GameObject thisObject;


    void Start()
    {
      Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();

      thisObject = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
      thisObject.transform.position = Vector2.MoveTowards(thisObject.transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

      Vector3 dir = Wpoints.waypoints[waypointIndex].position - thisObject.transform.position;
      float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      
      if(Vector2.Distance(thisObject.transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
      {
	      	if(waypointIndex <Wpoints.waypoints.Length - 1)
	      	{
	      		waypointIndex++;
	      	}
   		 }
   }
}

