using UnityEngine;

/// <summary>
/// ゲーム開始のボタンが押されたかを見るクラス
/// </summary>
public class StartButtonController : MonoBehaviour
{
    [SerializeField] private SummarizeUpdate _gameStart = default;
    private AudioSource _gameBGM = default;

    private void Start()
    {
        if (_gameStart == null)
        {
            Debug.LogError("SerializeFieldにGameStartがセットされていません！！");
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
