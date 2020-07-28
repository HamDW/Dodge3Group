using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSampleDlg : MonoBehaviour
{
 [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    private SaveSample m_SaveSample = new SaveSample();

    // Start is called before the first frame update
    void Start()
    {
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    public void OnClicked_Save()
    {
        m_SaveSample.SaveFile();
        m_txtResult.text = "sample.data에 저장 됐습니다.";
    }

    public void OnClicked_Load()
    {
        m_SaveSample.LoadFile();
        m_txtResult.text = m_SaveSample.m_tmpString;
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }


}
