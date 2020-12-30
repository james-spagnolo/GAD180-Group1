using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{


    Transform controlsArea;

    Event keyEvent;

    Text buttonText;

    KeyCode newKey;

    bool waitingForKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

    private GameObject currentKey = null;


    // Start is called before the first frame update
    void Start()
    {


        controlsArea = transform.Find("ControlsPanel").transform.Find("ControlsFrame").transform.Find("ControlsArea");

        waitingForKey = false;


        /*iterate through each child of the panel and check

         * the names of each one. Each if statement will

         * set each button's text component to display

         * the name of the key that is associated

         * with each command. Example: the ForwardKey

         * button will display "W" in the middle of it

         */

        for (int i = 0; i < controlsArea.childCount; i++)
        {

            if (controlsArea.GetChild(i).name == "UpButton")

                controlsArea.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.up.ToString();

            else if (controlsArea.GetChild(i).name == "DownButton")

                controlsArea.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.down.ToString();

            else if (controlsArea.GetChild(i).name == "LeftButton")

                controlsArea.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.left.ToString();

            else if (controlsArea.GetChild(i).name == "RightButton")

                controlsArea.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.right.ToString();

            else if (controlsArea.GetChild(i).name == "InteractButton")

                controlsArea.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.interact.ToString();

        }

    }

    private void OnGUI()
    {
        /*keyEvent dictates what key our user presses

       * bt using Event.current to detect the current

       * event

       */


        //Executes if a button gets pressed and

        //the user presses a key


        
        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey)
        {

                newKey = keyEvent.keyCode; //Assigns newKey to the key user presses

                waitingForKey = false;

                currentKey.GetComponent<Image>().color = normal;

                currentKey = null;

        }

    }





    /*Buttons cannot call on Coroutines via OnClick().

     * Instead, we have it call StartAssignment, which will

     * call a coroutine in this script instead, only if we

     * are not already waiting for a key to be pressed.

     */



    public void SetCurrentKey(GameObject keyClicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = keyClicked;
        currentKey.GetComponent<Image>().color = selected;
    }


    public void StartAssignment(string keyName)

    {

        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }

    }



    //Assigns buttonText to the text component of

    //the button that was pressed

    public void SendText(Text text)

    {

        buttonText = text;

    }



    //Used for controlling the flow of our below Coroutine

    IEnumerator WaitForKey()

    {

        while (!keyEvent.isKey)

            yield return null;

    }



    /*AssignKey takes a keyName as a parameter. The

     * keyName is checked in a switch statement. Each

     * case assigns the command that keyName represents

     * to the new key that the user presses, which is grabbed

     * in the OnGUI() function, above.

     */

    public IEnumerator AssignKey(string keyName)

    {

        waitingForKey = true;



        yield return WaitForKey(); //Executes endlessly until user presses a key



        switch (keyName)

        {

            case "up":

                ControlsManager.CM.up = newKey; //Set forward to new keycode

                buttonText.text = ControlsManager.CM.up.ToString(); //Set button text to new key

                PlayerPrefs.SetString("upKey", ControlsManager.CM.up.ToString()); //save new key to PlayerPrefs

                break;

            case "down":

                ControlsManager.CM.down = newKey; //set backward to new keycode

                buttonText.text = ControlsManager.CM.down.ToString(); //set button text to new key

                PlayerPrefs.SetString("downKey", ControlsManager.CM.down.ToString()); //save new key to PlayerPrefs

                break;

            case "left":

                ControlsManager.CM.left = newKey; //set left to new keycode

                buttonText.text = ControlsManager.CM.left.ToString(); //set button text to new key

                PlayerPrefs.SetString("leftKey", ControlsManager.CM.left.ToString()); //save new key to playerprefs

                break;

            case "right":

                ControlsManager.CM.right = newKey; //set right to new keycode

                buttonText.text = ControlsManager.CM.right.ToString(); //set button text to new key

                PlayerPrefs.SetString("rightKey", ControlsManager.CM.right.ToString()); //save new key to playerprefs

                break;

            case "interact":

                ControlsManager.CM.interact = newKey; //set jump to new keycode

                buttonText.text = ControlsManager.CM.interact.ToString(); //set button text to new key

                PlayerPrefs.SetString("interactKey", ControlsManager.CM.interact.ToString()); //save new key to playerprefs

                break;

        }



        yield return null;

    }
}

