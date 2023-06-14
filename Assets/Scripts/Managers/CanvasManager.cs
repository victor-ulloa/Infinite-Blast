using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text DistanceValue;

    [Header("Buttons")]
    [SerializeField] Button StartButton;
    [SerializeField] Button MenuButton;
    [SerializeField] Button RestartButton;

    void Start()
    {
        if (DistanceValue)
        {
            DistanceValue.text = GameManager.instance.distance.ToString() + " m";
            GameManager.instance.OnDistanceValueChanged.AddListener((value) => UpdateDistance(value));
        }

        if (StartButton)
        {
            StartButton.onClick.AddListener(() => StartButtonClicked());
        }

        if (MenuButton)
        {
            MenuButton.onClick.AddListener(() => MenuButtonClicked());
        }
        if (RestartButton)
        {
            RestartButton.onClick.AddListener(() => RestartButtonClicked());
        }
    }


    void UpdateDistance(int value)
    {
        DistanceValue.text = value.ToString() + " m";
    }

    void StartButtonClicked()
    {
        SceneManager.LoadScene("Level");
    }

    void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void RestartButtonClicked()
    {
        SceneManager.LoadScene("Level");
    }
}
