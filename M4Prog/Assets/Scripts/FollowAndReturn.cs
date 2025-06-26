using UnityEngine;

public class FollowAndReturnFollower : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(0, 1.2f, 0);

    public Transform playerPosition;

    private void Update()
    {
        if (Vector3.Distance(playerPosition.position, startPosition) > 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * 5);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition.position, 0.005f);
        }
    }
}
