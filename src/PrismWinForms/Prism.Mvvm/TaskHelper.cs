using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Practices.Prism.Mvvm
{
	internal static class TaskHelper
	{
		private static Task s_completedTask;

		internal static Task CompletedTask
		{
			get
			{
				var task = s_completedTask;
				if (task == null)
				{
					var tsc = new TaskCompletionSource<object>();
					tsc.SetResult(null);

					task = (s_completedTask = tsc.Task);
				}
				return task;
			}
		}
	}
}
