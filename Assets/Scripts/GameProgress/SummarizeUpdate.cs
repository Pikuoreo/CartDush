using UnityEngine;

/// <summary>
/// ゲームのUpdateを管理するクラス
/// </summary>
public class SummarizeUpdate:MonoBehaviour
{
    //ゲーム開始前の待機画面
    [SerializeField] private GameObject _startPreparationText=default;

    //trueでプレイヤー以外のゲーム全体のUpdateを流す
    private bool _isGameStart = false;

    //trueでプレイヤーの移動処理に関するUpdateを流す
    private bool _isStartPlayerMove = false;

    private void Update()
    {
        //ゲーム全体のUpdateを流す
        if (_isGameStart)
        {
            GameUpdator.Instance.UpdateHandler();
        }

        //プレイヤーの移動に関するUpdateを流す
        if (_isStartPlayerMove)
        {
            GameUpdator.Instance.PlayerUpdateHandler();
        }
    }

    /// <summary>
    /// ゲームの開始、終了をBool型で受け取る
    /// </summary>
    /// <param name="isGameStart">trueでゲーム開始、falseでゲーム終了</param>
    public void SetGameState(bool isGameStart)
    {
        _isGameStart = isGameStart;

        if (!_isGameStart)
        {
            _isStartPlayerMove = false;
        }
    }

    /// <summary>
    /// プレイヤーを移動可能にする
    /// </summary>
    public void StartPlayerMove()
    {
        _isStartPlayerMove = true;
        PreparationTextDisplay();
    }

    /// <summary>
    /// ゲーム開始前の待機画面を表示
    /// </summary>
    private void PreparationTextDisplay()
    {
        
        _startPreparationText.SetActive(true);
    }
}
