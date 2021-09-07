using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public void SetTarget(Node _target) {
        target = _target;
        transform.position = target.getBuildPosition();
    }
}
