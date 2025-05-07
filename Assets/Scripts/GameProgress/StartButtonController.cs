using UnityEngine;

/// <summary>
/// �Q�[���J�n�̃{�^���������ꂽ��������N���X
/// </summary>
public class StartButtonController : MonoBehaviour
{
    [SerializeField] private SummarizeUpdate _gameStart = default;
    private AudioSource _gameBGM = default;

    private void Start()
    {
        if (_gameStart == null)
        {
            Debug.LogError("SerializeField��GameStart���Z�b�g����Ă��܂���I�I");
        }

        _gameBGM=Camera.main.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           Camera.main.GetComponent<AudioSource>().Play();
            _gameStart.SetGameState(true);
            this.gameObject.SetActive(false);
        }
    }
}
