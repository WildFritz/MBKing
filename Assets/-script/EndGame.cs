using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//**** Moves winner to win scene
public class EndGame : MonoBehaviour
{

    public int sceneIndex = 2;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

}
