using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCell : MonoBehaviour
{
    private Transform UIIcon;
    private Transform UISelect;
    private Transform UIItemName;
    private Transform UIDeleteSelect;

    private PackageLocalItem packageLocalData;
    private PackageTableItem packageTableItem;
    private PackagePanel uiParent;

    private void Awake()
    {
        InitUIName();
    }
    private void InitUIName()
    {
        UIIcon = transform.Find("Top/Icon");
        UIItemName = transform.Find("Bottom/itemName");
        UISelect = transform.Find("Select");
        UIDeleteSelect = transform.Find("DeleteSelect");

        UIDeleteSelect.gameObject.SetActive(false);
    }

    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 数据初始化
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;
        // 显示物品名称（如果 UI 存在）
        if (UIItemName != null && this.packageTableItem != null)
        {
            Text nameText = UIItemName.GetComponent<Text>();
            if (nameText != null)
                nameText.text = this.packageTableItem.name;
        }
        // 物品的图片
        if (this.packageTableItem != null && !string.IsNullOrEmpty(this.packageTableItem.imagePath))
        {
            Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
            if (t != null)
            {
                Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
                Image img = UIIcon != null ? UIIcon.GetComponent<Image>() : null;
                if (img != null)
                    img.sprite = temp;
            }
        }
    }
    
}
