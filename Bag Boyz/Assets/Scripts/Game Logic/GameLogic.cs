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
    public GameObject[] checkoutObjects;

    public List<GameObject> itemPool = new List<GameObject>();

    public GameObject[] shoppingList;

    /*
    // Set 5 items in Unity Inspector
    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    public GameObject itemFour;
    public GameObject itemFive;
    */

    public List<GameObject> randomItems = new List<GameObject>();

    /*
    //Randomly Set 5 items
    public GameObject randomItemOne;
    public GameObject randomItemTwo;
    public GameObject randomItemThree;
    public GameObject randomItemFour;
    public GameObject randomItemFive;
    */

    private AudioController audioController;

    // Text displayed on Shopping List on UI
    public Text shoppingText;

    // Text displaying timeLeft on UI
    public Text timerText;

    //Text displaying score on UI
    public Text scoreText;

    // Amount in Seconds of timer
    public float timeLeft;

    // Is it time to checkout
    public bool checkout = false;

    private bool playSound = false;

    // Items Left to Collect
    private int itemsLeft;

    private int itemsToCollect = 5;

    private int score = 0;

    private List<string> itemNames = new List<string>();

    // 5 Item Names (for displaying text to UI)
    private string itemOneName;
    private string itemTwoName;
    private string itemThreeName;
    private string itemFourName;
    private string itemFiveName;

    private string randomItemsList;




    // Start is called before the first frame update
    void OnValidate()
    {
        interactionObjects = GameObject.FindGameObjectsWithTag("Interaction");
        groceryObjects = GameObject.FindGameObjectsWithTag("Grocery");
        gameOverUI = GameObject.FindGameObjectsWithTag("GameOver");
        winScreen = GameObject.FindGameObjectsWithTag("WinScreen");
        checkoutObjects = GameObject.FindGameObjectsWithTag("Checkout");

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
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        Time.timeScale = 1;

        itemsLeft = itemsToCollect;

        DisableGameOverUI();
        DisableWinScreen();
        DisableCheckout();
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

        //Update Shopping List
        shoppingText.text = itemOneName + "\n" + itemTwoName + "\n" + itemThreeName + "\n" + itemFourName + "\n" + itemFiveName;

        //Start counting down from timeLeft in seconds
        timeLeft -= Time.deltaTime;


        //If timeLeft reaches below zero
        if (timeLeft <= 0)
        {
            //Launch GameOver
            GameOver();
        }

        int roundTimeLeft = (int)Math.Round(timeLeft);
        string timeLeftText = roundTimeLeft.ToString();
        timerText.text = timeLeftText;
    }


    private void SetupRandomItemList()
    {


        // Generate and add items and their names to the lists
        // itemsToCollect is the amount of items generated
        for (int item = 0; item < itemsToCollect; item++)
        {


            //Pick a random item from the grocery list
            GameObject collectionItem = itemPool[Random.Range(0, itemPool.Count)];

            //Get that items name
            string itemName = collectionItem.transform.GetChild(0).GetComponent<Interactable>().itemName;

            //Debug.Log("itemName: " + itemName);
            
            
            randomItems.Add(collectionItem); //Add the item to randomItems
                 
            
            itemNames.Add(itemName);  //Add the name to item names


            itemPool.Remove(collectionItem); //Removes the item from list of items to pick from


            collectionItem.transform.GetChild(0).gameObject.SetActive(true); //Sets this object to be interactable

            

        }

        /*
        randomItemOne = itemPool[Random.Range(0, itemPool.Count)];
        itemPool.Remove(randomItemOne);
        randomItemTwo = itemPool[Random.Range(0, itemPool.Count)];
        itemPool.Remove(randomItemTwo);
        randomItemThree = itemPool[Random.Range(0, itemPool.Count)];
        itemPool.Remove(randomItemThree);
        randomItemFour = itemPool[Random.Range(0, itemPool.Count)];
        itemPool.Remove(randomItemFour);
        randomItemFive = itemPool[Random.Range(0, itemPool.Count)];
        itemPool.Remove(randomItemFive);

        //Activate Interaction for 5 items
        randomItemOne.transform.GetChild(0).gameObject.SetActive(true);
        randomItemTwo.transform.GetChild(0).gameObject.SetActive(true);
        randomItemThree.transform.GetChild(0).gameObject.SetActive(true);
        randomItemFour.transform.GetChild(0).gameObject.SetActive(true);
        randomItemFive.transform.GetChild(0).gameObject.SetActive(true);

        */

        itemOneName = itemNames[0];
        itemTwoName = itemNames[1];
        itemThreeName = itemNames[2];
        itemFourName = itemNames[3];
        itemFiveName = itemNames[4];


        randomItemsList = itemOneName + "\n" + itemTwoName + "\n" + itemThreeName + "\n" + itemFourName + "\n" + itemFiveName;

        shoppingText.text = randomItemsList;
    }


    private void SetupGroceryList()
    {
        foreach(GameObject groceryObject in GameObject.FindGameObjectsWithTag("Grocery"))
        {
            itemPool.Add(groceryObject);
        }
    }


    public void CollectedItem(Item itemCollected)
    {
        audioController.PlayCollectSound();

        itemsLeft -= 1;

        CheckItemCollected(itemCollected);

        Debug.Log("Items Left: " + itemsLeft);

        if (itemsLeft <= 0)
        {
            //Launch Checkout State
            Checkout();
        }
    }


    void CheckItemCollected(Item item)
    {
        if (item.ItemName == itemOneName)
        {
            itemOneName = "<color=green>" + itemOneName + "</color>";
        }
        else if (item.ItemName == itemTwoName)
        {
            itemTwoName = "<color=green>" + itemTwoName + "</color>";
        }
        else if (item.ItemName == itemThreeName)
        {
            itemThreeName = "<color=green>" + itemThreeName + "</color>";
        }
        else if (item.ItemName == itemFourName)
        {
            itemFourName = "<color=green>" + itemFourName + "</color>";
        }
        else if (item.ItemName == itemFiveName)
        {
            itemFiveName = "<color=green>" + itemFiveName + "</color>";
        }
        else
        {
            Debug.Log("Collection Error");
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

        audioController.PauseAudio();

        if (playSound == false)
        {
            audioController.PlayGameOverSound();
            playSound = true;
        }
        

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

    private void Checkout()
    {
        checkout = true;

        //Enable Checkout objects
        foreach (GameObject g in checkoutObjects)
        {
            g.SetActive(true);
        }
    }

    private void DisableCheckout()
    {
        checkout = false;

        //Disable Checkout objects
        foreach (GameObject g in checkoutObjects)
        {
            g.SetActive(false);
        }
    }
    
    public void WinScreen()
    {
        //Pause game
        Time.timeScale = 0;

        audioController.PauseAudio();
        audioController.PlayWinSound();

        score = (int)timeLeft * 10;

        scoreText.text = "Score: " + score;

        Debug.Log("Score: " + score);


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
