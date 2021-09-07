using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    public GameObject buildEffect;
    public GameObject standardTurretPrefab; //Store the turret prefab
    public GameObject BasicTurretPrefab;
    public GameObject LaserBeamer;

    public NodeUI nodeUI;

    private TurretBluePrint turretToBuild; // The turret to build now
    private Node selectedNode;

    void Awake() {
        instance = this;
        //turretToBuilt = standardTurretPrefab;
    }                                                     
       
    public void selectTurretToBuild(TurretBluePrint turret) { //using for modifying  what to build
        turretToBuild = turret;
        selectedNode = null;
        nodeUI.Hide();
    }

    public void selectNode(Node node) {
        if(selectedNode == node) {
            DeSelectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeSelectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public bool CanBuild {  //check for if we can build
        get {
            return turretToBuild != null;
        }
    }

    public bool HasMoney {
        get {
            return PlayerStatus.money >= turretToBuild.cost;
        }
    }

    public void BuildTurretOn(Node node) {
        if(PlayerStatus.money < turretToBuild.cost) {
            Debug.Log("We do not have enough money");
            return;
        }

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.getBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
        PlayerStatus.money -= turretToBuild.cost;
    }
}
