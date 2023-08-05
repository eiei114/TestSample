using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TestView : MonoBehaviour
{
    #region これまで

    [SerializeField] private Button oldTestButton;

    public IObservable<Unit> OldTestObservable => oldTestButton.OnClickAsObservable();

    #endregion
    
    #region 新しい考え

    [SerializeField] private Button testButton;

    private readonly Subject<TestEnum> _testSubject = new();
    public IObservable<TestEnum> TestEnumObservable => _testSubject;

    #endregion

    private void Start()
    {
        testButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                // ここでボタンの通知を公開
                _testSubject.OnNext(TestEnum.First);
                
                //view内部での処理を個々に書き込みたい
                //通知を公開するタイミングを選べるのがよいと思っています
                
            }).AddTo(this);
    }
}

public enum TestEnum{
    First,
    Second,
    Third,
}
