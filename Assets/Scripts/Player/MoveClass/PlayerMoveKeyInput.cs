using UnityEngine;

/// <summary>
/// �ړ��L�[�̔��������N���X
/// </summary>
public class PlayerMoveKeyInput : MonoBehaviour
{
    //�v���C���[�̈ړ�����
    public delegate void PlayerMove();

    //�v���C���[�̍��ړ��̃C�x���g
    private event PlayerMove _leftMoveHandler = default;

    //�v���C���[�̉E�ړ��̃C�x���g
    private event PlayerMove _rightMoveHandler = default;

    //�v���C���[�̃W�����v�̃C�x���g
    private event PlayerMove _jumpHandler = default;

    //true�ō��ړ��������Ăяo��
    private bool _isLeftMove = false;

    //true�ŉE�ړ��������Ăяo��
    private bool _isRightMove = false;

    //true�ŃW�����v�������Ăяo��
    private bool _isJump = false;

    //�v���C���[�̍��ړ��̃C�x���g
    public event PlayerMove LeftMoveHandler
    {
        add => _leftMoveHandler += value;

        remove => _leftMoveHandler -= value;
    }

    //�v���C���[�̉E�ړ��̃C�x���g
    public event PlayerMove RightMoveHandler
    {
        add => _rightMoveHandler += value;

        remove => _rightMoveHandler -= value;
    }

    //�v���C���[�̃W�����v�̃C�x���g
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
    /// �ړ������̃��\�b�h���Ăяo��
    /// </summary>
    private void PlayerMoveStart()
    {
        JudgeLeftMove();
        JudgeRightMove();
        JudgeJump();
    }

    /// <summary>
    /// ���ړ��\���̔�����Ƃ�
    /// </summary>
    private void JudgeLeftMove()
    {
        //���ړ��\��������
        if (_isLeftMove)
        {
            //���ړ��C�x���g���J�n
            _leftMoveHandler?.Invoke();
        }
    }

    /// <summary>
    /// �E�ړ��\���̔�����Ƃ�
    /// </summary>
    private void JudgeRightMove()
    {
        //�E�ړ��\��������
        if (_isRightMove)
        {
            //�E�ړ��C�x���g�J�n
            _rightMoveHandler?.Invoke();
        }
    }

    /// <summary>
    /// �W�����v�\���̔�����Ƃ�
    /// </summary>
    private void JudgeJump()
    {
        //�W�����v�\��������
        if (_isJump)
        {
            //�W�����v�����C�x���g�J�n
            _jumpHandler?.Invoke();
        }
    }

    /// <summary>
    /// �ړ��L�[�������������郁�\�b�h���Ăяo��
    /// </summary>
    private void MoveKeyInput()
    {
        LeftMoveKeyInput();
        RightMoveKeyInput();
        JumpKeyInput();
    }

    /// <summary>
    /// ���ړ��̃L�[�������Ă��邩����
    /// </summary>
    private void LeftMoveKeyInput()
    {
        //A�����������Ă����
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //���ړ����\��
            _isLeftMove = true;
            return;
        }
        //���ړ���s��
        _isLeftMove = false;
    }

    /// <summary>
    /// �E�ړ��̃L�[�������Ă��邩����
    /// </summary>
    private void RightMoveKeyInput()
    {
        //D�����������Ă����
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //�E�ړ����\��
            _isRightMove = true;
            return;
        }
        //�E�ړ���s��
        _isRightMove = false;
    }

    /// <summary>
    /// �W�����v�̃L�[�������Ă��邩����
    /// </summary>
    private void JumpKeyInput()
    {
        //�X�y�[�X�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�W�����v�\��
            _isJump = true;
            return;
        }
        //�W�����v�s��
        _isJump = false;
    }
}
