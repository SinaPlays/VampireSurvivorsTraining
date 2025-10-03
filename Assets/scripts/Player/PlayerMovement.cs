using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 1f;
    Vector3 moveDirection;

    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, vertical, 0).normalized;
        transform.position += moveDirection * Speed * Time.deltaTime;
    }
}
