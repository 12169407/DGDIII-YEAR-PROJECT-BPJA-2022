using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
	private LineRenderer lr;
	private Vector3 grapplePoint;
	public LayerMask whatIsGrappleable;
	public Transform gunTip, camera, player;
	private float maxDistance = 200f;
	private SpringJoint joint;
	void Awake()
	{

		lr = GetComponent<LineRenderer>();

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartGrapple();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			StopGrapple();
		}
	}

	void LateUpdate()
	{
		DrawRope();
	}

	void StartGrapple()
	{
		RaycastHit hit;
		if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
		{
			grapplePoint = hit.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;

			//The distance grapple will try to keep from grapple point.
			joint.connectedAnchor = grapplePoint;
			float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
			joint.maxDistance = distanceFromPoint = 0.0f;
			joint.minDistance = 0.24f;

			//these values are subject to modification
			joint.spring = 4.50f;
			joint.damper = 7f;
			joint.massScale = 4.5f;

			lr.positionCount = 2;
		}
	}

	void DrawRope()
	{
		//if not grappling, don't draw the rope
		if (!joint) return;

		lr.SetPosition(0, gunTip.position);
		lr.SetPosition(1, grapplePoint);
	}

	void StopGrapple()
	{
		lr.positionCount = 0;
		Destroy(joint);
	}

	public bool IsGrappling()
    {
		return joint != null;
    }

	public Vector3 GetGrapplePoint()
    {
		return grapplePoint;
    }
}


