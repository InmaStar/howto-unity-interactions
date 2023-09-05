using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Parameters")] 
    [SerializeField] private float MAX_VELOCITY = 1f;
    [SerializeField] private float MOVE_SPEED = 1f;

    private float _speed;
    private Direction _currentDirection;
    private Vector2 _deltaMove;
    private bool _isRunning = false;

    public delegate void DirectionChangeDelegate(Direction dir);
    public DirectionChangeDelegate OnDirectionChanged;
    
    public enum Direction
    {
        //None = -1,
        Down = 0,
        Right = 1,
        Up = 2,
        Left = 3,
    }

    private void FixedUpdate()
    {
        float velocity = Mathf.Clamp(Time.deltaTime * _speed, -MAX_VELOCITY, MAX_VELOCITY);
        _rb.position += _deltaMove * velocity;
    }

    void Update()
    {
        Direction newDirection = _currentDirection;
        Vector3 deltaMove = Vector3.zero;

        int verticalMove = GameControls.GetVerticalMove();
        int horizontalMove = GameControls.GetHorizontalMove();

        // Get direction from player's input
        if (verticalMove > 0)
        {
            deltaMove = Vector3.up;
            newDirection = Direction.Up;
        }
        else if (verticalMove < 0)
        {
            deltaMove = Vector3.down;
            newDirection = Direction.Down;
        }
        else if (horizontalMove < 0)
        {
            deltaMove = Vector3.left;
            newDirection = Direction.Left;
        }
        else if (horizontalMove > 0)
        {
            deltaMove = Vector3.right;
            newDirection = Direction.Right;
        }
        OnDirectionChanged?.Invoke(newDirection);

        // Update speed
        if (deltaMove != Vector3.zero)
        {
            _speed = MOVE_SPEED;
        }
        else
        {
            _speed = 0;
        }


        // Update direction
        _currentDirection = newDirection;
        _deltaMove = deltaMove;
    }
    
}