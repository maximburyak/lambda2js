using Lambda2Js.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lambda2Js.Tests
{
    [TestClass]
    public class StringMethodsTests
    {
        [TestMethod]
        public void StringLength()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Length;

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.length", js);
        }

        [TestMethod]
        public void SubstringOneParam()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Substring(1,5);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(1,5)", js);
        }

        [TestMethod]
        public void SubstringTwoParams()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Substring(5);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(5)", js);
        }

        [TestMethod]
        public void ReplaceChars()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Replace("a","b");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.replace(""a"",""b"")", js);
        }

        [TestMethod]
        public void ReplaceStrings()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Replace('a', 'b');

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.replace(""a"",""b"")", js);
        }

        [TestMethod]
        public void IndexOf1()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf('a');

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf2()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf3()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf('a',2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf4()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a", 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf5()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a", StringComparison.CurrentCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf6()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a", 2, StringComparison.InvariantCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf7()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a", 2,2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,2).indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf8()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf('a', 2, 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,2).indexOf(""a"")", js);
        }

        [TestMethod]
        public void IndexOf9()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.IndexOf("a", 2,6, StringComparison.InvariantCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,6).indexOf(""a"")", js);
        }

        [TestMethod]
        public void Contains()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Contains("a");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.includes(""a"")", js);
        }

        [TestMethod]
        public void Trim()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.Trim();

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.trim()", js);
        }

        [TestMethod]
        public void StartsWith1()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.StartsWith("a");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.startsWith(""a"")", js);
        }

        [TestMethod]
        public void StartsWith2()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.StartsWith("a",StringComparison.InvariantCultureIgnoreCase);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.startsWith(""a"")", js);
        }

        [TestMethod]
        public void EndsWith1()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.EndsWith("a");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.endsWith(""a"")", js);
        }

        [TestMethod]
        public void EndsWith2()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.EndsWith("a",StringComparison.Ordinal);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.endsWith(""a"")", js);
        }       

        [TestMethod]
        public void LastIndexOf1()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf('a');

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf2()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a");

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf3()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf('a', 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf4()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a", 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf5()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a", StringComparison.CurrentCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf6()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a", 2, StringComparison.InvariantCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2).lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf7()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a", 2, 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,2).lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf8()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf('a', 2, 2);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,2).lastIndexOf(""a"")", js);
        }

        [TestMethod]
        public void LastIndexOf9()
        {
            Expression<Func<MyClass, object>> expr =
                x => x.Name.LastIndexOf("a", 2, 6, StringComparison.InvariantCulture);

            var js = expr.CompileToJavascript(new JavascriptCompilationOptions(
                    JsCompilationFlags.BodyOnly,
                    new StringMethodsAndProperties()));
            Assert.AreEqual(@"x.Name.substr(2,6).lastIndexOf(""a"")", js);
        }
    }
}
