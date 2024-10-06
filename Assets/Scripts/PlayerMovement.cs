using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float moveSpeed;
    public Rigidbody2D RB;
    public SpriteRenderer SR;

    private Animator anim;
    public Sprite[] playerD;
    public Animator wpnAnim;

    public GameObject hurtEffect;
    public GameObject walkEffect;

    private bool isKnockingBack;

    public AudioClip walk;

    public float knockBackTime, knockBackForce;
    private float knockBackCounter;
    private Vector2 knockDir;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SR = GetComponent<Sprite>();
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    public void Movement()
    {
        if (!isKnockingBack)
        {
            //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), (transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime), transform.position.z);

            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
            anim.SetFloat("Speed", RB.velocity.magnitude);

            if (RB.velocity != Vector2.zero)
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    SR.sprite = playerD[0];
                    Instantiate(walkEffect, transform.position, transform.rotation);
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        SR.flipX = true;
                        wpnAnim.SetFloat("dirX", -1f);
                        wpnAnim.SetFloat("dirY", 0f);
                    }
                    else
                    {
                        SR.flipX = false;
                        wpnAnim.SetFloat("dirX", 1f);
                        wpnAnim.SetFloat("dirY", 0f);
                    }
                }
                else
                {
                    if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        Instantiate(walkEffect, transform.position, transform.rotation);
                        SR.sprite = playerD[1];
                        wpnAnim.SetFloat("dirX", 0f);
                        wpnAnim.SetFloat("dirY", -1f);
                    }
                    else
                    {
                        Instantiate(walkEffect, transform.position, transform.rotation);
                        SR.sprite = playerD[2];
                        wpnAnim.SetFloat("dirX", 0f);
                        wpnAnim.SetFloat("dirY", 1f);
                    }
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            RB.velocity = knockDir * knockBackForce;
            
            if(knockBackCounter <= 0)
            {
                isKnockingBack = false;
            }
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            wpnAnim.SetTrigger("Attack");
        }
    }

    public void PlayerHit(Vector3 kPos)
    {
        knockBackCounter = knockBackTime;
        isKnockingBack = true;

        knockDir = transform.position - kPos;
        knockDir.Normalize();

        Instantiate(hurtEffect, transform.position, transform.rotation);
    }
}
