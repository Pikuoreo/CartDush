using UnityEngine;


public class ObstacleFloorData : BaseFloor
{
    //���X�g�̑傫��
    private const int OBSTACLE_COUNT = 5;
    //��Q���̃I�u�W�F�N�g�@
    private GameObject[] _obstacles = new GameObject[OBSTACLE_COUNT];

    private GameObject _floorObject = default;

    //�ŏ��̏�Q���̍���
    private const int MIN_RANDOM_VALUE = 1;

    //�ő�̏�Q���̍���
    private const int MAX_RANDOM_VALUE = 6;

    //��Q���̍���
    private int _obstacleHeightValue = 0;

    public ObstacleFloorData(GameObject floorObject)
    {
        _floorObject = floorObject;

        ObstacleFloor();
    }

    public override void FloorEvent(LookPlayerPointLaneFloor lookPlayerPointLaneFloor)
    {
        lookPlayerPointLaneFloor.JudgeObstaclehit(_obstacleHeightValue);
    }

    /// <summary>
    /// �R���X�g���N�^�ŏ�Q���̏��I�u�W�F�N�g��F������
    /// </summary>
    /// <param name="floorObject">���I�u�W�F�N�g</param>
    private void ObstacleFloor()
    {
        //�����̎���Q���̃I�u�W�F�N�g���擾
        for (int currentChild = 0; currentChild < _floorObject.transform.childCount; currentChild++)
        {
            _obstacles[currentChild] = _floorObject.transform.GetChild(currentChild).gameObject;
        }
        SetObstacleHeight();
    }

    /// <summary>
    /// ��Q���̍�����ݒ肷��
    /// </summary>
    private void SetObstacleHeight()
    {
        //��Q���̍����������_���Ŏw��
        _obstacleHeightValue = Random.Range(MIN_RANDOM_VALUE, MAX_RANDOM_VALUE);

        //��Q���̍������I�u�W�F�N�g��SetActive��ON
        for (int i = 0; i < _obstacleHeightValue; i++)
        {
            _obstacles[i].gameObject.SetActive(true);
        }
    }
}
