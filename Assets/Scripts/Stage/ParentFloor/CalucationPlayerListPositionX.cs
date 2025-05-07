using UnityEngine;

public class CalucationPlayerListPositionX
{
    //�������I�u�W�F�N�g�̐e�̃|�W�V����
    private float floorPositionX = 0f;
    private float FloorPositionDivisionValue = 0f;

    private const int THREE_AWAY = 3;
    private const int TWO_AWAY = 2;
    private const int ONE_AWAY = 1;
    private const int HARF_LIST_LENGTH_X = 2;

    //�񎟌��z��̐^�񒆂̒l
    private int _playerHarfListPoint = 0;

    public int PlayerListPositionX
    {
        get; private set;
    }


    public CalucationPlayerListPositionX(Transform FloorTransofrm, int listCount)
    {
        floorPositionX = FloorTransofrm.position.x;
        //�n�ʂ�X�̕����V�����������̈�u���b�N���̑傫��
        FloorPositionDivisionValue = FloorTransofrm.localScale.x / listCount;

        _playerHarfListPoint = listCount / HARF_LIST_LENGTH_X;
    }
    /// <summary>
    /// �^�񒆂���ǂꂭ�炢����Ă��邩���v�Z����
    /// </summary>
    public void LookFarAwayBrock(float playerPositionX)
    {
        //�v���C���[�̃|�W�V������+��-��������
        bool _positivePlayerPosition = JudgePositiveNumber(playerPositionX);

        //�n�ʂ̐^�񒆂��猩�ĂR�u���b�N������Ă�����
        if (JudgeFarAwayBlock(playerPositionX, THREE_AWAY))
        {
            PlayerPointChange(THREE_AWAY, _positivePlayerPosition);
            return;
        }
        //�n�ʂ̐^�񒆂��猩�ĂQ�u���b�N������Ă�����
        else if (JudgeFarAwayBlock(playerPositionX, TWO_AWAY))
        {
            PlayerPointChange(TWO_AWAY, _positivePlayerPosition);
            return;
        }
        //�n�ʂ̐^�񒆂��猩�ĂP�u���b�N������Ă�����
        else if (JudgeFarAwayBlock(playerPositionX, ONE_AWAY))
        {
            PlayerPointChange(ONE_AWAY, _positivePlayerPosition);
            return;
        }
        //����ȊO�͂O�u���b�N�ŕԂ�
        PlayerPointChange(0, _positivePlayerPosition);
    }

    /// <summary>
    /// �v���C���[�̃|�W�V���������������𔻕�
    /// </summary>
    /// <param name="JudgeNumber">�v���C���[�̃|�W�V����</param>
    /// <returns>true�����Afalse������\��</returns>
    private bool JudgePositiveNumber(float JudgeNumber)
    {
        if (JudgeNumber > 0)
        {
            //����������true��Ԃ�
            return true;
        }
        else
        {
            //����������false��Ԃ�
            return false;
        }
    }

    /// <summary>
    /// farAwayValue������Ă��邩���鏈��
    /// </summary>
    /// <param name="playerPosition">�v���C���[�̃|�W�V����</param>
    /// <param name="farAwayValue������Ă���Ȃ�true�A�����łȂ����false">���u���b�N����Ă��邩������l</param>
    /// <returns>�󂯎�����ϐ�</returns>
    private bool JudgeFarAwayBlock(float playerPosition, int farAwayValue)
    {
        //�v���C���[�̃|�W�V�������Βl��
        float AbsolutePlayerPositionValueX = Mathf.Abs(playerPosition);

        //�v���C���[�̃|�W�V������farAwayValue������Ă�����
        if (AbsolutePlayerPositionValueX >= floorPositionX + FloorPositionDivisionValue * farAwayValue - FloorPositionDivisionValue / 2)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �񎟌��z��̒��Ńv���C���[�̌��ݒn��ύX
    /// </summary>
    /// <param name="FarAwayBrock">�^�񒆂��猩�ė���Ă���u���b�N��</param>
    /// <param name="JudgePositiveNumber">���̐���������</param>
    private void PlayerPointChange(int FarAwayBrock, bool JudgePositiveNumber)
    {
        if (JudgePositiveNumber)
        {
            PlayerListPositionX = _playerHarfListPoint + FarAwayBrock;
        }
        else
        {
            PlayerListPositionX = _playerHarfListPoint - FarAwayBrock;
        }
    }
}
