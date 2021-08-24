using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    public GameObject standardTurretPrefab; //Store the turret prefab
    public GameObject BasicTurretPrefab;

    private GameObject turretToBuild; // The turret to build now

    void Awake() {
        instance = this;
        //turretToBuilt = standardTurretPrefab;
    }                                                     
       
    public void setTurretToBuild(GameObject turret) { //using for modifying  what to build
        turretToBuild = turret;     
    }

    public GameObject GetTurretToBuild() { //using for getting what to build
        return turretToBuild;
    }
}
