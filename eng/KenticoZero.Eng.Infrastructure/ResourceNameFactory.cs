using System;
using System.Collections.Generic;
using Pulumi;
using Pulumi.Azure.Core;

namespace KenticoZero.Eng.Infrastructure
{
    internal class ResourceNameFactory
    {
        private const string DefaultDelimiter = "-";
        
        private readonly DeploymentInstance deployment;

        private static readonly Dictionary<Type, string> ResourceTypeShortNameMap = new Dictionary<Type, string>
        {
            { typeof(ResourceGroup), "resgrp" }
        };

        private static readonly Lazy<ResourceNameFactory> InstanceCreator = new Lazy<ResourceNameFactory>(() => new ResourceNameFactory());
        public static ResourceNameFactory Instance
        {
            get
            {
                return InstanceCreator.Value;
            }
        }

        private ResourceNameFactory()
        {
            deployment = Deployment.Instance;
        }

        public ResourceName CreateResourceGroupName(string delimiter = DefaultDelimiter)
        {
            return new ResourceName(args =>
            {
                args.ProjectShortName = deployment.ProjectName;
                args.Environment = deployment.StackName;
                args.ResourceShortName = GetResourceShortName<ResourceGroup>();
                args.Delimiter = delimiter;
            });
        }

        public ResourceName CreateResourceName<TResource>(string serviceShortName, string delimiter = DefaultDelimiter)
        {
            return new ResourceName(args =>
            {
                args.ProjectShortName = deployment.ProjectName;
                args.Environment = deployment.StackName;
                args.ServiceShortName = serviceShortName;
                args.ResourceShortName = GetResourceShortName<TResource>();
                args.Delimiter = delimiter;
            });
        }

        private string GetResourceShortName<TResource>()
        {
            return GetResourceShortName(typeof(TResource));
        }

        private string GetResourceShortName(Type resourceType)
        {
            return ResourceTypeShortNameMap.TryGetValue(resourceType, out var shortName)
                ? shortName
                : throw new ArgumentOutOfRangeException(nameof(resourceType), $"Type has no mapping to a resource short name '{resourceType.FullName}'");
        }
    }
}
