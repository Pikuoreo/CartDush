using UnityEngine;

/// <summary>
/// �ʏ�̃W�����v�������Ǘ�����N���X
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
    /// �W�����v���ł����Ԃ�����
    /// </summary>
    public override void JudgePossibleJump()
    {
        //�W�����v���Ă��Ȃ�������
        if (!_isJump)
        {
            //�W�����v���J�n������
            _isJump = true;
        }
    }

    /// <summary>
    /// �㏸����
    /// </summary>
    protected override void Up()
    {
        //�㏸
        this.transform.position += Vector3.up * _jumpPower * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);    
    }

    /// <summary>
    /// �~������
    /// </summary>
    protected override void Fall()
    {

        //�n�ʂ������ɂ��邩�̔�����J�n
        //�n�ʂ�����ꍇ
        //���Ƃ����ɗ������Ă��Ȃ���
        if (_groundJudgement.GroundJudge())
        {
            ReJumpable();
        }
        //�n�ʂ������ꍇ
        else
        {
            //�~����������
            this.transform.position += Vector3.up * _jumpPower * GRAVITY * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }

    /// <summary>
    /// �W�����v�͂����񂾂��߂�
    /// </summary>
    protected override void JumpPowerGettingWeeker()
    {
        _jumpPower -= (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
    }
}
