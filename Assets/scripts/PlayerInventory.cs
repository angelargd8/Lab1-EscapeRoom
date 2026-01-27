using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static bool hasKey = false;
    public static GameObject heldKey = null;
    public static bool hasAxe = false;
    public static GameObject heldAxe = null;

    //consumir la llave
    public static void ConsumeKey()
    {
        hasKey = false;

        if (heldKey != null)
        {
            Destroy(heldKey);
            heldKey = null;
        }
    }


    //consumir axe
    public static void ConsumeAxe()
    {
        hasAxe = false;

        if (heldAxe != null)
        {
            Destroy(heldAxe);
            heldAxe = null;
        }
    }

}
