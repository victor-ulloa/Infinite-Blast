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
    
    private int _distance = 0;
    public int distance {
        get { return _distance; }
        set {
            _distance = value;
            OnDistanceValueChanged.Invoke(_distance);
        }
    }

    void Awake() {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
    }

    public void GameOver() {
        distance = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
