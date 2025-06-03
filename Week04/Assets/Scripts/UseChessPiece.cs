using UnityEngine;
public class UseChessPiece : MonoBehaviour
{
    [SerializeField] ChessPieceSO piece;
    [SerializeField] ChessColorSO color;
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = piece.sprite;
        renderer.color = piece.pieceColor.color;
    }
}