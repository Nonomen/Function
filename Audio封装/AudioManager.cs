using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instace;

    SourceManager sourceManager;
    ClipManager clipManager;
	// Use this for initialization
	void Start () {
        Instace = this;
        sourceManager = new SourceManager(gameObject);
        clipManager = new ClipManager();
    }

    public void Stop(string audioName) {
        sourceManager.Stop(audioName);
    }
    public void Play(string audioName) {
        //拿一个空闲的AudioSource
        AudioSource tmpSource = sourceManager.GetFreeAudio();
        //找到需要播放的Clip
        SingleClip tmpClip = clipManager.FindClipByName(audioName);
        //在对应的Source播放Clip
        if (tmpClip != null) {
            tmpClip.Play(tmpSource);
        }
        
    }


}
