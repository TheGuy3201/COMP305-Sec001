using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class MoveManager : MonoBehaviour
{
    [HideInInspector] public delegate void MouseClickHandler();
    [HideInInspector] public static event MouseClickHandler OnMouseClick;
    [HideInInspector] public static Vector3 mousePosition;
    [HideInInspector] public static GameObject selectedObject;
    Vector3 offset;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick?.Invoke(); //Invoke if not null (thats what the ? is for)
            if (selectedObject != null)
            {
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject != null)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }
}