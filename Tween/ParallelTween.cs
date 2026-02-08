// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using Cysharp.Threading.Tasks;
//
// namespace NgoUyenNguyen
// {
//     [Serializable]
//     public class ParallelTween : Tween
//     {
//         private List<int> activeTweenIds = new();
//         private CancellationTokenSource cts;
//
//         public override bool Play(CancellationToken externalToken)
//         {
//             if (target == null || currentState != State.Idle) return false;
//
//             cts?.Cancel();
//             cts?.Dispose();
//             cts = new CancellationTokenSource();
//
//             var linkedSource = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, externalToken);
//     
//             PlayAsync(linkedSource).Forget();
//
//             return true;
//         }
//
//         private async UniTask PlayAsync(CancellationTokenSource linkedSource)
//         {
//             var token = linkedSource.Token;
//             try
//             {
//                 activeTweenIds.Clear();
//                 onAwake?.Invoke();
//                 await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: token);
//
//                 currentState = State.Playing;
//                 onStart?.Invoke();
//
//                 foreach (var config in configs.Where(c => c != null))
//                 {
//                     var id = config.Play(target);
//                     if (id != null) activeTweenIds.Add(id.Value);
//                 }
//
//                 var isAnyRunning = true;
//                 while (isAnyRunning)
//                 {
//                     await UniTask.Yield(PlayerLoopTiming.Update, token);
//                     isAnyRunning = activeTweenIds.Any(id => LeanTween.descr(id) != null);
//                 }
//
//                 onComplete?.Invoke();
//             }
//             catch (OperationCanceledException)
//             {
//                 foreach (var id in activeTweenIds)
//                 {
//                     LeanTween.cancel(id);
//                 }
//             
//                 onCancel?.Invoke();
//             }
//             finally
//             {
//                 activeTweenIds.Clear();
//                 currentState = State.Idle;
//             
//                 linkedSource.Dispose();
//             }
//         }
//
//         public override bool Pause()
//         {
//             if (target == null || currentState != State.Playing) return false;
//
//             foreach (var id in activeTweenIds)
//             {
//                 LeanTween.pause(id);
//             }
//             
//             currentState = State.Paused;
//             onPause?.Invoke();
//
//             return true;
//         }
//
//         public override bool Resume()
//         {
//             if (target == null || currentState != State.Paused) return false;
//
//             foreach (var id in activeTweenIds)
//             {
//                 LeanTween.resume(id);
//             }
//
//             currentState = State.Playing;
//             onResume?.Invoke();
//
//             return true;
//         }
//
//         public override bool Cancel()
//         {
//             if (target == null
//                 || cts == null 
//                 || currentState == State.Idle) return false;
//
//             cts.Cancel();
//
//             return true;
//         }
//     }
// }