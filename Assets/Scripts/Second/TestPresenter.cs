using System;
using UniRx;
using UnityEngine;

namespace Second
{
    public class TestPresenter :IDisposable
    {
        private readonly CompositeDisposable _disposable = new();

        public TestPresenter(TestView _view, TestModel _model)
        {
            _view.TestEnumObservable
                .Where(type => type == TestEnum.First)
                .Subscribe(type => { Debug.Log($"ボタンが押された！ / {type}"); }).AddTo(_disposable);

            _view.OldTestObservable
                .Subscribe(_ => { Debug.Log($"これまでのボタンが押された！ / {TestConstants.TEST_FIRST}"); }).AddTo(_disposable);

        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}