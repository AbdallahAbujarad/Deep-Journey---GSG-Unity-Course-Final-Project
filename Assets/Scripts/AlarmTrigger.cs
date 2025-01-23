using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public GameObject msg;
    public GameObject door;
    private AudioSource alarmAudioHandler;
    public AudioSource doorAudioHandler;
    private bool canClick = false;
    private void Start()
    {
        alarmAudioHandler = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject != null)
        {
            msg.SetActive(true);
            canClick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && gameObject != null)
        {
            msg.SetActive(false);
            canClick = false;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject != null && canClick)
        {
            msg.SetActive(false);
            door.SetActive(false);
            doorAudioHandler.Play();
            alarmAudioHandler.Stop();
            Destroy(gameObject);
        }
    }
}

