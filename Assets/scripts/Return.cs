using UnityEngine;

public class Return : MonoBehaviour
{
    public void ReturnMenu()
    {
        GameManager.Instance.LoadGame("MainMenu");
    }
}
