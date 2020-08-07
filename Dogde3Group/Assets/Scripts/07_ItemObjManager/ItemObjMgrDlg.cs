using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObjMgrDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnPlay = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] GameObject m_BgImage = null;

    [SerializeField] ItemObjectMgr m_ItemObjMgr = null;
    [SerializeField] float m_itemKeepTime = 3;
    [SerializeField] float m_itemAppearDelayTime = 5;

    private void Awake()
    {
        AssetMgr.Inst.Initialize();
    }

    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClicked_Play);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }

    public void OnClicked_Play()
    {
        m_BgImage.SetActive(false);
        m_ItemObjMgr.Initialize(m_itemKeepTime, m_itemAppearDelayTime);
        m_txtResult.text = "Start Play ....";
    }

    public void OnClicked_Stop()
    {
        m_BgImage.SetActive(true);
        m_ItemObjMgr.SetIsCreateItem(false);
        m_txtResult.text = "Stop Play ....";
    }
}
