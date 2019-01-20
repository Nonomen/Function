using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWHelper : MonoBehaviour {

    public static WWWHelper Instance;
    Queue<WWWIterm> allTask;
    //任务放入队列
    bool isDownLoadingFinsish = true;
    public void AddTask(WWWIterm iterm) {
        allTask.Enqueue(iterm);

        if (allTask.Count == 1 && isDownLoadingFinsish == true) {
            isDownLoadingFinsish = false;
            StartCoroutine(DownloadIterm());
        }
    }
    public IEnumerator DownloadIterm() {
        while (allTask.Count > 0) {
            WWWIterm iterm = allTask.Dequeue();//拿出第一个任务
            yield return iterm.Download();
        }
        isDownLoadingFinsish = true;
    }
    //下载列表初始化
    void Start () {
        Instance = this;
        allTask = new Queue<WWWIterm>();
	}

}
