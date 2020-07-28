using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SaveInfoDlg : MonoBehaviour
{

    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    private SaveInfo m_kSaveInfo = new SaveInfo();

    void Start()
    {
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        Initialize();
    }

    public void Initialize()
    {
        SaveTempData();
    }

    private void SaveTempData()
    {
        m_kSaveInfo.m_MaxScore = 1200;
        m_kSaveInfo.m_AccumulateScore = 17530;
        m_kSaveInfo.m_LastStage = 3;

        m_kSaveInfo.SetStageScore(1, 1200);
        m_kSaveInfo.SetStageScore(2, 650);
        m_kSaveInfo.SetStageScore(3, 930);
    }


    public void OnClicked_Save()
    {
        m_kSaveInfo.SaveFile();
        m_txtResult.text = "dodge3.data에 저장 됐습니다.";
    }

    public void OnClicked_Load()
    {
        m_kSaveInfo.LoadFile();
        PrintText();
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }


    private void PrintText()
    {
        StringBuilder kBuilder = new StringBuilder();
        kBuilder.Append(string.Format("MaxScore : {0}\n", m_kSaveInfo.m_MaxScore));
        kBuilder.Append(string.Format("AccumulateScore : {0}\n", m_kSaveInfo.m_AccumulateScore));
        kBuilder.Append(string.Format("LastStage : {0}\n", m_kSaveInfo.m_LastStage));

        for( int i = 0; i < m_kSaveInfo.m_listStageScore.Count; i++)
        {
            SaveInfo.SStage kStage = m_kSaveInfo.m_listStageScore[i];
            kBuilder.Append(string.Format("{0} stage : {1}\n", kStage.m_Stage, kStage.m_Score));
        }
        m_txtResult.text = kBuilder.ToString();
    }
}
