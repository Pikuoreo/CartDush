using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSceneSelect : MonoBehaviour
{
    /// <summary>
    /// タイトルのボタン選択を管理
    /// </summary> 

    //ゲームシーンの名前
    [SerializeField, SceneReference] private string _gameSceneName = default;

    void Update()
    {
        //ゲーム開始
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        //アプリを閉じる
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
