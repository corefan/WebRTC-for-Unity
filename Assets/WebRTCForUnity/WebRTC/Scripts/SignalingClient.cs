using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iBicha
{
	public abstract class SignalingClient {

		public delegate void OnJoinedDelegate (string roomId, string userId);
		public event OnJoinedDelegate Joined;

		public abstract bool JoinRoom (string roomId, string userId = null);

		public abstract bool LeaveRoom (string roomId);

		public abstract bool SendMessage (string message);

		public abstract bool SendOfferSDP (SessionDescription sdp);

		public abstract bool SendAnswerSDP (SessionDescription sdp);

		public abstract bool SendLocalIceCandidate (Object candidate);

		public abstract bool SendLocalIceCandidateRemovals (Object[] candidates);

	}
}
