using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStats : MonoBehaviour
{

    int GotKey;

    public GameObject tGotKey;

    // Start is called before the first frame update
    void Start()
    {
        //declare a player pref int
        GotKey = PlayerPrefs.GetInt("Key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
