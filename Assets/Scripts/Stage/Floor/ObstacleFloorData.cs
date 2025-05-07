using UnityEngine;


public class ObstacleFloorData : BaseFloor
{
    //リストの大きさ
    private const int OBSTACLE_COUNT = 5;
    //障害物のオブジェクト　
    private GameObject[] _obstacles = new GameObject[OBSTACLE_COUNT];

    private GameObject _floorObject = default;

    //最小の障害物の高さ
    private const int MIN_RANDOM_VALUE = 1;

    //最大の障害物の高さ
    private const int MAX_RANDOM_VALUE = 6;

    //障害物の高さ
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
    /// コンストラクタで障害物の床オブジェクトを認識する
    /// </summary>
    /// <param name="floorObject">床オブジェクト</param>
    private void ObstacleFloor()
    {
        //自分の持つ障害物のオブジェクトを取得
        for (int currentChild = 0; currentChild < _floorObject.transform.childCount; currentChild++)
        {
            _obstacles[currentChild] = _floorObject.transform.GetChild(currentChild).gameObject;
        }
        SetObstacleHeight();
    }

    /// <summary>
    /// 障害物の高さを設定する
    /// </summary>
    private void SetObstacleHeight()
    {
        //障害物の高さをランダムで指定
        _obstacleHeightValue = Random.Range(MIN_RANDOM_VALUE, MAX_RANDOM_VALUE);

        //障害物の高さ分オブジェクトのSetActiveをON
        for (int i = 0; i < _obstacleHeightValue; i++)
        {
            _obstacles[i].gameObject.SetActive(true);
        }
    }
}
