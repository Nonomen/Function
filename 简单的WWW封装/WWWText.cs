using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWText : MonoBehaviour {
    IEnumerator SendGet(string url) {
        WWW www = new WWW(url);
        yield return www;
        if (string.IsNullOrEmpty(www.error)) {
            Debug.Log("FinshGet=="+www.text);
        }
    }
    IEnumerator SendPost(string url,WWWForm form) {
        WWW www = new WWW(url,form);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("FinshPost==" + www.text);
        }
    }
    IEnumerator DownloadLocalFile(string url) {
        WWW www = new WWW(url);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("FinshDownloadLocalFile==" + www.text);
        }
    }
    //根据不同平台给url加前缀
    public string InitialUrl(string url) {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
            url = "file:///" + url;
        }
        else if (Application.platform == RuntimePlatform.Android) {
            url = "jar:file://" + url;
        }
        else {
            url = "file//" + url;
        }
        return url;
    }

	void Start () {
        string urlGet = "http://r.qzone.qq.com/cgi-bin/user/cgi_personal_card?uin=88888888";
        WWWHttpGet temGet = new WWWHttpGet(urlGet);
        WWWHelper.Instance.AddTask(temGet);
        //StartCoroutine(SendGet(urlGet));

        string urlPost = "http://r.qzone.qq.com/cgi-bin/user/cgi_personal_card";
        WWWForm form = new WWWForm();
        form.AddField("uin", "888");
        //WWWHttpPost temPost = new WWWHttpPost(urlPost,form);
        //WWWHelper.Instance.AddTask(temPost);
        StartCoroutine(SendPost(urlPost, form));


        string urlLocalFile = Application.dataPath + "/WWW/WWWText.cs";
        WWWLocalFile temText = new WWWLocalFile(urlLocalFile);
        WWWHelper.Instance.AddTask(temText);

    }
    //TextTrue
}
