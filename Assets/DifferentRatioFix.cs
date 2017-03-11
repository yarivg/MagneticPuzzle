using System;
using UnityEngine;
using UnityEngine.UI;

public class DifferentRatioFix : MonoBehaviour {
    
    [System.Serializable]
    public struct Icon
    {
        public Ratio portrait;
        public Ratio landspace;
        public string icon_name;
        public Button.ButtonClickedEvent action;
    }

    [System.Serializable]
    public struct Ratio
    {
        public Vector2 part_of_screen;
        public Vector2 scale_factor;
    }


    public Icon[] icons;
    private Icon[] prev_icons;
    public GameObject icon_prefab;
    private Rect title_rect;
    private Rect settings_rect;
    private Rect sound_rect;
    private Rect play_rect;

    private GameObject[] go_icons;
    // 
    public bool isChangingOnUpdate;
    void Start () {
        Debug.Log("Widht: " + ScreenDimensions.widthUnit + " & Height: " + ScreenDimensions.heightUnit);
        // TODO only for production, now using update method
        if (!isChangingOnUpdate)
        {
            SetGUIAspectRatio();
        } else
        {
            prev_icons = new Icon[icons.Length];
            go_icons = new GameObject[icons.Length];

            for (int icon_index = 0; icon_index < icons.Length; icon_index++)
            {
                prev_icons[icon_index].portrait.part_of_screen.x = icons[icon_index].portrait.part_of_screen.x;
                prev_icons[icon_index].portrait.part_of_screen.y = icons[icon_index].portrait.part_of_screen.y;
                prev_icons[icon_index].portrait.scale_factor.x = icons[icon_index].portrait.scale_factor.x;
                prev_icons[icon_index].portrait.scale_factor.y = icons[icon_index].portrait.scale_factor.y;

                prev_icons[icon_index].landspace.part_of_screen.x = icons[icon_index].landspace.part_of_screen.x;
                prev_icons[icon_index].landspace.part_of_screen.y = icons[icon_index].landspace.part_of_screen.y;
                prev_icons[icon_index].landspace.scale_factor.x = icons[icon_index].landspace.scale_factor.x;
                prev_icons[icon_index].landspace.scale_factor.y = icons[icon_index].landspace.scale_factor.y;

                go_icons[icon_index] = CreateIcon(icons[icon_index], ScreenDimensions.Screen_State);
            }
        }
    }

    private void Update()
    {
        if(isChangingOnUpdate)
        {
            for (int icon_index = 0; icon_index < icons.Length; icon_index++)
            {
                if (isDifferentPositionOrScale(prev_icons[icon_index].portrait, icons[icon_index].portrait) ||
                    isDifferentPositionOrScale(prev_icons[icon_index].landspace, icons[icon_index].landspace))
                {
                    Debug.Log("Desroying");
                    Destroy(go_icons[icon_index]);
                    go_icons[icon_index] = CreateIcon(icons[icon_index], ScreenDimensions.Screen_State);
                }
            }

            for (int icon_index = 0; icon_index < icons.Length; icon_index++)
            {
                prev_icons[icon_index].portrait.part_of_screen.x = icons[icon_index].portrait.part_of_screen.x;
                prev_icons[icon_index].portrait.part_of_screen.y = icons[icon_index].portrait.part_of_screen.y;
                prev_icons[icon_index].portrait.scale_factor.x = icons[icon_index].portrait.scale_factor.x;
                prev_icons[icon_index].portrait.scale_factor.y = icons[icon_index].portrait.scale_factor.y;

                prev_icons[icon_index].landspace.part_of_screen.x = icons[icon_index].landspace.part_of_screen.x;
                prev_icons[icon_index].landspace.part_of_screen.y = icons[icon_index].landspace.part_of_screen.y;
                prev_icons[icon_index].landspace.scale_factor.x = icons[icon_index].landspace.scale_factor.x;
                prev_icons[icon_index].landspace.scale_factor.y = icons[icon_index].landspace.scale_factor.y;
            }
        }
    }

    private bool isDifferentPositionOrScale(Ratio r1, Ratio r2)
    {
        if(r1.part_of_screen.x != r2.part_of_screen.x ||
            r1.part_of_screen.y != r2.part_of_screen.y ||
            r1.scale_factor.x != r2.scale_factor.x ||
            r1.scale_factor.y != r2.scale_factor.y)
        {
            return true;
        }

        return false;
    }

    void SetGUIAspectRatio()
    {
        foreach (var icon in icons)
        {
            CreateIcon(icon, ScreenDimensions.Screen_State);
        }
    }

    GameObject CreateIcon(Icon icon, SCREEN_STATE state)
    {
        Vector2 part_of_screen = state == SCREEN_STATE.PORTARAIT ? icon.portrait.part_of_screen : icon.landspace.part_of_screen;
        Vector2 scale_factor = state == SCREEN_STATE.PORTARAIT ? icon.portrait.scale_factor : icon.landspace.scale_factor;

        GameObject go = Instantiate(icon_prefab, transform);
        go.name = icon.icon_name;
        go.transform.position = new Vector3(part_of_screen.x * ScreenDimensions.widthUnit, Screen.height - part_of_screen.y * ScreenDimensions.heightUnit, go.transform.position.z);
        go.transform.localScale = scale_factor;
        go.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon.icon_name, typeof(Sprite));

        if(icon.action.GetPersistentEventCount() > 0)
        {
            Button btn = go.AddComponent<Button>();
            btn.onClick = icon.action;
        }

        return go;
    }
}
