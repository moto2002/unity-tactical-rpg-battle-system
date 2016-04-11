/*
The MIT License (MIT)

Copyright (c) 2016 Jonathan Parham

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using System;
using System.Collections;

public static class TransformAnimationExtensions
{
	public static Tweener MoveTo (this Transform t, Vector3 position)
	{
		return MoveTo (t, position, Tweener.DefaultDuration);
	}

	public static Tweener MoveTo (this Transform t, Vector3 position, float duration)
	{
		return MoveTo (t, position, duration, Tweener.DefaultEquation);
	}

	public static Tweener MoveTo (this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
	{
		TransformPositionTweener tweener = t.gameObject.AddComponent<TransformPositionTweener> ();
		tweener.startValue = t.position;
		tweener.endValue = position;
		tweener.easingControl.duration = duration;
		tweener.easingControl.equation = equation;
		tweener.easingControl.Play ();
		return tweener;
	}

	public static Tweener MoveToLocal (this Transform t, Vector3 position)
	{
		return MoveToLocal (t, position, Tweener.DefaultDuration);
	}

	public static Tweener MoveToLocal (this Transform t, Vector3 position, float duration)
	{
		return MoveToLocal (t, position, duration, Tweener.DefaultEquation);
	}

	public static Tweener MoveToLocal (this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
	{
		TransformLocalPositionTweener tweener = t.gameObject.AddComponent<TransformLocalPositionTweener> ();
		tweener.startValue = t.localPosition;
		tweener.endValue = position;
		tweener.easingControl.duration = duration;
		tweener.easingControl.equation = equation;
		tweener.easingControl.Play ();
		return tweener;
	}

	public static Tweener RotateToLocal (this Transform t, Vector3 euler, float duration, Func<float, float, float, float> equation)
	{
		TransformLocalEulerTweener tweener = t.gameObject.AddComponent<TransformLocalEulerTweener> ();
		tweener.startValue = t.localEulerAngles;
		tweener.endValue = euler;
		tweener.easingControl.duration = duration;
		tweener.easingControl.equation = equation;
		tweener.easingControl.Play ();
		return tweener;
	}

	public static Tweener ScaleTo (this Transform t, Vector3 scale)
	{
		return MoveTo (t, scale, Tweener.DefaultDuration);
	}

	public static Tweener ScaleTo (this Transform t, Vector3 scale, float duration)
	{
		return MoveTo (t, scale, duration, Tweener.DefaultEquation);
	}

	public static Tweener ScaleTo (this Transform t, Vector3 scale, float duration, Func<float, float, float, float> equation)
	{
		TransformScaleTweener tweener = t.gameObject.AddComponent<TransformScaleTweener> ();
		tweener.startValue = t.localScale;
		tweener.endValue = scale;
		tweener.easingControl.duration = duration;
		tweener.easingControl.equation = equation;
		tweener.easingControl.Play ();
		return tweener;
	}
}
