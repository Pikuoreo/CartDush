using UnityEngine;

/// <summary>
/// �������I�u�W�F�N�g�̃f�[�^���Ǘ�����N���X
/// </summary>
public class FloorCleater : MonoBehaviour
{
    private bool _isEndFloorChange = true;

    [SerializeField] private FloorCleaterListData _cleaterData = new FloorCleaterListData();

    //���̐擪��ǂݍ��݁A�i�[����N���X
    public FloorListPresenter FloorListPresenter
    {
        get; private set;
    }

    public FloorCleaterListData FloorListData
    {
        get { return _cleaterData; }
        set { _cleaterData = value; }
    }

    public bool IsEndFloorChange
    {
        get { return _isEndFloorChange; }
        set { _isEndFloorChange = value; }
    }

    private void Start()
    {
        //���z��̐擪��ǂݍ��݁A�i�[����N���X�̃C���X�^���X�𐶐�
        FloorListPresenter = new FloorListPresenter(this.GetComponent<FloorCleater>());

        this.gameObject.AddComponent<CleateFloor>();
    }
}
