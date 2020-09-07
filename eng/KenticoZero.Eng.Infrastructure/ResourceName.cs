using System;
using System.Collections.Generic;
using System.Linq;

namespace KenticoZero.Eng.Infrastructure
{
    internal class ResourceName
    {
        public string LogicalName { get; }
        public string PhysicalName { get; }

        public ResourceName(Action<ResourceNameArgs> argsAction)
        {
            var args = new ResourceNameArgs();
            argsAction.Invoke(args);

            LogicalName = SetLogicalName(args);
            PhysicalName = SetPhysicalName(args);
        }

        private string SetLogicalName(ResourceNameArgs args)
        {
            var segments = new [] { args.ProjectShortName, args.ServiceShortName, args.ResourceShortName };

            return SetName(args.Delimiter, segments);
        }

        private string SetPhysicalName(ResourceNameArgs args)
        {
            var segments = new [] { args.ProjectShortName, args.Environment, args.ServiceShortName, args.ResourceShortName };

            return SetName(args.Delimiter, segments);
        }

        private string SetName(string delimiter, IEnumerable<string> segments)
        {
            return string.Join(delimiter, segments.Where(segment => !string.IsNullOrEmpty(segment)));
        }
    }
}
