using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{


    public static ControlsManager CM;


    public KeyCode up { get; set; }
    public KeyCode down { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode interact { get; set; }



    private void Awake()
    {
        if (CM == null)
        {
            DontDestroyOnLoad(gameObject);
            CM = this;
        }
        else if (CM != null)
        {
            Destroy(gameObject);
        }

        /*Assign each keycode when the game starts.
        * Loads data from PlayerPrefs so if a user quits the game,
        * their bindings are loaded next time. Default values
        * are assigned to each Keycode via the second parameter
        * of the GetString() function
        */

        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "Space"));
    }
}
