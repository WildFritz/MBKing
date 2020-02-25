using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//**** Moves winner to win scene
public class MoveLevel1 : MonoBehaviour
{
    // player object
    // player health
    // item bool

    private void Start()
    {
        // get player
        //get player health
        
    }
    public int sceneIndex = 2;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            // PlayerPrefs.SetInt(P_Health)
            // PlayerPrefs.SetBool(item)

            SceneManager.LoadScene(sceneIndex);
        }
    }

}
