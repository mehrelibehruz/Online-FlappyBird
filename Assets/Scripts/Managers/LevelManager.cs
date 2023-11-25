using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject overPanel;
        private void Awake()
        {
            Time.timeScale = 1;
        }
        private void Start()
        {
            overPanel.SetActive(false);
            GameManager.instance.Score = 0;
        }
        public void UpdateScore()
        {
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
            Time.timeScale = 0;
            overPanel.SetActive(true);
        }
    }
}