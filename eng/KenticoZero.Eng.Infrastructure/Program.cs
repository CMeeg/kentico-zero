using System.Threading.Tasks;
using Pulumi;

namespace KenticoZero.Eng.Infrastructure
{
    class Program
    {
        static Task<int> Main() => Deployment.RunAsync<ProjectStack>();
    }
}
