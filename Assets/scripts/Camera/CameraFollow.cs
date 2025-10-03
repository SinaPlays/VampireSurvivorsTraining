using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerPosition;

    void Update()
    {
        playerPosition = player.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
    }
}
