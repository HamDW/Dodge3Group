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
    public bool IsUseSound { get; set; }


    private LocalSave()
    {
        IsUseSound = true;
    }

    // 멤버 함수
    public void Load()
    {
        int value = PlayerPrefs.GetInt("sound", 1);
        IsUseSound = value == 1 ? true : false;
    }


    public void Save()
    {
        int value = IsUseSound ? 1 : 0;
        PlayerPrefs.SetInt("sound", value);
    }


}
