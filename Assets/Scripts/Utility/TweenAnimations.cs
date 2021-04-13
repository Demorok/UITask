using UnityEngine;
using DG.Tweening;

namespace Animations
{
    public static class TweenAnimations
    {
        const float DEFAULTDURATION = 0.5f;

        public static void MoveObject(this GameObject gameObject, Vector3 target, float duration = DEFAULTDURATION)
        {
            gameObject.transform.DOMove(target, duration);
        }

        public static void Destroy_Window_X(this GameObject window, float duration = DEFAULTDURATION)
        {
            window.transform.DOScaleX(0, duration).OnComplete(() => Object.Destroy(window));
        }

        public static void Destroy_Window_X(this GameObject window, TweenCallback callback, float duration = DEFAULTDURATION)
        {
            window.transform.DOScaleX(0, duration).OnComplete(() => Object.Destroy(window)).OnComplete(callback);
        }

        public static void Open_Window_X(this GameObject window, float duration = DEFAULTDURATION)
        {
            window.transform.DOScaleX(window.transform.localScale.x, duration).From(0);
        }

        public static void Open_Window_X(this GameObject window, TweenCallback callback, float duration = DEFAULTDURATION)
        {
            window.transform.DOScaleX(window.transform.localScale.x, duration).From(0).OnComplete(callback);
        }
    }
}
