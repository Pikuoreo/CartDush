using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{


    public GameObject[] OBList;
    public Text Title;
    public int Selection = 0;

    public GameObject BackText;
    public GameObject NextText;
    public GameObject BackButton;
    public GameObject NextButton;

    void Start()
    {
        OBList[Selection].SetActive(true);
        Title.text = "Prefab Name: " + OBList[Selection].gameObject.transform.name.ToString();
    }
    void Update()
    {
        if (Selection == 0)
        {
            BackText.SetActive(false);
            BackButton.SetActive(false);
        }
        else
        {
            BackText.SetActive(true);
            BackButton.SetActive(true);
        }

        if (Selection == OBList.Length - 1)
        {
            NextText.SetActive(false);
            NextButton.SetActive(false);
        }
        else
        {
            NextText.SetActive(true);
            NextButton.SetActive(true);
        }

    }
    public void Back()
    {

        if (Selection < OBList.Length && Selection != 0)
        {
            OBList[Selection].SetActive(false);
            Selection -= 1;
            OBList[Selection].SetActive(true);
            Title.text = "Prefab Name: " + OBList[Selection].gameObject.transform.name.ToString();
        }

    }

    public void Next()
    {

        if (Selection < OBList.Length && Selection != OBList.Length - 1)
        {
            OBList[Selection].SetActive(false);
            Selection += 1;
            OBList[Selection].SetActive(true);
            Title.text = "Prefab Name: " + OBList[Selection].gameObject.transform.name.ToString();
        }

    }
}
