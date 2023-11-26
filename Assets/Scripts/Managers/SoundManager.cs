using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] AudioSource mainAudioSource;

    [Header(" -Clips- ")]
    [SerializeField] AudioClip startClip;
    [SerializeField] AudioClip submitNameClip;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip backClip;
    [SerializeField] AudioClip restartClip;
    [SerializeField] AudioClip exitClip;

    //[Header(" -Musics- ")]
    // [SerializeField] AudioClip backroundMusic;

    public void Restart()
    {
        mainAudioSource.PlayOneShot(restartClip);
    }
    public void GameOver()
    {
        mainAudioSource.PlayOneShot(gameOverClip);
    }
    public void Back()
    {
        mainAudioSource.PlayOneShot(backClip);
    }
    public void Exit()
    {
        mainAudioSource.PlayOneShot(exitClip);
    }
}
