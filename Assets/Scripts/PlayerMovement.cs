using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speed = 5f;
    private void Awake(){
        _rigidbody2d = GetComponent<Rigidbody2D>();
    } 

    void Update()
    {
        Vector2 inputDirection = GetInput();
        Move(inputDirection);
    }

    private void Move(Vector2 direction){
        _rigidbody2d.velocity = direction.normalized * _speed;
    }

    private Vector2 GetInput(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }
}
