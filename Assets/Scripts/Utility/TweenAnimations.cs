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
            Vector3 originalScale = window.transform.localScale;
            window.transform.DOScale(new Vector3(0, originalScale.y, originalScale.z), duration).OnComplete(() => Object.Destroy(window));
        }
    }
}
