using UnityEngine;

public class IKJointTester : MonoBehaviour {
	public IKJoint joint;

	private int direction = 1;

	public void Update() {
		if (!joint.ChangePosition(Time.deltaTime * direction)) direction *= -1;
	}
}
