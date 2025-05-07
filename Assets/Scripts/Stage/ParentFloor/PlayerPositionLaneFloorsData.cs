/// <summary>
/// �����ɐ���
/// �V���O���g���N���X
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

    //�������̖��������I�u�W�F�N�g�̂��ꂼ��̃��X�g�O�Ԗڂ̔ԍ��z��
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
