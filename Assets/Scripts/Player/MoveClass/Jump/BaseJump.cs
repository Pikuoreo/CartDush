using System;
using UnityEngine;

/// <summary>
/// ジャンプ処理の基底クラス
/// </summary>
[RequireComponent(typeof(GroundJudgement))]
public abstract class BaseJump : MonoBehaviour
{
    //trueでジャンプ開始
    protected bool _isJump = false;

    protected bool _isFalling = false;

    //ジャンプした時の力
    protected float _jumpPower = 0;

    //落下時にかかる重力の強さ
    protected readonly int GRAVITY = 1;

    //ジャンプ力の初期値
    protected const float DEFAULT_JUMP_POWER = 3.5f;

    protected const float TIME_DELTATIME_MULTIPLE = 10f;

    //地面判定の処理を管理するクラス
    protected GroundJudgement _groundJudgement = default;

    //着地した後に床判定を行うためのイベント
    public event Action _judgePlayerPosition;

    private void Start()
    {
        //ジャンプ力の初期化
        _jumpPower = DEFAULT_JUMP_POWER;

        _groundJudgement = GetComponent<GroundJudgement>();
        GameUpdator.Instance.SubscribePlayerUpdate(JumpUpdate);
    }

    protected abstract void JumpUpdate();

    public void ChangeFalling(bool changeValue)
    {
        _isFalling = changeValue;
        _isJump = changeValue;
    }

    /// <summary>
    /// ジャンプができる状態か見る
    /// </summary>
    public abstract void JudgePossibleJump();

    //ジャンプの上昇、降下の処理を呼び出す
    protected virtual void Jump()
    {
        if (_jumpPower >= 0)
        {
            //上昇させる
            Up();
        }
        //ジャンプ力が負なら
        else
        {
            //下降させる
            Fall();
        }
        //ジャンプ力を徐々に減少させる
        JumpPowerGettingWeeker();
    }

    /// <summary>
    /// 上昇処理
    /// </summary>
    protected abstract void Up();

    /// <summary>
    /// 降下処理
    /// </summary>
    protected abstract void Fall();

    protected void PitFall()
    {
        //降下し続ける
        this.transform.position -= Vector3.up * _jumpPower * GRAVITY * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
    }

    /// <summary>
    /// 一度ジャンプした後、またジャンプできるようにする処理
    /// </summary>
    protected void ReJumpable()
    {
        _isJump = false;
        _jumpPower = DEFAULT_JUMP_POWER;
        _judgePlayerPosition?.Invoke();
    }

    /// <summary>
    /// ジャンプ力をだんだん弱める
    /// </summary>
    protected abstract void JumpPowerGettingWeeker();

    
}


