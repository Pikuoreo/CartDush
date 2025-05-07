using UnityEngine;

/// <summary>
/// �W�����v���A�n�ʔ�����Ƃ鏈���̃N���X
/// </summary>
public class GroundJudgement : MonoBehaviour
{
    //���C�̒���
    private const float RAY_LENGTH = 1f;

    //���C�̓������Ăق������C���[�}�X�N(6bit�̒l)
    private const int GROUND_LAYER = 64;

    /// <summary>
    /// �n�ʂ����邩�̔�������
    /// </summary>
    /// <returns>true�ŏ��ɓ�����������Afalse�͉����������ĂȂ���������Ȃ�����</returns>
    public bool GroundJudge()
    {

        Vector3 rayStartPosition = this.gameObject.transform.position;

        //���C���������ɔ�΂��A�I�u�W�F�N�g�ɓ����������̔�����Ƃ�
        if (Physics.Raycast(rayStartPosition, Vector3.down, RAY_LENGTH, GROUND_LAYER))
        {
            // GROUND_LAYER�ɓ���������true��Ԃ�
            return true;
        }
        //�����������ĂȂ��Ȃ�false��Ԃ�
        return false;
    }
}
