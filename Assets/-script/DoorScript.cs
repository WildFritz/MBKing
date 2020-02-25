using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        //if(player.GetComponent<PlayerScript>().itemsCollected)
    //        //{
    //        //    Destroy(gameObject);
    //        //}
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //player.GetComponent<PlayerScript>().itemsCollected++;
            Destroy(gameObject);
        }
    }
}
