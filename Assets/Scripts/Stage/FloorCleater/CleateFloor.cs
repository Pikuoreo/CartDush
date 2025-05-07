using UnityEngine;

[RequireComponent(typeof(FloorCleater))]
///床を生成するクラス
public class CleateFloor : MonoBehaviour
{
    //オブジェクトのスケールを半分にするための値
    private const int HARF_OBJECT_SCALE = 2;

    //指定した数分だけ、一番最初にデフォルトの床を生成する
    private const int INTRO_STAGE_VALUE = 5;

    //配列の長さ
    private const int LIST_LENGHT = 15;

    //生成する位置(初期位置は３)
    private float _cleatePositionZ = 3f;

    //ひとつ前に生成したオブジェクト
    private GameObject _previewCleateObject = default;

    private FloorCleater _floorCleater = default;

    private FloorPool _floorPool = default;

    private void Start()
    {

        //コンポ―ネントの取得
        _floorCleater = this.GetComponent<FloorCleater>();
        _floorPool = GameObject.FindAnyObjectByType<FloorPool>();

        if (_floorPool == null)
        {
            Debug.LogError($"FloorPoolがついているオブジェクトが見つかりませんでした。");
            return;
        }

        //床を生成
        CleateStartStage();
    }

    /// <summary>
    /// 各フロアの番号
    /// </summary>
    private enum CleateFloorKinds
    {
        //ギミックなしの床の番号
        DefaultFloor = 0,
        //障害物ありの床の番号
        ObstacleFloor = 1,
        //落とし穴の床の番号
        PitFallFloor = 2,
        //スピードアップギミックの床の番号
        SpeedUpFloor = 3
    }

    /// <summary>
    /// ステージの床を生成する
    /// </summary>
    private void CleateStartStage()
    {
        for (int currentList = 0; currentList < LIST_LENGHT; currentList++)
        {
            GameObject floorObject;
            //ランダムで生成する床の番号をとる
            if (currentList <= INTRO_STAGE_VALUE)
            {
                floorObject = ReturnFloorKinds(0);
            }
            else
            {
                floorObject = ReturnFloorKinds((CleateFloorKinds)JudgeReturnFloorKindsValue(Random.Range(0, 10000)));
            }
            //床の配列に格納する
            _floorCleater.FloorListData.FloorObjectList.Enqueue(floorObject);

            //生成するポジションを計算する
            Vector3 cleatePosition = CleatePositionCalculation(floorObject);

            //オブジェクトの位置を変更する
            floorObject.transform.position = cleatePosition;

            //生成したオブジェクトを子の関係にする
            floorObject.transform.parent = this.transform;
        }

        //床の先頭を読み込ませる
        _floorCleater.FloorListPresenter.PassFloorListNumber();

        this.gameObject.AddComponent<ChangeFloorList>();
        this.gameObject.AddComponent<FloorMove>();
    }

    public void CleateStage()
    {
        //番号別の床をオブジェクトプールから取り出す
        GameObject floorObject = ReturnFloorKinds((CleateFloorKinds)JudgeReturnFloorKindsValue(Random.Range(0, 10000)));

        //生成するポジションを計算する
        Vector3 cleatePosition = CleatePositionCalculation(floorObject);

        //オブジェクトの位置を変更する
        floorObject.transform.position = cleatePosition;

        //床の配列に格納する
        _floorCleater.FloorListData.FloorObjectList.Enqueue(floorObject);

        //生成したオブジェクトを子の関係にする
        floorObject.transform.parent = this.transform;
    }

    /// <summary>
    /// 生成するオブジェクトをプール内から取得
    /// </summary>
    /// <param name="SelectObjectnumber">生成するオブジェクトの番号</param>
    /// <returns>生成するオブジェクトを返す</returns>
    private GameObject SelectCleateObject(int SelectObjectnumber)
    {
        //生成するオブジェクトをプール内から取得
        GameObject returnFloor = _floorPool.PoolDataList[SelectObjectnumber].GetFloor();

        //
        return returnFloor;
    }

    /// <summary>
    /// 床の生成をランダム化（ある程度のランダム制御）し、生成するオブジェクトを返す
    /// </summary>
    /// <param name="randomcleatefloorValue">生成する床の種類を決めるための乱数</param>
    /// <returns>生成する床のオブジェクトを返す</returns>
    private GameObject ReturnFloorKinds(CleateFloorKinds cleateFloorKinds)
    {
        GameObject returnObject = default;

        int floorKindsNumber = (int)cleateFloorKinds;

        //返すオブジェクトを取得
        returnObject = SelectCleateObject(floorKindsNumber);

        //返すオブジェクトがnullだった場合
        if (returnObject == null)
        {
            //enumの値をギミックなしの床の値に変更
            cleateFloorKinds = CleateFloorKinds.DefaultFloor;

            //生成する床の番号をギミックなしの床の番号に変更
            floorKindsNumber = (int)cleateFloorKinds;
            //ギミックなしの床を取得
            returnObject = SelectCleateObject(floorKindsNumber);
        }
        //床の番号を配列に格納する
        _floorCleater.FloorListData.FloorNumberList.Enqueue(floorKindsNumber);

        switch (cleateFloorKinds)
        {
            case CleateFloorKinds.DefaultFloor:

                // 通常の床のインスタンスを生成
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new DefaultFloor());

                break;

            case CleateFloorKinds.ObstacleFloor:

                // 障害物を持つ床のインスタンスを生成
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new ObstacleFloorData(returnObject));

                break;

            case CleateFloorKinds.PitFallFloor:

                // 落とし穴を持つ床のインスタンスを生成
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new PitFallFloorData());

                break;

            case CleateFloorKinds.SpeedUpFloor:

                // 落とし穴を持つ床のインスタンスを生成
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new SpeedUpFloorData());

                break;
        }
        //普通の床のオブジェクトを返す
        return returnObject;

    }

    private int JudgeReturnFloorKindsValue(int randomValue)
    {
        if (randomValue >= 9750)
        {
            return 3;
        }

        if (randomValue >= 9000)
        {
            return 2;
        }

        if (randomValue >= 6000)
        {
            return 1;
        }

        return 0;
    }

    /// <summary>
    /// 生成するポジションを実際に生成するオブジェクトごとに計算する
    /// </summary>
    /// <param name="cleateObject">実際に生成するオブジェクト</param>
    /// <returns>求めた生成するポジションを返す</returns>
    private Vector3 CleatePositionCalculation(GameObject cleateObject)
    {
        //すでにひとつ前に床を生成していたら
        if (_previewCleateObject != null)
        {
            //ひとつ前の床の奥端と、今回生成する床の手前端を取得する
            float previewObjectEdge = _previewCleateObject.transform.localScale.z / HARF_OBJECT_SCALE;
            float currentObjectEdge = cleateObject.transform.localScale.z / HARF_OBJECT_SCALE;

            //二つの端を併せて最終的に生成するポジションのZを求める
            _cleatePositionZ = previewObjectEdge + currentObjectEdge + _previewCleateObject.transform.localPosition.z;
        }
        //一つ目の床の生成だった場合
        else
        {
            //床のサイズが違っても端がそろうように調整
            _cleatePositionZ = (cleateObject.transform.localScale.z - _cleatePositionZ) / HARF_OBJECT_SCALE;
        }

        //最終的に生成するポジション全体を求める
        Vector3 CalculationResult = this.transform.position + new Vector3(0, 0, _cleatePositionZ);

        //今回生成したオブジェクトを次の計算で使うため、保持しておく
        _previewCleateObject = cleateObject;

        //生成するポジションを返す
        return CalculationResult;
    }

}
