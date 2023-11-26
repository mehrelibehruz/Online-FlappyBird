using LootLocker.Requests;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{

    public UnityEngine.SocialPlatforms.Impl.Leaderboard leaderboard;
    public TMP_InputField playerNameInputfield;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoginRoutine());
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
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        //yield return leaderboard.FetchTopHighscoresRoutine();
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
