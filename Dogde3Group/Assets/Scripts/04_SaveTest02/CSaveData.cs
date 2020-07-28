using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

/* 순번 이름 점수
    1. 홍길동    90
    2. 김말자    80
    3. 장기말    95  
*/

public class ScoreItem
{
    public int m_Index = 0;
    public string m_Name = "";
    public int m_Score = 0;

    public ScoreItem(int idx, string name, int score)
    {
        m_Index = idx;
        m_Name = name;
        m_Score = score;
    }
}


public class CSaveData 
{
    public const string DFILENAME = "test.data";

    public List<ScoreItem> m_ScoreItems = new List<ScoreItem>();


    public void AddScoreData()
    {
        m_ScoreItems.Clear();
        m_ScoreItems.Add(new ScoreItem(1, "홍길동", 90));
        m_ScoreItems.Add(new ScoreItem(2, "김말자", 80));
        m_ScoreItems.Add(new ScoreItem(3, "장기말", 95));
    }


    public void SaveFile()
    {
        FileStream fs = new FileStream(DFILENAME, FileMode.Create, FileAccess.Write);
        if (fs == null) return;

        BinaryWriter bw = new BinaryWriter(fs);

        WriteData(bw);

        bw.Close();
        fs.Close();
    }

    public void LoadFile()
    {
        try
        {
            FileStream fs = new FileStream(DFILENAME, FileMode.Open, FileAccess.Read);
            if (fs == null) return;

            BinaryReader br = new BinaryReader(fs);

            ReadData(br);

            br.Close();
            fs.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error SaveInfo.LoadFile() - " + e.ToString());
        }
    }


    private void WriteData(BinaryWriter bw)
    {
        int nCount = m_ScoreItems.Count;
        
        bw.Write(nCount);
        for( int i = 0; i < nCount; i++)
        {
            ScoreItem kItem = m_ScoreItems[i];

            bw.Write(kItem.m_Index);
            bw.Write(kItem.m_Name);
            bw.Write(kItem.m_Score);
        }
    }

    private void ReadData(BinaryReader br)
    {
        m_ScoreItems.Clear();

        int nCount = br.ReadInt32();

        for( int i = 0; i < nCount; i++)
        {
            int idx = br.ReadInt32();
            string name = br.ReadString();
            int score = br.ReadInt32();

            ScoreItem kItem = new ScoreItem(idx, name, score);
            m_ScoreItems.Add(kItem);
        }
    }

}
