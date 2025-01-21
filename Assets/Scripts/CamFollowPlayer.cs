using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;
    void FixedUpdate()
    {
        transform.position = player.position + Vector3.up * 3;
    }
}
