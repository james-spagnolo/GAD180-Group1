using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public GameObject[] groceryObjects;

    // Set 5 items in Unity Inspector
    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    public GameObject itemFour;
    public GameObject itemFive;

    // Text displayed on Shopping List on UI
    public Text shoppingText;

    // Amount in Seconds of timer
    public float timeLeft = 60.0f;

    // Items Left to Collect
    private int itemsLeft = 5;

    // 5 Items
    private string itemOneName;
    private string itemTwoName;
    private string itemThreeName;
    private string itemFourName;
    private string itemFiveName;

    // Start is called before the first frame update
    void OnValidate()
    {
        groceryObjects = GameObject.FindGameObjectsWithTag("Interaction");

        DisableItems();

        //Find the InteractionCircles attached to the 5 items
        itemOne.transform.GetChild(0).gameObject.SetActive(true);
        itemTwo.transform.GetChild(0).gameObject.SetActive(true);
        itemThree.transform.GetChild(0).gameObject.SetActive(true);
        itemFour.transform.GetChild(0).gameObject.SetActive(true);
        itemFive.transform.GetChild(0).gameObject.SetActive(true);

        //Find the Names of the 5 items
        itemOneName = itemOne.name;
        itemTwoName = itemTwo.name;
        itemThreeName = itemThree.name;
        itemFourName = itemFour.name;
        itemFiveName = itemFive.name;

        shoppingText.text = itemOneName + "\n" + itemTwoName + "\n" + itemThreeName + "\n" + itemFourName + "\n" + itemFiveName;
    }


    private void Update()
    {
        //Start counting down from timeLeft in seconds
        timeLeft -= Time.deltaTime;

        //If timeLeft reaches below zero
        if (timeLeft < 0)
        {
            //Launch GameOver
            GameOver();
        }
    }

    private void GameOver()
    {
        //Lose State
        Debug.Log("YOU LOSE!");
    }

    public void CollectedItem()
    {
        itemsLeft -= 1;

        Debug.Log("Items Left: " + itemsLeft);

        CheckItemsLeft();
    }

    void CheckItemsLeft()
    {
        if (itemsLeft <= 0)
        {
            //Win State
            Debug.Log("YOU WIN!");
        }
    }

    void DisableItems()
    {
        foreach (GameObject g in groceryObjects)
        {
            g.SetActive(false);
        }
    }

}
