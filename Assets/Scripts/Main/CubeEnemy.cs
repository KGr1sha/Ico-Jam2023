using UnityEngine;


public class CubeEnemy : BaseEnemy
{
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheckObject;

    private Rigidbody2D _rigidbody;
    private string _facingDirection;
    private float _baseCastDist = 0.3f;
    private Vector3 _baseScale;

    private const string LEFT = "left";
    private const string RIGHT = "right";

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
        _facingDirection = LEFT;
        _baseScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        float vX = _patrolSpeed;

        if (_facingDirection == RIGHT) vX = -_patrolSpeed;
        _rigidbody.velocity = new Vector2(-vX, _rigidbody.velocity.y);
        if (IsHittingWall())
        {
            if (_facingDirection == LEFT)
                ChangeFacingDirection(RIGHT);
            else
                ChangeFacingDirection(LEFT);
        }
    }

    private bool IsHittingWall()
    {
        bool val = false;
        float castDist = _baseCastDist;

        if (_facingDirection == RIGHT)
            castDist = -_baseCastDist;

        Vector3 targetPos = _groundCheckObject.position;
        targetPos.x += castDist;

        RaycastHit2D wallCast = Physics2D.Linecast(_groundCheckObject.position, targetPos, _groundMask);
        RaycastHit2D groundCast = Physics2D.Raycast(_groundCheckObject.position, Vector2.down, 0.3f, _groundMask);
        if (wallCast.collider != null || groundCast.collider == null)
        {
            val = true;
        }

        return val;
    }

    private void ChangeFacingDirection(string newDirection)
    {

        Vector3 newScale = _baseScale;

        if (newDirection == RIGHT)
        {
            newScale.x = -_baseScale.x;
        }
        transform.localScale = newScale;
        _facingDirection = newDirection;
        
    }
}
