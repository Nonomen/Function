using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWIterm {
    //下载开始
    public virtual void BeginDownload() {

    }
    //下载完成
    public virtual void DownloadFinish(WWW www) {

    }
    //下载出错
    public virtual void DownloadError(WWWIterm tmpIterm) {

    }
    public string Url { get; set; }
    //下载调用
    public IEnumerator Download() {

        BeginDownload();
        WWW www = new WWW(Url);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            DownloadFinish(www);
        }
        else {
            DownloadError(this);
        }
    }
}
