using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトプールのデータを管理するクラス
/// </summary>
public class FloorPoolData
{
    //オブジェクトプール
    private List<GameObject> _objectList = new List<GameObject>();

    //プール対象のオブジェクト
    private GameObject _poolObject = default;

    //生成する量
    private int _poolValue = 0;

    //ギミックなしの床を生成するインスタンスか
    private CleateFloorKinds _floorPoolKindsNumber = default;

    /// <summary>
    /// コンストラクタで生成するオブジェクトを指定
    /// </summary>
    /// <param name="poolObject">生成するオブジェクト</param>
    /// <param name="poolValue">生成する量</param>
    /// <param name="isDefaultFloorPool">ギミックなしの床を生成するインスタンスか</param>
    public FloorPoolData(GameObject poolObject, int poolValue, CleateFloorKinds cleateFloorKinds)
    {
        _poolObject = poolObject;
        _poolValue = poolValue;
        _floorPoolKindsNumber = cleateFloorKinds;
        CleateObject();
    }

    /// <summary>
    /// オブジェクト生成
    /// </summary>
    private void CleateObject()
    {
        for (int i = 0; i < _poolValue; i++)
        {
            _objectList.Add(MonoBehaviour.Instantiate(_poolObject));
            _objectList[i].SetActive(false);
        }
    }

    /// <summary>
    /// オブジェクトを渡す処理
    /// </summary>
    /// <returns>渡すオブジェクトを返す</returns>
    public GameObject GetFloor()
    {
        //配列の中でenableがfalseになっているものを探す
        foreach (GameObject objectList in _objectList)
        {
            //enableがfalseであれば
            if (!objectList.activeSelf)
            {
                //enableをtrueにし、そのオブジェクトを渡す
                objectList.SetActive(true);
                return objectList;
            }
        }

        //通常の床を生成するプールのみ行う処理
        if (_floorPoolKindsNumber==CleateFloorKinds.DefaultFloorPool)
        {
            //すでに全部使われていたら、新しいオブジェクトを生成
            _objectList.Add(MonoBehaviour.Instantiate(_poolObject));
            return _objectList[_objectList.Count - 1];
        }
        //それ以外は、全てのプールオブジェクトを使用していた場合、nullを返す
        return null;
    }

    /// <summary>
    /// オブジェクトを返却する処理
    /// </summary>
    /// <param name="returnObject">返却されたオブジェクト</param>
    public void ReturnObject(GameObject returnObject)
    {
        returnObject.transform.parent = null;
        // オブジェクトがプール内に存在するかを確認し、無ければ
        if (!_objectList.Contains(returnObject))
        {
            Debug.LogError($"参照したオブジェクトリスト：{_objectList[0]}のリスト、返却されたオブジェクト{returnObject}");
            Debug.LogError($"返却するオブジェクトが見つかりませんでした");
            return;
        }

        if (_floorPoolKindsNumber == CleateFloorKinds.ObstaclefloorPool)
        {
            ChangeObstacleSetActive(returnObject);
        }

        
        // あればオブジェクトを非アクティブにする
        returnObject.SetActive(false);

    }

    /// <summary>
    /// 障害物ギミック床についている子のSetActiveをすべてFalseにする
    /// </summary>
    /// <param name="obstacleFloor"></param>
    private void ChangeObstacleSetActive(GameObject obstacleFloor)
    {
        //子の障害物の数を取得
            int childCount = obstacleFloor.transform.childCount;

        //子の数分繰り返す
        while (childCount > 0)
            {

            childCount--;
            //子の障害物のSetActiveをFalseにする
            obstacleFloor.transform.GetChild(childCount).gameObject.SetActive(false);
            }   
    }

}
