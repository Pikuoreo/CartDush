using UnityEngine;

/// <summary>
/// 床の配列を変更するクラス
/// </summary>
[RequireComponent(typeof(FloorCleater))]
[RequireComponent(typeof(CleateFloor))]
public class ChangeFloorList : MonoBehaviour
{
    private FloorCleater _floorCleater = default;
    private FloorPool _floorPool = default;
    private CleateFloor _cleateFloor = default;
    private LookPlayerPointLaneFloor _lookPlayerPointLaneFloor = default;

    private int _floorNumber = 0;
    private int cleaterID = 0;


    void Start()
    {
        _floorCleater = this.GetComponent<FloorCleater>();
        _floorPool = GameObject.FindAnyObjectByType<FloorPool>();
        _cleateFloor = this.GetComponent<CleateFloor>();
        if (_floorPool == null)
        {
            Debug.LogError($"FloorPoolがついているオブジェクトが見つかりませんでした。");
            return;
        }

        _lookPlayerPointLaneFloor = this.GetComponentInParent<LookPlayerPointLaneFloor>();
        if (_lookPlayerPointLaneFloor == null)
        {
            Debug.LogError($"{this.gameObject.name}の親オブジェクトにLookPlayerPointLaneFloorがアタッチされていません！！");
            return;
        }

        //床生成するオブジェクトのIDを取得
        cleaterID = _floorCleater.FloorListData.FloorCleaterID;
    }

    /// <summary>
    /// 配列を変更
    /// </summary>
    public void ListChange()
    {

        RemoveFloor();

        UpdateListNumber();

        //配列の先頭を再読み込みさせる
        _floorCleater.FloorListPresenter.PassFloorListNumber();

        //先頭のオブジェクトを集合させている場所に渡す
        PlayerPositionLaneFloorsData.Instance.GetFloors(_floorNumber, cleaterID);

        //床の判定を開始
        _lookPlayerPointLaneFloor.PlayerPointJudge(_floorCleater.FloorListData.FloorCleaterID);

        //新しい床を生成
        _cleateFloor.CleateStage();

        _floorCleater.IsEndFloorChange = true;
    }

    private void UpdateListNumber()
    {
        //次の番号配列の先頭を代入
        _floorNumber = _floorCleater.FloorListData.FloorNumberList.Peek();
    }

    private void RemoveFloor()
    {
        //今の配列の先頭の番号を代入&削除
        _floorNumber = _floorCleater.FloorListData.FloorNumberList.Dequeue();

        _floorCleater.FloorListData.BaseFloorList.Dequeue();

        //オブジェクト配列の先頭を消去＆返却
        _floorPool.PoolDataList[_floorNumber].ReturnObject(_floorCleater.FloorListData.FloorObjectList.Dequeue());


    }
}
