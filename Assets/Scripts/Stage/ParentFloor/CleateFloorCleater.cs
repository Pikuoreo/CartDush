using System.Collections.Generic;
using UnityEngine;

public class CleateFloorCleater : MonoBehaviour
{
    //��������I�u�W�F�N�g
    [SerializeField] private GameObject _cleateObject = default;

    //���X�g�̃T�C�Y�i�Q�[�����̃��[���̐��j
    //��ɂ��Ȃ��Ƃ��������Ȃ�
    private const int LIST_CAPACITY = 7;

    //���������I�u�W�F�N�g���i�[���郊�X�g
    //�O������ύX�͂����Ȃ��A�Q�Ƃ͉\�ɂ���
    public List<GameObject> CleaterLists
    {
        get; private set;
    }

    //�I�u�W�F�N�g�𐶐�����|�W�V����
    private float cleatePositionX = 0;

    //��������|�W�V���������炷�l(���I�u�W�F�N�g��X��)
    private const int DISTANCE_VALUE = 3;

    /// <summary>
    /// �z��̑傫�����w��
    /// </summary>
    public void SetListCapacity()
    {
        CleaterLists = new List<GameObject>();
        CleaterLists.Capacity = LIST_CAPACITY;
    }

    private void CleatePositionCalucation()
    {
        float harfListCapacity = Mathf.Floor(LIST_CAPACITY / 2);
        cleatePositionX = -DISTANCE_VALUE * harfListCapacity;
    }
    /// <summary>
    /// ���𐶐�����I�u�W�F�N�g�𐶐�����
    /// </summary>
    public void Cleate()
    {
        CleatePositionCalucation();
        //CleaterLists�̃T�C�Y���J��Ԃ�
        for (int currentNumber = 0; currentNumber < CleaterLists.Capacity; currentNumber++)
        {
            //��������|�W�V�������Ƃ�
            Vector3 cleatePosition = this.transform.position + new Vector3(cleatePositionX, 0, 0);

            //�������A�z��Ɋi�[
            CleaterLists.Add(Instantiate(_cleateObject, cleatePosition, Quaternion.identity));

            //�q�I�u�W�F�N�g�ɃZ�b�g����
            CleaterLists[currentNumber].transform.parent = this.transform;

            //���������I�u�W�F�N�g����ID��n��
            CleaterLists[currentNumber].GetComponent<FloorCleater>().FloorListData.FloorCleaterID = currentNumber;

            //��������|�W�V������X�������炷
            cleatePositionX += DISTANCE_VALUE;
        }

    }

}
