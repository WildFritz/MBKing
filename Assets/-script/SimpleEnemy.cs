using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    //right most GameObject
    //left most GameObject
    //speed float
    //start position Vec3
    // right heading Bool
    public GameObject rightMost;
    public GameObject leftMost;
    public float speed = 0.1f;
    public Vector3 startPosition;
    public Transform start;
    public bool rightHeading = false;


    // Start is called before the first frame update
    void Start()
    {
        //set start pos
        // startPosition = new Vector3(transform.position.x, transform.position.y);
        startPosition = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHeading == false)
        {
            //transform translate to right most
            transform.Translate(Vector3.right * speed);
            transform.localScale = new Vector3(3, 3, 3);
        }
        else
        {
            //transfomr translate to left most
            transform.Translate(Vector3.left * speed);
            transform.localScale = new Vector3(-3, 3, 3);
        }
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if(col.gameObject.tag == "Right")
    //    {
    //        //right most is true
    //        rightHeading = true;
    //    }

    //    if(col.gameObject.tag == "Left")
    //    {
    //        // right most is false
    //        rightHeading = false;

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Right")
        {
            //right most is true
            rightHeading = true;
        }

        if (col.gameObject.tag == "Left")
        {
            // right most is false
            rightHeading = false;

        }
    }


}
