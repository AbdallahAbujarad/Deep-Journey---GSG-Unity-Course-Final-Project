using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Movement Vars
    Rigidbody rb;
    Coroutine movementCor;
    float jumpPower = 5;
    bool isJumped;
    bool isMoveActive = true;

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
    void FixedUpdate()
    {
        if (isCamActive)
        {
            CamRotLate();
        }
        if (isMoveActive)
        {
            Move();
        }
    }
    void Move()
    {
        float speed = 2f;
        if (Input.GetKey(KeyCode.LeftShift) && !isJumped)
        {
            speed = 4;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(-transform.forward * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumped = true;
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

