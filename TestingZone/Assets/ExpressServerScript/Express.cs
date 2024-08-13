using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using DG.Tweening.Core.Easing;


public class Express : MonoBehaviour
{
    public string url;
    [SerializeField]public DataInfo dataInfo;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            StartCoroutine(SendRequest(dataInfo, (isSuccess) =>
            {

            }));
        });
    }
    IEnumerator SendRequest(DataInfo data, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("SongName", data.SongName);
        form.AddField("PlayerName", data.PlayerName);
        form.AddField("Score", data.Score);
        

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url+ "/addPlayerData", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to save data to the server: " + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                
            }
        }
    }
}
[System.Serializable]
public class DataInfo
{
    public string SongName;
    public string PlayerName;
    public int Score;
}
