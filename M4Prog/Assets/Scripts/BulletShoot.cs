using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
