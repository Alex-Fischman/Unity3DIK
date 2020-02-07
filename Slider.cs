using UnityEngine;

public class Slider : IKJoint {
	public Vector3 direction;

	public override bool ChangePosition(float delta) {
		Vector3    oldPosition = transform.position;
		Quaternion oldRotation = transform.rotation;
		transform.Translate(direction.normalized * delta * speed);
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
