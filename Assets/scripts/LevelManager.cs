using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] FirstPersonController fpController;
    [SerializeField] AudioClip ambienceClip;

    private bool isPaused = false;

    void Start()
    {
        AudioManager.Instance.PlayAmbience(ambienceClip);
        Time.timeScale = 1.0f;

    }

    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        //apagar el delta del tiempo
        Time.timeScale = isPaused ? 0.0f: 1.0f;
        fpController.enabled = !isPaused;

        
        Cursor.lockState = isPaused ? CursorLockMode.None: CursorLockMode.Locked;
        Cursor.visible = !isPaused;

    }

    public void BackToMenu()
    {

        GameManager.Instance.LoadGame("MainMenu");
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }


}
