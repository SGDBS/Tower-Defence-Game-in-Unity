using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    //using for set what to build
    void Start() {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret() {
        Debug.Log("Standard Turret Purchased");
        BuildManager.instance.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseBasicTurret() {
        Debug.Log("Basic Turret Purchased");
        BuildManager.instance.setTurretToBuild(buildManager.BasicTurretPrefab);
    }
}
