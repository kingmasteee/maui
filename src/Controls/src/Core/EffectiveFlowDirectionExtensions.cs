using System;
using System.ComponentModel;

namespace Microsoft.Maui.Controls
{
	internal static class EffectiveFlowDirectionExtensions
	{
		internal static EffectiveFlowDirection ToEffectiveFlowDirection(this FlowDirection self, bool isExplicit = false)
		{
			switch (self)
			{
				case FlowDirection.MatchParent:
					return default(EffectiveFlowDirection);


				case FlowDirection.LeftToRight:
					if (isExplicit)
					{
						return EffectiveFlowDirection.Explicit;
					}
					else
					{
						return default(EffectiveFlowDirection);
					}

				case FlowDirection.RightToLeft:
					if (isExplicit)
					{
						return EffectiveFlowDirection.RightToLeft | EffectiveFlowDirection.Explicit;
					}
					else
					{
						return EffectiveFlowDirection.RightToLeft;
					}

				default:
					throw new InvalidOperationException($"Cannot convert {self} to {nameof(EffectiveFlowDirection)}.");
			}
		}

		internal static FlowDirection ToFlowDirection(this EffectiveFlowDirection self)
		{
			if (self.IsLeftToRight())
				return FlowDirection.LeftToRight;
			else
				return FlowDirection.RightToLeft;

			throw new InvalidOperationException($"Cannot convert {self} to {nameof(FlowDirection)}.");
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/EffectiveFlowDirectionExtensions.xml" path="//Member[@MemberName='IsRightToLeft']/Docs/*" />
		public static bool IsRightToLeft(this EffectiveFlowDirection self)
		{
			return (self & EffectiveFlowDirection.RightToLeft) == EffectiveFlowDirection.RightToLeft;
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/EffectiveFlowDirectionExtensions.xml" path="//Member[@MemberName='IsLeftToRight']/Docs/*" />
		public static bool IsLeftToRight(this EffectiveFlowDirection self)
		{
			return (self & EffectiveFlowDirection.RightToLeft) != EffectiveFlowDirection.RightToLeft;
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/EffectiveFlowDirectionExtensions.xml" path="//Member[@MemberName='IsImplicit']/Docs/*" />
		public static bool IsImplicit(this EffectiveFlowDirection self)
		{
			return (self & EffectiveFlowDirection.Explicit) != EffectiveFlowDirection.Explicit;
		}

		/// <include file="../../docs/Microsoft.Maui.Controls/EffectiveFlowDirectionExtensions.xml" path="//Member[@MemberName='IsExplicit']/Docs/*" />
		public static bool IsExplicit(this EffectiveFlowDirection self)
		{
			return (self & EffectiveFlowDirection.Explicit) == EffectiveFlowDirection.Explicit;
		}
	}
}