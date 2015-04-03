using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    public static class StoryboardExtensions
    {
        public static async Task BeginAsync(this Storyboard storyboard)
        {
            TaskCompletionSource<bool> tb = new TaskCompletionSource<bool>();
            EventHandler onComplete = null;
            onComplete = (s, e) =>
            {
                storyboard.Completed -= onComplete;
                tb.SetResult(true);
            };
            storyboard.Completed += onComplete;
            storyboard.Begin();
            await tb.Task;
        }
    }
}
