using UnityEngine;

[RequireComponent(typeof(GameOverAnimation))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioClip _rollSE = default;
    [SerializeField] private GameObject _player = default;
    private ChaserPlayer _chaserPlayer = default;
    private SummarizeUpdate _summarizeUpdate = default;
    private GameOverAnimation _gameOverAnimation = default;
    private PlaySE _playSE = default;
    
    void Start()
    {
        _chaserPlayer = FindFirstObjectByType<ChaserPlayer>();
        _summarizeUpdate = FindFirstObjectByType<SummarizeUpdate>();
        if (_chaserPlayer == null)
        {
            Debug.LogError("ChaserPlayerが見つかりませんでした");
            return;
        }

        if (_summarizeUpdate == null)
        {
            Debug.LogError("SummarizeUpdateが見つかりませんでした");
            return;
        }

        _gameOverAnimation = this.GetComponent<GameOverAnimation>();

        GameUpdator.Instance.SubscribeUpdate(JudgeGameOver);
        _playSE = new PlaySE();
    }

    /// <summary>
    /// ゲームオーバーの判定をとる
    /// </summary>
    private void JudgeGameOver()
    {
        if (_chaserPlayer.DisTance <= 0)
        {
            _playSE.StopSound();
            _playSE.PlaySound(_rollSE);
            _summarizeUpdate.SetGameState(false);
            _gameOverAnimation.StartGameOverAnimation();

            const float _playerScaleY = -1.9f;
            _player.transform.localScale += new Vector3(0, _playerScaleY, 0);
        }
    }
}
