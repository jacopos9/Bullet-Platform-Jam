using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce;
    public bool onGround = true;
    public bool isRight;
    public bool isLeft;

    public Rigidbody rb;
    public GameObject shotPoint;

    public void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(Vector2.right.x * speed * h, rb.velocity.y);

        rb.velocity = direction;

        if (direction.x < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
            isLeft = true;
            isRight = false;
        }

        if (direction.x > 0)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
            isRight = true;
            isLeft = false;
        }
    }

    public void Jumping()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse); // sistemare il salto
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag =="Bullet")
        {
            onGround = true;
        }
    }
    private void Update()
    {
        Movement();
        Jumping();

        if (isLeft)
        {
            shotPoint.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }

        if (isRight)
        {
            shotPoint.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
