using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

    //public GameObject ball;
	public Transform target;
    Vector3 vetocity = Vector3.zero;

	public float h = 25;
	public float gravity = -18;

	public bool debugPath;

	void Start() {
		//ball.useGravity = false;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Launch ();
		}

		if (debugPath) {
			DrawPath ();
		}
        print("hello");
	}

	void Launch() {
		Physics.gravity = Vector3.up * gravity;
		//ball.useGravity = true;
        vetocity = CalculateLaunchData ().initialVelocity;
	}

	LaunchData CalculateLaunchData() {
        float displacementY = target.position.y - vetocity.y;
        Vector3 displacementXZ = new Vector3 (target.position.x - vetocity.x, 0, target.position.z - vetocity.z);
		float time = Mathf.Sqrt(-2*h/gravity) + Mathf.Sqrt(2*(displacementY - h)/gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath() {
		LaunchData launchData = CalculateLaunchData ();
        Vector3 previousDrawPoint = vetocity;

		int resolution = 30;
		for (int i = 1; i <= resolution; i++) {
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up *gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = vetocity + displacement;
			Debug.DrawLine (previousDrawPoint, drawPoint, Color.green);
			previousDrawPoint = drawPoint;
		}
	}

	struct LaunchData {
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData (Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}
		
	}
}
	