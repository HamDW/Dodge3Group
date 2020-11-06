using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/* 
  <  사용 예제   >
    CTextFileSave kSave = new CTextFileSave();

    //텍스트 파일저장 및 열기
    kSave.SaveFile("textdata1.txt");
    kSave.LoadFile("textdata1.txt");


    // 바이너리 파일저장및 열기
    kSave.SaveBinaryFile("filedata2.data");
    kSave.LoadBinaryFile("filedata2.data");
*/

public class CTextFileSave
{
    public bool m_bCheck = false;
    public int m_nCount = 0;
    public float m_fValue = 0;
    public string m_Str = "";

    public void Initialize()
    {
        m_bCheck = true;
        m_nCount = 50;
        m_fValue = 3.567f;
        m_Str = "안녕하세요";
    }
    
    public void SaveFile(string sPath)
    {
        StreamWriter fw = new StreamWriter(sPath);
            fw.WriteLine(m_bCheck);
            fw.WriteLine(m_nCount);
            fw.WriteLine(m_fValue);
            fw.WriteLine(m_Str);
        fw.Close();
    }

    public void LoadFile(string sPath)
    {
        try
        {
            StreamReader fr = new StreamReader(sPath);

            string sCheck = fr.ReadLine();
            string sCount = fr.ReadLine();
            string sValue = fr.ReadLine();
            string sStr = fr.ReadLine();
            fr.Close();

            m_bCheck = bool.Parse(sCheck);
            m_nCount = int.Parse(sCount);
            m_fValue = float.Parse(sValue);
            m_Str = sStr;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

}

