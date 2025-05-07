using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�v�[���̃f�[�^���Ǘ�����N���X
/// </summary>
public class FloorPoolData
{
    //�I�u�W�F�N�g�v�[��
    private List<GameObject> _objectList = new List<GameObject>();

    //�v�[���Ώۂ̃I�u�W�F�N�g
    private GameObject _poolObject = default;

    //���������
    private int _poolValue = 0;

    //�M�~�b�N�Ȃ��̏��𐶐�����C���X�^���X��
    private CleateFloorKinds _floorPoolKindsNumber = default;

    /// <summary>
    /// �R���X�g���N�^�Ő�������I�u�W�F�N�g���w��
    /// </summary>
    /// <param name="poolObject">��������I�u�W�F�N�g</param>
    /// <param name="poolValue">���������</param>
    /// <param name="isDefaultFloorPool">�M�~�b�N�Ȃ��̏��𐶐�����C���X�^���X��</param>
    public FloorPoolData(GameObject poolObject, int poolValue, CleateFloorKinds cleateFloorKinds)
    {
        _poolObject = poolObject;
        _poolValue = poolValue;
        _floorPoolKindsNumber = cleateFloorKinds;
        CleateObject();
    }

    /// <summary>
    /// �I�u�W�F�N�g����
    /// </summary>
    private void CleateObject()
    {
        for (int i = 0; i < _poolValue; i++)
        {
            _objectList.Add(MonoBehaviour.Instantiate(_poolObject));
            _objectList[i].SetActive(false);
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g��n������
    /// </summary>
    /// <returns>�n���I�u�W�F�N�g��Ԃ�</returns>
    public GameObject GetFloor()
    {
        //�z��̒���enable��false�ɂȂ��Ă�����̂�T��
        foreach (GameObject objectList in _objectList)
        {
            //enable��false�ł����
            if (!objectList.activeSelf)
            {
                //enable��true�ɂ��A���̃I�u�W�F�N�g��n��
                objectList.SetActive(true);
                return objectList;
            }
        }

        //�ʏ�̏��𐶐�����v�[���̂ݍs������
        if (_floorPoolKindsNumber==CleateFloorKinds.DefaultFloorPool)
        {
            //���łɑS���g���Ă�����A�V�����I�u�W�F�N�g�𐶐�
            _objectList.Add(MonoBehaviour.Instantiate(_poolObject));
            return _objectList[_objectList.Count - 1];
        }
        //����ȊO�́A�S�Ẵv�[���I�u�W�F�N�g���g�p���Ă����ꍇ�Anull��Ԃ�
        return null;
    }

    /// <summary>
    /// �I�u�W�F�N�g��ԋp���鏈��
    /// </summary>
    /// <param name="returnObject">�ԋp���ꂽ�I�u�W�F�N�g</param>
    public void ReturnObject(GameObject returnObject)
    {
        returnObject.transform.parent = null;
        // �I�u�W�F�N�g���v�[�����ɑ��݂��邩���m�F���A�������
        if (!_objectList.Contains(returnObject))
        {
            Debug.LogError($"�Q�Ƃ����I�u�W�F�N�g���X�g�F{_objectList[0]}�̃��X�g�A�ԋp���ꂽ�I�u�W�F�N�g{returnObject}");
            Debug.LogError($"�ԋp����I�u�W�F�N�g��������܂���ł���");
            return;
        }

        if (_floorPoolKindsNumber == CleateFloorKinds.ObstaclefloorPool)
        {
            ChangeObstacleSetActive(returnObject);
        }

        
        // ����΃I�u�W�F�N�g���A�N�e�B�u�ɂ���
        returnObject.SetActive(false);

    }

    /// <summary>
    /// ��Q���M�~�b�N���ɂ��Ă���q��SetActive�����ׂ�False�ɂ���
    /// </summary>
    /// <param name="obstacleFloor"></param>
    private void ChangeObstacleSetActive(GameObject obstacleFloor)
    {
        //�q�̏�Q���̐����擾
            int childCount = obstacleFloor.transform.childCount;

        //�q�̐����J��Ԃ�
        while (childCount > 0)
            {

            childCount--;
            //�q�̏�Q����SetActive��False�ɂ���
            obstacleFloor.transform.GetChild(childCount).gameObject.SetActive(false);
            }   
    }

}
