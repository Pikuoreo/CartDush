
/// <summary>
/// ���ꂼ�ꂪ�����̔z��̐擪��n���N���X
/// </summary>
public class FloorListPresenter
{
    private FloorCleater _floorCleater = default;
    private PlayerPositionLaneFloorsData _playerPositionFloorData = default;
    private int _cleaterID = 0;

    /// <summary>
    /// �R���X�g���N�^�Ŋe�������I�u�W�F�N�g�̔ԍ��A�����Ă��鏰�z��̃f�[�^���擾����
    /// </summary>
    /// <param name="playerPositionFloor">�v���C���[�̈ʒu�Ƀ��[��������N���X</param>
    /// <param name="floorcleater">�������I�u�W�F�N�g�̃f�[�^���Ǘ�����N���X</param>
    public FloorListPresenter(FloorCleater floorcleater)
    {
        _playerPositionFloorData = PlayerPositionLaneFloorsData.Instance;
        _floorCleater = floorcleater;

        //�������I�u�W�F�N�g��ID���擾
        _cleaterID = _floorCleater.FloorListData.FloorCleaterID;
    }

    /// <summary>
    /// ���z��̐擪��ǂݍ��݁A�i�[����
    /// </summary>
    public void PassFloorListNumber()
    {
        //���z��̐擪�̔ԍ�����
        _playerPositionFloorData.FloorsNumber[_cleaterID] = _floorCleater.FloorListData.FloorNumberList.Peek();

        _playerPositionFloorData.BaseFloors[_cleaterID] = _floorCleater.FloorListData.BaseFloorList.Peek();

    }

}
