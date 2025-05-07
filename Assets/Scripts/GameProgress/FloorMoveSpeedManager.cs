/// <summary>
/// ���̓������x���Ǘ�����N���X
/// </summary>
public class FloorMoveSpeedManager
{
    //�V���O���g����
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

    //���̓������x
    private float _floorMoveSpeed = 0f;

    //�ő呬�x
    private float _maxFloorMoveSpeed = 3.15f;

    //���̓������x
    public float FloorMoveSpeed
    {
        get { return _floorMoveSpeed; }
        set { _floorMoveSpeed = value; }
    }

    //�ő呬�x
    public float MaxFloorMoveSpeed
    {
        get { return _maxFloorMoveSpeed; }
        set { _maxFloorMoveSpeed = value; }
    }
}
