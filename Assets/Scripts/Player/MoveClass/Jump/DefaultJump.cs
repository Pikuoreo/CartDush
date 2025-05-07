using UnityEngine;

/// <summary>
/// 通常のジャンプ処理を管理するクラス
/// </summary>
public class DefaultJump : BaseJump
{
    protected override void JumpUpdate()
    {
        if (_isFalling)
        {
            PitFall();
            return;
        }

        if (_isJump)
        {
            Jump();
        }
    }
    /// <summary>
    /// ジャンプができる状態か見る
    /// </summary>
    public override void JudgePossibleJump()
    {
        //ジャンプしていなかったら
        if (!_isJump)
        {
            //ジャンプを開始させる
            _isJump = true;
        }
    }

    /// <summary>
    /// 上昇処理
    /// </summary>
    protected override void Up()
    {
        //上昇
        this.transform.position += Vector3.up * _jumpPower * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);    
    }

    /// <summary>
    /// 降下処理
    /// </summary>
    protected override void Fall()
    {

        //地面が足元にあるかの判定を開始
        //地面がある場合
        //落とし穴に落下していない時
        if (_groundJudgement.GroundJudge())
        {
            ReJumpable();
        }
        //地面が無い場合
        else
        {
            //降下し続ける
            this.transform.position += Vector3.up * _jumpPower * GRAVITY * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }

    /// <summary>
    /// ジャンプ力をだんだん弱める
    /// </summary>
    protected override void JumpPowerGettingWeeker()
    {
        _jumpPower -= (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
    }
}
