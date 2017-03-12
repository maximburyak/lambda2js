using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lambda2Js.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lambda2Js.Tests
{
    [TestClass]
    public class NumericConversionTests
    {
        [TestMethod]
        public void ParseTo_int32()
        {
            Expression<Func<MyClass, object>> expr =
                 x => x.Phones.Where(y=>y.DDD == 4).Select(z=>z.DDD);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new NumericConversions()));
            Assert.AreEqual(@"x.Name.length", js);
        }
        
    }
}
