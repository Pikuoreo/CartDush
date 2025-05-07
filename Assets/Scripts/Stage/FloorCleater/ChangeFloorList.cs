using UnityEngine;

/// <summary>
/// ���̔z���ύX����N���X
/// </summary>
[RequireComponent(typeof(FloorCleater))]
[RequireComponent(typeof(CleateFloor))]
public class ChangeFloorList : MonoBehaviour
{
    private FloorCleater _floorCleater = default;
    private FloorPool _floorPool = default;
    private CleateFloor _cleateFloor = default;
    private LookPlayerPointLaneFloor _lookPlayerPointLaneFloor = default;

    private int _floorNumber = 0;
    private int cleaterID = 0;


    void Start()
    {
        _floorCleater = this.GetComponent<FloorCleater>();
        _floorPool = GameObject.FindAnyObjectByType<FloorPool>();
        _cleateFloor = this.GetComponent<CleateFloor>();
        if (_floorPool == null)
        {
            Debug.LogError($"FloorPool�����Ă���I�u�W�F�N�g��������܂���ł����B");
            return;
        }

        _lookPlayerPointLaneFloor = this.GetComponentInParent<LookPlayerPointLaneFloor>();
        if (_lookPlayerPointLaneFloor == null)
        {
            Debug.LogError($"{this.gameObject.name}�̐e�I�u�W�F�N�g��LookPlayerPointLaneFloor���A�^�b�`����Ă��܂���I�I");
            return;
        }

        //����������I�u�W�F�N�g��ID���擾
        cleaterID = _floorCleater.FloorListData.FloorCleaterID;
    }

    /// <summary>
    /// �z���ύX
    /// </summary>
    public void ListChange()
    {

        RemoveFloor();

        UpdateListNumber();

        //�z��̐擪���ēǂݍ��݂�����
        _floorCleater.FloorListPresenter.PassFloorListNumber();

        //�擪�̃I�u�W�F�N�g���W�������Ă���ꏊ�ɓn��
        PlayerPositionLaneFloorsData.Instance.GetFloors(_floorNumber, cleaterID);

        //���̔�����J�n
        _lookPlayerPointLaneFloor.PlayerPointJudge(_floorCleater.FloorListData.FloorCleaterID);

        //�V�������𐶐�
        _cleateFloor.CleateStage();

        _floorCleater.IsEndFloorChange = true;
    }

    private void UpdateListNumber()
    {
        //���̔ԍ��z��̐擪����
        _floorNumber = _floorCleater.FloorListData.FloorNumberList.Peek();
    }

    private void RemoveFloor()
    {
        //���̔z��̐擪�̔ԍ�����&�폜
        _floorNumber = _floorCleater.FloorListData.FloorNumberList.Dequeue();

        _floorCleater.FloorListData.BaseFloorList.Dequeue();

        //�I�u�W�F�N�g�z��̐擪���������ԋp
        _floorPool.PoolDataList[_floorNumber].ReturnObject(_floorCleater.FloorListData.FloorObjectList.Dequeue());


    }
}
