using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private float Playerstart_x = 0.0f;
    private float Playerstart_y = 0.0f;
    public Transform playerTransform;
    private Rigidbody2D _rb;
    private Animator anim;
    private Vector2 movement;
    public Vector2 direction { get; private set; } // Direction the player is facing
    private GameObject gameManager;
    private bool endflag = false; // Flag to check if the game has ended

    public float speed = 8.0f;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform.position = new Vector2(Playerstart_x, Playerstart_y);
        gameManager = GameObject.Find("GameManager");
        
    }

    private void Update()
    {
        endflag = gameManager.GetComponent<GameManager>().endflag;

        // ゲーム終了時は何もしない
        if (endflag)
        {
            movement = Vector2.zero;
            anim.SetBool("isWalking", false);
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetBool("isWalking", movement != Vector2.zero);
        if (movement != Vector2.zero)
        {
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            // Update the direction based on input
            direction = new Vector2(h, v).normalized;
        }
        
        
    }
    
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
