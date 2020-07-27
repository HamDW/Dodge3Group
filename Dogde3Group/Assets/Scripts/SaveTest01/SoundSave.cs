using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSave 
{
    public bool m_isBgm = false;
    public bool m_isSFX = false;

    
    public void Initialize()
    {
        LoadFile();
    }


    public void LoadFile()
    {
        int nBgm = PlayerPrefs.GetInt("BGM", 0);
        int nSFX = PlayerPrefs.GetInt("SFX", 0);

        m_isBgm = nBgm != 0;
        m_isSFX = nSFX != 0;
    }


    public void SaveFile()
    {
        int nBgm = m_isBgm ? 1 : 0;
        int nSFX = m_isSFX ? 1 : 0;

        PlayerPrefs.SetInt("BGM", nBgm);
        PlayerPrefs.SetInt("SFX", nSFX);
    }

    public void Clear()
    {
        m_isBgm = false;
        m_isSFX = false;
    }


}
