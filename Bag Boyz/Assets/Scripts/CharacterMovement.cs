using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private Animator anim;

	public float speed;
    public bool thisInteract = false;

	private Waypoints Wpoints;

	private int waypointIndex;
	private GameObject thisObject;

    private string thisNPC;

    private bool facingLeft = false;


    void Start()
    {
        switch (this.name)
        {
            case "CharityWorker":
                thisNPC = "CharityWorker";
                break;
            case "OldMan":
                thisNPC = "OldMan";
                break;
            case "Karen":
                thisNPC = "Karen";
                break;
            default:
                break;
        }


        Wpoints = GameObject.FindGameObjectWithTag(thisNPC).GetComponent<Waypoints>();
      

        thisObject = this.gameObject;

        anim = this.gameObject.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        if (thisInteract == false)
        {
            thisObject.transform.position = Vector2.MoveTowards(thisObject.transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

            Vector3 dir = Wpoints.waypoints[waypointIndex].position - thisObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (Vector2.Distance(thisObject.transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
            {
                if (waypointIndex < Wpoints.waypoints.Length - 1)
                {
                    waypointIndex++;
                }
                else if (waypointIndex >= Wpoints.waypoints.Length - 1)
                {
                    waypointIndex = 0;
                }
            }

            if (dir.x > 0)
            {
                TurnOffAnimations();
                anim.SetBool("Walking Right", true);
                facingLeft = true;
            }
            else if (dir.x < 0)
            {
                TurnOffAnimations();
                anim.SetBool("Walking Left", true);
                facingLeft = false;
            }
            else if (dir.x == 0)
            {
                TurnOffAnimations();

                if (facingLeft)
                {
                    anim.SetBool("Idle Left", true);
                }
                else
                {
                    anim.SetBool("Idle Right", true);
                }
            }

        }
        
    }

    void TurnOffAnimations()
    {
        anim.SetBool("Walking Left", false);
        anim.SetBool("Walking Right", false);
        anim.SetBool("Idle Left", false);
        anim.SetBool("Idle Right", false);
    }


}

