/*using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//https://github.com/parechae123/Header 해당프로젝트 링크
public class ShopUI
{
    public bool IsShopActivate
    {
        //상점 UI 판넬이 켜져있는지 확인하는 변수
        get { return ShopPanel.gameObject.activeSelf; }
        set
        {
            Managers.instance.UI.TargetUIOnOff(ShopPanel.rectTransform, value);
        }
    }
    #region 변수
    private Image shopPanel;
    public Image ShopPanel
    {
        get
        {
            //상점 전체판넬
            if (shopPanel == null)
            {
                shopPanel = new GameObject("ShopPanel").AddComponent<Image>();
                shopPanel.rectTransform.SetParent(Managers.instance.UI.loadingUIProps.SceneMainCanvas);
                shopPanel.rectTransform.anchoredPosition = Vector3.zero;
                shopPanel.rectTransform.anchorMax = Vector2.one;
                shopPanel.rectTransform.anchorMin = Vector2.zero;
                shopPanel.rectTransform.sizeDelta = Vector2.zero;
                shopPanel.sprite = Managers.instance.Resource.Load<Sprite>("shop_background_out");
                if (shopPanel.sprite == null) shopPanel.enabled = false;
                shopPanel.rectTransform.SetAsLastSibling();
                shopPanel.gameObject.SetActive(false);
                //씬에서 start함수에서 생성해주기에 기본 false
            }
            return shopPanel;
        }
    }
    private Image shopInnerPanel;
    public Image ShopInnerShopPanel
    {
        get
        {
            //상점 내부판넬
            if (shopInnerPanel == null)
            {
                shopInnerPanel = new GameObject("ShopInnerPanel").AddComponent<Image>();
                shopInnerPanel.rectTransform.SetParent(ShopPanel.rectTransform);
                shopInnerPanel.rectTransform.anchoredPosition = Vector3.zero;
                shopInnerPanel.rectTransform.anchorMax = new Vector2(0.99f, 0.98f);
                shopInnerPanel.rectTransform.anchorMin = new Vector2(0.01f, 0.02f);
                shopInnerPanel.rectTransform.sizeDelta = Vector2.zero;
                shopInnerPanel.sprite = Managers.instance.Resource.Load<Sprite>("shop_background_in");
            }
            return shopInnerPanel;
        }
    }
    private RectTransform shopPlayerStatusWindowPanel;
    public RectTransform ShopPlayerStatusWindowPanel
    {
        get
        {
            if (shopPlayerStatusWindowPanel == null)
            {
                //상점 내 플레이어 상태창
                shopPlayerStatusWindowPanel = new GameObject("ShopPlayerPanel").AddComponent<RectTransform>();
                shopPlayerStatusWindowPanel.SetParent(ShopInnerShopPanel.rectTransform);
                shopPlayerStatusWindowPanel.anchoredPosition = Vector3.zero;
                shopPlayerStatusWindowPanel.anchorMax = new Vector2(0.322f, 1f);
                shopPlayerStatusWindowPanel.anchorMin = Vector2.zero;
                shopPlayerStatusWindowPanel.sizeDelta = Vector2.zero;
            }
            return shopPlayerStatusWindowPanel;
        }
    }

    private Image merchantPortrait_Pannel;
    public Image MerchantPortrait_Pannel
    {
        get
        {
            //상인 초상화 판넬
            if (merchantPortrait_Pannel == null)
            {
                merchantPortrait_Pannel = new GameObject("MerchantPortrait_Pannel").AddComponent<Image>();
                RectTransform tempRect = merchantPortrait_Pannel.rectTransform;
                tempRect.SetParent(ShopPlayerStatusWindowPanel);
                Managers.instance.UI.SetUISize(ref tempRect, new Vector2(0.019f, 0.649f), new Vector2(0.505f, 0.981f));

                merchantPortrait_Pannel.sprite = Managers.instance.Resource.Load<Sprite>("shop_portrait_panel");
            }
            return merchantPortrait_Pannel;
        }
    }

    private Image merchantPortrait;
    public Image MerchantPortrait
    {
        get
        {
            //상인 초상화
            if (merchantPortrait == null)
            {
                merchantPortrait = new GameObject("MerchantPortrait").AddComponent<Image>();
                RectTransform tempRect = merchantPortrait.rectTransform;
                tempRect.SetParent(MerchantPortrait_Pannel.rectTransform);
                Vector2 portraitOutline = new Vector2(0.0683183521f, 0.0676659271f);
                Managers.instance.UI.SetUISize(ref tempRect, Vector2.zero + portraitOutline, Vector2.one - portraitOutline);

                merchantPortrait.sprite = Managers.instance.Resource.Load<Sprite>("shop_portrait");
            }
            return merchantPortrait;
        }
    }
    private Image merchantDialogPanel;
    public Image MerchantDialogPanel
    {
        get
        {
            //상인 대화 텍스트
            if (merchantDialogPanel == null)
            {
                merchantDialogPanel = new GameObject("merchantDialogPanel").AddComponent<Image>();
                merchantDialogPanel.rectTransform.SetParent(ShopPlayerStatusWindowPanel);
                merchantDialogPanel.rectTransform.anchoredPosition = Vector3.zero;
                merchantDialogPanel.rectTransform.anchorMax = new Vector2(0.971f, 0.971f);
                merchantDialogPanel.rectTransform.anchorMin = new Vector2(0.511f, 0.675f);
                merchantDialogPanel.rectTransform.sizeDelta = Vector2.zero;
                merchantDialogPanel.sprite = Managers.instance.Resource.Load<Sprite>("shop_chat_panel");
            }
            return merchantDialogPanel;
        }
    }
    private RectTransform playerBagPanel;
    public RectTransform PlayerBagPanel
    {
        get
        {
            //Shop내 플레이어 영역 판넬
            if (playerBagPanel == null)
            {
                playerBagPanel = new GameObject("PlayerBagPanel").AddComponent<RectTransform>();
                playerBagPanel.SetParent(ShopPlayerStatusWindowPanel);
                Managers.instance.UI.SetUISize(ref playerBagPanel, new Vector2(0.019f, 0.0252f), new Vector2(0.971f, 0.624f));
                playerBagPanel.anchoredPosition = Vector3.zero;
                playerBagPanel.anchorMax = new Vector2(0.971f, 0.624f);
                playerBagPanel.anchorMin = new Vector2(0.019f, 0.0252f);
                playerBagPanel.sizeDelta = Vector2.zero;

            }
            return playerBagPanel;
        }
    }
    private Image playerMoneyPannel;
    public Image PlayerMoneyPannel
    {
        get
        {
            //플레이어 소지금 표시창 백그라운드
            if (playerMoneyPannel == null)
            {
                playerMoneyPannel = new GameObject("PlayerMoneyPannel").AddComponent<Image>();
                RectTransform tempRect = playerMoneyPannel.rectTransform;
                playerMoneyPannel.rectTransform.SetParent(PlayerBagPanel);
                playerMoneyPannel.sprite = Managers.instance.Resource.Load<Sprite>("coin_pannel");
                float yPercentValue = playerMoneyPannel.sprite.bounds.size.y / playerMoneyPannel.sprite.bounds.size.x;
                Managers.instance.UI.SetUISize(ref tempRect, new Vector2(0, 1 - yPercentValue), Vector2.one);
            }
            return playerMoneyPannel;
        }
    }
    private Image playerInventoryPanel;
    public Image PlayerInventoryPanel
    {
        get
        {
            //플레이어 인벤토리 판넬
            if (playerInventoryPanel == null)
            {
                playerInventoryPanel = new GameObject("PlayerInventoryPanel").AddComponent<Image>();
                RectTransform tempRect = playerInventoryPanel.rectTransform;
                tempRect.SetParent(PlayerBagPanel);


                playerInventoryPanel.sprite = Managers.instance.Resource.Load<Sprite>("shop_bag_panel");
                float parentPercent = playerInventoryPanel.sprite.bounds.size.y;

                //x가 1일때 y의 비율\
                float walletPanelSize = PlayerMoneyPannel.rectTransform.anchorMax.y - PlayerMoneyPannel.rectTransform.anchorMin.y;
                walletPanelSize = walletPanelSize + (walletPanelSize / 2f);
                Managers.instance.UI.SetUISize(ref tempRect, Vector2.zero, Vector2.one - (Vector2.up * walletPanelSize));
            }
            return playerInventoryPanel;
        }
    }
    Button nextBTN;
    Button NextBTN
    {
        //인벤토리 다음페이지 이동버튼
        get
        {
            if (nextBTN == null)
            {

                Button tempNextBTN = new GameObject("WeaponNextBTN").AddComponent<Button>();
                RectTransform NextBTRT = tempNextBTN.transform.AddComponent<RectTransform>();
                NextBTRT.SetParent(PlayerInventoryPanel.rectTransform);
                Image tempNextBTNIMG = NextBTRT.AddComponent<Image>();
                tempNextBTN.targetGraphic = tempNextBTNIMG;
                float percent = PlayerInventoryPanel.rectTransform.rect.size.x / PlayerInventoryPanel.rectTransform.rect.size.y;
                Vector2 BeforeBTNStartPos = new Vector2(0f, 0.4f);
                Vector2 tempSize = new Vector2(0.1f, 0.1f * percent);
                tempNextBTNIMG.sprite = Managers.instance.Resource.Load<Sprite>("select_arrow_panel_R");
                BeforeBTNStartPos = new Vector2(1f, BeforeBTNStartPos.y + tempSize.y);
                NextBTRT.anchorMin = BeforeBTNStartPos - tempSize;
                NextBTRT.anchorMax = BeforeBTNStartPos;
                NextBTRT.anchoredPosition = Vector2.zero;
                NextBTRT.sizeDelta = Vector2.zero;
                tempNextBTN.onClick.AddListener(InvenNextBTN);
                Managers.instance.UI.RegistEventTrigger(NextBTRT);
                nextBTN = tempNextBTN;
            }
            return nextBTN;
        }
    }
    Button beforeBTN;
    Button BeforeBTN
    {
        //인벤토리 이전페이지 이동버튼
        get
        {
            if (beforeBTN == null)
            {
                Button tempBeforeBTN = new GameObject("WeaponBeforeBTN").AddComponent<Button>();
                RectTransform BeforeBTRT = tempBeforeBTN.transform.AddComponent<RectTransform>();
                Image tempBeforeBTNIMG = BeforeBTRT.AddComponent<Image>();
                tempBeforeBTN.targetGraphic = tempBeforeBTNIMG;
                tempBeforeBTNIMG.sprite = Managers.instance.Resource.Load<Sprite>("select_arrow_panel_L");


                BeforeBTRT.SetParent(PlayerInventoryPanel.rectTransform);
                float percent = PlayerInventoryPanel.rectTransform.rect.size.x / PlayerInventoryPanel.rectTransform.rect.size.y;
                Vector2 BeforeBTNStartPos = new Vector2(0f, 0.4f);
                Vector2 tempSize = new Vector2(0.1f, 0.1f * percent);
                BeforeBTRT.anchorMin = BeforeBTNStartPos;
                BeforeBTRT.anchorMax = BeforeBTNStartPos + tempSize;
                BeforeBTRT.anchoredPosition = Vector2.zero;
                BeforeBTRT.sizeDelta = Vector2.zero;
                tempBeforeBTN.onClick.AddListener(InvenBeforeBTN);
                Managers.instance.UI.RegistEventTrigger(BeforeBTRT);
                beforeBTN = tempBeforeBTN;
            }
            return beforeBTN;
        }
    }



    *//*    private Image playerMoneyIMG;
        public Image PlayerMoneyIMG
        {
            get
            {
                if (playerMoneyIMG == null)
                {
                    playerMoneyIMG = new GameObject("PlayerMoneyIMG").AddComponent<Image>();
                    playerMoneyIMG.rectTransform.SetParent(PlayerMoneyPanel.rectTransform);

                    playerMoneyIMG.rectTransform.anchoredPosition = Vector3.zero;
                    Vector2 startPos = new Vector2(0.055f, 0.225f);
                    Vector2 tempSize = new Vector2(0.15f, 0.15f * (PlayerMoneyPanel.rectTransform.rect.size.x / PlayerMoneyPanel.rectTransform.rect.size.y));
                    playerMoneyIMG.rectTransform.anchorMax = startPos + tempSize;
                    playerMoneyIMG.rectTransform.anchorMin = startPos;
                    playerMoneyIMG.rectTransform.sizeDelta = Vector2.zero;
                    PlayerMoneyIMG.sprite = Managers.instance.Resource.Load<Sprite>("coin");
                    //TODO : ShopPanel이 업로드시 해당 키값 작성 요망
                }
                return playerMoneyIMG;
            }
        }*//*
    private Text goldAmountText;
    public Text GoldAmountText
    {
        //플레이어 소지금 텍스트
        get
        {
            if (goldAmountText == null)
            {
                goldAmountText = new GameObject { name = "GoldAmountText" }.AddComponent<Text>();
                goldAmountText.rectTransform.SetParent(PlayerMoneyPannel.rectTransform);
                goldAmountText.rectTransform.anchorMin = new Vector2(0.400000006f, 0.224999994f);
                goldAmountText.rectTransform.anchorMax = Vector2.one;
                goldAmountText.rectTransform.sizeDelta = Vector2.zero;
                goldAmountText.rectTransform.anchoredPosition = Vector2.zero;
                goldAmountText.fontSize = 70;
                goldAmountText.resizeTextForBestFit = true;
                goldAmountText.color = Color.white;
                goldAmountText.font = Managers.instance.Resource.Load<Font>("InGameFont");
                goldAmountText.alignment = TextAnchor.LowerLeft;
                goldAmountText.horizontalOverflow = HorizontalWrapMode.Wrap;

            }
            return goldAmountText;
        }
    }
    private (Image, Text)[] inventoryIcons = new (Image, Text)[6];
    public (Image, Text)[] InventoryIcons
    {
        //소지중인 전구 사진과 갯수
        get
        {
            if (inventoryIcons.Length == 0)
            {
                inventoryIcons = new (Image, Text)[6];
            }
            for (int i = 0; i < inventoryIcons.Length; i++)
            {
                if (inventoryIcons[i].Item1 == null || inventoryIcons[i].Item2 == null)
                {
                    if (inventoryIcons[i].Item1 == null)
                    {
                        float xAixs = (float)i % 2f == 0f ? 0.27f : 0.62f;
                        //i가 홀수일때 x는 오른쪽에 위치하도록,짝수 혹은 0일때 왼쪽에 위치하도록
                        float yAixs = xAixs == 0.27f ? ((float)i / 2f) / 3f : (((float)i - 1f) / 2f) / 3f;
                        Vector2 maxValue = new Vector2(xAixs, 0.93f - yAixs);
                        float percent = PlayerInventoryPanel.rectTransform.rect.size.x / PlayerInventoryPanel.rectTransform.rect.size.y;
                        Vector2 IconSize = new Vector2(0.16f, 0.16f * percent);
                        //i를 2로 나눴을때 1이 나오면 y가 중앙에 위치하도록 설정,그렇지 않으면 x에서 구한 홀수 짝수를 이용해 값을 구함
                        inventoryIcons[i].Item1 = new GameObject("WeaponIconImage" + i).AddComponent<Image>();
                        inventoryIcons[i].Item1.rectTransform.SetParent(PlayerInventoryPanel.rectTransform);
                        inventoryIcons[i].Item1.rectTransform.anchorMin = maxValue - (Vector2.up * IconSize.y);
                        inventoryIcons[i].Item1.rectTransform.anchorMax = maxValue + (Vector2.right * IconSize.x);
                        inventoryIcons[i].Item1.rectTransform.anchoredPosition = Vector2.zero;
                        inventoryIcons[i].Item1.rectTransform.sizeDelta = Vector2.zero;
                    }
                    else
                    {
                        float xAixs = (float)i % 2f == 0f ? 0f : 0.5f;
                        //i가 홀수일때 x는 오른쪽에 위치하도록,짝수 혹은 0일때 왼쪽에 위치하도록
                        float yAixs = xAixs == 0 ? ((float)i / 2f) / 3f : (((float)i - 1f) / 2f) / 3f;
                        Vector2 maxValue = new Vector2(xAixs, 1 - yAixs);
                        //i를 2로 나눴을때 1이 나오면 y가 중앙에 위치하도록 설정,그렇지 않으면 x에서 구한 홀수 짝수를 이용해 값을 구함
                        inventoryIcons[i].Item1.rectTransform.SetParent(PlayerInventoryPanel.rectTransform);
                        inventoryIcons[i].Item1.rectTransform.anchorMin = maxValue - (Vector2.one * 0.11f);
                        inventoryIcons[i].Item1.rectTransform.anchorMax = maxValue;
                        inventoryIcons[i].Item1.rectTransform.anchoredPosition = Vector2.zero;
                        inventoryIcons[i].Item1.rectTransform.sizeDelta = Vector2.zero;
                    }
                    if (inventoryIcons[i].Item2 == null)
                    {
                        inventoryIcons[i].Item2 = new GameObject("WeaponAmountText" + i).AddComponent<Text>();
                        inventoryIcons[i].Item2.font = Managers.instance.Resource.Load<Font>("InGameFont");
                        inventoryIcons[i].Item2.fontSize = 40;
                        inventoryIcons[i].Item2.alignment = TextAnchor.LowerLeft;
                        inventoryIcons[i].Item2.color = Color.gray;
                        inventoryIcons[i].Item2.rectTransform.SetParent(inventoryIcons[i].Item1.rectTransform);
                        inventoryIcons[i].Item2.rectTransform.anchorMax = Vector2.one + Vector2.right;
                        inventoryIcons[i].Item2.rectTransform.anchorMin = Vector2.right;
                        inventoryIcons[i].Item2.rectTransform.anchoredPosition = Vector2.zero;
                        inventoryIcons[i].Item2.rectTransform.sizeDelta = Vector2.zero;
                    }
                    else
                    {
                        inventoryIcons[i].Item2.rectTransform.SetParent(inventoryIcons[i].Item1.rectTransform);
                        inventoryIcons[i].Item2.rectTransform.anchorMax = Vector2.one + Vector2.right;
                        inventoryIcons[i].Item2.rectTransform.anchorMin = Vector2.right;
                        inventoryIcons[i].Item2.rectTransform.anchoredPosition = Vector2.zero;
                        inventoryIcons[i].Item2.rectTransform.sizeDelta = Vector2.zero;

                    }
                }
            }

            return inventoryIcons;
        }
    }
    public List<(Sprite, string)> Inventory = new List<(Sprite, string)>();
    int invenPage;
    int NowPage
    {
        //페이지를 세팅해주는 변수
        set
        {
            if (value <= 0)
            {
                BeforeBTN.interactable = false;
            }
            else
            {
                BeforeBTN.interactable = true;
            }
            if (value < 0)
            {
                invenPage = 0;
            }
            else
            {
                SetInvenIMG(value);
                invenPage = value;
            }
        }
    }
    private Image shoppingPanel;
    public Image ShoppingPanel
    {
        //상점 아이템목록 판넬
        get
        {
            if (shoppingPanel == null)
            {
                shoppingPanel = new GameObject("shoppingPanel").AddComponent<Image>();
                shoppingPanel.rectTransform.SetParent(ShopInnerShopPanel.rectTransform);
                shoppingPanel.rectTransform.anchorMax = Vector2.one;
                shoppingPanel.rectTransform.anchorMin = new Vector2(0.33f, 0f);
                shoppingPanel.rectTransform.sizeDelta = Vector2.zero;
                shoppingPanel.rectTransform.anchoredPosition = Vector2.zero;
                shoppingPanel.sprite = Managers.instance.Resource.Load<Sprite>("shop_buy_panel");
            }
            return shoppingPanel;
        }
    }
    public Button[] shopWeaponItems;
    public void CreateWeaponBuyButtons(ExtraBallStat stat, int ballArray)
    {
        //상점 생성 함수로부터 상점 아이템 정보와 배치를 해주는 함수
        if (shopWeaponItems == null)
        {
            shopWeaponItems = new Button[0];
        }
        if (ballArray >= shopWeaponItems.Length)
        {
            Array.Resize(ref shopWeaponItems, shopWeaponItems.Length + 1);
            int arrayNum = shopWeaponItems.Length - 1;
            shopWeaponItems[arrayNum] = new GameObject("ShopWeaponBTN" + (shopWeaponItems.Length)).AddComponent<Button>();
            RectTransform tempParent = new GameObject("ShopWeaponBTNParentOBJ" + shopWeaponItems.Length).AddComponent<RectTransform>();
            tempParent.SetParent(ShoppingPanel.rectTransform);




            RectTransform tempRect = shopWeaponItems[arrayNum].AddComponent<RectTransform>();
            Image tempImage = shopWeaponItems[arrayNum].AddComponent<Image>();
            shopWeaponItems[arrayNum].targetGraphic = tempImage;
            tempRect.SetParent(tempParent);


            float shoppingPanelSizePercent = ShoppingPanel.rectTransform.rect.size.x / ShoppingPanel.rectTransform.rect.size.y;
            //얘를 버튼  y에 곱해주면 정사각형이 됨,X는 배열과 정비례하나 Y는 반비례함
            int tempClumm = arrayNum / 4;
            int tempRow = arrayNum % 4;
            *//*        if (tempClumm > 0)
                    {
                        int tempLength = (shopWeaponItems.Length / 5) + shopWeaponItems.Length;
                        tempRow = tempLength % 5;
                        tempClumm = tempLength / 5;
                        tempRow = tempRow== 0 ? 1: tempRow ;
                    }*//*

            float tempMaxX = tempRow * 0.25f;
            float tempMaxY = 1 - ((tempClumm * shoppingPanelSizePercent) * 0.25f);
            //row = 행 Clum = 열
            tempParent.anchorMax = new Vector2(tempMaxX + 0.25f, tempMaxY);
            tempParent.anchorMin = new Vector2(tempMaxX, tempMaxY + (-0.25f * shoppingPanelSizePercent));
            tempParent.sizeDelta = Vector2.zero;
            tempParent.anchoredPosition = Vector2.zero;

            Text priceText = new GameObject("ShopWeaponPriceText" + shopWeaponItems.Length).AddComponent<Text>();
            priceText.font = Managers.instance.Resource.Load<Font>("InGameFont");
            priceText.alignment = TextAnchor.UpperCenter;
            priceText.text = stat.ballPrice + "$";
            priceText.color = Color.gray;
            priceText.rectTransform.SetParent(tempParent);
            priceText.rectTransform.anchorMax = new Vector2(1f, 0.4f);
            priceText.rectTransform.anchorMin = Vector2.zero;
            priceText.rectTransform.sizeDelta = Vector2.zero;
            priceText.rectTransform.anchoredPosition = Vector2.zero;
            priceText.fontSize = (int)(70);

            tempRect.anchorMax = new Vector2(0.8f, 1);
            tempRect.anchorMin = new Vector2(0.2f, 0.4f);
            tempRect.sizeDelta = Vector2.zero;
            tempRect.anchoredPosition = Vector2.zero;
            tempImage.sprite = Managers.instance.Resource.Load<Sprite>(stat.ballName);
        }
        else
        {
            shopWeaponItems[ballArray].GetComponent<Image>().sprite = Managers.instance.Resource.Load<Sprite>(stat.ballName);
            shopWeaponItems[ballArray].transform.parent.Find("ShopWeaponPriceText" + ballArray + 1);
            for (int i = ballArray + 1; i < shopWeaponItems.Length; i++)
            {
                //갱신이 안된 버튼들은 꺼주는 구문
                shopWeaponItems[i].transform.parent.transform.gameObject.SetActive(false);
            }
            shopWeaponItems[ballArray].transform.parent.transform.gameObject.SetActive(true);
        }
        Managers.instance.UI.RegistEventTrigger(shopWeaponItems[ballArray].transform as RectTransform);
        shopWeaponItems[ballArray].onClick.RemoveAllListeners();
        shopWeaponItems[ballArray].onClick.AddListener(() =>
        {
            Managers.instance.PlayerDataManager.AddBall(stat, true);
        });


    }
    #endregion
    public void InvenBeforeBTN()
    {
        //인벤 이전페이지로 가는 함수
        NowPage = invenPage - 1;
    }
    public void InvenNextBTN()
    {
        //인벤 다음페이지로가는 함수
        NowPage = invenPage + 1;
    }
    public void UpdateInvenBulb(List<ExtraBallStat> ballList)
    {
        //현재 인벤에 존재하는 전구를 업데이트 해주는 함수
        (Sprite, string) tempSet;
        for (int i = 0; i < ballList.Count; i++)
        {
            if (i >= Inventory.Count || Inventory.Count == 0)
            {
                NowPage = i / 6;
                tempSet.Item1 = Managers.instance.Resource.Load<Sprite>(ballList[i].ballName);
                tempSet.Item2 = ballList[i].amount.ToString();
                Inventory.Add(tempSet);
            }
            else if (Inventory[i].Item1.name != ballList[i].ballName || ballList[i].amount.ToString() != Inventory[i].Item2.ToString())
            {
                NowPage = i / 6;
                if (Inventory[i].Item1.name != ballList[i].ballName && ballList[i].amount.ToString() != Inventory[i].Item2.ToString())
                {
                    tempSet.Item1 = Managers.instance.Resource.Load<Sprite>(ballList[i].ballName);
                    tempSet.Item2 = ballList[i].amount.ToString();
                    Inventory[i] = tempSet;
                }
                else if (Inventory[i].Item1.name != ballList[i].ballName)
                {
                    tempSet.Item1 = Managers.instance.Resource.Load<Sprite>(ballList[i].ballName);
                    tempSet.Item2 = Inventory[i].Item2;
                    Inventory[i] = tempSet;
                }
                else if (ballList[i].amount.ToString() != Inventory[i].Item2.ToString())
                {
                    tempSet.Item1 = Inventory[i].Item1;
                    tempSet.Item2 = ballList[i].amount.ToString();
                    Inventory[i] = tempSet;
                }
            }

            if (invenPage < 0)
            {
                NowPage = 0;
            }
        }
        SetInvenIMG();
    }
    private void SetInvenIMG(int targetPage = -1)
    {
        //인벤토리 이미지 배열 설정함수
        if (targetPage == -1)
        {
            targetPage = invenPage;
        }
        int caculatePage = 1 + targetPage;
        int arrayUI = 0;
        for (int i = targetPage * 6; i <= (caculatePage * 5) + targetPage; i++)
        {
            if (Inventory.Count > i)
            {
                NextBTN.interactable = true;
                InventoryIcons[arrayUI].Item1.sprite = Inventory[i].Item1;
                InventoryIcons[arrayUI].Item2.text = Inventory[i].Item2;
                InventoryIcons[arrayUI].Item1.gameObject.SetActive(true);
                InventoryIcons[arrayUI].Item2.gameObject.SetActive(true);
            }
            else
            {
                NextBTN.interactable = false;
                InventoryIcons[arrayUI].Item1.sprite = null;
                InventoryIcons[arrayUI].Item2.text = string.Empty;
                InventoryIcons[arrayUI].Item1.gameObject.SetActive(false);
                InventoryIcons[arrayUI].Item2.gameObject.SetActive(false);

            }
            arrayUI++;
        }
    }
    public void MoneyUpdate(int money)
    {
        //소지금 업데이트 함수
        IsShopActivate = Managers.instance.UI.shopUICall.IsShopActivate == true ? true : false;
        GoldAmountText.text = money.ToString();
    }
    public void ShopUISetting()
    {
        //Shop UI를 생성해줌
        MerchantPortrait.enabled = true;
        MerchantDialogPanel.enabled = true;
        PlayerInventoryPanel.enabled = true;
        MoneyUpdate(Managers.instance.PlayerDataManager.PlayerMoney);
        ShopPanel.gameObject.SetActive(false);
        UpdateInvenBulb(Managers.instance.PlayerDataManager.playerOwnBalls);
        NextBTN.enabled = true;
        BeforeBTN.enabled = true;
        ShoppingPanel.enabled = true;
    }

}
*/