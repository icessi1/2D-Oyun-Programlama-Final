using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public Slider HealthBar;

    private Rigidbody2D rb2d;
    public Animator playerAnim;

    [SerializeField] private LayerMask groundMask;

    private float moveInput;
    public float moveSpeed;
    public float JumpForce;
    [SerializeField] private bool onGround;
    private bool wasOnGround;
    private bool isJump;

    // ground circle collider
    private Collider2D[] colliders_1, colliders_2;
    private float groundCheckRadius = 0.036f;
    public Transform[] groundCheck;

    private Vector3 startPosition; // starting position of the player

    private void Awake()
    {
        HealthBar.maxValue = MaxHealth;
        HealthBar.value = MaxHealth;
        Health = MaxHealth; // Baþlangýçta saðlýk tam olsun
        startPosition = transform.position; // store the starting position
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Damage(int Amount)
    {
        Health -= Amount;
        if (Health < 0) Health = 0; // Saðlýk sýfýrýn altýna düþmesin
        HealthBar.value = Health;

        if (Health == 0) // if health is 0, kill the player
        {
            KillPlayer();
        }
    }

    void Regenerate(int Amount)
    {
        Health += Amount;
        if (Health > MaxHealth) Health = MaxHealth; // Saðlýk maksimum deðeri geçmesin
        HealthBar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Damage(20);
        }
        InputSystem();
        checkGround();
        CheckFalling(); // Yeniden doðma kontrolü
        Animations();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    private void InputSystem()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0f)
        {
            transform.localScale = new Vector3(moveInput, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }
    }

    void checkGround()
    {
        colliders_1 = Physics2D.OverlapCircleAll(groundCheck[0].position, groundCheckRadius, groundMask);
        colliders_2 = Physics2D.OverlapCircleAll(groundCheck[1].position, groundCheckRadius, groundMask);

        onGround = (colliders_1.Length > 0 || colliders_2.Length > 0);
    }

    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);
    }

    private void Animations()
    {
        playerAnim.SetFloat("SpeedX", Mathf.Abs(moveInput));
        playerAnim.SetFloat("SpeedY", rb2d.velocity.y);
        playerAnim.SetBool("onGround", onGround);
    }

    public void SpeedPowerUp(float Value)
    {
        moveSpeed += Value;
    }

    public void JumpPowerUp(float Value)
    {
        JumpForce += Value;
    }

    public void HealthPowerUp(float Value)
    {
        Regenerate(25);
    }

    private void KillPlayer()
    {
        // reset the player's position and health
        transform.position = startPosition;
        Health = MaxHealth;
        HealthBar.value = MaxHealth;
    }

    private void CheckFalling()
    {
        if (transform.position.y < -10f) // Eðer karakter -10 birimden daha aþaðýdaysa
        {
            KillPlayer(); // Oyuncuyu öldür ve yeniden doður
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sahne2"))
        {
            SceneManager.LoadScene("Sahne2");
        }
        

    }
}
