using UnityEngine;
using UnityEngine.UI;

public class DifferentRatioFix : MonoBehaviour {
    
    [System.Serializable]
    public struct Icon
    {
        public Vector2 part_of_screen;
        public Vector3 scaleFactor;
        public string iconName;
        public Button.ButtonClickedEvent action;
    }

    public GameObject buttonPrefab;
    public Icon[] portrait_icons;
    public Icon[] landspace_icons;
    private Rect titleRect;
    private Rect settingsRect;
    private Rect soundRect;
    private Rect playRect;
    //private float dx, dy;

    void Start () {
        //dx = Screen.width / 10f;
        //dy = Screen.height / 10f;

        Debug.Log("Widht: " + ScreenDimensions.widthUnit + " & Height: " + ScreenDimensions.heightUnit);
        SetGUIAspectRatio();
    }

    void SetGUIAspectRatio()
    {
        if(ScreenDimensions.heightUnit > ScreenDimensions.widthUnit)
        {
            foreach (var icon in portrait_icons)
            {
                CreateIcon(icon);
            }
            //CreateIcon(5, 8, 5, "title");
            //CreateIcon(3, 5, 2.5f, "soundOn");
            //CreateIcon(7, 5, 2.5f, "settings");
            //CreateIcon(5, 2, 4, "play");
            //CreateIcon(5, 3, 5, "lightning");
        } else
        {
            foreach (var icon in landspace_icons)
            {
                CreateIcon(icon);
            }
            //CreateIcon(5, 8, 2.5f, "title");
            //CreateIcon(2, 5, 1, "soundOn");
            //CreateIcon(8, 5, 1, "settings");
            //CreateIcon(5, 2, 2, "play");
            //CreateIcon(5, 4, 2, "lightning");
        }
    }

    GameObject CreateIcon(Icon icon)
    {
        GameObject go = Instantiate(buttonPrefab, transform);
        go.name = icon.iconName;
        go.transform.position = new Vector3(icon.part_of_screen.x * ScreenDimensions.widthUnit, Screen.height - icon.part_of_screen.y * ScreenDimensions.heightUnit, go.transform.position.z);
        go.transform.localScale = icon.scaleFactor;
        go.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon.iconName, typeof(Sprite));

        if(icon.action.GetPersistentEventCount() > 0)
        {
            Button btn = go.AddComponent<Button>();
            btn.onClick = icon.action;
        }

        return go;
    }
}
