using System;
using UniRx;

namespace Second
{
    public class TestModel : IDisposable
    {
        private readonly AsyncSubject<TestModel> _asyncInitializeSubject = new AsyncSubject<TestModel>();
        public IObservable<TestModel> OnAsyncInitializeObservable => _asyncInitializeSubject;

        public TestModel()
        {
            _asyncInitializeSubject.OnNext(this);
            _asyncInitializeSubject.OnCompleted();
        }
        
        public void Dispose()
        {
        }
    }
}