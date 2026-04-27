using UnityEngine;

public class IntroTextCycle : MonoBehaviour
{
    [SerializeField] GameObject Convoholder;
    private GameObject[] Convos;
    private int TotalElements;
    private int ConvoNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TotalElements = Convoholder.transform.childCount;
        Convos = new GameObject[TotalElements];

        for (int i = 0; i < TotalElements; i++)
        {
            Convos[i] = Convoholder.transform.GetChild(i).gameObject;
        }

    }

    public void nextcourse()
    {
        Convos[ConvoNumber].gameObject.SetActive(false);
        ConvoNumber++;

        Convos[ConvoNumber].gameObject.SetActive(true);
    }

}