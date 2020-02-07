using UnityEngine;

public class MultiGradientDescentIK : GradientDescentIK {
	public float multiplier;
	public int iterations;

	public override void FixedUpdate() {
		for (int i = 0; i < iterations; ++i) {
			float scale = Mathf.Pow(multiplier, i);
			foreach (IKJoint joint in joints) {
				if (GetDistance() < accuracy * scale) break;
				joint.ChangePosition(
					Time.fixedDeltaTime * speed * scale * 
					-PartialGradient(joint)
				);
			}
		}
	}
}
