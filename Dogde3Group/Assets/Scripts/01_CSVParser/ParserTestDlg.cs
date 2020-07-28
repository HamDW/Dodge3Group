using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class TestItem
{
    public int m_Id = 0;
    public string m_Name = "";
    public int m_Value = 0;
}


public class ParserTestDlg : MonoBehaviour
{
    public Text m_txtResult = null;
    public Button m_btnLoad = null;
    public Button m_btnParser = null;
    public Button m_btnClear = null;

    public List<TestItem> m_listItem = new List<TestItem>();
    

    // Start is called before the first frame update
    void Start()
    {
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnParser.onClick.AddListener(OnClicked_Parser);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }


    public void OnClicked_Load()
    {
        LoadingTest();
    }

    public void OnClicked_Parser()
    {
        ParsingTest();
    }

    public void OnClicked_Clear()
    {
        m_txtResult.text = "";
        m_listItem.Clear();
    }

    private void LoadingTest()
    {
        m_listItem.Clear();

        List<string[]> dataList = CSVParser.Load("TableData/test");
        //List<string[]> dataList = CSVParser.Load2("Assets/Resources/TableData/test.csv");

        string sResult = "";
        for (int i = 0; i < dataList.Count; i++)
        {
            string[] data = dataList[i];
            sResult += string.Format("{0}, {1}, {2}\n", data[0], data[1], data[2]);
        }
        m_txtResult.text = sResult;
    }

    public void ParsingTest()
    {
        //List<string[]> dataList = CSVParser.Load("TableData/test");
        List<string[]> dataList = CSVParser.Load2("Assets/Resources/TableData/test.csv");

        for (int i = 1; i < dataList.Count; i++)
        {
            string[] data = dataList[i];

            TestItem kItem = new TestItem();

            kItem.m_Id = int.Parse(data[0]);
            kItem.m_Name = data[1];
            kItem.m_Value = int.Parse(data[2]);

            m_listItem.Add(kItem);
        }

        PrintText();
    }




    private void PrintText()
    {
        StringBuilder kBuilder = new StringBuilder();

        for( int i = 0; i < m_listItem.Count; i++)
        {
            TestItem kItem = m_listItem[i];

            kBuilder.Append( string.Format("{0}, {1}, {2} \n", kItem.m_Id, kItem.m_Name, kItem.m_Value));
        }

        m_txtResult.text = kBuilder.ToString();
    }

  






}
