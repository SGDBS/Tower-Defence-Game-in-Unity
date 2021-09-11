using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upCost;
    public Text sellValue;
    private Node target;

    public void SetTarget(Node _target) {
        target = _target;
        transform.position = target.getBuildPosition();
        if(target.turret != null) {
            if (target.isUpgraded)
                upCost.text = "Upgraded";
            else 
                upCost.text = "upgrade" + "\n" + "$" + target.turretBluePrint.upgradeCost.ToString();
            sellValue.text = "sell" + "\n" + "$" + target.getSellValue().ToString();
        }
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        if(target.isUpgraded)
            return;
        target.UpGrade();
        BuildManager.instance.DeSelectNode();
    }

    public void Sell() {
        target.Sell();
        BuildManager.instance.DeSelectNode();
    }
}
