using UnityEngine;
public class ChessMoveableObject : MonoBehaviour
{
    Renderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }
    //checks if the mouse was pressed within this component, then it
    //assigns the current gameobject to the field selectedObject in
    //the ChessClickManager class
    void CheckForClick()
    {
        Vector3 positionToCheck = MoveManager.mousePosition;
        positionToCheck.z = myRenderer.bounds.center.z;
        if (myRenderer.bounds.Contains(positionToCheck))
        {
            MoveManager.selectedObject = gameObject;
        }
    }
    //sets the CheckForClick method as the OnMouseClick handler
    void OnEnable()
    {
        MoveManager.OnMouseClick += CheckForClick;
    }

    //removes the CheckForClick method as the OnMouseClick handler
    void OnDisable()
    {
        MoveManager.OnMouseClick -= CheckForClick;
    }
}