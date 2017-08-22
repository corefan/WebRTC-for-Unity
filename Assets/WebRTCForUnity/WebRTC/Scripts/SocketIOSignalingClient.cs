using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System;

namespace iBicha
{
	public class SocketIOSignalingClient {

		public delegate void OnJoinedDelegate (string roomId, string userId);
		public event OnJoinedDelegate Joined;

		public delegate void OnLeftDelegate (string roomId, string userId);
		public event OnLeftDelegate Left;

		public string ServerUri;

		private Socket socket;

		public SocketIOSignalingClient(string ServerUri) {
			this.ServerUri = ServerUri;

			socket = Socket.Connect(ServerUri);
 		}

		public bool IsConnected {
			get {
				return socket != null && socket.IsConnected;
			}
		}

		public bool JoinRoom (string roomId, string userId = null)
		{
			return EmitMessage ("JoinRoom", roomId, OnJoinRoomResponse);
		}

		public bool LeaveRoom (string roomId)
		{
			return EmitMessage ("JoinRoom", roomId, OnLeaveRoomResponse);
		}

		public bool EmitMessage (string eventName, object data, Action<string> ack)
		{
			if (!IsConnected)
				return false;

			socket.Emit (eventName, Serialize(data), ack);
			return true;
		}

		public bool SendOfferSDP (SessionDescription sdp)
		{
			if (!IsConnected)
				return false;
			
			throw new System.NotImplementedException ();
		}

		public bool SendAnswerSDP (SessionDescription sdp)
		{
			if (!IsConnected)
				return false;
			
			throw new System.NotImplementedException ();
		}

		public bool SendLocalIceCandidate (System.Object candidate)
		{
			if (!IsConnected)
				return false;
			
			throw new System.NotImplementedException ();
		}

		public bool SendLocalIceCandidateRemovals (System.Object[] candidates)
		{
			if (!IsConnected)
				return false;
			
			throw new System.NotImplementedException ();
		}


		public void OnJoinRoomResponse(string data) {
			if (data == "success") {
				if (Joined != null) {
					Joined ("roomId", "userId");
				}
			}
		}

		public void OnLeaveRoomResponse(string data) {
			if (data == "success") {
				if (Left != null) {
					Left ("roomId", "userId");
				}
			}
		}

		public string Serialize(System.Object obj) {
			return JsonUtility.ToJson (obj);
		}

		public T Deserialize<T>(string str) {
			return JsonUtility.FromJson <T>(str);
		}
	}
}
