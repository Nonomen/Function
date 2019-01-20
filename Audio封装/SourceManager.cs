using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager {

    public SourceManager(GameObject tmpOwer) {
        ower = tmpOwer;
        Initial();
    }

    List<AudioSource> allSources;

    GameObject ower;
    /// <summary>
    /// 初始化List
    /// </summary>
    public void Initial() {
        allSources = new List<AudioSource>();

        for (int i = 0; i < 3; i++) {
            AudioSource tmpSource = ower.AddComponent<AudioSource>();
            allSources.Add(tmpSource);
        }
    }
    /// <summary>
    /// 查找空闲Source
    /// </summary>
    public AudioSource GetFreeAudio() {
        for(int i = 0; i < allSources.Count; i++){
            if (!allSources[i].isPlaying) {
                return allSources[i];
            }
        }
        AudioSource tmpSource = ower.AddComponent<AudioSource>();
        allSources.Add(tmpSource);
        return tmpSource;
    }
    public void Stop(string audioName) {
        for (int i = 0; i < allSources.Count; i++) {
            if (allSources[i].isPlaying && allSources[i].clip.name.Equals(audioName)) {
                allSources[i].Stop();
            }
        }
    }
    /// <summary>
    /// 释放多余Sources
    /// </summary>
    public void ReleaseFreeAudio() {
        int tmpCount = 0;
        //Source删除列表
        List<AudioSource> tmpSources = new List<AudioSource>();
        for (int i = 0; i < allSources.Count; i++)
        {
            if (!allSources[i].isPlaying)
            {
                tmpCount++;
                //将要删除的Source加入删除列表
                if (tmpCount > 3)
                {
                    tmpSources.Add(allSources[i]);
                }
            }
        }
        for (int i = 0;i < tmpSources.Count; i++) {
            AudioSource tmpSource = tmpSources[i];
            //从Source总列表中删除
            allSources.Remove(tmpSource);
            //从场景中删除
            GameObject.Destroy(tmpSource);
        }
        //清空Source删除列表
        tmpSources.Clear();
        tmpSources = null;

    }
}
