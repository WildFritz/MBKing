using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    //if(col.gameObject.tag == "Enemy")
    //    //{
    //    //    col.GetComponent<EnemyScript>().EnemyHit();
    //    //}
    //    if(col.gameObject.tag == "Player")
    //    {
    //        col.GetComponent<PlayerScript>().GameOver();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("We Beefin");
            //player.GetComponent<PlayerScript>().
            SceneManager.LoadScene(6);
        }
    }
}
