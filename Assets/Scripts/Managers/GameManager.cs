using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [HideInInspector] public UnityEvent<int> OnDistanceValueChanged;
    [HideInInspector] public UnityEvent<int> OnCoinsValueChanged;
    
    private int _distance = 0;
    public int distance {
        get { return _distance; }
        set {
            _distance = value;
            OnDistanceValueChanged.Invoke(_distance);
        }
    }

    private int _coins = 0;
    public int coins {
        get { return _coins; }
        set {
            _coins = value;
            OnCoinsValueChanged.Invoke(_coins);
        }
    }

    [HideInInspector] public AudioSourceManager AudioManager;

    void Awake() {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 

        AudioManager = GetComponent<AudioSourceManager>(); 
    }

    public void GameOver() {
        distance = 0;
        SceneManager.LoadScene("GameOver");
    }
}
