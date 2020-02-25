using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//*** March left or right to limit
// if player close follow
//if player really close attack
// if player escapes go home
public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public enum EnemyState { Patrol, Follow, Attack,ReturnToPatrol, Dead};
    public EnemyState CurrentEnemyState;
    public Animator anim;
    public Vector3 leftPosition;  //how far left
    public Vector3 rightPosition;  //how far right
    public Vector3 EnemyStartPosition;  //where I started
    public Transform enemyTransform;  //where I is
    public Transform enemytarget;  //where player is
    public int EnemyHealth = 2;
    public bool Dead = false;
    public Collider2D EnemyAttackCol;
    public bool enemyAttacking = false;
    public float enemyAttactTimer = 0;
    public float enemyCD = 1;
    public float patrolDist = 3;


    // Start is called before the first frame update
    void Start()
    {
       // EnemyAttackCol = GameObject.Find("Enemycollider").GetComponent<Collider2D>();
        enemytarget = GameObject.Find("Player").GetComponent<Transform>();
        EnemyStartPosition = new Vector3(transform.position.x, transform.position.y);
        leftPosition = new Vector3(EnemyStartPosition.x + patrolDist, EnemyStartPosition.y);
        rightPosition = new Vector3(EnemyStartPosition.x - patrolDist, EnemyStartPosition.y);
        anim = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        StartCoroutine(Move(leftPosition));
        EnemyAttackCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentEnemyState)
        {
            case EnemyState.Patrol:
                float distToFollow = Vector2.Distance(enemyTransform.position, enemytarget.transform.position);

                if(distToFollow < 5)
                {
                    anim.SetBool("EnAttack", false);
                    anim.SetBool("EnRun", true);
                    StopCoroutine("Move");
                    SetCurrentEnemyState(EnemyState.Follow);
                    EnemyAttackCol.enabled = false;
                }
                break;

            case EnemyState.Follow:
                float distToAttack = Vector2.Distance(enemyTransform.position, enemytarget.transform.position);
                enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, enemytarget.position, 0.03f);
                if(transform.position.x < enemytarget.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                if(distToAttack < 1.5)
                {
                    anim.SetBool("EnAttack", true);
                    anim.SetBool("EnRun", false);
                    SetCurrentEnemyState(EnemyState.Attack);
                    EnemyAttackCol.enabled = true;
                }

                if (distToAttack > 7)
                {
                    anim.SetBool("EnAttack", false);
                    anim.SetBool("EnRun", true);
                    SetCurrentEnemyState(EnemyState.ReturnToPatrol);
                }
            break;


            case EnemyState.Attack:
                float distToFollowAgain = Vector2.Distance(enemyTransform.position, enemytarget.transform.position);


                if (transform.position.x < enemytarget.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                if(!enemyAttacking)
                {
                    enemyAttacking = true;
                    enemyAttactTimer = enemyCD;
                    EnemyAttackCol.enabled = true;
                }

                if (enemyAttacking)
                {
                    if(enemyAttactTimer > 0)
                    {
                        enemyAttactTimer -= Time.deltaTime;
                    }
                    else
                    {
                        enemyAttacking = false;
                        EnemyAttackCol.enabled = false;
                    }
                }


                    if (distToFollowAgain > 4 && distToFollowAgain < 7)
                {
                    anim.SetBool("EnAttack", false);
                    anim.SetBool("EnRun", true);
                    //StopCoroutine("Move");
                    SetCurrentEnemyState(EnemyState.Follow);
                    EnemyAttackCol.enabled = false;
                }
                
                break;


            case EnemyState.ReturnToPatrol:
                enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, EnemyStartPosition, 0.03f);
                if(transform.position.x < EnemyStartPosition.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (enemyTransform.position.x == EnemyStartPosition.x && enemyTransform.position.y == EnemyStartPosition.y)
                {
                   // StartCoroutine(Move(leftPosition));
                    anim.SetBool("EnAttack", false);
                    anim.SetBool("EnRun", true);
                    transform.localScale = new Vector3(1, 1, 1);
                    StartCoroutine(Move(leftPosition));
                    SetCurrentEnemyState(EnemyState.Patrol);
                    EnemyAttackCol.enabled = true;
                }
                break;
        }
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target.x - transform.localPosition.x)) > 2)
        {
            Vector3 direction = target.x == rightPosition.x ? Vector2.left : Vector2.right;
            transform.localPosition += direction * Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Vector3 exScale = transform.localScale;
        exScale.x *= -1;

        transform.localScale = exScale;
        Vector3 nextTarget = target.x == rightPosition.x ? leftPosition : rightPosition;
        StartCoroutine("Move", nextTarget);
    }

    void SetCurrentEnemyState(EnemyState state)
    {
        CurrentEnemyState = state;
    }

    public void EnemyHit()
    {
        if(EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            EnemyHealth--;
        }
    }
}
