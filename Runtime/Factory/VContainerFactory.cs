﻿#if VCONTAINER

using UnityEngine.Scripting;
using VContainer;

namespace Dre0Dru.Factory
{
    public class VContainerFactory : IIocFactory
    {
        private readonly IObjectResolver _resolver;

        [RequiredMember]
        public VContainerFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public TResult Create<TResult, T>(T param)
        {
            var registration = CreateRegistration<TResult>();

            registration
                .WithParameter(param);

            return Resolve<TResult>(registration);
        }

        public TResult Create<TResult, T1, T2>(T1 param1, T2 param2)
        {
            var registration = CreateRegistration<TResult>();

            registration
                .WithParameter(param1)
                .WithParameter(param2);

            return Resolve<TResult>(registration);
        }

        public TResult Create<TResult, T1, T2, T3>(T1 param1, T2 param2, T3 param3)
        {
            var registration = CreateRegistration<TResult>();

            registration
                .WithParameter(param1)
                .WithParameter(param2)
                .WithParameter(param3);

            return Resolve<TResult>(registration);
        }

        public TResult Create<TResult>(params object[] parameters)
        {
            var registration = CreateRegistration<TResult>();

            foreach (var parameter in parameters)
            {
                registration.WithParameter(parameter.GetType(), parameter);
            }

            return Resolve<TResult>(registration);
        }

        public TResult Inject<TResult>(TResult injected)
        {
            _resolver.Inject(injected);

            return injected;
        }

        private TResult Resolve<TResult>(RegistrationBuilder registration)
        {
            return (TResult)_resolver.Resolve(registration.Build());
        }

        private static RegistrationBuilder CreateRegistration<TResult>()
        {
            var registration = new RegistrationBuilder(typeof(TResult), Lifetime.Transient);
            return registration;
        }
    }
}

#endif
