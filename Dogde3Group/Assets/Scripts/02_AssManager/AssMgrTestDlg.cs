using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AssMgrTestDlg : MonoBehaviour
{
    public Text m_txtResult = null;
    public Button m_btnParser = null;
    public Button m_btnClear = null;

    // Start is called before the first frame update
    void Start()
    {
        m_btnParser.onClick.AddListener(OnClicked_Parser);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    public void Initialize()
    {

    }
        

    public void OnClicked_Parser()
    {
        AssetMgr.Inst.Initialize();

        PrintItem();
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }


    public void PrintItem()
    {
        List<AssetItem> kList = AssetMgr.Inst.m_AssItems;

        StringBuilder kBuilder = new StringBuilder();
        for( int i = 0; i <kList.Count; i++ )
        {
            AssetItem kAss = kList[i];

            //string str = string.Format("{0}, {1}, {2}, {3}, {4}\n", kAss.m_id, kAss.m_nType,kAss.m_sPrefabName,kAss.m_fValue, kAss.m_sDesc);
            string str = string.Format("{0}, {1}, {2}, {3}\n", kAss.m_id, kAss.m_nType, kAss.m_sPrefabName, kAss.m_fValue);
            kBuilder.Append(str);
        }

        m_txtResult.text = kBuilder.ToString();
    }

        

}
