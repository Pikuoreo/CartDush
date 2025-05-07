using System;
using UnityEngine;

/// <summary>
/// �W�����v�����̊��N���X
/// </summary>
[RequireComponent(typeof(GroundJudgement))]
public abstract class BaseJump : MonoBehaviour
{
    //true�ŃW�����v�J�n
    protected bool _isJump = false;

    protected bool _isFalling = false;

    //�W�����v�������̗�
    protected float _jumpPower = 0;

    //�������ɂ�����d�͂̋���
    protected readonly int GRAVITY = 1;

    //�W�����v�͂̏����l
    protected const float DEFAULT_JUMP_POWER = 3.5f;

    protected const float TIME_DELTATIME_MULTIPLE = 10f;

    //�n�ʔ���̏������Ǘ�����N���X
    protected GroundJudgement _groundJudgement = default;

    //���n������ɏ�������s�����߂̃C�x���g
    public event Action _judgePlayerPosition;

    private void Start()
    {
        //�W�����v�͂̏�����
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
    /// �W�����v���ł����Ԃ�����
    /// </summary>
    public abstract void JudgePossibleJump();

    //�W�����v�̏㏸�A�~���̏������Ăяo��
    protected virtual void Jump()
    {
        if (_jumpPower >= 0)
        {
            //�㏸������
            Up();
        }
        //�W�����v�͂����Ȃ�
        else
        {
            //���~������
            Fall();
        }
        //�W�����v�͂����X�Ɍ���������
        JumpPowerGettingWeeker();
    }

    /// <summary>
    /// �㏸����
    /// </summary>
    protected abstract void Up();

    /// <summary>
    /// �~������
    /// </summary>
    protected abstract void Fall();

    protected void PitFall()
    {
        //�~����������
        this.transform.position -= Vector3.up * _jumpPower * GRAVITY * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
    }

    /// <summary>
    /// ��x�W�����v������A�܂��W�����v�ł���悤�ɂ��鏈��
    /// </summary>
    protected void ReJumpable()
    {
        _isJump = false;
        _jumpPower = DEFAULT_JUMP_POWER;
        _judgePlayerPosition?.Invoke();
    }

    /// <summary>
    /// �W�����v�͂����񂾂��߂�
    /// </summary>
    protected abstract void JumpPowerGettingWeeker();

    
}


