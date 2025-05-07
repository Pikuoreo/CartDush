using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 床の配列を管理するクラス
/// </summary>
public class FloorCleaterListData
{
    ////床のオブジェクト配列
    private Queue<GameObject> _floorObjectList = new Queue<GameObject>();

    //床の番号配列
    private Queue<int> _floorNumberList = new Queue<int>();

    private Queue<BaseFloor> _baseFloorList = new Queue<BaseFloor>();

    //床生成オブジェクトの番号
    private int _floorCleaterID = 0;

    //床のオブジェクト配列
    public Queue<GameObject> FloorObjectList
    {
        get { return _floorObjectList; }
        set { _floorObjectList = value; }
    }

    //床の番号配列
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

    //床生成オブジェクトの番号
    public int FloorCleaterID
    {
        get { return _floorCleaterID; }
        set { _floorCleaterID = value; }
    }

}
