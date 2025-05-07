/// <summary>
/// 床の動く速度を管理するクラス
/// </summary>
public class FloorMoveSpeedManager
{
    //シングルトン化
    private static FloorMoveSpeedManager _instance = default;
    public static FloorMoveSpeedManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FloorMoveSpeedManager();
            }

            return _instance;
        }
    }

    //床の動く速度
    private float _floorMoveSpeed = 0f;

    //最大速度
    private float _maxFloorMoveSpeed = 3.15f;

    //床の動く速度
    public float FloorMoveSpeed
    {
        get { return _floorMoveSpeed; }
        set { _floorMoveSpeed = value; }
    }

    //最大速度
    public float MaxFloorMoveSpeed
    {
        get { return _maxFloorMoveSpeed; }
        set { _maxFloorMoveSpeed = value; }
    }
}
