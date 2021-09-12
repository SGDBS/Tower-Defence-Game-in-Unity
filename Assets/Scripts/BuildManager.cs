using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    public GameObject buildEffect;
    public GameObject upgradeEffect;

    public NodeUI nodeUI;

    private TurretBluePrint turretToBuild; // The turret to build now
    private Node selectedNode;

    void Awake() {
        instance = this;
        //turretToBuilt = standardTurretPrefab;
    }                                                     
    
    public TurretBluePrint getTurretToBuild() {
          return turretToBuild;
    }

    public void selectTurretToBuild(TurretBluePrint turret) { //using for modifying  what to build
        turretToBuild = turret;
        selectedNode = null; //When selecting a turret,we need deselect the node
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
}
