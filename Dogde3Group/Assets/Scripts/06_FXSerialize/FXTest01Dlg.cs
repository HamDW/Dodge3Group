using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXTest01Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnPlay = null;
    [SerializeField] Button m_btnStop = null;

    [SerializeField] FXSerialize m_FX = null;
    //[SerializeField] Button m_btnClear = null;


    // Start is called before the first frame update
    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClicked_Play);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }


    public void OnClicked_Play()
    {
        m_FX.Play();
        m_txtResult.text = "Start Play ....";
    }

    public void OnClicked_Stop()
    {
        m_FX.Stop();
        m_txtResult.text = "Stop Play ....";
    }



}
