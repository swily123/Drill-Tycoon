using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _exit;
    [SerializeField] private int _gameSceneIndex = 1;
    
    private void OnEnable()
    {
        _play.onClick.AddListener(PlayGame);
        _exit.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(PlayGame);
        _exit.onClick.RemoveListener(ExitGame);
    }

    private void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(_gameSceneIndex);
    }
    
    private void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
