using Assets.Scripts.Managers;
using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    [Range(1, 15)][SerializeField] float jumpAmount;
    [SerializeField] private Rigidbody2D rb;
    //bool jumpInput = false;

    Leaderboard _leaderboard;
    private void Awake()
    {
        _leaderboard = Object.FindObjectOfType<Leaderboard>();
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
        rb.velocity = new Vector2(0, 1 * jumpAmount); //* Time.deltaTime;
        //  rb.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            //StartCoroutine(OverDelay());
            SoundManager.instance.GameOver();
            rb.velocity = Vector2.zero;
            levelManager.GameOver();
            _leaderboard = levelManager.leaderboard;
            StartCoroutine(
            _leaderboard.SubmitScoreRoutine(_score));
        }
    }

    //IEnumerator OverDelay()
    //{
    //    yield return new WaitForSeconds(5f);
    //    yield return StartCoroutine(_leaderboard.SubmitScoreRoutine(_score));
    //}

    int _score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            levelManager.UpdateScore();
            _score++;
        }
    }
}
