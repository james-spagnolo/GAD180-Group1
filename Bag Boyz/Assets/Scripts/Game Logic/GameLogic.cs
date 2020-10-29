using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{

    public GameObject[] interactionObjects;
    public GameObject[] groceryObjects;
    public GameObject[] gameOverUI;
    public GameObject[] winScreen;

    public List<GameObject> groceryList = new List<GameObject>();

    public GameObject[] shoppingList;

    /*
    // Set 5 items in Unity Inspector
    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    public GameObject itemFour;
    public GameObject itemFive;
    */

    //Randomly Set 5 items
    public GameObject randomItemOne;
    public GameObject randomItemTwo;
    public GameObject randomItemThree;
    public GameObject randomItemFour;
    public GameObject randomItemFive;

    // Text displayed on Shopping List on UI
    public Text shoppingText;

    // Amount in Seconds of timer
    public float timeLeft;

    // Items Left to Collect
    private int itemsLeft = 5;

    // 5 Item Names (for displaying text to UI)
    private string itemOneName;
    private string itemTwoName;
    private string itemThreeName;
    private string itemFourName;
    private string itemFiveName;

    // Start is called before the first frame update
    void OnValidate()
    {
        interactionObjects = GameObject.FindGameObjectsWithTag("Interaction");
        groceryObjects = GameObject.FindGameObjectsWithTag("Grocery");
        gameOverUI = GameObject.FindGameObjectsWithTag("GameOver");
        winScreen = GameObject.FindGameObjectsWithTag("WinScreen");

        //Make sure all items are disabled by default
        DisableItems();

        /*
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

        //Display Items needed to the Shopping List
        shoppingText.text = itemOneName + "\n" + itemTwoName + "\n" + itemThreeName + "\n" + itemFourName + "\n" + itemFiveName;
        */
    }

    private void Start()
    {
        Time.timeScale = 1;
        DisableGameOverUI();
        DisableWinScreen();
        SetupGroceryList();
        SetupRandomItemList();

        /*
        //Randomly select 5 items
        randomItemOne = groceryObjects[Random.Range(0, groceryObjects.Length)];
        randomItemTwo = groceryObjects[Random.Range(0, groceryObjects.Length)];
        randomItemThree = groceryObjects[Random.Range(0, groceryObjects.Length)];
        randomItemFour = groceryObjects[Random.Range(0, groceryObjects.Length)];
        randomItemFive = groceryObjects[Random.Range(0, groceryObjects.Length)];
        */

    }


    private void Update()
    {
        //Start counting down from timeLeft in seconds
        timeLeft -= Time.deltaTime;


        //If timeLeft reaches below zero
        if (timeLeft <= 0)
        {
            //Launch GameOver
            GameOver();
        }
    }


    private void SetupRandomItemList()
    {
        randomItemOne = groceryList[Random.Range(0, groceryList.Count)];
        groceryList.Remove(randomItemOne);
        randomItemTwo = groceryList[Random.Range(0, groceryList.Count)];
        groceryList.Remove(randomItemTwo);
        randomItemThree = groceryList[Random.Range(0, groceryList.Count)];
        groceryList.Remove(randomItemThree);
        randomItemFour = groceryList[Random.Range(0, groceryList.Count)];
        groceryList.Remove(randomItemFour);
        randomItemFive = groceryList[Random.Range(0, groceryList.Count)];
        groceryList.Remove(randomItemFive);

        //Activate Interaction for 5 items
        randomItemOne.transform.GetChild(0).gameObject.SetActive(true);
        randomItemTwo.transform.GetChild(0).gameObject.SetActive(true);
        randomItemThree.transform.GetChild(0).gameObject.SetActive(true);
        randomItemFour.transform.GetChild(0).gameObject.SetActive(true);
        randomItemFive.transform.GetChild(0).gameObject.SetActive(true);

        //Setup Names for Items
        itemOneName = randomItemOne.name;
        itemTwoName = randomItemTwo.name;
        itemThreeName = randomItemThree.name;
        itemFourName = randomItemFour.name;
        itemFiveName = randomItemFive.name;

        shoppingText.text = itemOneName + "\n" + itemTwoName + "\n" + itemThreeName + "\n" + itemFourName + "\n" + itemFiveName;
    }


    private void SetupGroceryList()
    {
        foreach(GameObject groceryObject in GameObject.FindGameObjectsWithTag("Grocery"))
        {
            groceryList.Add(groceryObject);
        }
    }


    public void CollectedItem()
    {
        itemsLeft -= 1;

        Debug.Log("Items Left: " + itemsLeft);

        if (itemsLeft <= 0)
        {
            //Launch Win State
            WinScreen();
        }
    }


    void DisableItems()
    {
        foreach (GameObject g in interactionObjects)
        {
            g.SetActive(false);
        }
    }


    private void GameOver()
    {
        //Pause game
        Time.timeScale = 0;

        //Lose State
        foreach (GameObject g in gameOverUI)
        {
            g.SetActive(true);
        }
    }


    private void DisableGameOverUI()
    {
        //Lose State
        foreach (GameObject g in gameOverUI)
        {
            g.SetActive(false);
        }
    }

    
    void WinScreen()
    {
        //Pause game
        Time.timeScale = 0;

        //Win State
        foreach (GameObject g in winScreen)
        {
            g.SetActive(true);
        }
    }


    void DisableWinScreen()
    {
        foreach (GameObject g in winScreen)
        {
            g.SetActive(false);
        }
    }


}
