using UnityEngine;

/// <summary>
/// それぞれのイベントに対して処理を追加するクラス
/// </summary>
/// 
[RequireComponent(typeof(PlayerMoveKeyInput))]
[RequireComponent(typeof(PlayerHorizontalMove))]
public class PlayerMoveProssesPresenter : MonoBehaviour
{
    //移動キーを押したかの判定をとるクラス
    private PlayerMoveKeyInput _playerMoveKeyInput = default;

    //横移動のの処理を管理するクラス
    private PlayerHorizontalMove _playerHorizontalMove = default;

    //ジャンプの処理を管理するクラス
    private JumpClassChanger _jumpClassChanger = default;

    private void Start()
    {
        _playerMoveKeyInput = this.GetComponent<PlayerMoveKeyInput>();
        _playerHorizontalMove = this.GetComponent<PlayerHorizontalMove>();

        if (!TryGetComponent<JumpClassChanger>(out _jumpClassChanger))
        {
            Debug.LogError("JumpClassChangerアタッチされていません！！");
            return;
        }

        HandleSet();
    }

    /// <summary>
    /// 移動処理のメソッドをセットする
    /// </summary>
    private void HandleSet()
    {
        //左移動を呼び出す処理をセット
        _playerMoveKeyInput.LeftMoveHandler += HandleLeftMove;

        //右移動を呼び出す処理をセット
        _playerMoveKeyInput.RightMoveHandler += HandleRightMove;

        //ジャンプ処理を呼び出す処理をセット
        _playerMoveKeyInput.JumpHandler += HandleJump;
    }

    /// <summary>
    /// 左移動処理を呼び出す
    /// </summary>
    private void HandleLeftMove()
    {
        _playerHorizontalMove.LeftMove(this.transform);
    }

    /// <summary>
    /// 右移動処理を呼び出す
    /// </summary>
    private void HandleRightMove()
    {
        _playerHorizontalMove.RightMove(this.transform);
    }

    /// <summary>
    /// ジャンプ処理を呼び出す
    /// </summary>
    private void HandleJump()
    {
        _jumpClassChanger.CurrentJumpClass.JudgePossibleJump();
    }
}
