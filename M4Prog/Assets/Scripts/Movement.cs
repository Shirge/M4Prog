
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rigidbody;
    private Vector3 moveDirection;
    private bool onFloor;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        onFloor = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            return;
        }
        else
        {
            onFloor = false;
        }
    }

    private void FixedUpdate()
    {
        // Gravity * 8
        if (!onFloor)
            rigidbody.AddForce(Physics.gravity * 7);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rigidbody.AddForce(0, 50f, 0, ForceMode.Impulse);
            onFloor = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            speed = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            speed = 8;
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0));

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            rigidbody.linearVelocity = new Vector3(0, rigidbody.linearVelocity.y, 0);
            return;
        }
        else
        {
            moveDirection = Input.GetAxisRaw("Vertical") * transform.forward * speed * Time.deltaTime;
            rigidbody.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
    }
}