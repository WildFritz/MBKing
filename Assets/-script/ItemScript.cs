using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//** FInd player and detect collision - destroy me

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {
    //        player.GetComponent<PlayerScript>().itemsCollected++;
    //        Destroy(gameObject);
    //       // Destroy(GameObject.Find("door"));
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerScript>().itemsCollected++;
            Destroy(gameObject);
            // Destroy(GameObject.Find("door"));
        }
    }
}
