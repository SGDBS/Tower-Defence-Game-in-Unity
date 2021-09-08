using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target) {
        target = _target;
        transform.position = target.getBuildPosition();
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpGrade();
        BuildManager.instance.DeSelectNode();
    }
}
