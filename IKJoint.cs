using UnityEngine;

public abstract class IKJoint : MonoBehaviour {
	public float position { get; protected set; }

	public float speed;
	public bool bounded;
	public float min;
	public float max;

	public abstract bool ChangePosition(float delta);
}
