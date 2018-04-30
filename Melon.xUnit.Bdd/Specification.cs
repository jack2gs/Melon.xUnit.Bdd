using System;
namespace Melon.xUnit.Bdd
{
    public abstract class SpecificationBase<TComponent>
        where TComponent:class
    {
        protected TComponent _underTest;

        protected virtual void Because() { }

        protected virtual void DestroyContext() { }

        protected virtual void EstablishContext() { }

        internal void OnFinish()
        {
            DestroyContext();
        }

        internal void OnStart()
        {
            EstablishContext();
            Because();
        }
    }
}
