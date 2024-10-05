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
        //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), (transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime), transform.position.z);

        RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        anim.SetFloat("Speed", RB.velocity.magnitude);

        if(RB.velocity != Vector2.zero)
        {
            if (Input.GetAxisRaw("Horizontal")!=0)
            {
                SR.sprite = playerD[0];
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
            }else 
            {
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    SR.sprite = playerD[1];
                    wpnAnim.SetFloat("dirX", 0f);
                    wpnAnim.SetFloat("dirY", -1f);
                }
                else
                {
                    SR.sprite = playerD[2];
                    wpnAnim.SetFloat("dirX", 0f);
                    wpnAnim.SetFloat("dirY", 1f);
                }
            }
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            wpnAnim.SetTrigger("Attack");
        }
        else{

        }
    }
}
