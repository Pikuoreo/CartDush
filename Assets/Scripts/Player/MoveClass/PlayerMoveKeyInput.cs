using UnityEngine;

/// <summary>
/// 移動キーの判定をするクラス
/// </summary>
public class PlayerMoveKeyInput : MonoBehaviour
{
    //プレイヤーの移動処理
    public delegate void PlayerMove();

    //プレイヤーの左移動のイベント
    private event PlayerMove _leftMoveHandler = default;

    //プレイヤーの右移動のイベント
    private event PlayerMove _rightMoveHandler = default;

    //プレイヤーのジャンプのイベント
    private event PlayerMove _jumpHandler = default;

    //trueで左移動処理を呼び出す
    private bool _isLeftMove = false;

    //trueで右移動処理を呼び出す
    private bool _isRightMove = false;

    //trueでジャンプ処理を呼び出す
    private bool _isJump = false;

    //プレイヤーの左移動のイベント
    public event PlayerMove LeftMoveHandler
    {
        add => _leftMoveHandler += value;

        remove => _leftMoveHandler -= value;
    }

    //プレイヤーの右移動のイベント
    public event PlayerMove RightMoveHandler
    {
        add => _rightMoveHandler += value;

        remove => _rightMoveHandler -= value;
    }

    //プレイヤーのジャンプのイベント
    public event PlayerMove JumpHandler
    {
        add => _jumpHandler += value;

        remove => _jumpHandler -= value;
    }

    private void Start()
    {
        GameUpdator.Instance.SubscribePlayerUpdate(MoveUpdate);
    }

    private void MoveUpdate()
    {
        MoveKeyInput();
        PlayerMoveStart();
    }

    /// <summary>
    /// 移動処理のメソッドを呼び出す
    /// </summary>
    private void PlayerMoveStart()
    {
        JudgeLeftMove();
        JudgeRightMove();
        JudgeJump();
    }

    /// <summary>
    /// 左移動可能かの判定をとる
    /// </summary>
    private void JudgeLeftMove()
    {
        //左移動可能だったら
        if (_isLeftMove)
        {
            //左移動イベントを開始
            _leftMoveHandler?.Invoke();
        }
    }

    /// <summary>
    /// 右移動可能かの判定をとる
    /// </summary>
    private void JudgeRightMove()
    {
        //右移動可能だったら
        if (_isRightMove)
        {
            //右移動イベント開始
            _rightMoveHandler?.Invoke();
        }
    }

    /// <summary>
    /// ジャンプ可能かの判定をとる
    /// </summary>
    private void JudgeJump()
    {
        //ジャンプ可能だったら
        if (_isJump)
        {
            //ジャンプ処理イベント開始
            _jumpHandler?.Invoke();
        }
    }

    /// <summary>
    /// 移動キーを押したか見るメソッドを呼び出す
    /// </summary>
    private void MoveKeyInput()
    {
        LeftMoveKeyInput();
        RightMoveKeyInput();
        JumpKeyInput();
    }

    /// <summary>
    /// 左移動のキーを押しているか見る
    /// </summary>
    private void LeftMoveKeyInput()
    {
        //Aか←を押している間
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //左移動を可能に
            _isLeftMove = true;
            return;
        }
        //左移動を不可に
        _isLeftMove = false;
    }

    /// <summary>
    /// 右移動のキーを押しているか見る
    /// </summary>
    private void RightMoveKeyInput()
    {
        //Dか→を押している間
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //右移動を可能に
            _isRightMove = true;
            return;
        }
        //右移動を不可に
        _isRightMove = false;
    }

    /// <summary>
    /// ジャンプのキーを押しているか見る
    /// </summary>
    private void JumpKeyInput()
    {
        //スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ジャンプ可能に
            _isJump = true;
            return;
        }
        //ジャンプ不可に
        _isJump = false;
    }
}
