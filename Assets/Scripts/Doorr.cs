using UnityEngine;

public class Doorr : MonoBehaviour
{
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (gameObject != null)
        {
            audio.Play();
        }
    }
}
