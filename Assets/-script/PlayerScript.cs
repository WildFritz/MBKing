using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //run left and right and up and downbat speed
    public float H;
    public float V;
    public float speed = 0.5f;
    bool facingRight;

    public int itemsCollected;
    public Animator anim;
   

    public int PlayerHealth = 1;
    public Collider2D AttackCol;
    public bool playerDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        itemsCollected = 0;
        anim = GetComponent<Animator>();
       // AttackCol = GameObject.Find("Attackcollider").GetComponent<Collider2D>();
        //AttackCol.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // track input adn convert to motion
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        if(!playerDead)
        {
            MovePlayer(H, V);
            FlipPlayer(H);
        }
        else
        {
            StartCoroutine(PlayDead());
        }
        MovePlayer(H, V);
        FlipPlayer(H);

        if(itemsCollected == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("exit"));
        }

        //if (Input.GetKeyDown("f") && attacking == false)
        //{
        //    attacking = true;
        //    attackTimer = attackCD;
        //    AttackCol.enabled = true;
        //}

         //if (attacking)
         // {
         //    if (attackTimer > 0)
         //   {
         //          //count down
         //          attackTimer -= Time.deltaTime;
         //   }
         //     else
         //      {
         //         attacking = false;
         //         AttackCol.enabled = false;
         //   }
         // }
         //   anim.SetBool("attack", attacking);
        
    }


    void MovePlayer(float H, float V)
    {
        transform.Translate(new Vector2(H, V) * Time.deltaTime * speed);
        //anim player to run
        if(H != 0 || V != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            
        }
    }


    //flip player when moving neg x
    void FlipPlayer(float H)
    {
        if(H > 0 && !facingRight || H < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 playXScale = transform.localScale;
            playXScale.x *= -1;
            transform.localScale = playXScale;
        }
    }

    public void GameOver()
    {
        if(PlayerHealth <= 0)
        {
            playerDead = true;
        }
        else
        {
            PlayerHealth--;
            //playerHearts[PlayerHealth - 1].Setactive(false);
        }
    }

    IEnumerator PlayDead()
    {
        //anim.SetBool("dead", false);
        //anim.SetBool("run", false);
        //anim.SetBool("Attack", false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(6);
    }
}
