using UnityEngine;

public class FlyEnemy : BaseEnemy
{
    [SerializeField] private float _agroDistance;
    [SerializeField] private LayerMask _playerMask;

    public float ChaseSpeed = 3f;
    public float PatrolSpeed = 1f;
    public float PatrolRange = 2f;
    public LayerMask GroundLayer;
    public Transform playerTransform { get; private set; }

    private FlyingEnemyStates _stateMachine;
    private Rigidbody2D _rigidbody;
    private Vector3 _baseScale;

    protected override void Start()
    {
        base.Start();
        _stateMachine = GetComponent<FlyingEnemyStates>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _baseScale = transform.localScale;
    }

    private void Update()
    {
        HandleFlip();
        CheckForPlayer();
    }

    private void HandleFlip()
    {
        Vector3 localScale = _baseScale;
        if (_rigidbody.velocity.x > 0)
        {
            localScale.x = -_baseScale.x;
        }
        transform.localScale = localScale;
    }

    private void CheckForPlayer()
    {
        RaycastHit2D cast = Physics2D.CircleCast(transform.position, _agroDistance, Vector2.up, 0.1f, _playerMask);

        if (cast.collider != null)
        {
            _stateMachine.SetBehaviourAgressive();
            playerTransform = cast.transform;
        }
    }
}
