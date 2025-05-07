using UnityEngine;

/// <summary>
/// ���ꂼ��̃C�x���g�ɑ΂��ď�����ǉ�����N���X
/// </summary>
/// 
[RequireComponent(typeof(PlayerMoveKeyInput))]
[RequireComponent(typeof(PlayerHorizontalMove))]
public class PlayerMoveProssesPresenter : MonoBehaviour
{
    //�ړ��L�[�����������̔�����Ƃ�N���X
    private PlayerMoveKeyInput _playerMoveKeyInput = default;

    //���ړ��̂̏������Ǘ�����N���X
    private PlayerHorizontalMove _playerHorizontalMove = default;

    //�W�����v�̏������Ǘ�����N���X
    private JumpClassChanger _jumpClassChanger = default;

    private void Start()
    {
        _playerMoveKeyInput = this.GetComponent<PlayerMoveKeyInput>();
        _playerHorizontalMove = this.GetComponent<PlayerHorizontalMove>();

        if (!TryGetComponent<JumpClassChanger>(out _jumpClassChanger))
        {
            Debug.LogError("JumpClassChanger�A�^�b�`����Ă��܂���I�I");
            return;
        }

        HandleSet();
    }

    /// <summary>
    /// �ړ������̃��\�b�h���Z�b�g����
    /// </summary>
    private void HandleSet()
    {
        //���ړ����Ăяo���������Z�b�g
        _playerMoveKeyInput.LeftMoveHandler += HandleLeftMove;

        //�E�ړ����Ăяo���������Z�b�g
        _playerMoveKeyInput.RightMoveHandler += HandleRightMove;

        //�W�����v�������Ăяo���������Z�b�g
        _playerMoveKeyInput.JumpHandler += HandleJump;
    }

    /// <summary>
    /// ���ړ��������Ăяo��
    /// </summary>
    private void HandleLeftMove()
    {
        _playerHorizontalMove.LeftMove(this.transform);
    }

    /// <summary>
    /// �E�ړ��������Ăяo��
    /// </summary>
    private void HandleRightMove()
    {
        _playerHorizontalMove.RightMove(this.transform);
    }

    /// <summary>
    /// �W�����v�������Ăяo��
    /// </summary>
    private void HandleJump()
    {
        _jumpClassChanger.CurrentJumpClass.JudgePossibleJump();
    }
}
