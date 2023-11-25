using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
            
        public void UpdateScore()
        {
            GameManager.instance.Score += 1;            
            scoreText.text = GameManager.instance.Score.ToString();            
        }
    }
}