using System.Collections.Generic;
using UnityEngine;

public enum CleateFloorKinds
{
    DefaultFloorPool = 0,
    ObstaclefloorPool = 1,
    PitFallFloorPool = 2,
    SpeedUpfloorPool = 3
}

/// <summary>
/// 床の種類ごとのオブジェクトプールを生成するクラス
/// </summary>
public class FloorPool : MonoBehaviour
{
    //生成する床の種類
    [SerializeField] private List<GameObject> _cleateFloors = new List<GameObject>();

    //生成する床の数の配列
    [SerializeField] private int[] _floorPoolValueLists = new int[4];
    //床オブジェクトプールのデータのリスト
    private List<FloorPoolData> _poolDataList = new List<FloorPoolData>();

    //ギミック無しの床を生成するインスタンスか
    private bool _isDefaultFloorpool = true;
    public List<FloorPoolData> PoolDataList
    {
        get { return _poolDataList; }
        set { _poolDataList = value; }
    }

 

    private enum PoolFloorValue
    {
        //通常の床の生成数
        DefaultFloorValue = 50,

        //障害物ありの床の生成数
        ObstaclefloorValue = 10,

        //落とし穴床の生成数
        PitFallFloorValue = 5,

        //スピードアップ床の生成数
        SpeedUpfloorValue = 1
    }

    

    void Start()
    {
        //配列にそれぞれの床の生成数を代入
        _floorPoolValueLists[0] = (int)PoolFloorValue.DefaultFloorValue;
        _floorPoolValueLists[1] = (int)PoolFloorValue.ObstaclefloorValue;
        _floorPoolValueLists[2] = (int)PoolFloorValue.PitFallFloorValue;
        _floorPoolValueLists[3] = (int)PoolFloorValue.SpeedUpfloorValue;

        //床の種類分、床オブジェクトプールのインスタンスを生成
        for (int value = 0; value < _cleateFloors.Count; value++)
        {
            _poolDataList.Add(new FloorPoolData(_cleateFloors[value], _floorPoolValueLists[value], (CleateFloorKinds)value));
        }

    }
}
