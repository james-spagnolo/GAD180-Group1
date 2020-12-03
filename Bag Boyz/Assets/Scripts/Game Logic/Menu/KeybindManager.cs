using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindManager : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, interact;

    private GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Interact", KeyCode.E);

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        interact.text = keys["Interact"].ToString();
    }


    private void OnGUI()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
