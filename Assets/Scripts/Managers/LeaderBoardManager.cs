using TMPro;
using UnityEngine;
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;


        [SerializeField] private GameManager _exampleGame;

        private int Score => _exampleGame.Score;


        private void Start()
        {
            LoadEntries();
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
    }
}

