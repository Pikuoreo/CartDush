using UnityEngine;

public class FloorList
{
    //ステージの列
    private GameObject[] _stageFloorObjects = new GameObject[10];
    public GameObject[] StageFloorObjects
    {
        get { return _stageFloorObjects; }
        set { _stageFloorObjects = value; }
    }

    //ステージ列の番号の列
    private int[] _stageFloorNumber = new int[10];
    public int[] StageFloorNumber
    {
        get { return _stageFloorNumber; }
        set { _stageFloorNumber = value; }
    }
}
