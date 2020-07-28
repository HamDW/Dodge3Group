using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveTest01Dlg : MonoBehaviour
{

    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;

    [SerializeField] Toggle m_toggleBgm = null;
    [SerializeField] Toggle m_toggleSFX = null;


    private SoundSave m_kSave = new SoundSave();

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
        m_kSave.Initialize();

        m_toggleBgm.isOn = m_kSave.m_isBgm;
        m_toggleSFX.isOn = m_kSave.m_isSFX;
    }

    public void OnClicked_Save()
    {
        m_kSave.m_isBgm = m_toggleBgm.isOn;
        m_kSave.m_isSFX = m_toggleSFX.isOn;
        m_kSave.SaveFile();

        m_txtResult.text = "파일이 저장 되었습니다. ";
    }

    public void OnClicked_Load()
    {
        m_kSave.LoadFile();
        m_toggleBgm.isOn = m_kSave.m_isBgm;
        m_toggleSFX.isOn = m_kSave.m_isSFX;
        
        m_txtResult.text = "파일이 로딩 되었습니다. "; 
    }

    public void OnClicked_Clear()
    {
        m_toggleBgm.isOn = false;
        m_toggleSFX.isOn = false;

        m_kSave.Clear();
    }

 
}
