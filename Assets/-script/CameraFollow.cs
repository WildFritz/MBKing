using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    //Vector3 offset;

    void Start()
    {
      //  offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("GameManager").GetComponent<GameManager>().hasKey = false;
        transform.position = Vector3.Lerp(new Vector3(transform.position.x,transform.position.y,-5), new Vector3(player.transform.position.x, player.transform.position.y,-5),  0.07f);
    }
}
