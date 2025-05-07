using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSceneSelect : MonoBehaviour
{
    /// <summary>
    /// �^�C�g���̃{�^���I�����Ǘ�
    /// </summary> 

    //�Q�[���V�[���̖��O
    [SerializeField, SceneReference] private string _gameSceneName = default;

    void Update()
    {
        //�Q�[���J�n
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        //�A�v�������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
