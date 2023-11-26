using LootLocker.Requests;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI appVersionInfo;
    //public UnityEngine.SocialPlatforms.Impl.Leaderboard leaderboard;
    [SerializeField] Leaderboard leaderboard;
    public TMP_InputField playerNameInputfield;


    //New Code:
    [SerializeField] Button changeName;
    [SerializeField] TextMeshProUGUI oldName;
    [SerializeField] GameObject accountPanel;
    void Start()
    {
        appVersionInfo.text = GameManager.instance.AppVersion;
        StartCoroutine(SetupRoutine());
    }
    public void ChangeName()
    {
        accountPanel.SetActive(true);
        oldName.text = leaderboard.playerNames.text;
    }
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.errorData);
            }
        });
        playerNameInputfield.gameObject.SetActive(false); // Go to GameManager
        changeName.gameObject.SetActive(true);
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
