using Moq;
using NUnit.Framework;

namespace Tests
{
    public interface IMathService
    {
        int Add(int x, int y);
    }

    public class ViewModel
    {
        private readonly IMathService _mathService;

        public ViewModel(IMathService mathService)
        {
            _mathService = mathService;
        }

        public int Add10(int x)
        {
            return _mathService.Add(x, 10);
        }
    }
    public class Tests : Ease.NUnit.Unity.UnityContainerTestBase
    {
        [Test]
        public void ViewModel_Add10_Should_AddOnMathService()
        {
            RegisterMockType<IMathService>(() => p=> {});
            var vm = ResolveType<ViewModel>();

            vm.Add10(20);
            ValidateMock<IMathService>(p=>p.Verify(r=>r.Add(It.IsAny<int>(), 10)));
        }

        [Test]
        public void ViewModel_Add10_Should_Return30()
        {
            RegisterMockType<IMathService>(() => p=> p.Setup(r=>r.Add(It.IsAny<int>(),It.IsAny<int>())).Returns(30));
            var vm = ResolveType<ViewModel>();

            var result = vm.Add10(20);

            Assert.AreEqual(30, result);
        }
    }
}