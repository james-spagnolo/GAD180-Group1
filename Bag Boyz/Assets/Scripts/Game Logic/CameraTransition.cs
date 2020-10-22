using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Animator cameraAnimator;

    public int currentCamera;
    public int cameraTransition;

    private void Update()
    {
        if (currentCamera == 1)
        {
            cameraTransition = 2;
        }

        else if (currentCamera == 2)
        {
            cameraTransition = 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch(cameraTransition)
            {
                
                case 1: 
                    cameraAnimator.SetInteger("Camera", 1);
                    currentCamera = 1;
                    break;
                case 2: 
                    cameraAnimator.SetInteger("Camera", 2);
                    currentCamera = 2;
                    break;
                default: Debug.LogError("No Camera Selected"); break;
            }
        }
    }

    
}
