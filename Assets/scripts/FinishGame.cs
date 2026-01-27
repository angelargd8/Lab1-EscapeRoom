using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject gameOverPanel;
    private bool finished = false;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            Debug.Log("ALGO");
            finished = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
