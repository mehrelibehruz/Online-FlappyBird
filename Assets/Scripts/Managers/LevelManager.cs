//using Dan.Demo;
//using LeaderboardCreatorDemo;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public Leaderboard leaderboard;

        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject overPanel;

        //LeaderboardShowcase leaderboardShowcase;

        [SerializeField] float startDelay;

        private void Awake()
        {
            leaderboard = Object.FindAnyObjectByType<Leaderboard>();
        }

        private void Start()
        {
            overPanel.SetActive(false);
            GameManager.instance.Score = 0;
            StartCoroutine(StartDelay());
            
            Time.timeScale = 0.05f;
        }
        IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(startDelay);
            Time.timeScale = 1;
        }
        public void UpdateScore()
        {
            //LeaderBoardManager.instance.SetScore();
            GameManager.instance.Score += 1;
            scoreText.text = GameManager.instance.Score.ToString();
        }
        public void Restart()
        {
            SoundManager.instance.Restart();
            SceneManager.LoadScene("Game");
        }
        public void Back()
        {
            SoundManager.instance.Back();
            SceneManager.LoadScene("MainMenu");
        }

        public void Quit()
        {
            Application.Quit();
        }
        public void GameOver()
        {
            //LeaderBoardManager.instance.SetSubmit();
            Time.timeScale = 0;
            overPanel.SetActive(true);
        }
    }
}