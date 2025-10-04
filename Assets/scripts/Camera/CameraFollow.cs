using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void UpdateCamera()
    {
        playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
    }
}
