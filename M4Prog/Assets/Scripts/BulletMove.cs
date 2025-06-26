using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Transform dummyPosition;

    private void Start()
    {
        dummyPosition = GameObject.FindGameObjectWithTag("Dummy").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, dummyPosition.position, Time.deltaTime * 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == "Dummy") {
            Destroy(this.gameObject);
        }
    }
}
