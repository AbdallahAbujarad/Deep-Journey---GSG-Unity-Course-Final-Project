using System.Collections;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Movement Vars
    Rigidbody rb;
    Coroutine movementCor;
    float jumpPower = 5;
    bool isJumped;

    //Camera Vars
    float mouseSensetivity = 20;
    float xRotation;
    float yRotation;
    bool isCamActive = true;

    public Transform camTran;

    void Start()
    {
        //Movement
        rb = GetComponent<Rigidbody>();
        movementCor = StartCoroutine(Move());
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //Camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (isCamActive)
        {
            CamRot();
        }
    }
    void LateUpdate()
    {
        if (isCamActive)
        {
            CamRotLate();
        }
    }
    IEnumerator Move()
    {
        while (true)
        {

            float speed = 2f;
            Vector3 movement = new Vector3();
            if (Input.GetKey(KeyCode.LeftShift) && !isJumped)
            {
                speed = 4;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movement += transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement -= transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement -= transform.right * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += transform.right * speed;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
            {
                rb.velocity = Vector3.up * jumpPower;
                isJumped = true;
            }
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
            yield return null;
        }
    }
    void CamRot()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensetivity * Time.deltaTime;
        xRotation += mouseX;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90, 90);
    }
    void CamRotLate()
    {
        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        camTran.rotation = Quaternion.Euler(yRotation, xRotation, 0);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumped = false;
        }
    }
}

