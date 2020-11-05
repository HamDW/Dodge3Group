using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_FileTest
{

    /* 
      <  사용 예제   >
        FileSave kSave = new FileSave();

        //텍스트 파일저장 및 열기
        kSave.SaveTextFile("textdata1.txt");
        kSave.LoadTextFile("textdata1.txt");


        // 바이너리 파일저장및 열기
        kSave.SaveBinaryFile("filedata2.data");
        kSave.LoadBinaryFile("filedata2.data");

    */

    public class FileSave
    {

        public void SaveTextFile(string sPath)
        {
            StreamWriter fw = new StreamWriter(sPath);
            bool bCheck = true;
            int nCount = 50;
            float fValue = 3.567f;
            string str = "안녕하세요";

                fw.WriteLine(bCheck);
                fw.WriteLine(nCount);
                fw.WriteLine(fValue);
                fw.WriteLine(str);

            fw.Close();
        }



        public void LoadTextFile(string sPath)
        {
            try
            {
                StreamReader fr = new StreamReader(sPath);
                bool bCheck = bool.Parse(fr.ReadLine());
                int nCount = int.Parse(fr.ReadLine());
                float fValue = float.Parse(fr.ReadLine());
                string str = fr.ReadLine();
                fr.Close();

                Console.WriteLine("check = " + bCheck);
                Console.WriteLine("count = " + nCount);
                Console.WriteLine("value = " + fValue);
                Console.WriteLine("str = " + str);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public void SaveBinaryFile(string sPath)
        {
            bool bCheck = true;
            int nCount = 50;
            float fValue = 3.567f;
            string str = "안녕하세요";

            FileStream fs = new FileStream(sPath, FileMode.Create, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);

                br.Write(bCheck);
                br.Write(nCount);
                br.Write(fValue);
                br.Write(str);

            br.Close();
            fs.Close();


        }

        public void LoadBinaryFile(string sPath)
        {
            try
            {
                FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                bool bCheck = br.ReadBoolean();
                int nCount = br.ReadInt32();
                float fValue = br.ReadSingle();
                string str = br.ReadString();

                br.Close();
                fs.Close();

                Console.WriteLine("check2 = " + bCheck);
                Console.WriteLine("count2 = " + nCount);
                Console.WriteLine("value2 = " + fValue);
                Console.WriteLine("str2 = " + str);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }



    }
}
