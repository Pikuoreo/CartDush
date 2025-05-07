using UnityEngine;

[RequireComponent(typeof(FloorCleater))]
///���z��𓮂����N���X
public class FloorMove : MonoBehaviour
{
    private FloorCleater _floorCleater;
    private ChangeFloorList _changeFloorList = default;
    private FloorMoveSpeedManager _moveSpeedManager = FloorMoveSpeedManager.Instance;
    private Transform _playerPosition = default;

    private const int HARF_VALUE = 2;

    private const int TIME_DELTATIME = 10;
    void Start()
    {
        //�v���C���[�̈ʒu���擾
        const string FIND_TAG = "Player";
        _playerPosition = GameObject.FindGameObjectWithTag(FIND_TAG).transform;
        _floorCleater = this.GetComponent<FloorCleater>();
        _changeFloorList = this.GetComponent<ChangeFloorList>();

        GameUpdator.Instance.SubscribeUpdate(floorMoveUpdate);
    }

    // Update is called once per frame
    void floorMoveUpdate()
    {
        MoveCloser();
    }

    /// <summary>
    /// ��O�Ɉړ�
    /// </summary>
    private void MoveCloser()
    {
        //�z��̒��g���ړ�������
        foreach (GameObject floors in _floorCleater.FloorListData.FloorObjectList)
        {
            floors.transform.position += (Vector3.back * _moveSpeedManager.FloorMoveSpeed) * (Time.deltaTime * TIME_DELTATIME);
        }

        JudgeFloorPosition();
    }

    private void JudgeFloorPosition()
    {
        //��Ԏ�O�̃I�u�W�F�N�g���擾
        GameObject firstLaneFloor = _floorCleater.FloorListData.FloorObjectList.Peek();


        //��Ԏ�O�̃I�u�W�F�N�g���v���C���[�̈ʒu�ɂ܂ŗ�����
        if ((firstLaneFloor.transform.position.z + firstLaneFloor.transform.lossyScale.z / HARF_VALUE <= _playerPosition.transform.position.z) && _floorCleater.IsEndFloorChange)
        {
            _floorCleater.IsEndFloorChange = false;
            //��Ԏ�O�̃I�u�W�F�N�g��ύX����
            _changeFloorList.ListChange();
        }
    }

}
