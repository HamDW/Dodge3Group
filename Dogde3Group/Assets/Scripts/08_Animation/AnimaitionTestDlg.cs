using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaitionTestDlg : MonoBehaviour
{
    [SerializeField] Animation m_Animation = null;
    [SerializeField] Button m_btnPlay = null;
    [SerializeField] Button m_btnPlayQueued = null;
    [SerializeField] Button m_btnBlend = null;
    [SerializeField] Button m_btnCrossPade = null;
    [SerializeField] Button m_btnStop = null;
    [SerializeField] Button m_btnPlayMove = null;



    // Start is called before the first frame update
    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClicked_Play);
        m_btnPlayQueued.onClick.AddListener(OnClicked_PlayQueued);
        m_btnBlend.onClick.AddListener(OnClicked_Beled);
        m_btnCrossPade.onClick.AddListener(OnClicked_CrossPade);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
        m_btnPlayMove.onClick.AddListener(OnClicked_PlayMove);
    }


    public void OnClicked_Play()
    {
        m_Animation.Play("Rot02");
    }

    public void OnClicked_PlayQueued()
    {
        m_Animation.PlayQueued("Rot02");        // 이전 애니메이션이 모두 끝나고 플레이
    }
    public void OnClicked_Beled()
    {       
        m_Animation.Blend("Rot02");             // 2개의 플레이어 섞여서 나온다.
    }
    public void OnClicked_CrossPade()
    {
        m_Animation.CrossFade("Rot02", 0.5f);         // 부드럽게 다음 애니가 진행 된다.
    }
    public void OnClicked_Stop()
    {
        m_Animation.Stop();
    }


    public void OnClicked_PlayMove()
    {
        if( !m_Animation.isPlaying )
            m_Animation.Play("Move1");              // 이동 애니 플레이
    }


}
