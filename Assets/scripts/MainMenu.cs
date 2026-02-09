using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip ambienceClip;

    public void Start()
    {
        if (!AudioManager.Instance.IsFXPlaying(ambienceClip))
            AudioManager.Instance.PlayAmbience(ambienceClip);

        Time.timeScale = 1.0f;

    }
    public void PlayGame(string levelName)
    {
        GameManager.Instance.LoadGame(levelName);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

}
