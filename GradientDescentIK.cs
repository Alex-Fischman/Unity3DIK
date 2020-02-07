using UnityEngine;

public class GradientDescentIK : MonoBehaviour {
	public Transform[] targets;
	public Transform[] ends;
	public float[] positionWeights;
	public float[] rotationWeights;
	public float epsilon;
	public float accuracy;
	public float speed;
	public IKJoint[] joints;

	public virtual void FixedUpdate() {
		foreach (IKJoint joint in joints) {
			if (GetDistance() < accuracy) break;
			joint.ChangePosition(
				Time.fixedDeltaTime * speed * -PartialGradient(joint)
			);
		}
	}

	protected float PartialGradient(IKJoint joint) {
		joint.ChangePosition(-epsilon);
		float fx = GetDistance();
		joint.ChangePosition(epsilon * 2);
		float fxe = GetDistance();
		joint.ChangePosition(-epsilon);
		return (fxe - fx) / (epsilon * 2);
	}

	protected float GetDistance() {
		float total = 0;
		for (int i = 0; i < targets.Length; ++i) {
			total += 
				Vector3.Distance(
					targets[i].position, 
					ends[i].position
				) * positionWeights[i] + 
				Quaternion.Angle(
					targets[i].rotation, 
					ends[i].rotation
				) * rotationWeights[i];
		}
		return total;
	}
}
