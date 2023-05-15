using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float speedR=5;
    [SerializeField] private float jf=10;
    [SerializeField] private LayerMask lm;
    Vector2 move;

    public bool isGrounded;
    public Joystick js;
    public float x = 0;
    public bool walk;

    // Start is called before the first frame update
    void Start()
    {
        walk = isGrounded;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        x=Input.GetAxis("Horizontal");
#elif UNITY_ANDROID&&UNITY_EDITOR==false
        x = js.Horizontal;
#endif
        move = Quaternion.Euler(0,transform.eulerAngles.y,0)*new Vector2(x,0);
        Vector2 movedir = move.normalized;

        rb2d.velocity = movedir * speed + new Vector2(0, rb2d.velocity.y);
        if (movedir!=Vector2.zero)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
        if (x>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (isGrounded==true&&Input.GetButton("Jump"))
        {
            jump();
        }
    }
    public void jump()
    {
        if (isGrounded == true)
        {
            rb2d.AddForce(Vector2.up * jf, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Collider2D>().CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Collider2D>().CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.transform.tag == "Ground")
        //{
        //    isGrounded = true;
        //}
        if (collision.transform.tag=="Jembatan")
        {
            isGrounded = true;
            gameObject.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.transform.tag == "Ground")
        //{
        //    isGrounded = false;
        //}
        if (collision.transform.tag == "Jembatan")
        {
            isGrounded = false;
            gameObject.transform.parent = null;
        }
    }
}
