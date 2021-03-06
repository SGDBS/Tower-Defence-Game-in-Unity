using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    [Header("System Initialization")]
    public Color hoverColor;
    public Renderer rend;
    public Color startColor;
    public Color notEnoughColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;   //the turret we have built
    public TurretBluePrint turretBluePrint;
    BuildManager buildManager;
    public bool isUpgraded = false;

    private int turretValue; //using for selling

    void Start() {
        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition() {
        return transform.position + positionOffset;
    }

    void OnMouseEnter() {
        if (!buildManager.CanBuild) {
            return;
        }
        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    void OnMouseDown() {      

        if(this.turret != null) {   // there is no turret in this node
            buildManager.selectNode(this);
            return;
        }

        if (!buildManager.CanBuild) {  // check if we select a turret to build
            return;
        }

        BuildTurret(buildManager.getTurretToBuild());
    }

    void BuildTurret(TurretBluePrint turretToBuild) {
        if (PlayerStatus.money < turretToBuild.cost) {
            Debug.Log("We do not have enough money");
            return;
        }

        GameObject _turret = (GameObject)Instantiate(turretToBuild.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBluePrint = turretToBuild;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
        PlayerStatus.money -= turretToBuild.cost;
        turretValue = turretToBuild.cost;
    }

    public void UpGrade() {
        if (isUpgraded)
            return;
        if (PlayerStatus.money < turretBluePrint.upgradeCost) {
            Debug.Log("We do not have enough money");
            return;
        }
        Destroy(turret);
        isUpgraded = true;
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradePrefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildManager.upgradeEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 2.5f);
        PlayerStatus.money -= turretBluePrint.upgradeCost;
        turretValue += turretBluePrint.upgradeCost;
    }


    public void Sell() {
        Destroy(turret);
        PlayerStatus.money += turretValue / 2;
        turret = null;
        turretBluePrint = null;
    }

    public int getSellValue() {
        return turretValue / 2;
    }
}
