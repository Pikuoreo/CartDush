using UnityEngine;

/// <summary>
/// �v���C���[�̍��E�ړ������̃N���X
/// </summary>
public class PlayerHorizontalMove : MonoBehaviour
{
    //�x�[�X�ƂȂ鏰��Transform
    [SerializeField] private Transform _floorTransform = default;

    //���ړ��̑���
    private float _HorizontalMoveSpeed = 2.5f;

    //���[�̃|�W�V�����̒l
    private float _floorLeftEdge = 0;

    //�E�[�̃|�W�V�����̒l
    private float _floorRightEdge = 0;

    private const float TIME_DELTATIME_MULTIPLE = 5f;

    //�I�u�W�F�N�g�̒[���v�Z����Ƃ��A�[��菭����O�ɂ��邽�߂̕ϐ�
    private const float FLOOR_EDGE_ADJUSTMENT = 2.15f;

    private void Start()
    {
        //���̒[�̃|�W�V�������Ƃ�
        _floorLeftEdge = -_floorTransform.localScale.x / FLOOR_EDGE_ADJUSTMENT;
        _floorRightEdge = _floorTransform.localScale.x / FLOOR_EDGE_ADJUSTMENT;
    }

    /// <summary>
    /// ���ړ��̏���
    /// </summary>
    public void LeftMove(Transform playerTrandform)
    {
        //���̍��[����O�Ȃ�
        if (playerTrandform.position.x > _floorLeftEdge)
        {
            //���ړ�
            playerTrandform.position += Vector3.left * _HorizontalMoveSpeed * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }

    /// <summary>
    /// �E�ړ��̏���
    /// </summary>
    public void RightMove(Transform playerTrandform)
    {
        //���̉E�[����O�Ȃ�
        if (playerTrandform.position.x < _floorRightEdge)
        {
            //�E�ړ�
            playerTrandform.position += Vector3.right * _HorizontalMoveSpeed * (Time.deltaTime * TIME_DELTATIME_MULTIPLE);
        }
    }
}
