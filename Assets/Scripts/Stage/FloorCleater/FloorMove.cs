using UnityEngine;

[RequireComponent(typeof(FloorCleater))]
///床配列を動かすクラス
public class FloorMove : MonoBehaviour
{
    private FloorCleater _floorCleater;
    private ChangeFloorList _changeFloorList = default;
    private FloorMoveSpeedManager _moveSpeedManager = FloorMoveSpeedManager.Instance;
    private Transform _playerPosition = default;

    private const int HARF_VALUE = 2;

    private const int TIME_DELTATIME = 10;
    void Start()
    {
        //プレイヤーの位置を取得
        const string FIND_TAG = "Player";
        _playerPosition = GameObject.FindGameObjectWithTag(FIND_TAG).transform;
        _floorCleater = this.GetComponent<FloorCleater>();
        _changeFloorList = this.GetComponent<ChangeFloorList>();

        GameUpdator.Instance.SubscribeUpdate(floorMoveUpdate);
    }

    // Update is called once per frame
    void floorMoveUpdate()
    {
        MoveCloser();
    }

    /// <summary>
    /// 手前に移動
    /// </summary>
    private void MoveCloser()
    {
        //配列の中身を移動させる
        foreach (GameObject floors in _floorCleater.FloorListData.FloorObjectList)
        {
            floors.transform.position += (Vector3.back * _moveSpeedManager.FloorMoveSpeed) * (Time.deltaTime * TIME_DELTATIME);
        }

        JudgeFloorPosition();
    }

    private void JudgeFloorPosition()
    {
        //一番手前のオブジェクトを取得
        GameObject firstLaneFloor = _floorCleater.FloorListData.FloorObjectList.Peek();


        //一番手前のオブジェクトがプレイヤーの位置にまで来たら
        if ((firstLaneFloor.transform.position.z + firstLaneFloor.transform.lossyScale.z / HARF_VALUE <= _playerPosition.transform.position.z) && _floorCleater.IsEndFloorChange)
        {
            _floorCleater.IsEndFloorChange = false;
            //一番手前のオブジェクトを変更する
            _changeFloorList.ListChange();
        }
    }

}
