using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed; //public variable uses Pascal casing
    float move; //private variable
    public float JumpForce;
    public bool IsJumping;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input. GetAxis("Horizontal"); //x - axis
        rb2d. linearVelocity = new Vector2(move * Speed, rb2d. linearVelocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(rb2d. linearVelocity.x, JumpForce));
            Debug . Log("Jump"); //for debugging purpose
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject. CompareTag("Ground"))
        {
            IsJumping = false;
        }
    
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject. CompareTag("Ground"))
        {
            IsJumping = true;
        }

    }

}
