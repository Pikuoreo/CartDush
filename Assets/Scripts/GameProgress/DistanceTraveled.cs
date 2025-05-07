using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �Q�[�����̑��s�������Ǘ�����N���X
/// </summary>
public class DistanceTraveled
{
    private Text _distanceTraveledText = default;
    private float _distanceTraveledValue = 0f;

    //�X�s�[�h�̒l�����̂܂܌v�Z������l���傫������̂ŁA�P�O�O���̂P�ɂ���
    private const int FRACTION_OF_HUNDRED = 100;

    public DistanceTraveled(Text distanceTraveledText)
    {
        _distanceTraveledText = distanceTraveledText;
    }
    public void IncreaseDistanceTraveled()
    {
        _distanceTraveledValue += FloorMoveSpeedManager.Instance.FloorMoveSpeed / FRACTION_OF_HUNDRED;
        _distanceTraveledText.text = "�i�񂾋���"+_distanceTraveledValue.ToString("F0")+"m";
    }
}
