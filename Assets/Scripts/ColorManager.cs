using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private List<Color> _colorList;

    private void Awake()
    {
        
    }
    public Color GetRandomColor()
    {
        var randomIndex = Random.Range(0, 3);
        return _colorList[randomIndex];
    }
}