
/// <summary>
/// それぞれが持つ床の配列の先頭を渡すクラス
/// </summary>
public class FloorListPresenter
{
    private FloorCleater _floorCleater = default;
    private PlayerPositionLaneFloorsData _playerPositionFloorData = default;
    private int _cleaterID = 0;

    /// <summary>
    /// コンストラクタで各床生成オブジェクトの番号、持っている床配列のデータを取得する
    /// </summary>
    /// <param name="playerPositionFloor">プレイヤーの位置にレーンを見るクラス</param>
    /// <param name="floorcleater">床生成オブジェクトのデータを管理するクラス</param>
    public FloorListPresenter(FloorCleater floorcleater)
    {
        _playerPositionFloorData = PlayerPositionLaneFloorsData.Instance;
        _floorCleater = floorcleater;

        //床生成オブジェクトのIDを取得
        _cleaterID = _floorCleater.FloorListData.FloorCleaterID;
    }

    /// <summary>
    /// 床配列の先頭を読み込み、格納する
    /// </summary>
    public void PassFloorListNumber()
    {
        //床配列の先頭の番号を代入
        _playerPositionFloorData.FloorsNumber[_cleaterID] = _floorCleater.FloorListData.FloorNumberList.Peek();

        _playerPositionFloorData.BaseFloors[_cleaterID] = _floorCleater.FloorListData.BaseFloorList.Peek();

    }

}
