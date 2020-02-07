using UnityEngine;

public class Hinge : IKJoint {
	public Vector3 anchor;
	public Vector3 axis;

	public override bool ChangePosition(float delta) {
		Vector3    oldPosition = transform.position;
		Quaternion oldRotation = transform.rotation;
		transform.RotateAround(
			transform.TransformPoint(anchor), 
			transform.TransformDirection(axis.normalized), 
			delta * speed
		);
		position += delta * speed;
		if (bounded && (position > max || position < min)) {
			transform.position = oldPosition;
			transform.rotation = oldRotation;
			position -= delta * speed;
			return false;
		}
		else return true;
	}
}
