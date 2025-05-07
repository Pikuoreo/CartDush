using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̔z����Ǘ�����N���X
/// </summary>
public class FloorCleaterListData
{
    ////���̃I�u�W�F�N�g�z��
    private Queue<GameObject> _floorObjectList = new Queue<GameObject>();

    //���̔ԍ��z��
    private Queue<int> _floorNumberList = new Queue<int>();

    private Queue<BaseFloor> _baseFloorList = new Queue<BaseFloor>();

    //�������I�u�W�F�N�g�̔ԍ�
    private int _floorCleaterID = 0;

    //���̃I�u�W�F�N�g�z��
    public Queue<GameObject> FloorObjectList
    {
        get { return _floorObjectList; }
        set { _floorObjectList = value; }
    }

    //���̔ԍ��z��
    public Queue<int> FloorNumberList
    {
        get { return _floorNumberList; }

        set { _floorNumberList = value; }
    }

    public Queue<BaseFloor> BaseFloorList
    {
        get { return _baseFloorList; }
        set { _baseFloorList = value; }
    }

    //�������I�u�W�F�N�g�̔ԍ�
    public int FloorCleaterID
    {
        get { return _floorCleaterID; }
        set { _floorCleaterID = value; }
    }

}
