using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClipManager {

    public ClipManager()
    {
        ReadConfig();
        LoadClips();
    }
    //从配置文件加载Clip名字
    //string[] clipName = {"Mangic_Light", "Magic_AirAcross", "Magic-ElectricAcross" };


    string[] clipName;//Clip名字
    SingleClip[] allSingleClip;//SingleClip数组

    //加载Clip到内存
    public void LoadClips() {

        allSingleClip = new SingleClip[clipName.Length];

        for (int i = 0;i < clipName.Length; i++) {
            //Debug.Log(clipName[i]);
            AudioClip tmpClip = Resources.Load<AudioClip>("Audio/"+clipName[i]);
            SingleClip tmpSingle = new SingleClip(tmpClip);//SingleClip实例化
            allSingleClip[i] = tmpSingle;//SingleClip数组
        }
        
    }
    //根据名字找到SingClip
    public SingleClip FindClipByName(string tmpClipName) {
        int tmpIndex = -1;
        for (int i = 0; i < clipName.Length; i++) {
            if (clipName[i].Equals(tmpClipName)) {
                tmpIndex = i;
            }
        }
        if (tmpIndex != -1) {
            
            return allSingleClip[tmpIndex];
        }
        return null;
    }
    //读取配置文件
    void ReadConfig() {
        var fireAddredd = System.IO.Path.Combine(Application.streamingAssetsPath, "RoleText.txt");
        FileInfo fileInFo = new FileInfo(fireAddredd);
        if (fileInFo.Exists) {
            StreamReader r = new StreamReader(fireAddredd);

            string tmpLine = r.ReadLine();
            int lineCount = 0;
            //解析字符串为整形赋值给lineCount
            if (int.TryParse(tmpLine,out lineCount)) {

                clipName = new string[lineCount];

                for (int i = 0;i < lineCount; i++) {
                    tmpLine = r.ReadLine();
                    string[] splits = tmpLine.Split(" ".ToCharArray());//用空格分割字符串
                    clipName[i] = splits[0];
                    //Debug.Log(splits[0]);
                    //Debug.Log(clipName[i]);
                }
            }
            r.Close();


            //string allLine = r.ReadToEnd();
            //Debug.Log(tmpLine);
            //Debug.Log(allLine);

        }

    }
}
