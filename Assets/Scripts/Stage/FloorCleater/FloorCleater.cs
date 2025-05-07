using UnityEngine;

/// <summary>
/// 床生成オブジェクトのデータを管理するクラス
/// </summary>
public class FloorCleater : MonoBehaviour
{
    private bool _isEndFloorChange = true;

    [SerializeField] private FloorCleaterListData _cleaterData = new FloorCleaterListData();

    //床の先頭を読み込み、格納するクラス
    public FloorListPresenter FloorListPresenter
    {
        get; private set;
    }

    public FloorCleaterListData FloorListData
    {
        get { return _cleaterData; }
        set { _cleaterData = value; }
    }

    public bool IsEndFloorChange
    {
        get { return _isEndFloorChange; }
        set { _isEndFloorChange = value; }
    }

    private void Start()
    {
        //床配列の先頭を読み込み、格納するクラスのインスタンスを生成
        FloorListPresenter = new FloorListPresenter(this.GetComponent<FloorCleater>());

        this.gameObject.AddComponent<CleateFloor>();
    }
}
