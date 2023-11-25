using TMPro;
using UnityEngine;
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderBoardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;
      
        private int Score => GameManager.instance.Score;


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

