using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D RB;
    public Animator anim;

    public float moveSpeed;

    public float waitTime, moveTime;
    private float waitCounter, moveCounter;

    private Vector2 moveDir;

    public bool shouldChase;
    private bool isChasing;
    public float chaseSpeed, rangeToChase, waitAfterHit;

    public int damageToDeal;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = Random.Range(waitTime * .75f, waitTime * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChasing)
        {
            if (waitCounter > 0)
            {
                waitCounter = waitCounter - Time.deltaTime;
                RB.velocity = Vector2.zero;

                if (waitCounter <= 0)
                {
                    moveCounter = Random.Range(moveTime * .75f, moveTime * 1.25f);

                    anim.SetBool("Moving", true);

                    moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    moveDir.Normalize();
                }
            }
            else
            {
                moveCounter -= Time.deltaTime;

                RB.velocity = moveDir * moveSpeed;

                if (moveCounter <= 0)
                {
                    waitCounter = Random.Range(waitTime * .75f, waitTime * 1.25f);

                    anim.SetBool("Moving", false);
                }

                if (shouldChase)
                {
                    if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < rangeToChase)
                    {
                        isChasing = true;
                    }
                }
            }
        }
        else
        {
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
                RB.velocity = Vector2.zero;

                if (waitCounter <= 0)
                {
                    anim.SetBool("Moving", true);
                }
            }
            else
            {
                moveDir = PlayerMovement.instance.transform.position - transform.position;
                moveDir.Normalize();

                RB.velocity = moveDir * chaseSpeed;
            }
            if(Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > rangeToChase)
            {
                isChasing = false;
                waitCounter = waitTime;

                anim.SetBool("Moving", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isChasing == true)
            {
                waitCounter = waitAfterHit;
                anim.SetBool("Moving", false);

                PlayerMovement.instance.PlayerHit(transform.position);
                PlayerHealth.instance.DamagePlayer(damageToDeal);
            }
        }
    }
}
