using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    [SerializeField] public LayerMask Ground;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip[] sounds;

    public bool willJump;
    public float canJump;

    public Vector3 storedPos;
    public bool posStored;

    public ParticleSystem partDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Store")) { storedPos = transform.position; posStored = true; audioSource.PlayOneShot(sounds[2]); }
        if (Input.GetButtonDown("Release") && posStored) { transform.position = storedPos; posStored = false; audioSource.PlayOneShot(sounds[1]); }

        if (Input.GetButtonDown("Restart")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Only register jump if on the ground
        checkCanJump();

        if (canJump > 0 && Input.GetButtonDown("Jump"))
        {
            willJump = true;
            canJump = 0;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //transform.localScale = new Vector3(1,transform.localScale.y, transform.localScale.z);
            sprite.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            sprite.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        if (willJump)
        {
            audioSource.PlayOneShot(sounds[0]);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            willJump = false;
        }

        if (rb.velocity.y > 0.2 && !Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }

    private void checkCanJump()
    {
        if (isGrounded())
        {
            canJump = 0.1f;
            
        } else if (canJump > 0)
        {
            canJump -= Time.deltaTime;
        }
        else
        {
            canJump = 0;
        }
    }

    private void LateUpdate()
    {
        animator.SetFloat("hVelocity", Mathf.Abs(rb.velocity.x));
    }

    private bool isGrounded()
    {

        // Cast a box straight down.
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(0.5f,0.1f), 0f, -Vector2.up, 0.1f, Ground);

        // Return if it hits the ground
        return (hit.collider != null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            death();
        }
    }

    private void death()
    {
        Debug.Log("YOU DIEEEEED");
        //Instantiate(partDeath, transform.position, transform.rotation);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
