using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("Shoot", 1.5f);
        }
    }
}
