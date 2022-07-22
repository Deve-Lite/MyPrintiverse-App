using System.Diagnostics.Metrics;

namespace MyPrintiverse.Core.Collections;

public static class IEnumerableExtensions
{
	public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
	{
		foreach (var item in @this)
		{
			action?.Invoke(item);
		}
	}

	public static void ForEach<T>(this IEnumerable<T> @this, Action<T, int> action)
	{
		var counter = 0;

		foreach (var item in @this)
		{
			action?.Invoke(item, counter++);
		}
	}
}