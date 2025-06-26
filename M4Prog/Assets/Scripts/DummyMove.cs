using UnityEngine;

public class DummyMove : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 10, 10 - -10) + -10, transform.position.y, transform.position.z);
    }
}
