using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace iBicha
{
	public class Room
	{

		public event Action<Participant> Joined;
		public event Action<Participant> Left;

		private SocketIOSignalingClient _signalingClient;

		public SocketIOSignalingClient signalingClient { 
			get { 
				return _signalingClient;
			} 
			set {
				if (_signalingClient != null) {
					_signalingClient.Joined -= OnJoined;
					_signalingClient.Left -= OnLeft;
				}
				_signalingClient = value;
				if (_signalingClient != null) {
					_signalingClient.Joined += OnJoined;
					_signalingClient.Left += OnLeft;
				}
			}
		}

		public string RoomID {
			get {
				return uuid;
			}
		}

		private string uuid;

		public Room (string uuid)
		{
			this.uuid = uuid;
		}

		public bool Join ()
		{
			if (signalingClient == null) {
				Debug.LogError ("null signalingClient");
				return false;
			}

			return this.signalingClient.JoinRoom (uuid);
		}

		public bool Leave ()
		{
			if (signalingClient == null) {
				Debug.LogError ("null signalingClient");
				return false;
			}

			return this.signalingClient.LeaveRoom (uuid);
		}

		void OnJoined (string roomId, string userId)
		{
			
		}

		void OnLeft (string roomId, string userId)
		{
			
		}


		public class Participant
		{
			public string ID { get; set; }

			public VideoCapturer.CaptureSource VideoSource { get; set; }

			public bool IsAudioEnabled { get; set; }

			private PeerConnectionClient peerConnectionClient;
		}
	}

}