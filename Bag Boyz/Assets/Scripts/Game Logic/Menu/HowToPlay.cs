using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{

    public Sprite[] tutorialSprites;
    private Image tutorialImage;

    private int currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        currentTutorial = 0;

        tutorialImage = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        tutorialImage.sprite = tutorialSprites[currentTutorial];
    }

    // Update is called once per frame
    void Update()
    {
        tutorialImage.sprite = tutorialSprites[currentTutorial];
    }


    public void NextTutorial()
    {
        if (currentTutorial < (tutorialSprites.Length - 1))
        {
            currentTutorial += 1;
        }
    }


    public void PreviousTutorial()
    {
        if (currentTutorial > 0)
        {
            currentTutorial -= 1;
        }
        else
        {
            currentTutorial = 0;
        }
    }
}
