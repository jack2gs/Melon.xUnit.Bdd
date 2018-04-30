using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Melon.xUnit.Bdd.XunitExtensions
{
    public class ObservationExecutor : TestFrameworkExecutor<ObservationTestCase>
    {
        public ObservationExecutor(AssemblyName assemblyName,
                                   ISourceInformationProvider sourceInformationProvider,
                                   IMessageSink diagnosticMessageSink)
            : base(assemblyName, sourceInformationProvider, diagnosticMessageSink) { }

        protected override ITestFrameworkDiscoverer CreateDiscoverer()
        {
            return new ObservationDiscoverer(AssemblyInfo, SourceInformationProvider, DiagnosticMessageSink);
        }

        protected override async void RunTestCases(IEnumerable<ObservationTestCase> testCases,
                                                   IMessageSink executionMessageSink,
                                                   ITestFrameworkExecutionOptions executionOptions)
        {
            string config = null;
#if NET452
            config = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
#endif
            var testAssembly = new TestAssembly(AssemblyInfo, config);

            using (var assemblyRunner = new ObservationAssemblyRunner(testAssembly, testCases, DiagnosticMessageSink, executionMessageSink, executionOptions))
                await assemblyRunner.RunAsync();
        }
    }
}
