using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50f;
    public Rigidbody rb;
    PlayerController playerController;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isRight)
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

        if (playerController.isLeft)
        {
            
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed = 0f;

            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ 
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }
    
}
