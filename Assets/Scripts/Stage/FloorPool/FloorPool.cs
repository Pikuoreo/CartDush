using System.Collections.Generic;
using UnityEngine;

public enum CleateFloorKinds
{
    DefaultFloorPool = 0,
    ObstaclefloorPool = 1,
    PitFallFloorPool = 2,
    SpeedUpfloorPool = 3
}

/// <summary>
/// ���̎�ނ��Ƃ̃I�u�W�F�N�g�v�[���𐶐�����N���X
/// </summary>
public class FloorPool : MonoBehaviour
{
    //�������鏰�̎��
    [SerializeField] private List<GameObject> _cleateFloors = new List<GameObject>();

    //�������鏰�̐��̔z��
    [SerializeField] private int[] _floorPoolValueLists = new int[4];
    //���I�u�W�F�N�g�v�[���̃f�[�^�̃��X�g
    private List<FloorPoolData> _poolDataList = new List<FloorPoolData>();

    //�M�~�b�N�����̏��𐶐�����C���X�^���X��
    private bool _isDefaultFloorpool = true;
    public List<FloorPoolData> PoolDataList
    {
        get { return _poolDataList; }
        set { _poolDataList = value; }
    }

 

    private enum PoolFloorValue
    {
        //�ʏ�̏��̐�����
        DefaultFloorValue = 50,

        //��Q������̏��̐�����
        ObstaclefloorValue = 10,

        //���Ƃ������̐�����
        PitFallFloorValue = 5,

        //�X�s�[�h�A�b�v���̐�����
        SpeedUpfloorValue = 1
    }

    

    void Start()
    {
        //�z��ɂ��ꂼ��̏��̐���������
        _floorPoolValueLists[0] = (int)PoolFloorValue.DefaultFloorValue;
        _floorPoolValueLists[1] = (int)PoolFloorValue.ObstaclefloorValue;
        _floorPoolValueLists[2] = (int)PoolFloorValue.PitFallFloorValue;
        _floorPoolValueLists[3] = (int)PoolFloorValue.SpeedUpfloorValue;

        //���̎�ޕ��A���I�u�W�F�N�g�v�[���̃C���X�^���X�𐶐�
        for (int value = 0; value < _cleateFloors.Count; value++)
        {
            _poolDataList.Add(new FloorPoolData(_cleateFloors[value], _floorPoolValueLists[value], (CleateFloorKinds)value));
        }

    }
}
