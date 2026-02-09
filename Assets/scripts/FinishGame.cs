using UnityEngine;
using UnityEngine.InputSystem;

using StarterAssets;

public class FinishGame : MonoBehaviour
{
    [SerializeField] AudioClip FinalSFX;

    [SerializeField] FirstPersonController fpController;

    [SerializeField] GameObject gameOverPanel;

    private bool finished = false;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (finished && Keyboard.current.mKey.wasPressedThisFrame)
        {
            GoToMainMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            finished = true;

            AudioManager.Instance.StopAmbience();

            AudioManager.Instance.PlaySFX(FinalSFX);

            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            //apagar el delta del tiempo
            Time.timeScale = finished ? 0.0f : 1.0f;
            fpController.enabled = !finished;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameManager.Instance.LoadGame("MainMenu");
    }
}
