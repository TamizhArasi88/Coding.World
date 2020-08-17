using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDynamics
{
    public class Program
    {
        static readonly TypeDynamic _C = new TypeDynamic();

        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Program>();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }

        class TypeDynamic
        {
            public MemberTypes M { get; set; }
        }
        #region BenchMark
        [Benchmark(Baseline = true)]
        public static void DirectCalculation()
        {
            _C.M = MemberTypes.Event | MemberTypes.Method;
            var b = (_C.M & MemberTypes.Method) == MemberTypes.Method;
            if (b == false)
            {
                throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public static void MatchWithConvert()
        {
            _C.M = MemberTypes.Event | MemberTypes.Method;
            var b = CExtensions.MatchFlags(_C.M, MemberTypes.Method);
            if (b == false)
            {
                throw new InvalidOperationException();
            }
        }

        [Benchmark]
        public void MatchWithHasFlag()
        {
            _C.M = MemberTypes.Event | MemberTypes.Method;
            var b = _C.M.HasFlag(MemberTypes.Method);
            if (b == false)
            {
                throw new InvalidOperationException();
            }
        }
        #endregion
    }
}
