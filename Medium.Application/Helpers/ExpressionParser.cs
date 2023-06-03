using System.Linq.Expressions;
using System.Text;

namespace Medium.Application.Helpers
{
    public static class ExpressionParser
    {
        public static string Parse<T>(Expression<Func<T, bool>> expression)
        {
            var builder = new StringBuilder();
            Parse(expression.Body, builder);
            // builder.ToString().Trim('=');
            var a = builder.ToString().Split();
            Console.WriteLine(a[0]);
            Console.WriteLine(a[1]);
            Console.WriteLine(builder.ToString());
            return builder.ToString();
        }

        private static void Parse(Expression expression, StringBuilder builder)
        {
            if (expression is BinaryExpression binary)
            {
                Parse(binary.Left, builder);
                builder.Append(GetOperator(binary.NodeType));
                //builder.Append('$');
                builder.Append("{");
                Parse(binary.Right, builder);
                builder.Append("}");

            }
            else if (expression is MemberExpression member)
            {
                builder.Append($"{member.Member.Name}");
            }
            else if (expression is ConstantExpression constant)
            {
                builder.Append(constant.Value);
            }
            else if (expression is UnaryExpression unary && unary.Operand is MemberExpression operand)
            {
                builder.Append(operand.Member.Name);
            }
            else
            {
                throw new ArgumentException("Unsupported expression type: " + expression.GetType());
            }
        }

        private static string GetOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return " = ";
                case ExpressionType.NotEqual:
                    return " !=";
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.AndAlso:
                    return " AND ";
                case ExpressionType.OrElse:
                    return " OR ";
                default:
                    throw new ArgumentException("Unsupported binary operator: " + type);
            }
        }
    }

}
