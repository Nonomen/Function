using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWLocalFile : WWWIterm {

    public WWWLocalFile(string url) {
        Initial(url);
    }
    //根据不同平台给url加前缀
    public void Initial(string url) {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Url = "file:///" + url;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            Url = "jar:file://" + url;
        }
        else
        {
            Url = "file//" + url;
        }
    }

    public override void BeginDownload()
    {
        //base.BeginDownload();
        Debug.Log("Bgein Download!");
    }
    public override void DownloadError(WWWIterm tmpIterm)
    {
        //base.DownloadError(tmpIterm);
        WWWHelper.Instance.AddTask(tmpIterm);
    }
    public override void DownloadFinish(WWW www)
    {
        //base.DownloadFinish(url);
        Debug.Log("Finsih Download ==" + www.text);
    }

}
