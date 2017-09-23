﻿/* 
MIT License

Copyright (c) 2017 Lewis Johnson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.ScreenSpace.PercentageBased.Scripts {

    [RequireComponent(typeof(RectTransform))]
    [ExecuteInEditMode]
    [AddComponentMenu("Scripts/CSS/Scaled UI Component")]
    public class ScaledComponent : MonoBehaviour {

        public Position ComponentPosition;
        public Scale ComponentScale;
        public RectTransform Container;

#if UNITY_EDITOR
        public GameObject DebugText;
#endif
        public void Start() {
            this.RefreshUI();
        }

        public void Update() {
            this.RefreshUI();
        }

        private string PrettyPrint() {
            return string.Format(
                "Top: {0}%\nLeft: {1}%\nWidth: {2}%\nHeight: {3}%",
                this.ComponentPosition.Top,
                this.ComponentPosition.Left,
                this.ComponentScale.Width,
                this.ComponentScale.Height);
        }

        private void RefreshUI() {
            var width = this.ComponentScale.Width / 100 * this.Container.GetComponent<Container>().Width;
            var height = this.ComponentScale.Height / 100 * this.Container.GetComponent<Container>().Height;

            var top = this.ComponentPosition.Top / 100 * this.Container.GetComponent<Container>().Height;
            var left = this.ComponentPosition.Left / 100 * this.Container.GetComponent<Container>().Width;

            this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(left, top, 0);

#if UNITY_EDITOR
            this.DebugText.GetComponent<Text>().text = this.PrettyPrint();
#endif
        }

    }

    [Serializable]
    public class Position {

        public float Left;
        public float Top;

    }

    [Serializable]
    public class Scale {

        public float Height;
        public float Width;

    }

}