using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpgradeMechanics : MonoBehaviour
{
    public Transform upgradePanel;

    public UnityEngine.UI.Image towerImg;

    public Transform levelText;
    public Transform catnameText;

    public Transform buyButton;
    public Transform moneyText;

    public GameObject updateTarget = null;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach (RaycastHit2D target in hit)
            {
                if (!target.collider.gameObject.CompareTag("Tower") && target.collider.gameObject.CompareTag("upgradePannel") && upgradePanel.gameObject.active == true)
                {
                    PannelToggle();
                    
                }
            }
        }
    }

    public void UpdatePanelEnable(GameObject tower)
    {
        updateTarget = tower;
        var towerMechanics = updateTarget.GetComponent<CatStationMechanics>();

        PannelToggle();

        towerImg.sprite = updateTarget.GetComponent<SpriteRenderer>().sprite;
        levelText.GetComponent<TextMeshProUGUI>().text = towerMechanics.level.ToString();
        catnameText.GetComponent<TextMeshProUGUI>().text = towerMechanics.catParent.name.ToString();

        var offset = new Vector3 (10, -10, 0);
        if(updateTarget.transform.position.y < 0)
        {
            offset = new Vector3(10, 10, 0);
        }
        Vector3 screenCoord = Camera.main.WorldToScreenPoint(updateTarget.transform.position + offset);
        upgradePanel.transform.position = screenCoord;

        if (towerMechanics.level > 2)
        {
            buyButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            buyButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            buyButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
            buyButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(UpgradeCurrent);


        }

    }

    public void UpdateButton()
    {
        if (updateTarget == null) return;
        var towerMechanics = updateTarget.GetComponent<CatStationMechanics>();

        levelText.GetComponent<TextMeshProUGUI>().text = towerMechanics.level.ToString();
        if (towerMechanics.level > 2)
        {
            buyButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }

    public void UpgradeCurrent()
    {
        if (updateTarget == null) return;

        updateTarget.GetComponent<CatStationMechanics>().LevelUp();

    }

    public void PannelToggle()
    {
        upgradePanel.gameObject.active = !upgradePanel.gameObject.active;
    }


}
