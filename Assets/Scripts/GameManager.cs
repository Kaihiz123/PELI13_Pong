using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    int leftPlayerGamePoints = 0;
    int rightPlayerGamePoints = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LeftPlayerGetsAPoint()
    {
        leftPlayerGamePoints++;
    }

    public void RightPlayerGetsAPoint()
    {
        rightPlayerGamePoints++;
    }
}
