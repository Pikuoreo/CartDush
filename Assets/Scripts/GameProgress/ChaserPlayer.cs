using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[��ǂ������鑤�i�Q�[���I�[�o�[�]�[���j�̋������Ǘ�����N���X
/// </summary>
public class ChaserPlayer : MonoBehaviour
{
    [SerializeField,Header("��Ƃ̋����e�L�X�g")] private Text _distanceText = default;
    [SerializeField,Header("���U���g�̑��s�����e�L�X�g")] private Text _distanceTraveledText = default;

    //�Q�[���I�[�o�[�ɂȂ�܂ł̋���
    public float DisTance
    {
        get; private set;
    }

    //�v���C���[�ɋ߂Â��Ă�������
    private float _closerSpeed = 2.7f;

    //�o�ߎ���
    private float _elapsedTime = 0f;

    //�����x���A�b�v����܂ł̎���
    private float _levelUpTime = 8;

    //�߂Â����A�i�ޑ��̃X�s�[�h���ׂė���Ă��鋗���̌v�Z�Ɏg��
    //�X�s�[�h�̒l�����̂܂܌v�Z������l���傫������̂ŁA�P�O�O���̂P�ɂ���
    private const int FRACTION_OF_HUNDRED = 100;

    //���̃��x���A�b�v����܂ł̒ǉ�����
    private const float NEXT_LEVEL_UP_TIME = 0.25f;

    //�Q�[���J�n���̃v���C���[�Ɨ���Ă��鋗��
    private const float START_DISTANCE_VALUE = 200f;

    private DistanceTraveled _distanceTraveled=default;
    private void Start()
    {
        DisTance = START_DISTANCE_VALUE;
        GameUpdator.Instance.SubscribeUpdate(ChaserPlayerUpdate);

        _distanceTraveled=new DistanceTraveled(_distanceTraveledText);
    }
    void ChaserPlayerUpdate()
    {
            DistanceUpdate();
            _distanceTraveled.IncreaseDistanceTraveled();
    }

    /// <summary>
    /// �o�ߎ��Ԃ��Ƃɒǂ�������X�s�[�h�A�i�ރX�s�[�h�𑁂�����
    /// </summary>
    private void DifficultyLevelUp()
    {
        //�o�ߎ���
        _elapsedTime += Time.deltaTime;

        //�����o�ߎ��Ԃ����x���A�b�v�܂ł̎��Ԃ𒴂�����
        if (_elapsedTime > _levelUpTime)
        {

            //�o�ߎ��Ԃ����Z�b�g
            _elapsedTime = 0;

            //���̃��x���A�b�v�܂ł̎��Ԃ�������������
            _levelUpTime += NEXT_LEVEL_UP_TIME;

            const float CLOSER_SPEED_UP_VALUE = 0.1f;
            //�߂Â��X�s�[�h�𑁂߂�
            _closerSpeed += CLOSER_SPEED_UP_VALUE;

            const float MOVE_SPEED_UP_VALUE = 0.04f;
            //�v���C���[�̐i�ރX�s�[�h�𑁂߂�
            FloorMoveSpeedManager.Instance.FloorMoveSpeed += MOVE_SPEED_UP_VALUE;
        }
    }

    /// <summary>
    /// �v���C���[�Ƃ̋������X�V
    /// </summary>
    private void DistanceUpdate()
    {
        //�ǂ������鑤�̃X�s�[�h���������A�v���C���[���i�ރX�s�[�h���𑫂�
        //���ʁA�v���C���[�Ƃǂꂭ�炢����Ă��邩���v�Z
        DisTance -= _closerSpeed / FRACTION_OF_HUNDRED;
        DisTance += FloorMoveSpeedManager.Instance.FloorMoveSpeed / FRACTION_OF_HUNDRED;

        const string DISTANCE = "��Ƃ̋����F";
        const string METER = "m";
        //�e�L�X�g�̍X�V
        _distanceText.text = DISTANCE + DisTance.ToString("F0")+METER;

        DifficultyLevelUp();
    }
}
