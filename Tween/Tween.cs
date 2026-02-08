using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace NgoUyenNguyen
{
    [Serializable]
    public class Tween
    {
        public string name = string.Empty;
        public GameObject target;
        public Type type;
        [Min(0)] public float delay;
        
        [SerializeReference, SubclassSelector]
        public List<TweenConfig> configs = new();
        
        public UnityEvent onAwake;
        public UnityEvent onStart;
        public UnityEvent onComplete;
        public UnityEvent onCancel;
        public UnityEvent onPause;
        public UnityEvent onResume;
        
        protected State currentState = State.Idle;
        
        private List<int> activeTweenIds = new();
        private CancellationTokenSource cts;
        
        public State CurrentState => currentState;
        
        public bool Play(CancellationToken externalToken)
        {
            if (target == null || currentState != State.Idle) return false;

            cts?.Cancel();
            cts?.Dispose();
            cts = new CancellationTokenSource();

            var linkedSource = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, externalToken);
    
            PlayAsync(linkedSource).Forget();

            return true;
        }

        private async UniTask PlayAsync(CancellationTokenSource linkedSource)
        {
            var token = linkedSource.Token;
            try
            {
                activeTweenIds.Clear();
                onAwake?.Invoke();
                await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: token);

                currentState = State.Playing;
                onStart?.Invoke();

                switch (type)
                {
                    case Type.Sequence: await PlaySequence(token); break;
                    case Type.Parallel: await PlayParallel(token); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                currentState = State.Idle;
                onComplete?.Invoke();
            }
            catch (OperationCanceledException)
            {
                foreach (var id in activeTweenIds)
                {
                    LeanTween.cancel(id);
                }
            
                onCancel?.Invoke();
            }
            finally
            {
                activeTweenIds.Clear();
                currentState = State.Idle;
            
                linkedSource.Dispose();
            }
        }

        private async UniTask PlayParallel(CancellationToken token)
        {
            foreach (var config in configs.Where(c => c != null))
            {
                var id = config.Play(target);
                if (id != null) activeTweenIds.Add(id.Value);
            }

            var isAnyRunning = true;
            while (isAnyRunning)
            {
                await UniTask.Yield(PlayerLoopTiming.Update, token);
                isAnyRunning = activeTweenIds.Any(id => LeanTween.descr(id) != null);
            }
        }

        private async UniTask PlaySequence(CancellationToken token)
        {
            foreach (var config in configs.Where(c => c != null))
            {
                var id = config.Play(target);
                if (id == null) continue;

                activeTweenIds.Clear();
                activeTweenIds.Add(id.Value);

                while (LeanTween.descr(id.Value) != null)
                    await UniTask.Yield(PlayerLoopTiming.LastUpdate, token);
            }
        }

        public bool Pause()
        {
            if (target == null || currentState != State.Playing) return false;

            foreach (var id in activeTweenIds)
            {
                LeanTween.pause(id);
            }
            
            currentState = State.Paused;
            onPause?.Invoke();

            return true;
        }

        public bool Resume()
        {
            if (target == null || currentState != State.Paused) return false;

            foreach (var id in activeTweenIds)
            {
                LeanTween.resume(id);
            }

            currentState = State.Playing;
            onResume?.Invoke();

            return true;
        }

        public bool Cancel()
        {
            if (target == null
                || cts == null 
                || currentState == State.Idle) return false;

            cts.Cancel();

            return true;
        }

        public enum State
        {
            Idle,
            Playing,
            Paused
        }

        public enum Type
        {
            Sequence,
            Parallel
        }
    }
}