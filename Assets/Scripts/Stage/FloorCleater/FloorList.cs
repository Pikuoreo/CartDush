using UnityEngine;

public class FloorList
{
    //�X�e�[�W�̗�
    private GameObject[] _stageFloorObjects = new GameObject[10];
    public GameObject[] StageFloorObjects
    {
        get { return _stageFloorObjects; }
        set { _stageFloorObjects = value; }
    }

    //�X�e�[�W��̔ԍ��̗�
    private int[] _stageFloorNumber = new int[10];
    public int[] StageFloorNumber
    {
        get { return _stageFloorNumber; }
        set { _stageFloorNumber = value; }
    }
}
