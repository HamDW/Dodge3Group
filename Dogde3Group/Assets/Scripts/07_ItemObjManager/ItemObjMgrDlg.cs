using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObjMgrDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnPlay = null;
    [SerializeField] Button m_btnStop = null;


    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClicked_Play);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }

    public void OnClicked_Play()
    {
        m_txtResult.text = "Start Play ....";
    }

    public void OnClicked_Stop()
    {
        m_txtResult.text = "Stop Play ....";
    }
}
