using System.Collections;
using UnityEngine;

public class RedManScript : MonoBehaviour
{
    Vector3 TargetCorner;
    public int speed;
    public bool isLeft;
    public bool isRight;
    public Vector3 rightCorner;
    public Vector3 leftCorner;

    private void Start()
    {
        if (isLeft)
        {
            TargetCorner = leftCorner;
        }
        if (isRight)
        {
            TargetCorner = rightCorner;
        }
    }

    private bool coroutineStarted = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !coroutineStarted)
        {
            StartCoroutine(RotateHand());
        }
    }
    IEnumerator RotateHand()
    {
        while (true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(TargetCorner), Time.deltaTime * speed);
            yield return null;
        }
    }
}
