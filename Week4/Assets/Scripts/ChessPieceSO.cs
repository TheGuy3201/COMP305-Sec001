using UnityEngine;

[CreateAssetMenu(
fileName = "ChessPieceScriptableObject",
menuName = "Chess/ChessPiece")]
public class ChessPieceSO : ScriptableObject
{
    [Header("Chess Piece Details")] //this will show up as a label in the inspector
    public new string name; //input is facilitated via a textbox
    public string description; //input is facilitated via a textbox
                               //input of all numeric types is also
                               //facilitated via a textbox
                               //bool is facilitated via a checkbox
    [Range(0, 1)] //this will constrain the succeeding input
    public float importance; //input is facilitated via a slider
    public ChessColorSO pieceColor; //input is facilitated via drag and drop
    public Sprite sprite; //input is facilitated via drag and drop
    public enum PieceName //this is digested in unity as a drop list
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }
    [Tooltip("Select a name from the droplist")]
    public PieceName pieceName; //input is facilitated via a drop list
}