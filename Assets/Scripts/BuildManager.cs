using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    public GameObject standardTurretPrefab; //Store the turret prefab
    public GameObject BasicTurretPrefab;

    private TurretBluePrint turretToBuild; // The turret to build now

    void Awake() {
        instance = this;
        //turretToBuilt = standardTurretPrefab;
    }                                                     
       
    public void selectTurretToBuild(TurretBluePrint turret) { //using for modifying  what to build
        turretToBuild = turret;     
    }

    public bool CanBuild {  //check for if we can build
        get {
            return turretToBuild != null;
        }
    }

    public void BuildTurretOn(Node node) {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
