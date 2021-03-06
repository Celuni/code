    using System;
    using System.Data.Entity.Core.Common.CommandTrees;
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace EFHacks
    {
    	public class MyDbCommandTreeInterceptor : IDbCommandTreeInterceptor
    	{
    		public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
    		{
    			if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace) return;
    			var queryCommand = interceptionContext.Result as DbQueryCommandTree;
    			if (queryCommand != null)
    			{
    				var newQuery = queryCommand.Query.Accept(new GuidToStringComparisonRewriter());
    				if (newQuery != queryCommand.Query)
    				{
    					interceptionContext.Result = new DbQueryCommandTree(
    						queryCommand.MetadataWorkspace,
    						queryCommand.DataSpace,
    						newQuery);
    				}
    			}
    		}
    	}
    	class GuidToStringComparisonRewriter : DefaultExpressionVisitor
    	{
    		public override DbExpression Visit(DbComparisonExpression expression)
    		{
    			if (IsString(expression.Left.ResultType) && IsString(expression.Right.ResultType))
    			{
    				var left = expression.Left;
    				var right = expression.Right;
    				if (RemoveCast(ref right) || RemoveCast(ref left))
    					return CreateComparison(expression.ExpressionKind, left, right);
    			}
    			return base.Visit(expression);
    		}
    
    		static bool IsGuid(TypeUsage type)
    		{
    			var pt = type.EdmType as PrimitiveType;
    			return pt != null && pt.PrimitiveTypeKind == PrimitiveTypeKind.Guid;
    		}
    
    		static bool IsString(TypeUsage type)
    		{
    			var pt = type.EdmType as PrimitiveType;
    			return pt != null && pt.PrimitiveTypeKind == PrimitiveTypeKind.String;
    		}
    
    		static bool RemoveCast(ref DbExpression expr)
    		{
    			var funcExpr = expr as DbFunctionExpression;
    			if (funcExpr != null &&
    				funcExpr.Function.BuiltInTypeKind == BuiltInTypeKind.EdmFunction &&
    				funcExpr.Function.FullName == "Edm.ToLower" &&
    				funcExpr.Arguments.Count == 1)
    			{
    				var castExpr = funcExpr.Arguments[0] as DbCastExpression;
    				if (castExpr != null && IsGuid(castExpr.Argument.ResultType))	
    				{
    					expr = castExpr.Argument;
    					return true;
    				}
    			}
    			return false;
    		}
    
    		static readonly Func<DbExpressionKind, DbExpression, DbExpression, DbComparisonExpression> CreateComparison = BuildCreateComparisonFunc();
    
    		static Func<DbExpressionKind, DbExpression, DbExpression, DbComparisonExpression> BuildCreateComparisonFunc()
    		{
    			var kind = Expression.Parameter(typeof(DbExpressionKind), "kind");
    			var booleanResultType = Expression.Field(null, typeof(DbExpressionBuilder), "_booleanType");
    			var left = Expression.Parameter(typeof(DbExpression), "left");
    			var right = Expression.Parameter(typeof(DbExpression), "right");
    			var result = Expression.New(
    				typeof(DbComparisonExpression).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
    				new[] { kind.Type, booleanResultType.Type, left.Type, right.Type }, null),
    				kind, booleanResultType, left, right);
    			var expr = Expression.Lambda<Func<DbExpressionKind, DbExpression, DbExpression, DbComparisonExpression>>(
    				result, kind, left, right);
    			return expr.Compile();
    		}
    	}
    }
