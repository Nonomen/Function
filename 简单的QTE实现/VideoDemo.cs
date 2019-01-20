using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoDemo : MonoBehaviour {
    private bool qteSwitch;
    public bool QteSwitch {
        get {
            return qteSwitch;
        }
        set {
            qteSwitch = value;
        }
    }
    public Text text;
    /// <summary>
    /// QTE逻辑
    /// </summary>
    private double timeCount;//QTE持续时间
    public double tmpTime;//当前的QTE时间
    public int tmpTimeCount = 0;//当前的QTE序号
    public void OnEnter(string tmpKey)
    {
        //显示当前QET 读取下一个QET时间 画面减速 计时器归零 
        text.text = tmpKey.ToString();
        text.transform.position += new Vector3(0,0,+1100);
        video.playbackSpeed = 0.01f;
        
        Debug.Log(tmpTimeCount);
        
    }
    public void OnStay(string tmpKey)
    {
        //等待输入
        
        if (Input.GetKeyDown(tmpKey))
        {
            OnSuccess();
            timeCount = 4;
        }
        if (timeCount >= 2&& timeCount <=3)
        {
            OnFail();
        }
    }
    public void OnSuccess()
    {
        //输入成功 取消UI 画面恢复
        text.transform.position += new Vector3(0, 0, -1100);
        video.playbackSpeed = 1f;

    }
    public void OnFail()
    {
        //text.transform.position += new Vector3(0, 0, -1100);
        //输入失败 返回上一节点
        timeCount = 4;
        video.playbackSpeed = 0.01f;
        //video.time = 0.3f;
    }
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public string[] QTEName;
    public string[] QTETime;
    void ReadConfig()
    {
        var fireAddredd = System.IO.Path.Combine(Application.streamingAssetsPath, "VideoConfig.txt");
        FileInfo fileInFo = new FileInfo(fireAddredd);
        if (fileInFo.Exists)
        {
            StreamReader r = new StreamReader(fireAddredd);

            string tmpLine = r.ReadLine();
            int lineCount = 0;
            //解析字符串为整形赋值给lineCount
            if (int.TryParse(tmpLine, out lineCount))
            {

                QTEName = new string[lineCount];
                QTETime = new string[lineCount];

                for (int i = 0; i < lineCount; i++)
                {
                    tmpLine = r.ReadLine();
                    string[] splits = tmpLine.Split(" ".ToCharArray());//用空格分割字符串
                    QTEName[i] = splits[0];
                    QTETime[i] = splits[1];
                }
            }
            r.Close();
        }
    }
    /// <summary>
    /// 解析string为Double
    /// </summary>
    /// <param name="tmpStr"></param>
    /// <returns></returns>
    double TryDouble(string tmpStr) {
        double tmpDouble;
        double.TryParse(tmpStr, out tmpDouble);
        return tmpDouble;
    }

    VideoPlayer video;
    void Start () {
        video = GetComponent<VideoPlayer>();
        text.transform.position += new Vector3(0, 0, -1100);
        ReadConfig();
    }
	
	void Update () {
        timeCount += Time.deltaTime;//计时器
        if (video.time >= TryDouble(QTETime[tmpTimeCount])) {
            tmpTimeCount++;
            OnEnter(QTEName[tmpTimeCount - 1]);
            timeCount = 0;
        }
        OnStay(QTEName[tmpTimeCount - 1]);
    }
}
