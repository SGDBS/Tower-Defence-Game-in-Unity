using UnityEngine;

public class BuiltManager : MonoBehaviour {
    public static BuiltManager instance;
    public GameObject standardTurretPrefab;
    public GameObject BasicTurretPrefab;

    private GameObject turretToBuilt;

    void Awake() {
        instance = this;
        //turretToBuilt = standardTurretPrefab;
    }
                                                      
    void start() {
        //turretToBuilt = standardTurretPrefab;
    }
       
    public void setTurretToBuilt(GameObject turret) {
        turretToBuilt = turret;
    }

    public GameObject GetTurretToBuild() {
        return turretToBuilt;
    }

    public GameObject GetTurretToBuilt() {
        Debug.Log("We have built a turret!!!" + turretToBuilt.name);
        return turretToBuilt;
    }
}
