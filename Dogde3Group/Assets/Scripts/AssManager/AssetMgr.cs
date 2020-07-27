using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CAsset
{
    public int m_id = 0;                // id
}

// 스테이지 정보 파일
public class AssetStage : CAsset
{
    //public int m_id = 0;                // Stage
    public float m_FireDelayTime = 0;   // 총알 발사 지연시간    
    public float m_BulletSpeed = 0;     // 총알 속도
    public float m_StageKeepTime = 0;   // 스테이지 유지시간    
    public int m_PlayerHP = 0;          // 플레이어 체력
    public int m_BulletAttack = 0;      // 총알 공격력(데미지)
    public float m_ItemAppearDelay = 0; // 아이템 생성 지연 시간 또는 간격.
    public float m_ItemKeepTime = 0;    // 아이템 화면 출력 유지 시간    
    public int m_TurretCount = 0;       // 터렛 갯수
}


public class AssetItem : CAsset
{
    public int m_nType = 1;
    public string m_sPrefabName = "";
    public float m_fValue;
    public string m_sDesc = "";
}


/*
 *  어셋 정보 관리자
 */
public class AssetMgr 
{
    static AssetMgr _instance = null;
    public static AssetMgr Inst
    {
        get
        {
            if (_instance == null)
                _instance = new AssetMgr();

            return _instance;
        }
    }

    private AssetMgr()
    {
        IsInstalled = false;
    }

    //----------------------------------------------------------
    public bool IsInstalled { get; set; }
    public List<AssetStage> m_AssStages = new List<AssetStage>();
    public List<AssetItem> m_AssItems = new List<AssetItem>();

    public void Initialize()
    {
        Initialzie_Stage("TableData/stage");
        Initialize_Item("TableData/item");
        IsInstalled = true;
    }

    public int GetAsstItemCount() {
        return m_AssItems.Count;
    }
    public int GetAssetStageCount() {
        return m_AssStages.Count;
    }


    public void Initialzie_Stage( string pathName )
    {
        List<string[]> kDatas = CSVParser.Load(pathName);
        if (kDatas == null)
            return;

        for (int i = 1; i < kDatas.Count; i++)
        {
            string[] aStr = kDatas[i];
            AssetStage kStage = new AssetStage();

            kStage.m_id = int.Parse(aStr[0]);
            kStage.m_FireDelayTime = float.Parse(aStr[1]);
            kStage.m_BulletSpeed = float.Parse(aStr[2]);
            kStage.m_StageKeepTime = int.Parse(aStr[3]);
            kStage.m_PlayerHP = int.Parse(aStr[4]);
            kStage.m_BulletAttack = int.Parse(aStr[5]);
            kStage.m_ItemAppearDelay = float.Parse(aStr[6]);
            kStage.m_ItemKeepTime = float.Parse(aStr[7]);
            kStage.m_TurretCount = int.Parse(aStr[8]);

            m_AssStages.Add(kStage);
        }
        kDatas.Clear();
    }

    public void Initialize_Item( string pathName )
    {
        List<string[]> kDatas = CSVParser.Load(pathName);
        if (kDatas == null)
            return;

        for (int i = 1; i < kDatas.Count; i++)
        {
            string[] aStr = kDatas[i];
            AssetItem kItem = new AssetItem();

            kItem.m_id = int.Parse(aStr[0]);
            kItem.m_nType = int.Parse(aStr[1]);
            kItem.m_sPrefabName = aStr[2];
            kItem.m_fValue = float.Parse(aStr[3]);
            kItem.m_sDesc = aStr[4];

            m_AssItems.Add(kItem);
        }
        kDatas.Clear();
    }



    //------------------------------------------------------------------
    public AssetStage GetAssetStage(int iStage )
    {
        if( iStage > 0 && iStage <= m_AssStages.Count){
            return m_AssStages[iStage - 1];
        }
        return null;
    }

    //------------------------------------------------------------------
    public AssetItem GetAssetItem(int id)
    {
        if (id > 0 && id <= m_AssItems.Count)
        {
            return m_AssItems[id - 1];
        }
        return null;
    }

}
