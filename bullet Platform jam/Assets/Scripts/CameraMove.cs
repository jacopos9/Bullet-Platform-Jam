using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
  
    void FollowPlayer()
    {
        transform.position = target.transform.position + distance;
    }

    private void Update()
    {
        FollowPlayer();
    }

}
