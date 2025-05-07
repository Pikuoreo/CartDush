using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CleateFloorCleater))]
/// <summary>
/// �v���C���[�̂���|�W�V�����ɂ��鏰���Ǘ�����
/// </summary>
public class PlayerPositionFloor : MonoBehaviour
{
    //�������̖��������I�u�W�F�N�g�̂��ꂼ��̃��X�g�O�Ԗڂ̃I�u�W�F�N�g
    [SerializeField] private List<int> _floorsNumber = new List<int>();

    //�������̖��������I�u�W�F�N�g�̂��ꂼ��̃��X�g�O�Ԗڂ̃I�u�W�F�N�g
    public List<int> FloorsNumber
    {
        get { return _floorsNumber; }
        set { _floorsNumber = value; }
    }

    //�������̖��������I�u�W�F�N�g�𐶐����鏈�����Ǘ����Ă���N���X
    private CleateFloorCleater _cleateFloorCleater = default;

    private void Start()
    {
        //�������̖��������I�u�W�F�N�g�𐶐����鏈�����Ǘ����Ă���N���X���擾
        _cleateFloorCleater = this.GetComponent<CleateFloorCleater>();

        _cleateFloorCleater.SetListCapacity();

        //���𐶐�����q�̐��ƈꏏ�ɂ���
        FloorsNumber.Capacity = _cleateFloorCleater.CleaterLists.Capacity;

        SetListSize();
    }

    /// <summary>
    /// ���X�g�̃T�C�Y��ݒ肷��
    /// </summary>
    private void SetListSize()
    {
        while (FloorsNumber.Count < FloorsNumber.Capacity)
        {
            FloorsNumber.Add(0);
        }

        floorCleate();
    }

    /// <summary>
    /// ���𐶐�����I�u�W�F�N�g�𐶐�����
    /// </summary>
    private void floorCleate()
    {
        _cleateFloorCleater.Cleate();
    }
}
