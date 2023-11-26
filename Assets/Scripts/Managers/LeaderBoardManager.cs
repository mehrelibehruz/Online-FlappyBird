using TMPro;
using UnityEngine;
using Dan.Main;
using UnityEngine.SceneManagement;
using Dan.Demo;

namespace LeaderboardCreatorDemo
{
    public class LeaderBoardManager : MonoBehaviour
    {
        public static LeaderBoardManager instance;
        private void Awake()
        {
            instance = this;
        }
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] LeaderboardShowcase _leaderboardShowcase;
        private int Score => GameManager.instance.Score;
        //[SerializeField] LeaderboardShowcase _leaderboardShowcase;

        private void Start()
        {
            LoadEntries();
        }
        public void SetSubmit()
        {
            _leaderboardShowcase.Submit();
        }
        public void SetScore()
        {
            _leaderboardShowcase.AddPlayerScore();
        }

        private void LoadEntries()
        {
            Leaderboards.FlappyBirdOnline.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }

        public void UploadEntry()
        {
            Leaderboards.FlappyBirdOnline.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

