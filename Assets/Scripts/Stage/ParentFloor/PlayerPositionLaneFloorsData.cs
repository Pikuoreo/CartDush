/// <summary>
/// ここに説明
/// シングルトンクラス
/// </summary>
public class PlayerPositionLaneFloorsData
{
    private static PlayerPositionLaneFloorsData _instance = default;
    private const int FLOOR_LANE_LENGTH = 7;

    public static PlayerPositionLaneFloorsData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerPositionLaneFloorsData();
            }

            return _instance;
        }
    }

    //床生成の役割をもつオブジェクトのそれぞれのリスト０番目の番号配列
    private int[] _floorsNumber = new int[FLOOR_LANE_LENGTH];

    public int[] FloorsNumber
    {
        get { return _floorsNumber; }
        set { _floorsNumber = value; }
    }

    private BaseFloor[] _baseFloors = new BaseFloor[FLOOR_LANE_LENGTH];


    public BaseFloor[] BaseFloors
    {
        get { return _baseFloors; }
        set { _baseFloors = value; }
    }
    public void GetFloors(int floorNumber, int childrenID)
    {
        _floorsNumber[childrenID] = floorNumber;
    }


}
