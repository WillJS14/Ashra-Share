using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    public Vector2 homePosition;
    public float roamRadius = 15f;

    private Transform player;
    private Vector2 moveDirection;
    private float changeDirectionTimer;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        PickNewDirection();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform.position;
    }

    void Update()
    {
        float distanceFromHome = Vector2.Distance(transform.position, homePosition);

        Wander();
    }

    void Wander()
    {
        Vector2 nextPosition = 
            (Vector2)transform.position + moveDirection * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(nextPosition, homePosition) > roamRadius)
        {
            // steer back toward home
            moveDirection = (homePosition - (Vector2)transform.position).normalized;
        }

        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0)
        {
            PickNewDirection();
        }

        Move(moveDirection, moveSpeed);
    }

    void Move(Vector2 direction, float speed)
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;

        animator.SetBool("isMoving", direction != Vector2.zero);
    }


    void PickNewDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;
        changeDirectionTimer = Random.Range(2f, 4f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(homePosition, roamRadius);
    }
}