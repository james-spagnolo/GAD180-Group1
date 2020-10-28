using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Animator cameraAnimator;
    public GameObject player;

    public int cameraOne;
    public int cameraTwo;

    [System.Serializable]
    public enum cameraTrigger
    {
        Cam1toCam2,
        Cam2toCam1,
        Cam2toCam3,
        Cam3toCam2,
    }

    public cameraTrigger thisTrigger;

    public int camTrigger;
    public int currentCamera;
    public int cameraTransition;

    bool cameraMoving = false;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        DetermineCameraTransition(thisTrigger);
    }


    private void Update()
    {

        
        CheckPlayerWithinBounds(thisTrigger, player.transform.position);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cameraMoving = true;

            switch(cameraOne)
            {
                
                case 1: 
                    cameraAnimator.SetInteger("Camera", cameraTwo);
                    thisTrigger = cameraTrigger.Cam2toCam1;
                    DetermineCameraTransition(thisTrigger);
                    break;
                case 2: 
                    cameraAnimator.SetInteger("Camera", cameraTwo);
                    thisTrigger = cameraTrigger.Cam1toCam2;
                    DetermineCameraTransition(thisTrigger);
                    break;
                default: Debug.LogError("No Camera Selected"); break;
            }
        }
    }


    public void DetermineCameraTransition(cameraTrigger cam)
    {
        int i = (int)cam;

        switch(i)
        {
            case 0:
                cameraOne = 1;
                cameraTwo = 2;
                break;
            case 1:
                cameraOne = 2;
                cameraTwo = 1;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    
    public void CheckPlayerWithinBounds(cameraTrigger cam, Vector3 playerPosition)
    {
        int i = (int)cam;

        switch(i)
        {
            case 0:
                if(playerPosition.x >= this.transform.position.x)
                {
                    cameraAnimator.SetInteger("Camera", 2);
                }
                else
                {
                    cameraAnimator.SetInteger("Camera", 1);
                }
                break;
            case 1:
                if(playerPosition.x <= this.transform.position.x)
                {
                    cameraAnimator.SetInteger("Camera", 1);
                }
                else
                {
                    cameraAnimator.SetInteger("Camera", 2);
                }
                break;
            default:
                break;
        }
    }
    
}
