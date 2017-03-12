using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lambda2Js.Plugins
{
    public class StringMethodsAndProperties : JavascriptConversionExtension
    {
        public override void ConvertToJavascript(JavascriptConversionContext context)
        {
            var unary = context.Node as UnaryExpression;
            var writer = context.GetWriter();
            if (unary != null)
            {
                ProccessUnary(context, unary, writer);
                return;
            }

            var methodCall = context.Node as System.Linq.Expressions.MethodCallExpression;
            if (methodCall != null)
            {
                ProccessMethodCall(context, writer, methodCall);
                return;
            }


        }

        private static void ProccessMethodCall(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            if (methodCall.Object.Type == typeof(string))
            {
                if (methodCall.Method.Name == nameof(string.Substring))
                {
                    ProccessSubstring(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.Replace))
                {
                    ProccessReplace(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.IndexOf))
                {
                    ProccessIndexOf(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.LastIndexOf))
                {
                    ProccessLastIndexOf(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.Contains))
                {
                    ProccessContains(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.Trim) && methodCall.Arguments.Count == 0)
                {
                    ProccessTrim(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.StartsWith) && methodCall.Arguments.Count <= 2)
                {
                    ProccessStartsWith(context, writer, methodCall);
                }
                else if (methodCall.Method.Name == nameof(string.EndsWith) && methodCall.Arguments.Count <= 2)
                {
                    ProccessEndsWith(context, writer, methodCall);
                }
                

            }
        }

        private static void ProccessEndsWith(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            writer.Write(".endsWith(");
            context.Visitor.Visit(methodCall.Arguments[0]);
            writer.Write(")");
            context.PreventDefault();
        }

        private static void ProccessStartsWith(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            writer.Write(".startsWith(");
            context.Visitor.Visit(methodCall.Arguments[0]);
            writer.Write(")");
            context.PreventDefault();
        }

        private static void ProccessTrim(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            writer.Write(".trim()");
            context.PreventDefault();
        }

        private static void ProccessContains(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            writer.Write(".includes(");
            context.Visitor.Visit(methodCall.Arguments[0]);
            writer.Write(")");
            context.PreventDefault();
        }

        private static void ProccessIndexOf(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            if (methodCall.Arguments.Count == 1 ||
                methodCall.Arguments.Count == 2 && methodCall.Arguments[1].Type == typeof(StringComparison))
            {
                writer.Write(".indexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
            else if (methodCall.Arguments.Count == 2 ||
                methodCall.Arguments.Count == 3 && methodCall.Arguments[2].Type == typeof(StringComparison))
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[1]);
                writer.Write(")");
                writer.Write(".indexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
            else if (methodCall.Arguments.Count == 3 ||
                methodCall.Arguments.Count == 4 && methodCall.Arguments[3].Type == typeof(StringComparison))
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[1]);
                writer.Write(",");
                context.Visitor.Visit(methodCall.Arguments[2]);
                writer.Write(")");
                writer.Write(".indexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
        }

        private static void ProccessLastIndexOf(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            if (methodCall.Arguments.Count == 1 ||
                methodCall.Arguments.Count == 2 && methodCall.Arguments[1].Type == typeof(StringComparison))
            {
                writer.Write(".lastIndexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
            else if (methodCall.Arguments.Count == 2 ||
                methodCall.Arguments.Count == 3 && methodCall.Arguments[2].Type == typeof(StringComparison))
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[1]);
                writer.Write(")");
                writer.Write(".lastIndexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
            else if (methodCall.Arguments.Count == 3 ||
                methodCall.Arguments.Count == 4 && methodCall.Arguments[3].Type == typeof(StringComparison))
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[1]);
                writer.Write(",");
                context.Visitor.Visit(methodCall.Arguments[2]);
                writer.Write(")");
                writer.Write(".lastIndexOf(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(")");
                context.PreventDefault();
            }
        }

        private static void ProccessReplace(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            writer.Write(".replace(");
            context.Visitor.Visit(methodCall.Arguments[0]);
            writer.Write(",");
            context.Visitor.Visit(methodCall.Arguments[1]);
            writer.Write(")");
            context.PreventDefault();
        }

        private static void ProccessSubstring(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            context.Visitor.Visit(methodCall.Object);
            if (methodCall.Arguments.Count == 1)
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[0]);               
                writer.Write(")");
                context.PreventDefault();
            }
            else
            {
                writer.Write(".substr(");
                context.Visitor.Visit(methodCall.Arguments[0]);
                writer.Write(",");
                context.Visitor.Visit(methodCall.Arguments[1]);
                writer.Write(")");
                context.PreventDefault();
            }
        }

        private static void ProccessUnary(JavascriptConversionContext context, UnaryExpression unary, JavascriptWriter writer)
        {
            var operand = unary.Operand as MemberExpression;

            if (operand != null)
            {
                if (operand.Expression.Type == typeof(string))
                {
                    if (operand.Member.Name == "Length")
                    {
                        context.Visitor.Visit(operand.Expression);
                        writer.Write(".length");
                        context.PreventDefault();
                    }
                }
            }
        }
    }
}
