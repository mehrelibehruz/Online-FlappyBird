using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Range(1, 15)][SerializeField] float jumpAmount;
    bool jumpInput = false;
    [SerializeField] private Rigidbody2D rb;

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
        rb.velocity = new Vector2(0, 1 * jumpAmount); //* Time.deltaTime;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Score updated");
        if (collision.gameObject.CompareTag("Score"))
        {
            print("Score updated");
            //GameManager.instance.Score += 1;
        }
    }
}
