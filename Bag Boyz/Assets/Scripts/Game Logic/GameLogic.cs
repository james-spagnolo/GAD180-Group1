using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    public GameObject itemFour;
    public GameObject itemFive;

    private int itemsLeft = 5;
    
    // Start is called before the first frame update
    void OnValidate()
    {
        itemOne.transform.GetChild(0).gameObject.SetActive(true);
        itemTwo.transform.GetChild(0).gameObject.SetActive(true);
        itemThree.transform.GetChild(0).gameObject.SetActive(true);
        itemFour.transform.GetChild(0).gameObject.SetActive(true);
        itemFive.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void CollectedItem()
    {
        itemsLeft -= 1;

        CheckItemsLeft();
    }

    void CheckItemsLeft()
    {
        if (itemsLeft <= 0)
        {
            //Win State
        }
    }
}
