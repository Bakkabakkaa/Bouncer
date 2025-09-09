using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private MeshRenderer _candyColor;
    
    public Color CandyColor { get; private set; }
    
    public void SetColor(Color color)
    {
        _candyColor.material.color = color;
        CandyColor = color;
    }
}