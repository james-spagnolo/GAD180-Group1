using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{

    public Sprite[] tutorialSprites;

    private Image tutorialImage;
    private Transform nextButton;
    private Transform previousButton;

    private int currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        currentTutorial = 0;

        tutorialImage = this.GetComponent<Image>();
        tutorialImage.sprite = tutorialSprites[currentTutorial];

        nextButton = transform.Find("NextImageButton");
        previousButton = transform.Find("PreviousImageButton");
    }

    // Update is called once per frame
    void Update()
    {
        tutorialImage.sprite = tutorialSprites[currentTutorial];

        CheckButtons();
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


    private void CheckButtons()
    {

        if (currentTutorial == 0)
        {
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
        }

        if (currentTutorial == (tutorialSprites.Length - 1))
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }
    }
}
