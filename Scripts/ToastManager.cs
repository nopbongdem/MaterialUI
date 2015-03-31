//  Copyright 2014 Invex Games http://invexgames.com
//	Licensed under the Apache License, Version 2.0 (the "License");
//	you may not use this file except in compliance with the License.
//	You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//	Unless required by applicable law or agreed to in writing, software
//	distributed under the License is distributed on an "AS IS" BASIS,
//	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//	See the License for the specific language governing permissions and
//	limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MaterialUI
{
	[ExecuteInEditMode]
	public class ToastManager : MonoBehaviour
	{
		private static ToastManager _instance;

		public static ToastManager instance
		{
			get
			{
				if (_instance == null)
				{
					GameObject go = new GameObject();
					_instance = go.AddComponent<ToastManager>();
					go.name = "ToastManager";
				}

				return _instance;
			}
		}

		static GameObject theToast;
		public static string toastText;
		public static float toastDuration;
		public static Color toastPanelColor;
		public static Color toastTextColor;
		public static int toastFontSize;
		public static Canvas parentCanvas;

		void Awake()
		{
			_instance = this;

			if (!theToast)
				InitToastSystem(GetComponentInParent<Canvas>());
		}

		void OnCreate()
		{
			if (GetComponentInParent<Canvas>())
				InitToastSystem(GetComponentInParent<Canvas>());
			else
				Debug.LogWarning("Please put ToastManager under a canvas!");
		}

		public static void InitToastSystem(Canvas theCanvas)
		{
			theToast = Resources.Load("Toast", typeof(GameObject)) as GameObject;
			parentCanvas = theCanvas;
		}

		public void InstanceShow(string content)
		{
			Show(content);
		}

		public static void Show(string content)
		{
			toastText = content;
			toastDuration = 2f;
			toastPanelColor = Color.white;
			toastTextColor = Color.black;
			toastFontSize = 16;
			Instantiate(theToast);
		}

		public static void Show(string content, float duration)
		{
			toastText = content;
			toastDuration = duration;
			toastPanelColor = Color.white;
			toastTextColor = Color.black;
			toastFontSize = 16;
			Instantiate(theToast);
		}

		public static void Show(string content, float duration, Color panelColor, Color textColor, int fontSize)
		{
			toastText = content;
			toastDuration = duration;
			toastPanelColor = panelColor;
			toastTextColor = textColor;
			toastFontSize = fontSize;
			Instantiate(theToast);
		}
	}
}