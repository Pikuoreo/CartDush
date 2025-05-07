using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CleateFloorCleater))]
/// <summary>
/// プレイヤーのいるポジションにある床を管理する
/// </summary>
public class PlayerPositionFloor : MonoBehaviour
{
    //床生成の役割をもつオブジェクトのそれぞれのリスト０番目のオブジェクト
    [SerializeField] private List<int> _floorsNumber = new List<int>();

    //床生成の役割をもつオブジェクトのそれぞれのリスト０番目のオブジェクト
    public List<int> FloorsNumber
    {
        get { return _floorsNumber; }
        set { _floorsNumber = value; }
    }

    //床生成の役割をもつオブジェクトを生成する処理を管理しているクラス
    private CleateFloorCleater _cleateFloorCleater = default;

    private void Start()
    {
        //床生成の役割をもつオブジェクトを生成する処理を管理しているクラスを取得
        _cleateFloorCleater = this.GetComponent<CleateFloorCleater>();

        _cleateFloorCleater.SetListCapacity();

        //床を生成する子の数と一緒にする
        FloorsNumber.Capacity = _cleateFloorCleater.CleaterLists.Capacity;

        SetListSize();
    }

    /// <summary>
    /// リストのサイズを設定する
    /// </summary>
    private void SetListSize()
    {
        while (FloorsNumber.Count < FloorsNumber.Capacity)
        {
            FloorsNumber.Add(0);
        }

        floorCleate();
    }

    /// <summary>
    /// 床を生成するオブジェクトを生成する
    /// </summary>
    private void floorCleate()
    {
        _cleateFloorCleater.Cleate();
    }
}
