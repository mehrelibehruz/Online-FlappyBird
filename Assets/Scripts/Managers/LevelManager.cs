using Dan.Demo;
using LeaderboardCreatorDemo;
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

        private void Awake()
        {
            leaderboard = Object.FindAnyObjectByType<Leaderboard>();
            Time.timeScale = 1;
        }
        private void Start()
        {
            overPanel.SetActive(false);
            //GameManager.instance.Score = 0;
        }
        public void UpdateScore()
        {
            //LeaderBoardManager.instance.SetScore();
            GameManager.instance.Score += 1;
            scoreText.text = GameManager.instance.Score.ToString();
        }
        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }
        public void Back()
        {
            SceneManager.LoadScene("BoardScene");
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