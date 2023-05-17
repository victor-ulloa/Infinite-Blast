using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text distanceValue;
    
    void Start()
    {
        if (distanceValue)
        {
            distanceValue.text = GameManager.instance.distance.ToString() + " m";
            GameManager.instance.OnDistanceValueChanged.AddListener((value) => UpdateDistance(value));
        }
    }


    void UpdateDistance(int value)
    {
        distanceValue.text = value.ToString() + " m";
    }
}
