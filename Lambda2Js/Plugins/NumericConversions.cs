using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lambda2Js.Plugins
{
    public class NumericConversions: JavascriptConversionExtension
    {
        public override void ConvertToJavascript(JavascriptConversionContext context)
        {
            var writer = context.GetWriter();

            var methodCall = context.Node as System.Linq.Expressions.MethodCallExpression;
            if (methodCall != null)
            {
                ProccessMethodCall(context, writer, methodCall);
                return;
            }


        }

        private void ProccessMethodCall(JavascriptConversionContext context, JavascriptWriter writer, MethodCallExpression methodCall)
        {
            if (methodCall.Object == null)
            {
                if (methodCall.Method.Name == "Parse")
                {
                    if (methodCall.Type == typeof(Int16) || methodCall.Type == typeof(Int32)
                        || methodCall.Type == typeof(Int64))
                    {
                        writer.Write("parseInt(");
                        context.Visitor.Visit(methodCall.Arguments[0]);
                        writer.Write(")");
                        context.PreventDefault();
                    }
                    else if (methodCall.Type == typeof(float) || methodCall.Type == typeof(double)
                             || methodCall.Type == typeof(decimal))
                    {
                        writer.Write("parseFloat(");
                        context.Visitor.Visit(methodCall.Arguments[0]);
                        writer.Write(")");
                        context.PreventDefault();
                    }
                }
            }
            
        }
    }
}
