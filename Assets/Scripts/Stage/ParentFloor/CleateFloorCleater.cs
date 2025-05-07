using System.Collections.Generic;
using UnityEngine;

public class CleateFloorCleater : MonoBehaviour
{
    //生成するオブジェクト
    [SerializeField] private GameObject _cleateObject = default;

    //リストのサイズ（ゲーム中のレーンの数）
    //奇数にしないとおかしくなる
    private const int LIST_CAPACITY = 7;

    //生成したオブジェクトを格納するリスト
    //外部から変更はさせない、参照は可能にする
    public List<GameObject> CleaterLists
    {
        get; private set;
    }

    //オブジェクトを生成するポジション
    private float cleatePositionX = 0;

    //生成するポジションをずらす値(床オブジェクトのX幅)
    private const int DISTANCE_VALUE = 3;

    /// <summary>
    /// 配列の大きさを指定
    /// </summary>
    public void SetListCapacity()
    {
        CleaterLists = new List<GameObject>();
        CleaterLists.Capacity = LIST_CAPACITY;
    }

    private void CleatePositionCalucation()
    {
        float harfListCapacity = Mathf.Floor(LIST_CAPACITY / 2);
        cleatePositionX = -DISTANCE_VALUE * harfListCapacity;
    }
    /// <summary>
    /// 床を生成するオブジェクトを生成する
    /// </summary>
    public void Cleate()
    {
        CleatePositionCalucation();
        //CleaterListsのサイズ分繰り返す
        for (int currentNumber = 0; currentNumber < CleaterLists.Capacity; currentNumber++)
        {
            //生成するポジションをとる
            Vector3 cleatePosition = this.transform.position + new Vector3(cleatePositionX, 0, 0);

            //生成し、配列に格納
            CleaterLists.Add(Instantiate(_cleateObject, cleatePosition, Quaternion.identity));

            //子オブジェクトにセットする
            CleaterLists[currentNumber].transform.parent = this.transform;

            //生成したオブジェクト毎にIDを渡す
            CleaterLists[currentNumber].GetComponent<FloorCleater>().FloorListData.FloorCleaterID = currentNumber;

            //生成するポジションのX軸をずらす
            cleatePositionX += DISTANCE_VALUE;
        }

    }

}
