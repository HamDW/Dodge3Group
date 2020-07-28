using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SaveTest02Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    CSaveData m_kSaveData = new CSaveData();

    // Start is called before the first frame update
    void Start()
    {
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        Initialize();
    }

    public void Initialize()
    {
        m_kSaveData.AddScoreData();
    }


    public void OnClicked_Save()
    {
        m_kSaveData.SaveFile();
        m_txtResult.text = "test.data에 저장 됐습니다.";
    }

    public void OnClicked_Load()
    {
        m_kSaveData.LoadFile();
        PrintText();
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }


    private void PrintText()
    {
        StringBuilder kBuilder = new StringBuilder();

        for (int i = 0; i < m_kSaveData.m_ScoreItems.Count; i++)
        {
            ScoreItem kItem = m_kSaveData.m_ScoreItems[i];

            kBuilder.Append(string.Format("{0}, {1}, {2} \n", kItem.m_Index, kItem.m_Name, kItem.m_Score));
        }

        m_txtResult.text = kBuilder.ToString();
    }


}
