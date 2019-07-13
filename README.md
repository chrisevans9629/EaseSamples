# What is this project?
These provide samples for how to use the [Ease library](https://github.com/EaseLibrary/Ease)


Additionally, you can find the examples in this project [here](https://github.com/chrisevans9629/EaseSamples/blob/master/EaseSamples/MathExamples.cs)

## Examples

  
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
