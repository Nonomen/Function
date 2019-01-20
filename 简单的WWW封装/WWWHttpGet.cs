using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWHttpGet : WWWIterm {
    public WWWHttpGet(string url) {
        Initia(url);
    }
    public void Initia(string url) {
        Url = url;
    }
    /*
    public WWWHttp(string url, WWWForm form) {
        Form = form;
    }
    private WWWForm Form { get; set; }
    */
    public override void BeginDownload()
    {
        //base.BeginDownload();
        Debug.Log("Bgein Get!");
    }
    public override void DownloadError(WWWIterm tmpIterm)
    {
        //base.DownloadError(tmpIterm);
        WWWHelper.Instance.AddTask(tmpIterm);
    }
    public override void DownloadFinish(WWW www)
    {
        //base.DownloadFinish(url);
        Debug.Log("Finsih Get ==" + www.text);
    }
    /*
    public void BeginDownload(WWWForm Form)
    {
        //base.BeginDownload();
        Debug.Log("Bgein post!");
    }
    public void DownloadError(WWWIterm tmpIterm, WWWForm Form)
    {
        //base.DownloadError(tmpIterm);
        WWWHelper.Instance.AddTask(tmpIterm);
    }
    public void DownloadFinish(WWW www, WWWForm Form)
    {
        //base.DownloadFinish(url);
        Debug.Log("Finsih post" +
            "==" + www.text);
    }
    public IEnumerator Download(WWWForm Form)
    {

        BeginDownload(Form);
        WWW www = new WWW(Url);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            DownloadFinish(www, Form);
        }
        else
        {
            DownloadError(this);
        }
    }
    */
}
