using UnityEngine;

public class UI_Legacy : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] GUISkin skin;
    string[] names = "Amy, Bob, Cate, Don, Elly, Fred".Split();
    private int selectedName;
    string fieldContent = "Type here";
    bool toggleVal;

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(10, 10, 256, 42), "An old plain label");

        //Label with texture
        GUI.Label(new Rect(10, 36, texture.width, texture.height), texture);

        //Regular Button
        if (GUI.Button(new Rect(10, 200, 200, 100), new GUIContent("CLICKIEEEEE")))
        {
            Debug.Log("YAY you clicked me");
        }

        //Repeating Button
        if (GUI.RepeatButton(new Rect(200, 400, 200, 100), new GUIContent("Repeatingggggg")))
        {
            Debug.Log("You clicked the other button");
        }

        //Box
        GUI.Box(new Rect(290, 10, 250, 240), "A box can appear as a container thingy");
        if (GUI.Button(new Rect(420, 400, 200, 100), "Press thingy"))
        {
            Debug.Log(selectedName + " " + toggleVal);
        }

        //Toolbar
        selectedName = GUI.Toolbar(new Rect(290, 270, 300, 32), selectedName, names);

        //textfield
        fieldContent = GUI.TextField(new Rect(620, 400, 200, 100), fieldContent);

        //Toggle
        toggleVal = GUI.Toggle(new Rect(550, 72, 100, 32), toggleVal, "Most awesome game");

        //box at bottom left of screen
        GUI.Box(new Rect(0, Screen.height - 500, 100, 50), "Bottom Left");
        GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom Right");
    }
}
