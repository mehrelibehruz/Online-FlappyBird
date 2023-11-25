using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Range(1, 2000)][SerializeField] float jumpAmount;
    bool jumpInput = false;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {

    }

    //  private void FixedUpdate()
    //  {

    //  }

    private void Update()
    {
        //jumpInput = Input.GetMouseButtonDown(0);

        if (Input.GetMouseButtonDown(0))
        {
            DoJump();
        }
    }

    private void DoJump()
    {
        rb.velocity = Vector2.up * jumpAmount * Time.deltaTime;
        //  rb.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            rb.velocity = Vector2.zero;
            Time.timeScale = 0;
            print("Game over!");
        }
    }
}
