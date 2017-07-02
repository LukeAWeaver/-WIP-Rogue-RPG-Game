using UnityEngine;
using System.Collections;

public class dmgTextController : MonoBehaviour
{
    private static DmgScript popupText;
    private static Canvas canvas;

    public static void Initialize()
    {
        if (canvas == null)
            canvas = FindObjectOfType<Canvas>();
        if (popupText == null)
            popupText = Resources.Load<DmgScript>("prefab/DmgParent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
        Initialize();

        DmgScript instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.2f, .2f), location.position.y + Random.Range(-.2f, .2f)));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
