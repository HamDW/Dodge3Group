using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveSample 
{
    public string m_tmpString = "";

    public bool SaveFile()
    {
        int i = 100;
        float f = 123.34f;
        double d = 456789.1234;
        string str = "cafe.naver.com";

        FileStream fs = new FileStream("sample.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(i);
        bw.Write(f);
        bw.Write(d);
        bw.Write(str);

        bw.Close();
        fs.Close();

        return true;
    }



    public bool LoadFile()
    {
        FileStream fs = new FileStream("sample.data", FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);

        int i = br.ReadInt32();
        float f = br.ReadSingle();
        double d = br.ReadDouble();
        string str = br.ReadString();

        br.Close();
        fs.Close();

        m_tmpString = string.Format(" i = {0}\n f = {1}\n d = {2}\n str = {3}", i, f, d, str);
        Debug.Log(m_tmpString);

        return true;
    }

    public bool LoadFile2()
    {
        try
        {
            FileStream fs = new FileStream("sample.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int i = br.ReadInt32();
            float f = br.ReadSingle();
            double d = br.ReadDouble();
            string str = br.ReadString();

            br.Close();
            fs.Close();

            m_tmpString = string.Format(" i = {0}\n f = {1}\n d = {2}\n str = {3}", i, f, d, str);
            Debug.Log(m_tmpString);
        }
        catch (Exception e)
        {
            Debug.Log("LoadFile Error : " + e.ToString());
        }
        return true;
    }
}
