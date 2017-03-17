using System;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void OnOrientationChange()
    {

        Debug.Log("Change! " + ScreenDimensions.Screen_State.ToString());
        for (int icon_index = 0; icon_index < icons.Length; icon_index++)
        {
            ChangeIconPosition(icons[icon_index], go_icons[icon_index]);
        }
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
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

    GameObject CreateIcon(Icon icon, DeviceOrientation state)
    {
        GameObject go_icon = Instantiate(icon_prefab, transform);
        go_icon.name = icon.icon_name;
        go_icon.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon.icon_name, typeof(Sprite));
        go_icon.GetComponent<Image>().color = new Color(go_icon.GetComponent<Image>().color.r,
                                                        go_icon.GetComponent<Image>().color.g,
                                                        go_icon.GetComponent<Image>().color.b,
                                                        0);
        ChangeIconPosition(icon, go_icon);

        if (icon.action.GetPersistentEventCount() > 0)
        {
            Button btn = go_icon.AddComponent<Button>();
            btn.onClick = icon.action;
        }

        return go_icon;
    }

    bool isPortrait()
    {
        // Only on emulator
        if(Input.deviceOrientation == DeviceOrientation.Unknown)
        {
            return Screen.height > Screen.width;
        } else
        {
            return Input.deviceOrientation == DeviceOrientation.Portrait;
        }
    }
    void ChangeIconPosition(Icon icon, GameObject go_icon)
    {
        Vector2 part_of_screen = isPortrait() ? icon.portrait.part_of_screen : icon.landspace.part_of_screen;
        Vector2 scale_factor = isPortrait() ? icon.portrait.scale_factor : icon.landspace.scale_factor;
        go_icon.transform.localPosition = new Vector3(part_of_screen.x * ScreenDimensions.widthUnit, Screen.height - part_of_screen.y * ScreenDimensions.heightUnit, go_icon.transform.position.z);
        go_icon.transform.localScale = scale_factor;
    }
}
