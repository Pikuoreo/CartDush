using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectRetry : MonoBehaviour
{
   private bool _isSelectRetry = false;

    //�Q�[�����̃V�[���̖��O
    [SerializeField, SceneReference] private string _gameScene = default;

    //�^�C�g���V�[���̖��O
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
        //�^�C�g���ɖ߂�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameUpdator.Instance.ResetInstance();
            PlayerState.Instance.ResetInstance();
            SceneManager.LoadScene(_titleScene);
        }

        //������x�Q�[�����v���C
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
