using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;
    void LateUpdate()
    {
        transform.position = player.position + Vector3.up;
    }
}
