using UnityEngine;

[RequireComponent(typeof(CleateFloorCleater))]
public class LookPlayerPointLaneFloor : MonoBehaviour
{
    [SerializeField] private FloorMoveSpeedChanger _floorMoveSpeedChanger = default;
    private GameObject _player = default;

    //プレイヤーの位置の二次元配列
    private int[,] PlayerList = default;

    //プレイヤーの仮リスト変数X
    private int _playerListPointX = 0;

    private int _prePlayerListPointX = 0;

    //プレイヤーの仮リスト変数Y
    private int _playerListPointY = 0;

    const int MAX_PLAYER_LIST_Y = 5;

    private CalucationPlayerListPositionX _calucationPlayerPositionX = default;
    private CalucationPlayerListPositionY _calucationPlayerPositionY = default;

    private LookPlayerPointLaneFloor _myScript = default;

    private BaseJump _baseJump = default;

    private PlayerPositionReset _playerPositionReset = default;

    private void Start()
    {
        //プレイヤーのオブジェクトを検索
        const string PLAYER_TAG = "Player";
        _player = GameObject.FindGameObjectWithTag(PLAYER_TAG);

        _playerPositionReset=new PlayerPositionReset(this.transform,_player.transform);

        //プレイヤーについているジャンプクラスを取得
         _baseJump = _player.GetComponent<BaseJump>();

        //自身のクラスを取得
        _myScript = this.GetComponent<LookPlayerPointLaneFloor>();

        //床判定をする瞬間を指定
        //ジャンプが終わった時
        _baseJump._judgePlayerPosition += HandleFarAwayblock;

        InitializationPlayerPosition();
    }
    /// <summary>
    /// プレイヤーの仮リスト変数を初期化
    /// </summary>
    private void InitializationPlayerPosition()
    {
        //床生成オブジェクトを生成するクラスを取得
       　CleateFloorCleater cleateFloorChildren = this.GetComponent<CleateFloorCleater>();

        //リストのサイズを変更
        PlayerList = new int[cleateFloorChildren.CleaterLists.Count, MAX_PLAYER_LIST_Y];
        //Xポジションを計算のクラスをインスタンス
        _calucationPlayerPositionX = new CalucationPlayerListPositionX(this.transform, cleateFloorChildren.CleaterLists.Count);

        //Yポジションを計算するクラスをインスタンス
        _calucationPlayerPositionY = new CalucationPlayerListPositionY(_player.transform.position.y, MAX_PLAYER_LIST_Y);

        const int HARF_LIST_LENGTH_X = 2;
        //プレイヤーの位置を配列の真ん中としてみる
        _playerListPointX = Mathf.CeilToInt(PlayerList.GetLength(0) / HARF_LIST_LENGTH_X);
        _playerListPointY = 3;
    }

    /// <summary>
    /// プレイヤーがいる床の種類を見る
    /// </summary>
    public void PlayerPointJudge(int laneValue)
    {
        _calucationPlayerPositionX.LookFarAwayBrock(_player.transform.position.x);
        //現在のプレイヤーの位置が列の真ん中からどれぐらい離れているかを見る
        _playerListPointX = _calucationPlayerPositionX.PlayerListPositionX;

        _playerListPointY = _calucationPlayerPositionY.CalucationPlayerPosition(_player.transform.position.y);

        //見たい床がある列とプレイヤーのいる列が一致しない場合、比較しない
        //７つの配列で見たとき、プレイヤーの列が変わっていなかったら比較しない
        if (laneValue != _playerListPointX &&
            _prePlayerListPointX == _playerListPointX)
        {
            return;
        }

        _prePlayerListPointX = _playerListPointX;

        //フロア別に起こるイベントをセット
        PlayerPositionLaneFloorsData.Instance.BaseFloors[_playerListPointX].FloorEvent(_myScript);
    }

    /// <summary>
    /// 障害物に当たったかの処理
    /// </summary>
    /// <param name="obstacleHeight">障害物の高さ</param>
    public void JudgeObstaclehit(int obstacleHeight)
    {
        if (_playerListPointY <= obstacleHeight)
        {
            _floorMoveSpeedChanger.InitializeToSpeed();
        }
    }

    /// <summary>
    /// 落とし穴ギミックの床に乗っているかの処理
    /// </summary>
    public void JudgeOnPitFall()
    {
        //プレイヤーの位置が一番下だったら＆＆ダメージを受けていない状態だったら
        if (_playerListPointY <= 0&&!PlayerState.Instance.isDamage)
        {
            _baseJump.ChangeFalling(true);
            StartCoroutine(_playerPositionReset.IntervalResetPosition(_baseJump));
        }
    }

    /// <summary>
    /// スピードアップギミックの床に乗っているかの処理
    /// </summary>
    public void JudgeOnSpeedUpFloor()
    {
        if (_playerListPointY <= 0)
        {
            _floorMoveSpeedChanger.TemporarySpeedUp();
        }
    }

    /// <summary>
    /// 床の判定を開始するメソッドを呼び出す
    /// </summary>
    private void HandleFarAwayblock()
    {
        PlayerPointJudge(_playerListPointX);
    }
}
