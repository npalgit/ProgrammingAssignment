using Ninject;
using ProgrammingAssignmentCore;
using ProgrammingAssignmentEngine;

namespace ProgrammingAssignment
{
    public class MainModule
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load<CoreModule>();
            kernel.Load<EngineModule>();
        }
    }
}
