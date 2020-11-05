using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextFileSaveDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    CTextFileSave m_kSaveData = new CTextFileSave();

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
        m_kSaveData.Initialize();
    }


    public void OnClicked_Save()
    {
        m_kSaveData.SaveFile("test01.txt");
        m_txtResult.text = "test01.txt에 저장 됐습니다.";
    }

    public void OnClicked_Load()
    {
        m_kSaveData.LoadFile("test01.txt");
        PrintText();
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }


    private void PrintText()
    {
        string sResult = string.Format("{0}\n{1}\n{2}\n{3}\n",
            m_kSaveData.m_bCheck,
            m_kSaveData.m_nCount,
            m_kSaveData.m_fValue,
            m_kSaveData.m_Str);
        m_txtResult.text = sResult;
    }
}
