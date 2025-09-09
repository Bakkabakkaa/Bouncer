using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private MeshRenderer _litRenderer;
    public Color GiftColor { get; private set; }

    public void SetColor(Color color)
    {
        _litRenderer.materials[1].color = color;
        GiftColor = color;
    }
}