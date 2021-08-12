using UnityEngine;

public class Shop : MonoBehaviour {

    BuiltManager builtManager;

    void Start() {
        builtManager = BuiltManager.instance;
    }

    public void PurchaseStandardTurret() {
        Debug.Log("Standard Turret Purchased");
        BuiltManager.instance.setTurretToBuilt(builtManager.standardTurretPrefab);
    }

    public void PurchaseBasicTurret() {
        Debug.Log("Basic Turret Purchased");
        BuiltManager.instance.setTurretToBuilt(builtManager.BasicTurretPrefab);
    }
}
