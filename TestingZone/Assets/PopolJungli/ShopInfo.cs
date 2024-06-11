/*using HeaderPadDefines;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    // Start is called before the first frame update
    //유니티 인스펙터에서 아이템 이름을 입력
    public string[] sellableBallNames = new string[0];
    //실행 시 shopBalls를 데이터테이블에서 가져와서 등록
    [SerializeField] private BallStat[] shopBalls;

    public BallStat[] CallBallList()
    {
        if (sellableBallNames.Length != shopBalls.Length || sellableBallNames.Length == 0)
        {
            SetShopList();
        }
        return shopBalls;
    }

    void Start()
    {
        //상점에 배치 할 배열을 업데이트 하기 전 상점을 동적생성 
        Managers.instance.UI.shopUICall.ShopUISetting();
        CallBallList();
    }

    // Update is called once per frame
    public void SetShopList()
    {
        //Json파일 분석하여 상점에 배치 할 전구 배열에 넣어줌
        if (Managers.instance.Resource._weaponDictionary.Count <= 0)
        {
            JObject tempJson = JObject.Parse(Managers.instance.Resource.Load<TextAsset>("Weapon_Table").text);
            JToken tempJToken = tempJson["Weapon_Table"];
            ExtraBallStat[] tempBallTable = tempJToken.ToObject<ExtraBallStat[]>();
            for (int i = 0; i < tempBallTable.Length; i++)
            {
                Managers.instance.Resource._weaponDictionary.Add(tempBallTable[i].ballName, tempBallTable[i]);
            }
        }

        if (sellableBallNames.Length == 0)
        {
            ExtraBallStat[] tempStatArray = Managers.instance.Resource._weaponDictionary.Values.ToArray<ExtraBallStat>();
            for (int i = 0; i < 4; i++)
            {
                Array.Resize<BallStat>(ref shopBalls, i + 1);
                int tempRandomNumber = UnityEngine.Random.Range(0, tempStatArray.Length);
                shopBalls[i] = tempStatArray[tempRandomNumber];
                if (Managers.instance.PlayerDataManager.isChallengeMode) shopBalls[i].ballPrice = 0;
                Managers.instance.UI.shopUICall.CreateWeaponBuyButtons(tempStatArray[tempRandomNumber], i);
            }
        }
        else
        {
            for (int i = 0; i < sellableBallNames.Length; i++)
            {
                Array.Resize<BallStat>(ref shopBalls, i + 1);
                if (Managers.instance.Resource._weaponDictionary.TryGetValue(sellableBallNames[i], out ExtraBallStat targetStat))
                {
                    shopBalls[i] = targetStat;
                    if (Managers.instance.PlayerDataManager.isChallengeMode) shopBalls[i].ballPrice = 0;
                    //판매아이템을 만들어줌
                    Managers.instance.UI.shopUICall.CreateWeaponBuyButtons(targetStat, i);
                }
                else
                {
                    Debug.LogError("이름에 해당하는 공이 없습니다 입력명 : " + shopBalls[i]);
                }
            }
        }
    }
}*/