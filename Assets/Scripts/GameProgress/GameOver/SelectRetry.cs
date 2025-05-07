using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectRetry : MonoBehaviour
{
   private bool _isSelectRetry = false;

    //ゲーム中のシーンの名前
    [SerializeField, SceneReference] private string _gameScene = default;

    //タイトルシーンの名前
    [SerializeField, SceneReference] private string _titleScene = default;

    private void Update()
    {
        if (_isSelectRetry)
        {
            Select();
        }
    }

    private void Select()
    {
        //タイトルに戻る
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameUpdator.Instance.ResetInstance();
            PlayerState.Instance.ResetInstance();
            SceneManager.LoadScene(_titleScene);
        }

        //もう一度ゲームをプレイ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameUpdator.Instance.ResetInstance();
            PlayerState.Instance.ResetInstance();
            SceneManager.LoadScene(_gameScene);
        }   
    }

    public void StartSelect()
    {
        _isSelectRetry = true;
    }
}
