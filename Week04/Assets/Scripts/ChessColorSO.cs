using UnityEngine;
[CreateAssetMenu(
fileName = "ChessColorScriptableObject",
menuName = "Chess/ChessColor")] //where to access this Scriptable

public class ChessColorSO : ScriptableObject //must inherit from the ScriptableObject class
{
    [Tooltip("Use the color picker to choose your color")] //pops up in the inspector
    [Header("Piece Color ")] //displays this header in the inspector
    public Color color; //input is driven by unity color picker
}