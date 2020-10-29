using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Animator cameraAnimator;
    public GameObject player;
    public GameObject center;
    public Transform centerT;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        center = GameObject.FindGameObjectWithTag("Center");
        centerT = center.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerLocation(player.transform.position);
    }

    void CheckPlayerLocation(Vector3 playerPosition)
    {
        if (playerPosition.x <= centerT.position.x && playerPosition.y >= centerT.position.y)
        {
            //Camera 1
            cameraAnimator.SetInteger("Camera", 1);
        }
        else if (playerPosition.x >= centerT.position.x && playerPosition.y >= centerT.position.y)
        {
            //Camera 2
            cameraAnimator.SetInteger("Camera", 2);
        }
        else if (playerPosition.x >= centerT.position.x && playerPosition.y <= centerT.position.y)
        {
            //Camera 3
            cameraAnimator.SetInteger("Camera", 3);
        }
        else
        {
            //Camera 4
            cameraAnimator.SetInteger("Camera", 4);
        }
    }
}
