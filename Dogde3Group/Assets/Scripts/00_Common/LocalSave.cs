using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSave 
{
    //싱글톤 클래스 ---------------------------------------------
    private static LocalSave _Instance = null;
    public static LocalSave Inst() 
    {
        if (_Instance == null)
            _Instance = new LocalSave();

        return _Instance;
    }
    //------------------------------------------------------------

    // 멤버 변수
    public bool IsUseSFX { get; set; }
    public bool IsUseBgm { get; set; }


    private LocalSave()
    {
        IsUseSFX = true;
        IsUseBgm = true;
    }

    // 멤버 함수
    public void Load()
    {
        int value = PlayerPrefs.GetInt("SFX", 1);
        IsUseSFX = value == 1 ? true : false;

        value = PlayerPrefs.GetInt("BGM", 1);
        IsUseBgm = value == 1 ? true : false;

    }


    public void Save()
    {
        int value = IsUseSFX ? 1 : 0;
        PlayerPrefs.SetInt("SFX", value);

        value = IsUseBgm ? 1 : 0;
        PlayerPrefs.SetInt("BGM", value);
    }


 
        

}
