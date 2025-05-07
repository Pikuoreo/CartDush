using UnityEngine;

[RequireComponent(typeof(FloorCleater))]
///���𐶐�����N���X
public class CleateFloor : MonoBehaviour
{
    //�I�u�W�F�N�g�̃X�P�[���𔼕��ɂ��邽�߂̒l
    private const int HARF_OBJECT_SCALE = 2;

    //�w�肵�����������A��ԍŏ��Ƀf�t�H���g�̏��𐶐�����
    private const int INTRO_STAGE_VALUE = 5;

    //�z��̒���
    private const int LIST_LENGHT = 15;

    //��������ʒu(�����ʒu�͂R)
    private float _cleatePositionZ = 3f;

    //�ЂƂO�ɐ��������I�u�W�F�N�g
    private GameObject _previewCleateObject = default;

    private FloorCleater _floorCleater = default;

    private FloorPool _floorPool = default;

    private void Start()
    {

        //�R���|�\�l���g�̎擾
        _floorCleater = this.GetComponent<FloorCleater>();
        _floorPool = GameObject.FindAnyObjectByType<FloorPool>();

        if (_floorPool == null)
        {
            Debug.LogError($"FloorPool�����Ă���I�u�W�F�N�g��������܂���ł����B");
            return;
        }

        //���𐶐�
        CleateStartStage();
    }

    /// <summary>
    /// �e�t���A�̔ԍ�
    /// </summary>
    private enum CleateFloorKinds
    {
        //�M�~�b�N�Ȃ��̏��̔ԍ�
        DefaultFloor = 0,
        //��Q������̏��̔ԍ�
        ObstacleFloor = 1,
        //���Ƃ����̏��̔ԍ�
        PitFallFloor = 2,
        //�X�s�[�h�A�b�v�M�~�b�N�̏��̔ԍ�
        SpeedUpFloor = 3
    }

    /// <summary>
    /// �X�e�[�W�̏��𐶐�����
    /// </summary>
    private void CleateStartStage()
    {
        for (int currentList = 0; currentList < LIST_LENGHT; currentList++)
        {
            GameObject floorObject;
            //�����_���Ő������鏰�̔ԍ����Ƃ�
            if (currentList <= INTRO_STAGE_VALUE)
            {
                floorObject = ReturnFloorKinds(0);
            }
            else
            {
                floorObject = ReturnFloorKinds((CleateFloorKinds)JudgeReturnFloorKindsValue(Random.Range(0, 10000)));
            }
            //���̔z��Ɋi�[����
            _floorCleater.FloorListData.FloorObjectList.Enqueue(floorObject);

            //��������|�W�V�������v�Z����
            Vector3 cleatePosition = CleatePositionCalculation(floorObject);

            //�I�u�W�F�N�g�̈ʒu��ύX����
            floorObject.transform.position = cleatePosition;

            //���������I�u�W�F�N�g���q�̊֌W�ɂ���
            floorObject.transform.parent = this.transform;
        }

        //���̐擪��ǂݍ��܂���
        _floorCleater.FloorListPresenter.PassFloorListNumber();

        this.gameObject.AddComponent<ChangeFloorList>();
        this.gameObject.AddComponent<FloorMove>();
    }

    public void CleateStage()
    {
        //�ԍ��ʂ̏����I�u�W�F�N�g�v�[��������o��
        GameObject floorObject = ReturnFloorKinds((CleateFloorKinds)JudgeReturnFloorKindsValue(Random.Range(0, 10000)));

        //��������|�W�V�������v�Z����
        Vector3 cleatePosition = CleatePositionCalculation(floorObject);

        //�I�u�W�F�N�g�̈ʒu��ύX����
        floorObject.transform.position = cleatePosition;

        //���̔z��Ɋi�[����
        _floorCleater.FloorListData.FloorObjectList.Enqueue(floorObject);

        //���������I�u�W�F�N�g���q�̊֌W�ɂ���
        floorObject.transform.parent = this.transform;
    }

    /// <summary>
    /// ��������I�u�W�F�N�g���v�[��������擾
    /// </summary>
    /// <param name="SelectObjectnumber">��������I�u�W�F�N�g�̔ԍ�</param>
    /// <returns>��������I�u�W�F�N�g��Ԃ�</returns>
    private GameObject SelectCleateObject(int SelectObjectnumber)
    {
        //��������I�u�W�F�N�g���v�[��������擾
        GameObject returnFloor = _floorPool.PoolDataList[SelectObjectnumber].GetFloor();

        //
        return returnFloor;
    }

    /// <summary>
    /// ���̐����������_�����i������x�̃����_������j���A��������I�u�W�F�N�g��Ԃ�
    /// </summary>
    /// <param name="randomcleatefloorValue">�������鏰�̎�ނ����߂邽�߂̗���</param>
    /// <returns>�������鏰�̃I�u�W�F�N�g��Ԃ�</returns>
    private GameObject ReturnFloorKinds(CleateFloorKinds cleateFloorKinds)
    {
        GameObject returnObject = default;

        int floorKindsNumber = (int)cleateFloorKinds;

        //�Ԃ��I�u�W�F�N�g���擾
        returnObject = SelectCleateObject(floorKindsNumber);

        //�Ԃ��I�u�W�F�N�g��null�������ꍇ
        if (returnObject == null)
        {
            //enum�̒l���M�~�b�N�Ȃ��̏��̒l�ɕύX
            cleateFloorKinds = CleateFloorKinds.DefaultFloor;

            //�������鏰�̔ԍ����M�~�b�N�Ȃ��̏��̔ԍ��ɕύX
            floorKindsNumber = (int)cleateFloorKinds;
            //�M�~�b�N�Ȃ��̏����擾
            returnObject = SelectCleateObject(floorKindsNumber);
        }
        //���̔ԍ���z��Ɋi�[����
        _floorCleater.FloorListData.FloorNumberList.Enqueue(floorKindsNumber);

        switch (cleateFloorKinds)
        {
            case CleateFloorKinds.DefaultFloor:

                // �ʏ�̏��̃C���X�^���X�𐶐�
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new DefaultFloor());

                break;

            case CleateFloorKinds.ObstacleFloor:

                // ��Q���������̃C���X�^���X�𐶐�
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new ObstacleFloorData(returnObject));

                break;

            case CleateFloorKinds.PitFallFloor:

                // ���Ƃ����������̃C���X�^���X�𐶐�
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new PitFallFloorData());

                break;

            case CleateFloorKinds.SpeedUpFloor:

                // ���Ƃ����������̃C���X�^���X�𐶐�
                _floorCleater.FloorListData.BaseFloorList.Enqueue(new SpeedUpFloorData());

                break;
        }
        //���ʂ̏��̃I�u�W�F�N�g��Ԃ�
        return returnObject;

    }

    private int JudgeReturnFloorKindsValue(int randomValue)
    {
        if (randomValue >= 9750)
        {
            return 3;
        }

        if (randomValue >= 9000)
        {
            return 2;
        }

        if (randomValue >= 6000)
        {
            return 1;
        }

        return 0;
    }

    /// <summary>
    /// ��������|�W�V���������ۂɐ�������I�u�W�F�N�g���ƂɌv�Z����
    /// </summary>
    /// <param name="cleateObject">���ۂɐ�������I�u�W�F�N�g</param>
    /// <returns>���߂���������|�W�V������Ԃ�</returns>
    private Vector3 CleatePositionCalculation(GameObject cleateObject)
    {
        //���łɂЂƂO�ɏ��𐶐����Ă�����
        if (_previewCleateObject != null)
        {
            //�ЂƂO�̏��̉��[�ƁA���񐶐����鏰�̎�O�[���擾����
            float previewObjectEdge = _previewCleateObject.transform.localScale.z / HARF_OBJECT_SCALE;
            float currentObjectEdge = cleateObject.transform.localScale.z / HARF_OBJECT_SCALE;

            //��̒[�𕹂��čŏI�I�ɐ�������|�W�V������Z�����߂�
            _cleatePositionZ = previewObjectEdge + currentObjectEdge + _previewCleateObject.transform.localPosition.z;
        }
        //��ڂ̏��̐����������ꍇ
        else
        {
            //���̃T�C�Y������Ă��[�����낤�悤�ɒ���
            _cleatePositionZ = (cleateObject.transform.localScale.z - _cleatePositionZ) / HARF_OBJECT_SCALE;
        }

        //�ŏI�I�ɐ�������|�W�V�����S�̂����߂�
        Vector3 CalculationResult = this.transform.position + new Vector3(0, 0, _cleatePositionZ);

        //���񐶐������I�u�W�F�N�g�����̌v�Z�Ŏg�����߁A�ێ����Ă���
        _previewCleateObject = cleateObject;

        //��������|�W�V������Ԃ�
        return CalculationResult;
    }

}
