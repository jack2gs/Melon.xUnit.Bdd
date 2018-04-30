using System;
using Xunit;
using Melon.xUnit.Bdd;
using Melon.xUnit.Bdd.XunitExtensions;


namespace Melon.xUnit.Bdd.Example.UnitTest
{
    public class Given_a_new_calculator: SpecificationBase<Calulator>
    {
        protected override void EstablishContext() 
        {
            _underTest = new Calulator();
        }

        public class When_add_tow_ingegers: Given_a_new_calculator
        {
            private int _actural = 0;
			protected override void Because()
			{
                base.Because();
                _actural = _underTest.Add(1, 1);
			}

            [Observation]
            public void Then_the_result_should_be_2(){
                Assert.Equal(2, _actural);
            }
		}
    }
}
